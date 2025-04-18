using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

public static class WebDriverFactory
{
    public static IWebDriver CreateDriver(string browser)
    {
        return browser.ToLower() switch
        {
            "chrome" => new ChromeDriver(GetChromeOptions()),
            "firefox" => new FirefoxDriver(),
            _ => throw new ArgumentException($"Unsupported browser: {browser}")
        };
    }

    private static ChromeOptions GetChromeOptions()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-infobars");
        options.AddArgument("--disable-extensions");
        return options;
    }
}
