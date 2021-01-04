using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetQAFinalAssessment.GoogleTest.GooglePageObject
{
    public class GoogleHomePageObject
    {
        /// <summary>
        /// constructor to initialize page objects
        /// </summary>
        /// <param name="driver"></param>
        public GoogleHomePageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Google Home page search bar
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//body/div[@id='viewport']/div[@id='searchform']/form[@id='tsf']/div[2]/div[1]/div[1]/div[1]/div[2]/input[1]")]
        public IWebElement searchBar { get; set; }
    }
}
