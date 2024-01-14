using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.OpenApi.Models;
using OcelotGateway.Models;
using OcelotGateway.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Auth0 utilizando IConfiguration para obtener los valores
var auth0SettingsSection = builder.Configuration.GetSection("Auth0");
builder.Services.Configure<Auth0TokenSettings>(auth0SettingsSection);
var auth0Settings = auth0SettingsSection.Get<Auth0TokenSettings>();


// 1. Add Authentication Services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var domain = builder.Configuration["Auth0:Domain"];
    var audience = builder.Configuration["Auth0:ClientId"]; // This seems to be the audience in your setup
    options.Authority = $"https://{domain}/";
    options.Audience = audience;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Aquí se configura para que la audiencia pueda ser cualquiera de las dos APIs.
        ValidAudiences = new List<string> { "https://labcibe-users-api-dev.azurewebsites.net/swagger/", "https://labcibe-books-api-dev.azurewebsites.net/" }
    };
});

builder.Services.AddAuthorization();
builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.UseRouting();
app.UseAuthentication(); // Asegúrate de llamar UseAuthentication antes de UseAuthorization
app.UseAuthorization();
await app.UseOcelot();
app.Run();

