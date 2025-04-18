

using OpenQA.Selenium;

public abstract class BaseTest
{
    protected IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        driver = WebDriverFactory.CreateDriver(TestSuiteSetup.Config.Browser);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TestSuiteSetup.Config.ImplicitWait);
    }

    [TearDown]
    public void TearDown()
    {
        var context = TestContext.CurrentContext;
        bool isSuccess = context.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
        string screenshotPath = null;

        if (!isSuccess)
        {
            screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, context.Test.Name, TestSuiteSetup.Config.ScreenshotPath);
        }

        TestSuiteSetup.Reporter.AddResult(context.Test.Name, isSuccess, context.Result.Message, screenshotPath);
        driver.Quit();
    }
}


