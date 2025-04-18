using OpenQA.Selenium;

public static class WebObjectExtension
{
    public static void Click(this WebObject obj, IWebDriver driver)
    {
        driver.FindElement(obj.Locator).Click();
    }

    public static void SendKeys(this WebObject obj, IWebDriver driver, string text)
    {
        var element = driver.FindElement(obj.Locator);
        element.Clear();
        element.SendKeys(text);
    }

    public static string GetText(this WebObject obj, IWebDriver driver)
    {
        return driver.FindElement(obj.Locator).Text;
    }

    public static bool IsDisplayed(this WebObject obj, IWebDriver driver)
    {
        try
        {
            return driver.FindElement(obj.Locator).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
