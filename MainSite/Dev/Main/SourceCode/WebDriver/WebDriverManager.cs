using System;
using System.IO;
using BrowserMob.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UAT.MainSite.Automation.WebDriver
{
    public class WebDriverManager
    {
        public WebDriverManager()
        {
           
        }

        private Server ProxyServer { get; set; }

        public IWebDriver WebDriver { get; set; }

        public WebDriverWait Wait { get; set; }

        public Client ProxyServerStart()
        {
            //try
            //{
            //    if (Configuration.UseGlobalE && Configuration.UsePreprod)
            //    {
            //        throw new Exception("cannot have 'UsePreProd' and 'UseGlobalE' setting enabled at the same time.");
            //    }

                ProxyServer = new Server();
                ProxyServer.Start();

                //if (Configuration.UsePreprod)
                //{
                //    return ProxyServer.CreateProxy(Configuration.PreProdUrl);
                //}

                //if (Configuration.UseGlobalE)
                //{
                //    var proxy = ProxyServer.CreateProxy(Configuration.GlobalEJPProxyUrl, Configuration.GlobalEJPProxyUsername, Configuration.GlobalEJPProxyPassword);

                //    return proxy;
                //}
            {

                return ProxyServer.CreateProxy();
            //}
            //catch(Exception ex)
            //{
                //throw new Exception(ex.Message);
                //ProxyServer.Stop();
                //ProxyServer.Start();
                //return ProxyServer.CreateProxy();
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
