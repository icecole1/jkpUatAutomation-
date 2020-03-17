using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Mobile.Pages.Panels;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages.Modals;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class ProductDetailPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public ProductDetailPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {

            _webDriverManager = webDriverManager;
            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            CheckoutNotification = new CheckoutNotification(_webDriverManager);
            HemmingModal = new HemmingModal(_webDriverManager);
        }

        public CheckoutNotification CheckoutNotification { get; set; }

        public HemmingModal HemmingModal { get; set; }

        //TODO: assign an id to get a handle on the addtobag web elements.
        public IWebElement AddToBag => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("pdpAddToBagButton")));
        
        public List<IWebElement> Colours()
        {
            try
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("pdpSCBoxes")));
                _uiHelper.ScrollToElement(webElement, -100);

                //TODO: assign an id to get a handle on the colours list web elements.
                return _webDriverManager.WebDriver.FindElements(By.XPath("//*[@id='pm-addToBagMain']/form/div[1]/div[1]/div[2]/ul/li[not(contains(@class, 'notAvailable'))]")).ToList();

            }
            catch (WebDriverTimeoutException e)
            {
                // ignore...
                return null;
            }
       }

        public List<IWebElement> SizeTypes()
        {
            try
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("pdpSizeTypeChart")));
                _uiHelper.ScrollToElement(webElement, -100);

                //TODO: assign an id to get a handle on the sizetypes list web elements.
                return _webDriverManager.WebDriver.FindElements(By.XPath(".//*[@id='pm-addToBagMain']/form/div[1]/div[3]/div[2]/ul/li[not(contains(@class, 'notAvailable'))]")).ToList();

            }
            catch (WebDriverTimeoutException e)
            {
                // ignore...
                return null;
            }
        }

        public List<IWebElement> Sizes()
        {
            try
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("pdpSizeChart")));
                _uiHelper.ScrollToElement(webElement, -100);

                if (SizeTypes()?.Count > 0)
                {
                    //TODO: assign an id to get a handle on the sizes list web elements.
                    return _webDriverManager.WebDriver.FindElements(By.XPath(".//*[@id='pm-addToBagMain']/form/div[1]/div[3]/div[3]/ul/li[not(contains(@class, 'notAvailable'))]")).ToList();
                }

                //TODO: assign an id to get a handle on the sizes list web elements.
                return _webDriverManager.WebDriver.FindElements(By.XPath(".//*[@id='pm-addToBagMain']/form/div[1]/div[3]/div[2]/ul/li[not(contains(@class, 'notAvailable'))]")).ToList();
            }
            catch (WebDriverTimeoutException e)
            {
                // ignore...
                return null;
            }
        }

        public List<IWebElement> CardValue()
        {
            try
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("pdpSizeChart")));
                _uiHelper.ScrollToElement(webElement.ElementAt(0), -100);

                //TODO: assign an id to get a handle on the sizes list web elements.
                return _webDriverManager.WebDriver.FindElements(By.XPath(".//*[@id='pm-addToBagMain']/form/div[1]/div[3]/div[2]/ul/li[not(contains(@class, 'notAvailable'))]")).ToList();
            }
            catch (WebDriverTimeoutException e)
            {
                // ignore...
                return null;
            }
        }

        public ProductDetailPage SelectAvailableColourAndSize()
        {
            Thread.Sleep(2000);

            if (Colours()?.Count > 0)
            {
                Colours().First().Click();
            }

            if (SizeTypes()?.Count > 0)
            {
                SizeTypes().First().Click();
            }

            if (Sizes()?.Count > 0)
            {
                Sizes().First().Click();
            }

            return this;
        }

        public ProductDetailPage SelectAvailableCardValue()
        {
            if (Sizes()?.Count > 0)
            {
                Sizes().First().Click();
            }

            return this;
        }

        public ProductDetailPage SelectGiftCardValue(Enums.Market market, int cardValue)
        {
            if (Configuration.Market == market)
            {
                var cardValueIndex = DataHelper.GetGiftCardIndex(cardValue, market);

                CardValue()[cardValueIndex].Click();
            }

            return this;
        }
    }
}
