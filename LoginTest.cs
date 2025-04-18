using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class LoginTest : BaseTest
{


    [Test]
    public void TestLogin_WithPom()
    {
        var loginPage = new LoginPage(driver);
        loginPage
            .Navigate()
            .LogIn("username1", "password1");

        var element = loginPage.GetErrorLoginMessageWithWait();
        Assert.That(element, Is.Not.Null);
    }

}