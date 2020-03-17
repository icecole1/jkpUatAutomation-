using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages.Panels
{
    public class Footer
    {
        private readonly WebDriverManager _webDriverManager;


        public Footer(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        public IWebElement SecurityFaq =>
            _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("footersecurityinfo"))).FindElement(By.TagName("a"));
    }
}
