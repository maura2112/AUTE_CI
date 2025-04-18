using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class BaseTest
{
    public IWebDriver driver;
    public WebDriverWait wait;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }
  [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
