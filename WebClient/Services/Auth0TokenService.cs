using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SampleMvcApp.Services
{

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
                client_id = "ud9zdyd3d3fdbW5sHvDxGSPg6NNcbzKA",
                client_secret = "3UclGDro1uswQW9epC1f_gVXTTlsTutj9eVTtsDYUAUXC9yPS0kBcdiVShpJ48cI",
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
}
