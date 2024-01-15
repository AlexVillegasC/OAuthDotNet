namespace Client.WebApp.Services.MessageHandler;

public interface ITokenProviderService
{
    public Task<string> GetAccessTokenAsync(CancellationToken cancellationToken);
}
