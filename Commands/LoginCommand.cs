public class LoginCommand : ICommand<LoginResult>
{
    private readonly LoginPage _loginPage;
    private readonly LoginData _data;

    public LoginCommand(LoginPage loginPage, LoginData data)
    {
        this._loginPage = loginPage;
        this._data = data;
    }

    public LoginResult Execute()
    {
        _loginPage.Navigate()
                 .EnterUsername(_data.Username)
                 .EnterPassword(_data.Password)
                 .ClickLogin();

        var errorType = _loginPage.GetDisplayedErrorType();

        return new LoginResult
        {
            IsErrorDisplayed = errorType.HasValue,
            ErrorMessage = errorType.HasValue ? _loginPage.GetError(errorType.Value) : null,
            CurrentUrl = _loginPage.GetCurrentLoginUrl()
        };
    }
}
