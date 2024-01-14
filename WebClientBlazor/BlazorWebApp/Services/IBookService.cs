using Client.WebApp.Models;

namespace WebApp.Services;

public interface IBooksService
{
    Task<BooksModel> GetBookAsync(int bookId);
    Task<List<BooksModel>> GetBooksAsync();
}
