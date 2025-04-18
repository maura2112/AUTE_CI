using OpenQA.Selenium;

public static class PageFactory
{
    public static T Create<T>(IWebDriver driver) where T : class
    {
        return Activator.CreateInstance(typeof(T), driver) as T
            ?? throw new InvalidOperationException($"Cannot create instance of {typeof(T)}");
    }
}