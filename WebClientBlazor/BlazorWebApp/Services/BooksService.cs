using Client.WebApp.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Json;
using WebApp.Services;

namespace Client.WebApp.Services;


public class BooksService : IBooksService
{
    private HttpClient _httpClient { get; set; }

    public BooksService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BooksModel> GetBookAsync(int bookId)
    {
        var response = await _httpClient.GetAsync($"api/Book/{bookId}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<BooksModel>();
    }

    public async Task<List<BooksModel>> GetBooksAsync()
    {
        //var client = new HttpClient();

        //Set the Bearer token
        //client.DefaultRequestHeaders.Authorization =
        //    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InFJcFZVb2ZJak8tX2wyelZlR0lLeCJ9.eyJodHRwczovL2xhYmNpYmUtY2xpZW50LXJvbGVzL3JvbGUiOiJBZG1pbiIsImdpdmVuX25hbWUiOiJBbGV4IiwiZmFtaWx5X25hbWUiOiJWaWxsZWdhcyIsIm5pY2tuYW1lIjoiYWxleHZpbGxlZ2FzY2FycmFuemEiLCJuYW1lIjoiQWxleCBWaWxsZWdhcyIsInBpY3R1cmUiOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS9BQ2c4b2NLM2p4M09UalpDczRsZFI3YlFKWG5Kek4wWlpFVnhpVXpPUHdpTk1fV1NJczg9czk2LWMiLCJsb2NhbGUiOiJlcyIsInVwZGF0ZWRfYXQiOiIyMDIzLTExLTIxVDA2OjIxOjAxLjY3MloiLCJpc3MiOiJodHRwczovL2Rldi1teTNvZWp1Y21leTI2Y2JzLnVzLmF1dGgwLmNvbS8iLCJhdWQiOiJmVXhJUjBhbTNsa1ppTXFVQ3J0djViUW45bWQwS0FMNSIsImlhdCI6MTcwMDU0NzY2MiwiZXhwIjoxNzM2NTQ3NjYyLCJzdWIiOiJnb29nbGUtb2F1dGgyfDExMTk1ODc3NTE4MDUzNzA5NTAwNyIsInNpZCI6InNlWXZzZHVsT3p2bndzd25FazhmR3NTcW5iUG1COFg1Iiwibm9uY2UiOiI5MDcwOTM4MDFhZGM0YTEyOTFhMzdlNWY5YzBmNmI3NCJ9.WpY8YA1hJtXPPbecF7u9PMCIdBBgds6wVfSjjvWIu_ytEqT0SJ5Mit92la-cznEIabczmrog4-mUz1RzPPQ3bsgIWz3JcjKitFLr2JoAFEX-X9S-70QYgKVt0J8cnnqHajUPw7MEqxZZpLquWYt-C206BYmVasWfobzZJVh48rALiEJ7gGpMjouYRUvAK3RVIk8kqoWEz6DoXmKRfjuvp7ItAw2ShQ41gdPsaU2kXSvIFJxLq3HGHtul_uqa8tWpxQnllbUhd46r-LQf7B2CjGPaNAM9zKWZL8MvDQjgcmkwa1-TO500ES8XtQnYXD1cwbDDZlakVkRkUEMJngb-5g");

        //_httpClient.DefaultRequestHeaders.Authorization =
        //     new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InFJcFZVb2ZJak8tX2wyelZlR0lLeCJ9.eyJodHRwczovL2xhYmNpYmUtY2xpZW50LXJvbGVzL3JvbGUiOiJBZG1pbiIsImdpdmVuX25hbWUiOiJBbGV4IiwiZmFtaWx5X25hbWUiOiJWaWxsZWdhcyIsIm5pY2tuYW1lIjoiYWxleHZpbGxlZ2FzY2FycmFuemEiLCJuYW1lIjoiQWxleCBWaWxsZWdhcyIsInBpY3R1cmUiOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS9BQ2c4b2NLM2p4M09UalpDczRsZFI3YlFKWG5Kek4wWlpFVnhpVXpPUHdpTk1fV1NJczg9czk2LWMiLCJsb2NhbGUiOiJlcyIsInVwZGF0ZWRfYXQiOiIyMDIzLTExLTIxVDA2OjIxOjAxLjY3MloiLCJpc3MiOiJodHRwczovL2Rldi1teTNvZWp1Y21leTI2Y2JzLnVzLmF1dGgwLmNvbS8iLCJhdWQiOiJmVXhJUjBhbTNsa1ppTXFVQ3J0djViUW45bWQwS0FMNSIsImlhdCI6MTcwMDU0NzY2MiwiZXhwIjoxNzM2NTQ3NjYyLCJzdWIiOiJnb29nbGUtb2F1dGgyfDExMTk1ODc3NTE4MDUzNzA5NTAwNyIsInNpZCI6InNlWXZzZHVsT3p2bndzd25FazhmR3NTcW5iUG1COFg1Iiwibm9uY2UiOiI5MDcwOTM4MDFhZGM0YTEyOTFhMzdlNWY5YzBmNmI3NCJ9.WpY8YA1hJtXPPbecF7u9PMCIdBBgds6wVfSjjvWIu_ytEqT0SJ5Mit92la-cznEIabczmrog4-mUz1RzPPQ3bsgIWz3JcjKitFLr2JoAFEX-X9S-70QYgKVt0J8cnnqHajUPw7MEqxZZpLquWYt-C206BYmVasWfobzZJVh48rALiEJ7gGpMjouYRUvAK3RVIk8kqoWEz6DoXmKRfjuvp7ItAw2ShQ41gdPsaU2kXSvIFJxLq3HGHtul_uqa8tWpxQnllbUhd46r-LQf7B2CjGPaNAM9zKWZL8MvDQjgcmkwa1-TO500ES8XtQnYXD1cwbDDZlakVkRkUEMJngb-5g");

        //// Make the GET request
        //HttpResponseMessage response = await client.GetAsync("https://labcibe-books-api-dev.azurewebsites.net/api/Book");

        try
        {
            // Your API call logic here
            HttpResponseMessage response = await _httpClient.GetAsync("api/Book");

            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                string responseData = await response.Content.ReadAsStringAsync();
                return await response.Content.ReadFromJsonAsync<List<BooksModel>>();
            }
            else
            {
                return null;
            }
        }
        catch (Exception exception)
        {
            //exception.Redirect();
        }

        return null;
    }
}