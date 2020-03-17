using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;

        public OrderConfirmationPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        public IWebElement DeliveryOption => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("coPListPriceSumm")));

        public bool IsDisplayed()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("coOrderConfirmation")));

            if (webElement != null)
            {
                return true;
            }

            return false;
        }

        public string GetOrderNumber => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("OrderSummaryConfirmationNumber"))).FindElement(By.TagName("span")).Text;

        public string GetDeliveryOption => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("coPListShipping"))).Text;

        public IWebElement TotalPrice
        {
            get
            {
                var staleElement = true;
                IWebElement webElement = null;

                while (staleElement)
                {
                    try
                    {
                        //TODO: assign id to get handle on shipping web element..
                        webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("coPListTotal"))).FindElement(By.TagName("span"));

                        staleElement = false;
                    }
                    catch (StaleElementReferenceException e)
                    {
                        staleElement = true;
                    }
                }

                return webElement;
            }
        }
    }
}
