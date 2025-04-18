
using OpenQA.Selenium;

public class LoginPage
{
    private readonly IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public WebObject txtUsername => new(By.Id("userName"));
    public WebObject txtPassword => new(By.Id("password"));
    public WebObject btnLogin => new(By.Id("login"));
    public WebObject lblInvalidCredentials => new(By.XPath("//p[text()='Invalid username or password!']"));
    public WebObject lblUsernameError => new(By.Id("//div[@ng-messages='submitted && loginForm.username.$error']//p[@ng-message='required']"));
    public WebObject lblPasswordError => new(By.Id("//div[@ng-messages='submitted && loginForm.password.$error']//p[@ng-message='required']"));
    private Dictionary<LoginErrorType, WebObject> _errorLocators;

    public LoginPage Navigate()
    {
        _driver.Navigate().GoToUrl(TestSuiteSetup.Config.BaseUrl + "/login");
        InitializeErrorMap();
        return this;
    }

    public LoginPage EnterUsername(string username)
    {
        txtUsername.SendKeys(_driver, username);
        return this;
    }

    public LoginPage EnterPassword(string password)
    {
        txtPassword.SendKeys(_driver, password);
        return this;
    }

    public LoginPage ClickLogin()
    {
        btnLogin.Click(_driver);
        return this;
    }

    public string GetCurrentLoginUrl() => _driver.Url;

    public string GetErrorMessage(By locator)
    {
        var obj = new WebObject(locator);
        return obj.GetText(_driver);
    }

    public bool IsErrorDisplayed(WebObject obj)
    {
        return obj.IsDisplayed(_driver);
    }

    public LoginPage InitializeErrorMap()
    {
        _errorLocators = new Dictionary<LoginErrorType, WebObject>
        {
            [LoginErrorType.InvalidCredentials] = lblInvalidCredentials,
            [LoginErrorType.EmptyUsername] = lblUsernameError,
            [LoginErrorType.EmptyPassword] = lblPasswordError
        };

        return this;
    }

    public string GetError(LoginErrorType errorType)
    {
        return _errorLocators[errorType].GetText(_driver);
    }


    public LoginErrorType? GetDisplayedErrorType()
    {
        foreach (var entry in _errorLocators)
        {
            if (entry.Value.IsDisplayed(_driver))
            {
                return entry.Key;
            }
        }
        return null;
    }


}
