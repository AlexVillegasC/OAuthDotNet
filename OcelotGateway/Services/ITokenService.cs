using OcelotGateway.Models;

namespace OcelotGateway.Services
{
    public interface ITokenService
    {
        Task<Auth0Response> GetToken(string username, string password);
    }
}
