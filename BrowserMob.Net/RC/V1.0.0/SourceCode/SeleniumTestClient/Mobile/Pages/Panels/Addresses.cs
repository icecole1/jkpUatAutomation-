using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class Addresses
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public Addresses(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);

            CollectionAddress = new CollectionAddress(_webDriverManager);
            DeliveryAddress = new DeliveryAddress(_webDriverManager);
            BillingAddress = new BillingAddress(webDriverManager);
        }

        public IWebElement ShippingAddress
        {
            get
            {
                var webElement =
                    _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("coAddShippingAddress")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public IWebElement ChangeAddress
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='deliveryBillingAddress']/div/a")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public IWebElement EnterSeperateBillingAddress
        {
            get
            {
                Thread.Sleep(3000);
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("IsBillingSameAsDeliveryFalse")));

                _uiHelper.ScrollToElement(webElement, 400);

                return webElement;
            }
        }

        public CollectionAddress CollectionAddress { get; }

        public DeliveryAddress DeliveryAddress { get; }

        public BillingAddress BillingAddress { get; }

        public IWebElement UseTheseAddresses
        {
            get
            {
                Thread.Sleep(3000);
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("finishedDelivery")));

                _uiHelper.ScrollToElement(webElement, 200);

                return webElement;
            }
        }
    }
}
