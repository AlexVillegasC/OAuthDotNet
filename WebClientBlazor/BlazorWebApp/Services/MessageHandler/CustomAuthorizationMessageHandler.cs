using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;


namespace WebApp.Services.MessageHandler;

public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public CustomAuthorizationMessageHandler(IAccessTokenProvider accessTokenProvider, NavigationManager navigationManager, IConfiguration configuration)
        // IConfiguration is injected to read from appsettings
        : base(accessTokenProvider, navigationManager)
    {
        // Example: Reading from configuration
        var apiBaseUrl = configuration["ApiSettings:BaseUrl"]; // Adjust the key as per your config
        var scopes = configuration.GetSection("ApiSettings:Scopes").Get<string[]>();

        // Configuring the handler with the API base URL and scopes
        //ConfigureHandler(
        //    authorizedUrls: new[] { apiBaseUrl },
        //    scopes: scopes,
        //    returnUrl: apiBaseUrl
        //    );
    }
}



//protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//{
//    //var tokenResult = await _accessTokenProvider.RequestAccessToken();
//    request.Headers.Authorization =
//        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InFJcFZVb2ZJak8tX2wyelZlR0lLeCJ9.eyJodHRwczovL2xhYmNpYmUtY2xpZW50LXJvbGVzL3JvbGUiOiJBZG1pbiIsImdpdmVuX25hbWUiOiJBbGV4IiwiZmFtaWx5X25hbWUiOiJWaWxsZWdhcyIsIm5pY2tuYW1lIjoiYWxleHZpbGxlZ2FzY2FycmFuemEiLCJuYW1lIjoiQWxleCBWaWxsZWdhcyIsInBpY3R1cmUiOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS9BQ2c4b2NLM2p4M09UalpDczRsZFI3YlFKWG5Kek4wWlpFVnhpVXpPUHdpTk1fV1NJczg9czk2LWMiLCJsb2NhbGUiOiJlcyIsInVwZGF0ZWRfYXQiOiIyMDIzLTExLTIxVDA2OjIxOjAxLjY3MloiLCJpc3MiOiJodHRwczovL2Rldi1teTNvZWp1Y21leTI2Y2JzLnVzLmF1dGgwLmNvbS8iLCJhdWQiOiJmVXhJUjBhbTNsa1ppTXFVQ3J0djViUW45bWQwS0FMNSIsImlhdCI6MTcwMDU0NzY2MiwiZXhwIjoxNzM2NTQ3NjYyLCJzdWIiOiJnb29nbGUtb2F1dGgyfDExMTk1ODc3NTE4MDUzNzA5NTAwNyIsInNpZCI6InNlWXZzZHVsT3p2bndzd25FazhmR3NTcW5iUG1COFg1Iiwibm9uY2UiOiI5MDcwOTM4MDFhZGM0YTEyOTFhMzdlNWY5YzBmNmI3NCJ9.WpY8YA1hJtXPPbecF7u9PMCIdBBgds6wVfSjjvWIu_ytEqT0SJ5Mit92la-cznEIabczmrog4-mUz1RzPPQ3bsgIWz3JcjKitFLr2JoAFEX-X9S-70QYgKVt0J8cnnqHajUPw7MEqxZZpLquWYt-C206BYmVasWfobzZJVh48rALiEJ7gGpMjouYRUvAK3RVIk8kqoWEz6DoXmKRfjuvp7ItAw2ShQ41gdPsaU2kXSvIFJxLq3HGHtul_uqa8tWpxQnllbUhd46r-LQf7B2CjGPaNAM9zKWZL8MvDQjgcmkwa1-TO500ES8XtQnYXD1cwbDDZlakVkRkUEMJngb-5g");

//    return await base.SendAsync(request, cancellationToken);
//}