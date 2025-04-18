using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public abstract class BasePage
{
    protected readonly IWebDriver driver;
    protected readonly WebDriverWait wait;
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(JsonReader.ReadConfig().ImplicitWait);

    protected BasePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, DefaultTimeout);
    }

    protected void GoToUrl(string url) => driver.Navigate().GoToUrl(url);
    protected string GetCurrentUrl() => driver.Url;

    protected IWebElement WaitForElement(By locator) =>
        wait.Until(driver => driver.FindElement(locator));

    protected IWebElement WaitUntilElementExists(By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(drv => drv.FindElement(locator));
    }

    protected IWebElement WaitUntilClickable(By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(drv =>
        {
            var element = drv.FindElement(locator);
            return (element != null && element.Enabled && element.Displayed) ? element : null;
        });
    }

    protected bool WaitUntilUrlContains(string partialUrl, int timeoutInSeconds = 10)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
            .Until(d => d.Url.Contains(partialUrl));
    }

    protected bool WaitUntilElementTextContains(By locator, string expectedText, int timeoutInSeconds = 10)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
            .Until(d => d.FindElement(locator).Text.Contains(expectedText));
    }

    protected bool WaitUntilElementVisible(By locator, int timeoutInSeconds = 10)
    {
        try
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(d => d.FindElement(locator).Displayed);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void Click(By locator) => WaitForElement(locator).Click();

    protected void JsClick(By locator)
    {
        var element = WaitForElement(locator);
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].click();", element);
    }

    protected void SendKeys(By locator, string text)
    {
        var element = WaitForElement(locator);
        element.Clear();
        element.SendKeys(text);
    }

    protected string GetElementText(By locator) =>
        WaitForElement(locator).Text;

    protected bool IsElementDisplayed(By locator)
    {
        try
        {
            return WaitForElement(locator).Displayed;
        }
        catch
        {
            return false;
        }
    }

    protected bool IsFieldMarkedInvalid(By locator)
    {
        var element = WaitForElement(locator);
        var classAttr = element.GetAttribute("class");
        return classAttr != null && classAttr.Contains("is-invalid");
    }

    protected void ScrollIntoView(By locator)
    {
        var element = WaitForElement(locator);
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

    protected void HoverElement(By locator)
    {
        var element = WaitForElement(locator);
        Actions actions = new Actions(driver);
        actions.MoveToElement(element).Perform();
    }


    protected void SelectByVisibleText(By locator, string text)
    {
        var element = WaitForElement(locator);
        var select = new SelectElement(element);
        select.SelectByText(text);
    }

    protected void SelectByText(By locator, string text)
    {
        SelectByVisibleText(locator, text);
    }

    protected void SelectByValue(By locator, string value)
    {
        var element = WaitForElement(locator);
        var select = new SelectElement(element);
        select.SelectByValue(value);
    }

    protected void SelectByIndex(By locator, int index)
    {
        var element = WaitForElement(locator);
        var select = new SelectElement(element);
        select.SelectByIndex(index);
    }

    protected void SelectCustomDropdown(By dropdownLocator, By optionLocator)
    {
        Click(dropdownLocator);
        Click(optionLocator);
    }

    protected void SelectCustomDropdown(By dropdownLocator, string visibleText)
    {
        Click(dropdownLocator);
        var optionLocator = By.XPath($"//li[contains(., '{visibleText}')]");
        Click(optionLocator);
    }

    protected void SetCheckboxState(By locator, bool shouldBeChecked)
    {
        var checkbox = WaitForElement(locator);
        if (checkbox.Selected != shouldBeChecked)
        {
            checkbox.Click();
        }
    }

    protected string GetToastMessage(By toastLocator)
    {
        try
        {
            return WaitForElement(toastLocator).Text;
        }
        catch
        {
            return string.Empty;
        }
    }

    protected void SelectDate(By dateFieldLocator, string date)
    {
        Click(dateFieldLocator);
        var dateTime = DateTime.Parse(date);
        var day = dateTime.Day;
        var dayLocator = By.XPath($"//td[contains(@id, '-{day}')]//button[@ng-click='select(dt.date)']");
        Click(dayLocator);
    }

    protected void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [INFO] {message}");
    }
}
