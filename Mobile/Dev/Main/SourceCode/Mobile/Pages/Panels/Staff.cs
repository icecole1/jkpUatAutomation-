using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class Staff
    {

        private readonly WebDriverManager _webDriverManager;
        
        public Staff (WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

        }
        public IWebElement ApplyCredit => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("applyCredit")));

        public bool IsDisplayed()
        {
            try
            {
                var webElement =
                    _webDriverManager.Wait.Until(
                        ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("stafftoolbar")));

                if (webElement.Count > 0)
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
