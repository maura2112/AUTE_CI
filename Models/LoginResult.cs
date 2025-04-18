public class LoginResult
{
    public bool IsErrorDisplayed { get; set; }
    public string? CurrentUrl { get; set; }
    public string? ErrorMessage { get; set; }

    public static string SuccessUrl = TestSuiteSetup.Config.BaseUrl + "/search";
    public static string FailedUrl = TestSuiteSetup.Config.BaseUrl + "/login";
    public const string InvalidUserMsg = "Invalid username or password!";
    public const string EmptyFieldErrorMsg = "This is a required field.";
}

