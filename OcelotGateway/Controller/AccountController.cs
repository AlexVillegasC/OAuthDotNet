using Microsoft.AspNetCore.Mvc;
using OcelotGateway.Services;

namespace OcelotGateway.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AccountController(ITokenService tokenService) { 
        
        _tokenService = tokenService;
        }

        [HttpGet("Get Token")]
        public async Task<IActionResult> SignInAndGetToken(string username,string password)
        {
            var oktaToken =await _tokenService.GetToken(username, password);
            if (oktaToken != null)
                return Ok(oktaToken);



            return null;

        }
    }
}
