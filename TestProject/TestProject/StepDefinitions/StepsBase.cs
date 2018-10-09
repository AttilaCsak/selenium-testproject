using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestProject.StepDefinitions
{
    [Binding]
    public class StepsBase
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            ScenarioContext.Current.Add("currentDriver", _driver);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            _driver?.Quit();
        }
    }
}