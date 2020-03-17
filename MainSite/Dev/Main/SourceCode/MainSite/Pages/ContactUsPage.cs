using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages
{
    public class ContactUsPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private object get;

        public ContactUsPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            PageFactory.InitElements(webDriverManager.WebDriver, this);
            _webDriverManager = webDriverManager;

        }


        public IWebElement ContactUsPageTitle => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\'content\']/article/div/div/div/div/section[1]/div/div/div/div/div/div[1]/div/h2[2]")));

    }
}
