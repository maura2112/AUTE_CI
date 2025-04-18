using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class HtmlReporter
{
    private readonly List<string> entries = new();
    private readonly string reportPath;

    public HtmlReporter(string path)
    {
        reportPath = path;
        Directory.CreateDirectory(reportPath);
    }

    public void AddResult(string testName, bool isSuccess, string message, string screenshotPath = null)
    {
        var status = isSuccess ? "Passed" : "Failed";
        var color = isSuccess ? "green" : "red";

        var screenshotHtml = string.IsNullOrEmpty(screenshotPath) ? "" :
            $"<br><img src='{screenshotPath}' width='400'/>";

        string row = $@"
            <tr>
                <td>{testName}</td>
                <td style='color:{color}'>{status}</td>
                <td>{message}{screenshotHtml}</td>
            </tr>";

        entries.Add(row);
    }

    public void GenerateReport()
    {
        string filePath = Path.Combine(reportPath, $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");

        var html = new StringBuilder();
        html.AppendLine("<html><head><title>Test Report</title></head><body>");
        html.AppendLine("<h2>Automation Test Report</h2>");
        html.AppendLine("<table border='1' cellspacing='0' cellpadding='5'>");
        html.AppendLine("<tr><th>Test Name</th><th>Status</th><th>Details</th></tr>");

        foreach (var entry in entries)
        {
            html.AppendLine(entry);
        }

        html.AppendLine("</table></body></html>");

        File.WriteAllText(filePath, html.ToString());
    }
}
