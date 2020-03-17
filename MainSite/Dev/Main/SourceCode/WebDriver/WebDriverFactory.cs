using System;
using System.IO;
using System.Net;
using System.Web;
using AutomationData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace UAT.MainSite.Automation.WebDriver
{
    public class WebDriverFactory
    {
        private static WebDriverManager _webDriverManager;
        
        public static WebDriverManager Get()
        {
            _webDriverManager = new WebDriverManager();
            var proxy = ConfigureProxy();
            ConfigureWebDriver(proxy);
            ConfigureWebDriverWait();

            return _webDriverManager;
        }

        private static Proxy ConfigureProxy()
        {
            var httpClient = _webDriverManager.ProxyServerStart();


            httpClient.Blacklist(@".*monetate.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*btstatic.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*thebrighttag.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*adobedtm.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*taboola.com.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*sub2tech.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*skimresources.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*redirectingat.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*rfihub.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*crwdcntrl.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*casalemedia.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*facebook.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*facebook.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*ecustomeropinions.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*dotomi.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*dtmpub.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*dwin1.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*criteo.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*criteo.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*bluekai.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*bkrtx.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*foresee.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*googletagmanager.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*omtrdc.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*liveperson.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*lpsnmedia.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*exelator.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*addthis.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*demdex.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*doubleclick.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*googleadservices.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*ist-track.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*ricdn.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*turn.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*google-analytics.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*resultspage.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*stats.g.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*rfihub.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*googleads.g.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*jpbodenandco.d3.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*hotjar.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*fullstory.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*google.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*photorank*", (int)HttpStatusCode.NotFound);
            //httpClient.Blacklist(@".*global-e*", (int)HttpStatusCode.NotFound);

            var proxy = new Proxy
            {
                HttpProxy = httpClient.SeleniumProxy,
                SslProxy = httpClient.SeleniumProxy
            };

            return proxy;
        }

        private static void ConfigureWebDriver(Proxy proxy)
        {
            EventFiringWebDriver eventDriver;

            switch (Configuration.Browser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions
                    {
                        Proxy = proxy
                    };

                    if (Configuration.HeadlessMode)
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    chromeOptions.AddArgument("--lang=en-GB");
                    chromeOptions.AddArgument("no-sandbox");
                    chromeOptions.AddArguments("--disable-popup-blocking");
                    chromeOptions.AddArgument("--acceptSslCerts=true");
                    chromeOptions.AddArgument("--acceptInsecureCerts=true");

                    var chromeDriverService = ChromeDriverService.CreateDefaultService();
                    eventDriver = new EventFiringWebDriver(new ChromeDriver(chromeDriverService, chromeOptions, Configuration.BrowserTimeoutInSeconds));
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.Profile = new FirefoxProfile();
                    firefoxOptions.Profile.SetProxyPreferences(proxy);
                    firefoxOptions.SetPreference("marionette", false); // true gives that Javascript error (AddonManager is not initialized)

                    var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
                    eventDriver = new EventFiringWebDriver(new FirefoxDriver(firefoxDriverService, firefoxOptions, Configuration.BrowserTimeoutInSeconds));
                    break;
                case "ie":
                    eventDriver = new EventFiringWebDriver(new InternetExplorerDriver());
                    break;
                case "phantomjs":
                    eventDriver = new EventFiringWebDriver(new PhantomJSDriver());
                    break;
                case "browserstack":
                    IWebDriver driver;
                    DesiredCapabilities capability = new DesiredCapabilities();
                    //capability.SetCapability("os_version", "11.0");
                    //capability.SetCapability("device", "iPad 5th");
                    //capability.SetCapability("real_mobile", "true");
                    capability.SetCapability("os", "Windows");
                    capability.SetCapability("os_version", "10");
                    capability.SetCapability("browser", "Chrome");
                    capability.SetCapability("browser_version", "60.0");
                    capability.SetCapability("browserstack.debug", "true");
                    capability.SetCapability("browserstack.user", "cameronrichmond1");
                    capability.SetCapability("browserstack.key", "xPP5hWEGqUzHGUZ1kmAD");

                    driver = new RemoteWebDriver(
                        new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
                    );

                    eventDriver = new EventFiringWebDriver(driver);
                    break;
                default:
                    eventDriver = new EventFiringWebDriver(new ChromeDriver());
                    break;
            }

            eventDriver.ExceptionThrown += EventDriver_ExceptionThrown;
            _webDriverManager.WebDriver = eventDriver;

            if (Configuration.ImplicitSecondsToWait > 0)
            {
                _webDriverManager.WebDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, Configuration.ImplicitSecondsToWait);
            }

            if (Configuration.PageLoadSecondsToWait > 0)
            {
                _webDriverManager.WebDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, Configuration.PageLoadSecondsToWait);
            }

            if (Configuration.Browser != "browserstack")
            {
                _webDriverManager.WebDriver.Manage().Window.Maximize();
            }
        }

        private static void EventDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            //if (Configuration.IsLoggingEnabled)
            //{
            //    var logRepository = new LogRepository("main", Configuration.Market.ToString(), Configuration.LogConnectionString);
            //    logRepository.Log(_webDriverManager.ScreenShotFileName, HttpUtility.HtmlEncode(e.ThrownException.Message));
            //}
        }

        private static void ConfigureWebDriverWait()
        {
            var timespanInSeconds = new TimeSpan(0,0,0, Configuration.WebDriverWaitInSeconds);
            _webDriverManager.Wait = new WebDriverWait(_webDriverManager.WebDriver, timespanInSeconds);
        }
    }
}
