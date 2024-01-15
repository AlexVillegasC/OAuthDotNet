using Client.WebApp.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Text.Json;

namespace Client.WebApp.Services.MessageHandler;

public class TokenProviderService : ITokenProviderService
{
    
    private readonly IJSRuntime _jsRuntime;
   
    
    public TokenProviderService(IConfiguration configuration, IJSRuntime jsRuntime)
    {    
        _jsRuntime = jsRuntime;        
    }

    public async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken)
    {
        var token = await _jsRuntime.GetAccessToken();
        
        using (JsonDocument doc = JsonDocument.Parse(token))
        {
            JsonElement root = doc.RootElement;

            if (root.TryGetProperty("id_token", out JsonElement idTokenElement))
            {
                return idTokenElement.GetString();
            }
            else
            {
                return null; // or handle the absence of id_token as needed
            }
        }

        return token;
    }
}

