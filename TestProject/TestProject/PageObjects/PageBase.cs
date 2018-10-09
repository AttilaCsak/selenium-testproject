using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    public class PageBase
    {
        private IWebDriver _driver;

        /// <summary>
        ///     Initialize the PageBase class
        /// </summary>
        /// <param name="driver">web driver</param>
        public PageBase(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}