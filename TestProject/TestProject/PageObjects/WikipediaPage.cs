using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject.PageObjects
{
    public class WikipediaPage : PageBase
    {
        private static IWebDriver _driver;
        private IWebElement _englishLanguageSetting;
        private IWebElement _searchBox;

        /// <summary>
        ///     Initialize the Wikipedia page class
        /// </summary>
        /// <param name="driver">web driver</param>
        public WikipediaPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        /// <summary>
        ///     Set the language page to English
        /// </summary>
        public void SetPageLanguageToEnglish()
        {
            _englishLanguageSetting = GetElement("#js-link-box-en strong");
            _englishLanguageSetting.Click();
        }

        /// <summary>
        ///     Wait until the given element displayed on the page
        /// </summary>
        /// <param name="locator">Locator string where the element can be found</param>
        /// <returns>The element on the given location</returns>
        public IWebElement GetElement(string locator)
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(x => x.FindElement(By.CssSelector(locator)));

            try
            {
                return _driver.FindElement(By.CssSelector(locator));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        /// <summary>
        ///     Check if element is exist on the given page
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>True if the element is displayed</returns>
        public bool CheckPageElementExist(string locator)
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(c => c.FindElement(By.CssSelector(locator)));
            var pageElement = _driver.FindElement(By.CssSelector(locator));
            return pageElement.Displayed;
        }

        /// <summary>
        ///     Search on Wikipedia main page
        /// </summary>
        /// <param name="name"></param>
        public void Search(string name)
        {
            _searchBox = GetElement("[type='search']");
            _searchBox.SendKeys(name);
            _searchBox.SendKeys(Keys.Enter);
        }

        /// <summary>
        ///     Check the elements in the Contents section
        /// </summary>
        /// <param name="elementName">Name of the element</param>
        /// <returns>True if the element exist</returns>
        public bool CheckContents(string elementName)
        {
            var elementTexts =
                new List<string>(_driver.FindElements(By.ClassName("toctext")).Select(iw => iw.Text));

            foreach (var element in elementTexts)
            {
                if (element.ToUpper() == elementName.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Check the test automation interface image exists on the page
        /// </summary>
        /// <returns>True if the image exists</returns>
        public bool CheckImageElementExist()
        {
            var element = _driver.FindElement(By.XPath(
                "/html//div[@id=\'mw-content-text\']//div[@class=\'thumbinner\']/a[@href=\'/wiki/File:Test_Automation_Interface.png\']/img[@alt=\'\']"));

            if (element.Displayed)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Open linked page
        /// </summary>
        /// <param name="name">Name of the link</param>
        public void OpenLinkedPage(string linkName)
        {
            var locator = $"//div[@id='mw-content-text']/div/ol[3]//a[@title='{linkName}']";

            var element =
                _driver.FindElement(By.XPath(locator));

            element?.Click();
        }
    }
}