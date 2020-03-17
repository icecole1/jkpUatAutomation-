using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.MainSite.Automation.MainSite.Pages.Panels;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages
{
    public class UDOMNgPdpPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private object get;

        public UDOMNgPdpPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            PageFactory.InitElements(webDriverManager.WebDriver, this);
            _webDriverManager = webDriverManager;

        }

        public IWebElement OuterWrapper => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("wc-stripe-payment-request-button-separator")));

        public IWebElement BuyNowButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("42fca68d")));

    }
}
