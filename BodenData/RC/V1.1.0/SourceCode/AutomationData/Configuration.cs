using System.Configuration;

namespace AutomationData
{
    public static class Configuration
    {
        public static string ProductDbConnectionString => ConfigurationManager.AppSettings["ProductDbConnectionString"];

        public static string LogDbConnectionString => ConfigurationManager.AppSettings["LogDbConnectionString"];
    }
}