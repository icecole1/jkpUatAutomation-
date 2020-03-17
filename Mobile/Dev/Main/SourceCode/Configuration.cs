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
        public static Enums.Market Market => GetValue("Market",
            x => (Enums.Market)Enum.Parse(typeof(Enums.Market), x));

        /// <summary>
        /// Specify the environment to run the tests against.
        /// </summary>
        public static string Environment => GetValue("Environment", x => x);

        public static string EnvironmentGlobalE => GetValue("Environment", x =>
        {
            var url = x.Replace("http://", "");

            if (UseGlobalE)
            {
                url = $"http://{GlobalETestUsername}:{GlobalETestPassword}@{url}";
            }

            return url;
        });

        /// <summary>
        /// Specify which browser to run the test against.
        /// </summary>
        public static string Browser => GetValue("Browser", x => x);

        public static bool HeadlessMode => GetValue("HeadlessMode", bool.Parse);

        /// <summary>
        /// Used with Thread.Sleep.
        /// </summary>
        public static int MilliSecondsToWait => GetValue("MilliSecondsToWait", int.Parse);

        /// <summary>
        /// Used with webdriver to wait until something happens.
        /// </summary>
        public static int ImplicitSecondsToWait => GetValue("ImplicitSecondsToWait", int.Parse);

        /// <summary>
        /// Used with webdriver to specify how long to wait until page DOM is loaded.
        /// </summary>
        public static int PageLoadSecondsToWait => GetValue("PageLoadSecondsToWait", int.Parse);

        /// <summary>
        /// Used with webdriver to specify seconds to wait on Webdriver.Wait.Until expected condition.
        /// </summary>
        public static int WebDriverWaitInSeconds => GetValue("WebDriverWaitInSeconds", int.Parse);

        /// <summary>
        /// Used to specify which database to use for test data dependent on DB\Environment.
        /// </summary>
        public static string ProductDbConnectionString => GetValue("ProductDbConnectionString", x => x);

        public static bool UsePreprod => GetValue("UsePreprod", bool.Parse);

        /// <summary>
        /// Used to specify browser timeout for the relevant Browser used.
        /// </summary>
        public static TimeSpan BrowserTimeoutInSeconds => GetValue("BrowserTimeoutInSeconds", x => new TimeSpan(0, 0, 0, int.Parse(x)));

        /// <summary>
        /// Used to specify the url for pre production environment.
        /// </summary>
        public static string PreProdUrl => GetValue("PreProdUrl", x => x);

        /// <summary>
        /// Used to run CSA tests on stage environment.
        /// </summary>
        public static string CSAPasswordStage => GetValue("CSAPasswordStage", x => x);

        public static bool CreateSetupAccounts => GetValue("CreateSetupAccounts", bool.Parse);

        public static bool IsLiveConfigurationEnabled => !Environment.ToLower().Contains("stage");

        /// <summary>
        /// Used to run against globalE environment.
        /// </summary>
        public static bool UseGlobalE => GetValue("UseGlobalE", bool.Parse);

        /// <summary>
        /// Used to specify the username for globalE access from test environment.
        /// </summary>
        public static string GlobalETestUsername => GetValue("GlobalETestUsername", x => x);

        /// <summary>
        /// Used to specify the password for globalE access from test environment.
        /// </summary>
        public static string GlobalETestPassword => GetValue("GlobalETestPassword", x => x);


        /// <summary>
        /// Used to run against globalE market.
        /// </summary>
        public static Enums.GlobalEMarket GlobalEMarket => GetValue("GlobalEMarket",
            x => (Enums.GlobalEMarket)Enum.Parse(typeof(Enums.GlobalEMarket), x));

        /// <summary>
        /// Used to specify the proxy url for globalE environment.
        /// </summary>
        public static string GlobalEJPProxyUrl => GetValue("GlobalEJPProxyUrl", x => x);

        /// <summary>
        /// Used for globalE proxy username credential.
        /// </summary>
        public static string GlobalEJPProxyUsername => GetValue("GlobalEJPProxyUsername", x => x);

        /// <summary>
        /// Used for globalE proxy password credential.
        /// </summary>
        public static string GlobalEJPProxyPassword => GetValue("GlobalEJPProxyPassword", x => x);

        /// <summary>
        /// Gets value from Environment Variable, or App./Web.Config if not set.
        /// </summary>
        /// <exception cref="ConfigurationErrorsException">Thrown if key not found</exception>
        /// <param name="key">The configuration key to find</param>
        /// <param name="parseValue">provides a way of converting string to an object</param>
        /// <returns>value object for the provided key</returns>
        private static T GetValue<T>(string key, Func<string, T> parseValue)
        {
            var value = System.Environment.GetEnvironmentVariable(key.ToUpperInvariant());
            value = string.IsNullOrWhiteSpace(value) == false
                ? value
                : ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException($"{key} not found in AppSettings or Environment Variables");
            }

            return parseValue(value);
        }

        private static string GetConnectionString(string name)
        {
            string value = System.Environment.GetEnvironmentVariable(name.ToUpperInvariant());
            value = string.IsNullOrWhiteSpace(value) == false
                ? value
                : ConfigurationManager.ConnectionStrings[name].ConnectionString;

            if (string.IsNullOrWhiteSpace(value))
            {
                // your prograam should probably stop if you can't find a connection string.
                throw new ConfigurationErrorsException($"ConnectionString {name} not found");
            }

            return value;
        }
    }
}
