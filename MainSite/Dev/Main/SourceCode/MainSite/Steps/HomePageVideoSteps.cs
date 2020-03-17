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
    public class HomePageVideoSteps
    {
        private readonly MainSiteNavigation _mainSiteNavigation;

        public HomePageVideoSteps()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);
           

        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _mainSiteNavigation.GoToHomePage();
        }

        [When(@"I play the home page video")]
        public void WhenIPlayTheHomePageVideo()
        {
          
            _mainSiteNavigation.HomePage.PlayButtonClick();
        }

        [Then(@"the progress bar time is greater than (.*)")]
        public void ThenTheProgressBarTimeIsGreaterThan(int p0)
        {
            string progressBarValue = _mainSiteNavigation.HomePage.ProgressBarValue.Text;

            Thread.Sleep(20000);

            Assert.AreNotEqual(p0,progressBarValue); 
        }

        [When(@"I select the share video button")]
        public void WhenISelectTheShareVideoButton()
        {
            _mainSiteNavigation.HomePage.ShareButtonClick();
        }

        [Then(@"The share content panel is displayed")]
        public void ThenTheShareContentPanelIsDisplayed()
        {
            var isDisplayed = _mainSiteNavigation.HomePage.SharePannelIsDisplayed();

            Assert.True(isDisplayed);
        }

        [When(@"I select full screen")]
        public void WhenISelectFullScreen()
        {
            _mainSiteNavigation.HomePage.PlayInFullScreenButton();
        }

        [Then(@"the exit full screen  button is displayed")]
        public void ThenTheExitFullScreenButtonIsDisplayed()
        {

          
          Assert.IsTrue(_mainSiteNavigation.HomePage.ExitFullScreen.Contains("Exit full screen")); 


           
        }







    }
}


    