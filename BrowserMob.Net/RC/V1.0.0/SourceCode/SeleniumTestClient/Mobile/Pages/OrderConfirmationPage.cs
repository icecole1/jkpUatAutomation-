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

        //TODO: assign id to get handle on shipping web element..
        public IWebElement OrderMessages => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("coDetailMsgBG")));

        //TODO: assign id to get handle on shipping web element..
        public IWebElement DeliveryOption => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("coPListPriceSumm")));

        //TODO: assign id to get handle on shipping web element..
        public bool IsDisplayed()
        {
            //TODO: assign id to get handle on panel webelement. 
            var webElement = _webDriverManager.Wait.Until(Configuration.Market == Enums.Market.DE
                                    ? ExpectedConditions.ElementExists(By.ClassName("noBigTick"))
                                    : ExpectedConditions.ElementExists(By.ClassName("coOrderSumRhs")));


            if (webElement != null)
            {
                return true;
            }

            return false;
        }

        //TODO: assign id to get handle on shipping web element..
        public string GetOrderNumber => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("bold"))).Text;

        //TODO: assign id to get handle on shipping web element..
        public string GetDeliveryOption => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("coPListShipping"))).Text;

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
                        webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("coPListTotal"))).FindElement(By.TagName("span"));

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
