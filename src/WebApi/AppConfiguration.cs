﻿namespace Building.Core.WebApi
{
    public class AppConfiguration
    {
        public const string Configuration = nameof(Configuration);
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
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
}