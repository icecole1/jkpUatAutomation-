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
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace UAT.Mobile.Automation.WebDriver
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

            httpClient.Blacklist(@".*monetate.net.*", (int) HttpStatusCode.OK);
            httpClient.Blacklist(@".*btstatic.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*thebrighttag.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*adobedtm.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*taboola.com.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*sub2tech.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*skimresources.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*redirectingat.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*rfihub.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*photorank.me.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*crwdcntrl.net.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*casalemedia.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*facebook.net.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*facebook.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*ecustomeropinions.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*dotomi.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*dtmpub.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*dwin1.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*criteo.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*criteo.net.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*bluekai.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*bkrtx.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*foresee.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*googletagmanager.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*omtrdc.net.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*liveperson.net.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*lpsnmedia.net.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*resultspage.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*exelator.com.*", (int)HttpStatusCode.OK);
            httpClient.Blacklist(@".*addthis.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*demdex.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*doubleclick.net.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*googleadservices.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*ist-track.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*ricdn.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*turn.com.*", (int)HttpStatusCode.NotFound);
            httpClient.Blacklist(@".*google-analytics.com.*", (int)HttpStatusCode.NotFound);
            //httpClient.SetHeader("accept-language", "en-GB");

            var proxy = new Proxy();

#if DEBUG
            proxy.HttpProxy = httpClient.SeleniumProxy;
            proxy.SslProxy = httpClient.SeleniumProxy;
#else
            proxy.HttpProxy = httpClient.SeleniumProxy;
            proxy.SslProxy = httpClient.SeleniumProxy;
#endif   
            return proxy;
        }

        private static void ConfigureWebDriver(Proxy proxy)
        {
            EventFiringWebDriver eventDriver;

            var androidS6 = "Mozilla/5.0 (Linux; Android 7.0; SM-G920F Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Mobile Safari/537.36";
            
            switch (Configuration.Browser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions
                    {
                        Proxy = proxy
                    };

                    var device = new ChromeMobileEmulationDeviceSettings
                    {
                        Height = 640,
                        Width = 360,
                        UserAgent = androidS6,
                        PixelRatio = 4,
                        EnableTouchEvents = true
                    };

                    //chromeOptions.AddArguments("--test-type");
                    //chromeOptions.AddArgument("--lang=en-GB");
                    chromeOptions.AddArgument("--acceptSslCerts=true");
                    chromeOptions.AddArgument("--acceptInsecureCerts=true");
                    chromeOptions.AddArgument("no-sandbox");
                    chromeOptions.EnableMobileEmulation(device);

                    var chromeDriverService = ChromeDriverService.CreateDefaultService();

                    eventDriver = new EventFiringWebDriver(new ChromeDriver(chromeDriverService, chromeOptions, Configuration.BrowserTimeoutInSeconds));
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();

                    const string mobileNumber = "07950111222";
                    var profile = new FirefoxProfile();
                    if (File.Exists("modify_headers-0.7.1.1-fx.xpi"))
                        profile.AddExtension("modify_headers-0.7.1.1-fx.xpi");
                    else
                        profile.SetProxyPreferences(proxy);
                        profile.SetPreference("marionette", false); // true gives that Javascript error (AddonManager is not initialized)
                        profile.SetPreference("modifyheaders.config.active", true);
                        profile.SetPreference("modifyheaders.config.alwaysOn", true);
                        profile.SetPreference("modifyheaders.headers.count", 2);
                        profile.SetPreference("modifyheaders.headers.action0", "Add");
                        profile.SetPreference("modifyheaders.headers.name0", "User-Agent");
                        profile.SetPreference("modifyheaders.headers.value0", androidS6);
                        profile.SetPreference("modifyheaders.headers.enabled0", true);
                        profile.SetPreference("modifyheaders.headers.action1", "Add");
                        profile.SetPreference("modifyheaders.headers.name1", "x-up-subno");
                        profile.SetPreference("modifyheaders.headers.value1", mobileNumber);
                        profile.SetPreference("modifyheaders.headers.enabled1", true);

                    firefoxOptions.Profile = profile;
           
                    var firefoxDriverService = FirefoxDriverService.CreateDefaultService();

                    eventDriver = new EventFiringWebDriver(new FirefoxDriver(firefoxDriverService, firefoxOptions, Configuration.BrowserTimeoutInSeconds));
                    break;
                case "ie":
                    eventDriver = new EventFiringWebDriver(new InternetExplorerDriver());
                    break;
                case "phantomjs":
                    eventDriver = new EventFiringWebDriver(new PhantomJSDriver());
                    break;
                default:
                    eventDriver = new EventFiringWebDriver(new ChromeDriver());
                    break;
            }

            eventDriver.ExceptionThrown += EventDriver_ExceptionThrown;
            _webDriverManager.WebDriver = eventDriver;
            _webDriverManager.WebDriver.Manage().Cookies.DeleteAllCookies();

            if (Configuration.ImplicitSecondsToWait > 0)
            {
                _webDriverManager.WebDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, Configuration.ImplicitSecondsToWait);
            }

            if (Configuration.PageLoadSecondsToWait > 0)
            {
                _webDriverManager.WebDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, Configuration.PageLoadSecondsToWait);
            }
            
            _webDriverManager.WebDriver.Manage().Window.Maximize();
        }

        private static void EventDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            // Take screenshot
            var path = string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\logs\screenshots\");

            var directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            var fullPath = string.Concat(path, _webDriverManager.ScreenShotFileName);
            var screenshot = ((ITakesScreenshot)_webDriverManager.WebDriver).GetScreenshot();

            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);

            // Log error
            //var logRepository = new LogRepository("mobile", Configuration.Market.ToString());
            //logRepository.Log(_webDriverManager.ScreenShotFileName, HttpUtility.HtmlEncode(e.ThrownException.Message));
        }

        private static void ConfigureWebDriverWait()
        {
            var timespanInSeconds = new TimeSpan(0,0,0, Configuration.WebDriverWaitInSeconds);
            _webDriverManager.Wait = new WebDriverWait(_webDriverManager.WebDriver, timespanInSeconds);
        }
    }
}
