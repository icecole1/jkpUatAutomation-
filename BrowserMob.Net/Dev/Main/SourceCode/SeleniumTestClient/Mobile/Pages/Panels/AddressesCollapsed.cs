using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class AddressesCollapsed
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public AddressesCollapsed(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        //public bool IsDisplayed(int scrollOffset)
        //{
        //    var elements = new List<IWebElement>
        //    {
        //        _webDriverManager.WebDriver.FindElement(By.ClassName("deliveryBillingAddress"))
        //    };

        //    if (elements.Count > 0)
        //    {
        //        _uiHelper.ScrollToElement(elements.First(), scrollOffset);

        //        return true;
        //    }
        //    return false;
        //}

        //TODO: assign id to get handle on panel webelement. 
        public IWebElement BillingAddress
            => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("pFBilling")));

        //TODO: assign id to get handle on panel webelement. 
        public IWebElement DeliveryAddress
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("pFShipping")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        //TODO: assign id to get handle on panel webelement. 
        public IWebElement CollectionAddress
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("pFShipping")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }
    }
}
