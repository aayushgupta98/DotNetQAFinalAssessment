using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNetQAFinalAssessment
{
    public class TestInitialization
    {
        /// <summary>
        /// web driver
        /// </summary>
        IWebDriver webDriver;

        /// <summary>
        /// initializing browser
        /// </summary>
        public void Init_Browser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// navigating to specified url
        /// </summary>
        /// <param name="url"></param>
        public void Goto(string url)
        {
            webDriver.Url = url;
        }

        /// <summary>
        /// closing browser
        /// </summary>
        public void Close()
        {
            webDriver.Quit();
        }

        /// <summary>
        /// returning instance of webdriver
        /// </summary>
        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
    }
}
