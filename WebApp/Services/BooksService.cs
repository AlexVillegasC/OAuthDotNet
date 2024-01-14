using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public interface IBookService
    {
        Task<BooksModel> GetBookAsync(int bookId, string token);
        Task<List<BooksModel>> GetBooksAsync();
    }

    public class BookService : IBookService
    {
        [Inject]
        private Auth0TokenService AuthService { get; set; }

        private readonly HttpClient _httpClient;
        private readonly Auth0TokenService _auth0TokenService;

        public BookService(HttpClient httpClient, Auth0TokenService auth0TokenService)
        {
            _httpClient = httpClient;
            _auth0TokenService = auth0TokenService;
        }

        public async Task<BooksModel> GetBookAsync(int bookId, string token)
        {
            //var accessToken = await AuthService.GetAccessTokenAsync();
            //if (accessToken == null)
            //{
            //    return null;

            //}

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://labcibe-books-api-dev.azurewebsites.net/api/books/{bookId}");
            if (response.IsSuccessStatusCode)
            {
                var book = await response.Content.ReadFromJsonAsync<BooksModel>();
                return book;
            }

            return null; // Or handle errors as needed
        }

        public async Task<List<BooksModel>> GetBooksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<BooksModel>>($"https://labcibe-books-api-dev.azurewebsites.net/api/books");
        }
    }

}
