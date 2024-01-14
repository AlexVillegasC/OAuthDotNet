using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.WebApp.Helper;


public static class JwtParser
{
    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(jwt);
        var tokenS = handler.ReadToken(jwt) as JwtSecurityToken;

        return tokenS?.Claims;
    }
}
