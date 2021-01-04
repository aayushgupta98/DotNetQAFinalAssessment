using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DotNetQAFinalAssessment.GoogleTest.GoogleTestHelper;
using NUnit.Framework;
using System;
using System.Net;

namespace DotNetQAFinalAssessment.GoogleTest.Tests 
{
    public class GoogleHomePageTest : GoogleWebTestHelper
    {
        /// <summary>
        /// creating instance for Google Home Page
        /// </summary>
        public GoogleHomePageHelper googleHomePage;

        /// <summary>
        /// variable to declare whether 1st test passed or not
        /// </summary>
        private bool isTestPassed = true;

        /// <summary>
        /// instance for ExtentReports
        /// </summary>
        private ExtentReports extentReports = new ExtentReports();

        /// <summary>
        /// creating test in extent reports
        /// </summary>
        /// <param name="testName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        ExtentTest extentTest(string testName, string description) => extentReports.CreateTest(testName, description);

        ExtentTest test = null;

        /// <summary>
        /// constructor for test class to add env variables
        /// </summary>
        public GoogleHomePageTest()
        {
            string hostname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;

            extentReports.AddSystemInfo("Operating System", os.ToString());
            extentReports.AddSystemInfo("HostName", hostname);
            extentReports.AddSystemInfo("Browser", "Google Chrome");
        }

        /// <summary>
        /// attaching report before run of every test
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\aayush.gupta\source\repos\DotNetQAFinalAssessment\Reports\TestSuite2\GoogleTest.html");
            extentReports.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// test for google search
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="expectedTitle"></param>
        [TestCase("Selenium", "Selenium01 - Google Search")]
        [TestCase("Testing", "Testing01 - Google Search")]
        public void Test_GoogleSearch(string keyword, string expectedTitle)
        {
            // arrange
            test = extentTest("GoogleSearch", "Google Search Test on google home page");
            googleHomePage = new GoogleHomePageHelper();
            browser.Goto("https://www.google.com/");

            // act
            test.Log(Status.Info, "Test Case Starts.");
            googleHomePage.Search(keyword, googlePageObject);

            // assert
            if (!isTestPassed)
                Assert.Fail();
            else
                Assert.AreEqual(expectedTitle, driver.Title);
        }

        /// <summary>
        /// function to perform after test
        /// </summary>
        [TearDown]
        public void StopTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testCaseArguments = TestContext.CurrentContext.Test.Arguments;
            var expectedTitile = testCaseArguments[1];
            string screenshotPath = Capture(driver, Convert.ToString(testCaseArguments[0]));
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(Status.Fail, $"Expected Title -> {expectedTitile} -> Test Case Failed.");
                isTestPassed = false;
            }
            else
                test.Log(Status.Pass, $"Expected Title -> {expectedTitile} -> Test Case Passed.");
            test.AddScreenCaptureFromPath(screenshotPath, Convert.ToString(testCaseArguments[0]));
            extentReports.Flush();
        }
    }
}
