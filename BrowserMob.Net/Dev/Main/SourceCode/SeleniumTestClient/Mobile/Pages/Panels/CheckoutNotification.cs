using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class CheckoutNotification
    {
        private readonly WebDriverManager _webDriverManager;

        public CheckoutNotification(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        public bool IsDisplayed()
        {
            try
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("pm-addedToBag")));

                if (webElement != null)
                {
                    var style = webElement.GetAttribute("style");
                    var displayed = !style.Contains("top: -217px");

                    return displayed;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        //public void WaitUntilNotDisplayed()
        //{
        //    var hidden =
        //        _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("pm-addedToBag")))
        //            .GetAttribute("style")
        //            .Contains("top: -217px");
        //}

        //TODO: assign an id to get a handle on the image webelement.UAT.Automation.
        public IWebElement GotoCheckout => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("pdpATBGoCO")));
    }
}
