using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.MainSite.Automation.Helpers;
using UAT.MainSite.Automation.MainSite.Pages.Panels;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages
{
   public class OurWorkPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private object get;
        private readonly UIHelper _uiHelper;

        public OurWorkPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            PageFactory.InitElements(webDriverManager.WebDriver, this);
            _webDriverManager = webDriverManager;
            _uiHelper = new UIHelper(_webDriverManager.WebDriver);

        }

        public IWebElement OurWorkTitle => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\'content\']/article/div/div/div/div/section[1]/div/div/div/div/div/div[2]/div/h2")));
    }
}
