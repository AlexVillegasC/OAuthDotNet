using Blazored.LocalStorage;
using Client.WebApp;
using Client.WebApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp.Services;
using WebApp.Services.MessageHandler;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var apiBaseUrl = builder.Configuration["BooksApi:Url"];

builder.Services.AddBlazoredLocalStorage();

// builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient("BooksAPI", client =>
{
    //client.BaseAddress = new Uri(apiBaseUrl);
    client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InFJcFZVb2ZJak8tX2wyelZlR0lLeCJ9.eyJodHRwczovL2xhYmNpYmUtY2xpZW50LXJvbGVzL3JvbGUiOiJBZG1pbiIsImdpdmVuX25hbWUiOiJBbGV4IiwiZmFtaWx5X25hbWUiOiJWaWxsZWdhcyIsIm5pY2tuYW1lIjoiYWxleHZpbGxlZ2FzY2FycmFuemEiLCJuYW1lIjoiQWxleCBWaWxsZWdhcyIsInBpY3R1cmUiOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS9BQ2c4b2NLM2p4M09UalpDczRsZFI3YlFKWG5Kek4wWlpFVnhpVXpPUHdpTk1fV1NJczg9czk2LWMiLCJsb2NhbGUiOiJlcyIsInVwZGF0ZWRfYXQiOiIyMDIzLTExLTIxVDA2OjIxOjAxLjY3MloiLCJpc3MiOiJodHRwczovL2Rldi1teTNvZWp1Y21leTI2Y2JzLnVzLmF1dGgwLmNvbS8iLCJhdWQiOiJmVXhJUjBhbTNsa1ppTXFVQ3J0djViUW45bWQwS0FMNSIsImlhdCI6MTcwMDU0NzY2MiwiZXhwIjoxNzM2NTQ3NjYyLCJzdWIiOiJnb29nbGUtb2F1dGgyfDExMTk1ODc3NTE4MDUzNzA5NTAwNyIsInNpZCI6InNlWXZzZHVsT3p2bndzd25FazhmR3NTcW5iUG1COFg1Iiwibm9uY2UiOiI5MDcwOTM4MDFhZGM0YTEyOTFhMzdlNWY5YzBmNmI3NCJ9.WpY8YA1hJtXPPbecF7u9PMCIdBBgds6wVfSjjvWIu_ytEqT0SJ5Mit92la-cznEIabczmrog4-mUz1RzPPQ3bsgIWz3JcjKitFLr2JoAFEX-X9S-70QYgKVt0J8cnnqHajUPw7MEqxZZpLquWYt-C206BYmVasWfobzZJVh48rALiEJ7gGpMjouYRUvAK3RVIk8kqoWEz6DoXmKRfjuvp7ItAw2ShQ41gdPsaU2kXSvIFJxLq3HGHtul_uqa8tWpxQnllbUhd46r-LQf7B2CjGPaNAM9zKWZL8MvDQjgcmkwa1-TO500ES8XtQnYXD1cwbDDZlakVkRkUEMJngb-5g");
});
//}).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped(
                sp => sp.GetService<IHttpClientFactory>().CreateClient("BooksAPI"));

builder.Services.AddScoped<IBooksService, BooksService>(sp =>
{
    var httpClientFactoryClient = sp.GetService<IHttpClientFactory>().CreateClient("BooksAPI");
    var accessTokenProvider = sp.GetRequiredService<IAccessTokenProvider>();
    return new BooksService(httpClientFactoryClient);
});

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = builder.Configuration["Auth0:Authority"];
    options.ProviderOptions.ClientId = builder.Configuration["Auth0:ClientId"];
    options.ProviderOptions.DefaultScopes.Add("Admin");
    options.UserOptions.RoleClaim = "https://labcibe-client-roles/role";
});


await builder.Build().RunAsync();



//builder.Services.AddAuthorizationCore();

//builder.Services.AddAuthorizationCore(config =>
//{
//    config.AddPolicy("delete-access",
//          new AuthorizationPolicyBuilder().
//              RequireAuthenticatedUser().
//              RequireRole("Admin").
//              Build()
//          );
//});
