namespace OcelotGateway.Models
{
    public class Auth0TokenSettings
    {
         public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Domain { get; set; }

        public string AuthorizationServerId { get; set; }

        public string Audience { get; set; }


    }
}
