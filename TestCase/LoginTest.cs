
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

[TestFixture]
public class LoginTest : BaseTest
{
    // [Test]
    // public void LoginWithValidCredentials()
    // {

    //     var loginPage = PageFactory.Create<LoginPage>(driver);
    //     var loginData = LoginData.ValidUser();

    //     var invoker = new CommandInvoker<LoginResult>();
    //     invoker.AddCommand(new LoginCommand(loginPage, loginData));
    //     var results = invoker.ExecuteAll();
    //     var loginResult = results.First();

    //     Assert.That(loginResult.CurrentUrl, Is.EqualTo(LoginResult.SuccessUrl));
    // }

    [Test]
    public void LoginWithInvalidCredentials()
    {
        var loginPage = PageFactory.Create<LoginPage>(driver);
        var loginData = LoginData.InvalidUser();

        var invoker = new CommandInvoker<LoginResult>();
        invoker.AddCommand(new LoginCommand(loginPage, loginData));
        var results = invoker.ExecuteAll();
        var loginResult = results.First();


        Assert.IsTrue(loginResult.IsErrorDisplayed);
        Assert.That(loginResult.ErrorMessage, Is.EqualTo(LoginResult.InvalidUserMsg));
        Assert.That(loginResult.CurrentUrl, Is.EqualTo(LoginResult.FailedUrl));

    }

    // [Test]
    // public void LoginWithInvalidCredentials1()
    // {
    //     var loginPage = PageFactory.Create<LoginPage>(driver);
    //     var loginData = LoginData.InvalidUser();

    //     var invoker = new CommandInvoker<LoginResult>();
    //     invoker.AddCommand(new LoginCommand(loginPage, loginData));
    //     var results = invoker.ExecuteAll();
    //     var loginResult = results.First();


    //     Assert.IsTrue(loginResult.IsErrorDisplayed);
    //     Assert.That(loginResult.ErrorMessage, Is.EqualTo(LoginResult.InvalidUserMsg));
    //     Assert.That(loginResult.CurrentUrl, Is.EqualTo(LoginResult.FailedUrl));

    // }
    // [Test]
    // public void LoginWithInvalidCredentials2()
    // {
    //     var loginPage = PageFactory.Create<LoginPage>(driver);
    //     var loginData = LoginData.InvalidUser();

    //     var invoker = new CommandInvoker<LoginResult>();
    //     invoker.AddCommand(new LoginCommand(loginPage, loginData));
    //     var results = invoker.ExecuteAll();
    //     var loginResult = results.First();


    //     Assert.IsTrue(loginResult.IsErrorDisplayed);
    //     Assert.That(loginResult.ErrorMessage, Is.EqualTo(LoginResult.InvalidUserMsg));
    //     Assert.That(loginResult.CurrentUrl, Is.EqualTo(LoginResult.FailedUrl));

    // }

    // [Test]
    // public void LoginWithEmptyPassword()
    // {
    //     var loginPage = PageFactory.Create<LoginPage>(driver);
    //     var loginData = LoginData.EmptyPassword();

    //     var invoker = new CommandInvoker<LoginResult>();
    //     invoker.AddCommand(new LoginCommand(loginPage, loginData));
    //     var results = invoker.ExecuteAll();
    //     var loginResult = results.First();


    //     Assert.IsTrue(loginResult.IsErrorDisplayed);
    //     Assert.That(loginResult.ErrorMessage, Is.EqualTo(LoginResult.EmptyFieldErrorMsg));
    //     Assert.That(loginResult.CurrentUrl, Is.EqualTo(LoginResult.FailedUrl));

    // }

    // [Test]
    // public void LoginWithEmptyUsername()
    // {
    //     var loginPage = PageFactory.Create<LoginPage>(driver);
    //     var loginData = LoginData.EmptyUserName();

    //     var invoker = new CommandInvoker<LoginResult>();
    //     invoker.AddCommand(new LoginCommand(loginPage, loginData));
    //     var results = invoker.ExecuteAll();
    //     var loginResult = results.First();

    //     Assert.IsTrue(loginResult.IsErrorDisplayed);
    //     Assert.That(loginResult.ErrorMessage, Is.EqualTo(LoginResult.EmptyFieldErrorMsg));
    //     Assert.That(loginResult.CurrentUrl, Is.EqualTo(LoginResult.FailedUrl));

    // }

    // [Test]
    // public void LoginWithEmptyField()
    // {
    //     var loginPage = PageFactory.Create<LoginPage>(driver);
    //     var loginData = LoginData.EmptyUser();

    //     var invoker = new CommandInvoker<LoginResult>();
    //     invoker.AddCommand(new LoginCommand(loginPage, loginData));
    //     var results = invoker.ExecuteAll();
    //     var loginResult = results.First();

    //     Assert.IsTrue(loginResult.IsErrorDisplayed);
    //     Assert.That(loginResult.ErrorMessage, Is.EqualTo(LoginResult.EmptyFieldErrorMsg));
    //     Assert.That(loginResult.CurrentUrl, Is.EqualTo(LoginResult.FailedUrl));

    // }
}

