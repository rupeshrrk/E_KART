using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using WebDriverManager.DriverConfigs.Impl;

namespace E_KART.Utilities
{
    public class Base
    {
        protected IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Tester:", "Rupesh");
            extent.AddSystemInfo("Environment:", "QA 212 Box");
        }

        [SetUp]
        public void StartBrowser()
        {
            //test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            TestDataReader Data = new TestDataReader();
            String URL = Data.getURL();
            String BrowserName = Data.getBrowserName();
            InitBrowser(BrowserName);
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //extent = new ExtentReports();
            //var htmlReporter = new ExtentHtmlReporter(@"C:\Users\al4000\source\repos\E_KART\Output\TestReport.html");
            //extent.AttachReporter(htmlReporter);

         
        }


        public IWebDriver getDriver()
        {
            return driver;
        }

        public void InitBrowser(string BrowserName)
        {

            switch(BrowserName)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new EdgeDriver();
                    break;

            }
        }



        [TearDown]
        public void AfterTestExe()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;



            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {

                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {

            }

            extent.Flush();
            driver.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }

    }

}
