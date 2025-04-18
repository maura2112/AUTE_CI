using OpenQA.Selenium;

public static class ScreenshotHelper
{
    public static string CaptureScreenshot(IWebDriver driver, string testName, string path)
    {
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"{testName}_{timestamp}.png";
        string fullPath = Path.Combine(path, fileName);

        Directory.CreateDirectory(path);

        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile(fullPath);

        return fullPath;
    }
}

