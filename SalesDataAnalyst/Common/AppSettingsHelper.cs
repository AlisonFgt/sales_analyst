using Microsoft.Extensions.Configuration;
using System.IO;

namespace SalesDataAnalyst.Common
{
    public class AppSettingsHelper
    {
        public static IConfigurationRoot Builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        public static string GetPathIN()
        {
            return Builder.GetSection("AppConfig").GetSection("Path_in").Value;
        }

        public static string GetPathOUT()
        {
            return Builder.GetSection("AppConfig").GetSection("Path_out").Value;
        }

        public static string GetEnvironmentVariable()
        {
            return Builder.GetSection("AppConfig").GetSection("EnvironmentVariable").Value;
        }
    }
}
