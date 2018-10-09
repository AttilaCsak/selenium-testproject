using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject.PageObjects;

namespace TestProject.StepDefinitions
{
    [Binding]
    public class WikipediaSteps
    {
        private readonly IWebDriver _driver;
        private readonly WikipediaPage _wikipediaPage;

        public WikipediaSteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            _wikipediaPage = new WikipediaPage(_driver);
        }

        [Given(@"I Navigate to the Wikipedia page")]
        public void GivenINavigateToTheWikipediaPage()
        {
            _driver.Navigate().GoToUrl("https://www.wikipedia.org/");
        }

        [When(@"The '(.*)' page is opened")]
        [Then(@"The '(.*)' page is opened")]
        public void WhenThePageIsOpened(string title)
        {
            Assert.IsTrue(_driver.Title == title, "The " + title + "page is not opened");
        }

        [Then(@"I set English language")]
        public void ThenISetEnglishLanguage()
        {
            _wikipediaPage.SetPageLanguageToEnglish();
        }

        [Then(@"I search for '(.*)' on main page")]
        public void ThenISearchFor(string text)
        {
            _wikipediaPage.Search(text);
        }

        [Then(@"I check the '(.*)' content on the page")]
        public void ThenICheckTheTextOnThePage(string text)
        {
            Assert.IsTrue(_wikipediaPage.CheckContents(text), "The following" + text + " content was not found");
        }

        [Then(@"I check the interface modul image on the page")]
        public void ThenICheckTheModulImageOnThePage()
        {
            Assert.IsTrue(_wikipediaPage.CheckImageElementExist(), "The image was not found");
        }

        [Then(@"I open the '(.*)' page")]
        public void ThenIOpenThePage(string linkName)
        {
            _wikipediaPage.OpenLinkedPage(linkName);
        }
    }
}