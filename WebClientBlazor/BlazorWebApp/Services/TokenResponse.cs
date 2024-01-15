namespace Client.WebApp.Services
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }
    }
}
