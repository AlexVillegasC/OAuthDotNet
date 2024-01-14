using ApiEBooks.Services;
using LabCibe.OwaspHeaders.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

const string AllowSpecificOrigin = "AllowSpecificOrigin";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Authorization token using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.OperationFilter<SecurityRequirementsOperationFilter>();

    // Resto de la configuración de Swagger...
});

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
});


builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBookService, BookService>();

//configure policies
builder.Services.AddCors(o => o.AddPolicy(AllowSpecificOrigin, builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
    });
}

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("local",
//        builder =>
//            builder.WithOrigins(
//                        "https://localhost:[BlazorWebAssemblyApp PORT]",
//                        "https://localhost:[BlazorServerApp PORT]")
//                        .AllowAnyHeader());
//});



//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Admin", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim("scope", "Admin");
//    });
//});


//app.UseSecureHeadersMiddleware(SecureHeadersMiddlewareExtensions.BuildDefaultConfiguration());

app.UseCors(AllowSpecificOrigin);

app.UseHttpsRedirection();

// 2. Add Authentication Middleware
app.UseAuthentication();

// 3. Add Authorization Middleware
app.UseAuthorization();

app.MapControllers();

app.Run();
