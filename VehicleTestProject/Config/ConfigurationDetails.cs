using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTestProject.Config
{
    public static class ConfigurationDetails
    {
        public static IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the correct path
                .AddJsonFile("Config/appsettings.json")
                .Build();

            return configuration;
        }
    }
}
