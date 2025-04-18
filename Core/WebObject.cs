using OpenQA.Selenium;

public class WebObject
{
    public By Locator { get; }

    public WebObject(By locator)
    {
        Locator = locator;
    }
}
