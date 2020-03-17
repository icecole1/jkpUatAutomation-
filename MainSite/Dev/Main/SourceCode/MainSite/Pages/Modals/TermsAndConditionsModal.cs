using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages.Modals
{
    public class TermsAndConditionsModal
    {
        private readonly WebDriverManager _webDriverManager;


        public TermsAndConditionsModal (WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        public bool IsDisplayed()
        {
            try
            {
                var webElement =
                    _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("termsAndConditions")));

                if (webElement != null)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                // ignore..
                return false;
            }

        }
    }
}
