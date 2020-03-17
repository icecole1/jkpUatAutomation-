using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class CollectionAddress
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public CollectionAddress(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        public IWebElement Name
        {
            get
            {
                IWebElement webElement;

                if (Configuration.Market == Enums.Market.DE)
                {
                    webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='AddressManualMain']/div[2]/div[1]/b")));
                }
                else
                {
                    webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='AddressManualMain']/div[1]/div[1]/b")));
                }

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public IWebElement MobileNumber
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("ClickAndCollectAddress_MobileNo")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public IWebElement PostNumber
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("ClickAndCollectAddress_TanCode")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public IWebElement AddressLine1
        {
            get
            {
                IWebElement webElement;

                if (Configuration.Market == Enums.Market.DE)
                {
                    webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='AddressManualMain']/div[2]/div[2]")));
                }
                else
                {
                    webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='AddressManualMain']/div[1]/div[2]")));
                }

                return webElement;
            }
        }

        public IWebElement AddressLine2
        {
            get
            {
                IWebElement webElement;

                if (Configuration.Market == Enums.Market.DE)
                {
                    webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='AddressManualMain']/div[2]/div[3]")));
                }
                else
                {
                    webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='AddressManualMain']/div[1]/div[3]")));
                }

                return webElement;
            }
        }

    }
}
