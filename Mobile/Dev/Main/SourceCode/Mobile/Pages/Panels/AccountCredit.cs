using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class AccountCredit
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public AccountCredit(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        public bool IsDisplayed()
        {
            try
            {
                //TODO: assign id to get handle on panel webelement. 
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("coAccCdt")));

                if (webElement.Count > 0)
                {
                    _uiHelper.ScrollToElement(webElement.First());
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

        public IWebElement TermsAccepted => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("TermsAccepted")));

        public IWebElement PlaceOrderButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("placeOrder")));

        public IWebElement ApplyCredit => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("applyCredit")));

        public IWebElement DontApplyCredit => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("dontApplyCredit")));
    }
}
