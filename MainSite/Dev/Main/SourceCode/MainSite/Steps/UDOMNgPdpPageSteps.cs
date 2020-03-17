using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using UAT.MainSite.Automation.Data;
using UAT.MainSite.Automation.Helpers;
using UAT.MainSite.Automation.MainSite.Pages;
using UAT.MainSite.Automation.MainSite.Pages.Panels;

namespace UAT.MainSite.Automation.MainSite.Steps
{
    [Binding]
    public class UDOMNgPdpPageSteps
    {

        private readonly MainSiteNavigation _mainSiteNavigation;

        public UDOMNgPdpPageSteps()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);


        }

        [Then(@"I am taken to the UDOMNG pdp page")]
        public void ThenIAmTakenToTheUDOMNGPdpPage()
        {
            var outerWrapperDisplayed = _mainSiteNavigation.UdomNgPdpPage.OuterWrapper.Displayed;
        }


        [Then(@"the buy now button is displayed")]
        public void ThenTheBuyNowButtonIsDisplayed()
        {
            var outerWrapperDisplayed = _mainSiteNavigation.UdomNgPdpPage.BuyNowButton.Displayed;
        }



    }
}
