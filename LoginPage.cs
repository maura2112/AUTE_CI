using OpenQA.Selenium;

public class LoginPage(IWebDriver driver) : BasePage(driver)
{
    public static readonly By usernameTxtBoxLocator = By.Id("userName");
    public static readonly By passwordTxtBoxLocator = By.Id("password");
    public static readonly By loginButtonLocator = By.Id("login");
    public static readonly By loginErrorMessage = By.XPath("//p[text()='Invalid username or password!']");

    public LoginPage Navigate()
    {
        GoToUrl("https://demoqa.com/login");

        return this;
    }

    public void InputUsername(string username)
    {
        SendKeysToWebElement(usernameTxtBoxLocator, username);
    }

    public void InputPassword(string password)
    {
        SendKeysToWebElement(passwordTxtBoxLocator, password);
    }

    public void ClickLoginButton()
    {
        SendKeysToWebElement(usernameTxtBoxLocator, Keys.Enter);
    }

    public void LogIn(string username, string password)
    {
        InputUsername(username);
        InputPassword(password);
        ClickLoginButton();
    }

    public IWebElement GetErrorLoginMessageWithWait()
    {
        WaitForElementToBeDisplayed(loginErrorMessage);

        return GetWebElement(loginErrorMessage);
    }
}