using Microsoft.AspNetCore.Http;
using SampleMvcApp.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System;
using Microsoft.AspNetCore.Components;

namespace SampleMvcApp.Services
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
