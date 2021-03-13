using Microsoft.Extensions.Configuration;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UrlCreator : IUrlCreator
    {
        private readonly IConfiguration _Configuration;

        public UrlCreator(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // Complejidad ciclomatica: 3
        public string GetUrl()
        {
            string url = string.Empty;

            ServerUrl backendUrl = new ServerUrl();

            _Configuration.GetSection("WebServer").Bind(backendUrl);

            url += backendUrl.Protocol;
            url += "://"; // http://
            url += backendUrl.Domain; // http://localhost

            if (!String.IsNullOrEmpty(backendUrl.Port))
            {
                url += ":";
                url += backendUrl.Port; // http://localhost:5000
            }

            if (!String.IsNullOrEmpty(backendUrl.Subfix))
            {
                url += "/";
                url += backendUrl.Subfix; // http://localhost:5000/api 
            }

            return url;
        }
    }
}
