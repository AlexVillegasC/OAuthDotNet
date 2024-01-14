using Client.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using WebApp.Services;

namespace Client.WebApp.Pages;

[Authorize]
public partial class Books
{
    [Inject]
    private IBooksService BooksService { get; set; }


    private List<BooksModel> books;

    protected override async Task OnInitializedAsync()
    {
        books = await BooksService.GetBooksAsync();
    }
}
