using System.Diagnostics;
using RestSharp;

public class DemoAPITest
{
    [Test]
    public void GetBookAPI()
    {
        RestClient _client = new("https://demoqa.com");
        RestRequest getRequest = new("/BookStore/v1/Books", Method.Get);

        RestResponse getResponse = _client.Execute(getRequest);

    }

    [Test]
    public void PostBookAPI_WithAuth()
    {
        var client = new RestClient("https://demoqa.com");

        // Login
        var loginRequest = new RestRequest("/Account/v1/GenerateToken", Method.Post);
        var loginBody = new
        {
            userName = "maura",
            password = "Abc123!z"
        };
        loginRequest.AddJsonBody(loginBody);
        var loginResponse = client.Execute<LoginResponse>(loginRequest);

        var token = loginResponse.Data.Token;

        // Post Book
        var postRequest = new RestRequest("/BookStore/v1/Books", Method.Post);
        postRequest.AddHeader("Authorization", $"Bearer {token}");

        var postBody = new
        {
            userId = "fea82248-9b9d-4894-b2b6-1c4add268ecc",
            collectionOfIsbns = new[]
            {
            new { isbn = "9781449325862" }
        }
        };

        postRequest.AddJsonBody(postBody);
        var postResponse = client.Execute(postRequest);

        Console.WriteLine(postResponse.StatusCode);
        Console.WriteLine(postResponse.Content);
    }


}
public class LoginResponse
{
    public string Token { get; set; }
    public string Expires { get; set; }
    public string Status { get; set; }
    public string Result { get; set; }
    public string Username { get; set; }
    public string UserId { get; set; }
}
