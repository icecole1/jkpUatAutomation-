using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using UAT.MainSite.Automation.Data;
using UAT.MainSite.Automation.Helpers;
using UAT.MainSite.Automation.MainSite.Pages;
using UAT.MainSite.Automation.MainSite.Pages.Panels;

namespace UAT.MainSite.Automation.MainSite.Steps
{
    [Binding]
    public class PaymentSteps
    {
        private readonly MainSiteNavigation _mainSiteNavigation;

        public PaymentSteps()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I have a product in my shopping basket")]
        [When(@"I have a product in my shopping basket")]
        public void GivenIHaveAProductInMyShoppingBasket()
        {
            _mainSiteNavigation.GoToHomePage();
        }
    }
}
       




