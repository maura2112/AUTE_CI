using OpenQA.Selenium;


[SetUpFixture]
public class TestSuiteSetup
{
    public static HtmlReporter Reporter;
    public static TestConfig Config;

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        Config = JsonReader.ReadConfig();
        Reporter = new HtmlReporter(Config.ReportPath);
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        Reporter.GenerateReport();
    }
}