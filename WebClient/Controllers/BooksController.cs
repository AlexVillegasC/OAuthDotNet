using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace SampleMvcApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve the access token from the current user's claims
            string accessToken = await HttpContext.GetTokenAsync("id_token");
            // Decode the JWT token to extract user info
            // var handler = new JwtSecurityTokenHandler();
            //var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;
            // var payload = jsonToken?.Payload;
            if (accessToken is null)
                return Redirect("Account/Login");


            var book = await _bookService.GetBookAsync(1, accessToken); // Fetch book with ID 1

            return View(book);
        }
    }
}
