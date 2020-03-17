using System;
using System.IO;
using BrowserMob.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UAT.Mobile.Automation.WebDriver
{
    public class WebDriverManager
    {
        public WebDriverManager()
        {
            ScreenShotFileName = string.Concat("Exception-", new Random().Next(0, 1000), "-", DateTime.Now.ToString("dd-MM-yyyy-HHmm-ss"), ".png");
        }

        private Server ProxyServer { get; set; }

        public IWebDriver WebDriver { get; set; }

        public WebDriverWait Wait { get; set; }

        public string ScreenShotFileName { get; set; }

        public void Initialise()
        {
            
        }

        public Client ProxyServerStart()
        {
            try
            {
                ProxyServer = new Server();
                ProxyServer.Start();

                if (Configuration.UseGlobalE && Configuration.UsePreProd)
                {
                    throw new Exception("cannot have 'UsePreProd' and 'UseGlobalE' setting enabled at the same time.");
                }

                if (Configuration.UsePreProd)
                {
                    var proxy = ProxyServer.CreateProxy(Configuration.PreProdUrl);

                    return proxy;
                }

                if (Configuration.UseGlobalE)
                {
                    var proxy = ProxyServer.CreateProxy(Configuration.GlobalEProxyUrl, Configuration.GlobalEProxyUsername, Configuration.GlobalEProxyPassword );

                    return proxy;
                }

                return ProxyServer.CreateProxy();
            }
            catch(Exception ex)
            {
                ProxyServer.Stop();
                ProxyServer.Start();
                return ProxyServer.CreateProxy();
            }
        }

        public void Teardown()
        {
            ProxyServer.Stop();
            WebDriver.Quit();
            WebDriver = null;
        }
    }
}
