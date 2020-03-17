using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class PayPalLoginOptionPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;

        public PayPalLoginOptionPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(webDriverManager.WebDriver, this);

            PayPalLoginPage = new PayPalLoginPage(_webDriverManager);
        }

        public PayPalLoginPage PayPalLoginPage { get; }

        public bool IsDisplayed()
        {
            Thread.Sleep(Configuration.MilliSecondsToWait);
            var webElements = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("singlePagePayment")));

            if (webElements.Count > 0)
            {
                return true;
            }
            return false;
        }

        public IWebElement Login => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("baslLoginButtonContainer")));
    }
}
