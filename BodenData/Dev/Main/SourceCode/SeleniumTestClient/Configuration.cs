using System;
using System.Configuration;
using UAT.Mobile.Automation.Helpers;

namespace UAT.Mobile.Automation
{
    public static class Configuration
    {
        /// <summary>
        /// Specify which markets to run the tests for and run the logic contained in code for that market.
        /// </summary>
        public static Enums.Market Market => (Enums.Market) Enum.Parse(typeof(Enums.Market), ConfigurationManager.AppSettings["Market"]);

        /// <summary>
        /// Specify the environment to run the tests against.
        /// </summary>
        public static string Environment => ConfigurationManager.AppSettings["Environment"];

        /// <summary>
        /// Specify which browser to run the test against.
        /// </summary>
        public static string Browser => ConfigurationManager.AppSettings["Browser"];

        /// <summary>
        /// Used with Thread.Sleep.
        /// </summary>
        public static int MilliSecondsToWait => int.Parse(ConfigurationManager.AppSettings["MilliSecondsToWait"]);

        /// <summary>
        /// Used with webdriver to wait until something happens.
        /// </summary>
        public static int ImplicitSecondsToWait => int.Parse(ConfigurationManager.AppSettings["ImplicitSecondsToWait"]);
    
        /// <summary>
        /// Used with webdriver to specify how long to wait until page DOM is loaded.
        /// </summary>
        public static int PageLoadSecondsToWait => int.Parse(ConfigurationManager.AppSettings["PageLoadSecondsToWait"]);

        /// <summary>
        /// Used with webdriver to specify seconds to wait on Webdriver.Wait.Until expected condition.
        /// </summary>
        public static int WebDriverWaitInSeconds => int.Parse(ConfigurationManager.AppSettings["WebDriverWaitInSeconds"]);

        /// <summary>
        /// Used to specify which database to use for test data dependent on DB\Environment.
        /// </summary>
        public static string ProductDbConnectionString => ConfigurationManager.AppSettings["ProductDbConnectionString"];

        /// <summary>
        /// Used to specify browser timeout for the relevant Browser used.
        /// </summary>
        public static TimeSpan BrowserTimeoutInSeconds => new TimeSpan(0,0,0, int.Parse(ConfigurationManager.AppSettings["BrowserTimeoutInSeconds"]));

        /// <summary>
        /// Used to run against preprod environment.
        /// </summary>
        public static bool UsePreProd => bool.Parse(ConfigurationManager.AppSettings["UsePreprod"]);

        /// <summary>
        /// Used to specify the url for pre production environment.
        /// </summary>
        public static string PreProdUrl => ConfigurationManager.AppSettings["PreProdUrl"];

        public static string LogDbConnectionString => ConfigurationManager.ConnectionStrings["LogDbConnectionString"].ConnectionString;

        public static bool IsLoggingEnabled => Convert.ToBoolean(ConfigurationManager.AppSettings["LoggingEnabled"]);
    }
}
