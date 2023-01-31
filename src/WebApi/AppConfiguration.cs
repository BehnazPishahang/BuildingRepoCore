namespace Building.Core.WebApi
{
    public class AppConfiguration
    {

        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public JwtConfig JwtConfig { get; set; }
        public string JWTTokenValidMinute { get; set; }
        
    }



    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class JwtConfig
    {
        public string Secret { get; set; }
    }

    public class RedisConfig
    {
        public string Configuration { get; set; }
    }
}