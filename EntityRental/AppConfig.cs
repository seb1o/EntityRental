using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRental
{
    internal class AppConfig
    {
        public static IConfiguration Configuration { get; set; }
        static AppConfig()
        {
            if (Configuration == null)
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appConfig.json", optional: true, reloadOnChange: true)
                    .Build();
            }
        }
        public static string? GetConnectionString()
        {
            return Configuration.GetConnectionString("postgres");
        }
    }
}
