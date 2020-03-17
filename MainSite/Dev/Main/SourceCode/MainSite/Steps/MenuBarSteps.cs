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
    public class MenuBarSteps
    {
        private readonly MainSiteNavigation _mainSiteNavigation;

        public MenuBarSteps()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);
        }

        [When(@"I select the about us menu tab")]
        public void WhenISelectTheAboutUsMenuTab()
        {
            _mainSiteNavigation.GoToMenuPage(Header.Segment.AboutUs);
        }


    }

}


