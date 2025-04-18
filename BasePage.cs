using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public abstract class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    private static readonly TimeSpan timespan = TimeSpan.FromSeconds(5);

    protected BasePage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(this.driver, timespan);
    }

    protected void GoToUrl(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    protected IWebElement GetWebElement(By by)
    {
        var element = wait.Until(d => d.FindElement(by));

        return element;
    }

    protected void WaitForElementToBeDisplayed(By by)
    {
        wait.Until(d => d.FindElement(by).Displayed);
    }

    protected void ClickWebElement(By by)
    {
        GetWebElement(by).Click();
    }

    protected void SendKeysToWebElement(By by, string keys)
    {
        GetWebElement(by).Clear();
        GetWebElement(by).SendKeys(keys);
    }
}