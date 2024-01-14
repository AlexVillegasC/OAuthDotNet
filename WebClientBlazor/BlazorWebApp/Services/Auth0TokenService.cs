using Newtonsoft.Json;
using System.Text;

namespace Client.WebApp.Services;
public class Auth0TokenService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public Auth0TokenService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        using var client = new HttpClient();
        var tokenRequest = new
        {
            client_id = "fUxIR0am3lkZiMqUCrtv5bQn9md0KAL5",
            client_secret = "3R_TjnNt_I45CCRN2UIi6UKMDb1bqwflSGpoK1xclVfICAyNdlajaskOjmLl0AgE",
            audience = "https://labcibe-books-api-dev.azurewebsites.net",
            grant_type = "client_credentials"
        };

        var content = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://dev-my3oejucmey26cbs.us.auth0.com/oauth/token", content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
            return tokenResponse?.access_token;
        }

        return null;
    }
}
