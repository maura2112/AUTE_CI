using OpenQA.Selenium;

public static class PreConditionManager
{
    public static void Execute(IWebDriver driver, params PreConditionType[] preConditions)
    {
        foreach (var pre in preConditions)
        {
            switch (pre)
            {
                case PreConditionType.Login:
                    var loginPage = PageFactory.Create<LoginPage>(driver);
                    var loginData = LoginData.ValidUser();
                    var loginInvoker = new CommandInvoker<LoginResult>();
                    loginInvoker.AddCommand(new LoginCommand(loginPage, loginData));
                    loginInvoker.ExecuteAll();
                    break;

                case PreConditionType.CreateDefaultProject:
                    break;

                default:
                    throw new NotImplementedException($"Precondition '{pre}' not found");
            }
        }
    }
}
