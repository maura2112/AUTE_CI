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
        options.AddArgument("--headless=new");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--disable-extensions");
        options.AddArgument("--window-size=1920,1080");

        string uniqueUserDataDir = Path.Combine(Path.GetTempPath(), "chrome-profile-" + Guid.NewGuid());
        options.AddArgument($"--user-data-dir={uniqueUserDataDir}");
        return options;
    }
}
