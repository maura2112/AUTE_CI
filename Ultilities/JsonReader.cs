using System.IO;
using Newtonsoft.Json;

public class TestConfig
{
    public string? BaseUrl { get; set; }
    public string? Browser { get; set; }
    public int ImplicitWait { get; set; }
    public string? ScreenshotPath { get; set; }
    public string? ReportPath { get; set; }
}

public static class JsonReader
{
    private static readonly string configPath = Path.Combine(
       Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName,
       "Ultilities", "testconfig.json"
   );


    public static TestConfig ReadConfig()
    {
        if (!File.Exists(configPath))
            throw new FileNotFoundException("Config file not found: " + configPath);

        string json = File.ReadAllText(configPath);
        return JsonConvert.DeserializeObject<TestConfig>(json);
    }
}
