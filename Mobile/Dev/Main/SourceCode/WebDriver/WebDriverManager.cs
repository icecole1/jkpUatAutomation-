using System;
using System.IO;
using BrowserMob.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UAT.Mobile.Automation.WebDriver
{
    public class WebDriverManager
    {
        private Server ProxyServer { get; set; }

        public IWebDriver WebDriver { get; set; }

        public WebDriverWait Wait { get; set; }

        public void Initialise()
        {
            
        }

        public Client ProxyServerStart()
        {
            try
            {
                ProxyServer = new Server();
                ProxyServer.Start();

                if (Configuration.UsePreprod)
                {
                    return ProxyServer.CreateProxy(Configuration.PreProdUrl);
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
