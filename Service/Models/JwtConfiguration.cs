namespace Service.Models
{
    public class JwtConfiguration
    {
        public string IssuerSigningKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int Duration { get; set; }
    }
}
