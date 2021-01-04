using OpenQA.Selenium;
using System;
namespace DotNetQAFinalAssessment.GoogleTest.GoogleTestHelper
{
    public class GoogleWebTestHelper
    {
        /// <summary>
        /// web driver
        /// </summary>
        protected IWebDriver driver;

        /// <summary>
        /// browser
        /// </summary>
        protected readonly TestInitialization browser;

        /// <summary>
        /// page object
        /// </summary>
        protected GooglePageObject.GoogleHomePageObject googlePageObject;

        /// <summary>
        /// constructor for initializing browser instance
        /// </summary>
        public GoogleWebTestHelper()
        {
            browser = new TestInitialization();
        }

        /// <summary>
        /// taking screenshot
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="screenshotName"></param>
        /// <returns></returns>
        public static string Capture(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string uptoBinPath = path.Substring(0, path.LastIndexOf("bin")) + "Reports/images\\" + screenshotName + ".png";
            string localPath = new Uri(uptoBinPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }

        /// <summary>
        /// Initializing browser
        /// </summary>
        [NUnit.Framework.OneTimeSetUp]
        public void start_Browser()
        {
            try
            {
                browser.Init_Browser();
                driver = browser.getDriver;
                googlePageObject = new GooglePageObject.GoogleHomePageObject(driver);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Exception occured - {e}");
            }
        }

        /// <summary>
        /// closing browser
        /// </summary>
        [NUnit.Framework.OneTimeTearDown]
        public void closeBrowser()
        {
            browser.Close();
        }
    }
}
