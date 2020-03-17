using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class ShoppingBag
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public ShoppingBag(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        public IWebElement IsEmpty => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("coBagEmpty")));

        public IReadOnlyCollection<IWebElement> Products
        {
            get
            {
                Thread.Sleep(3000);
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(".//*[@id='coShoppingBag']/div[1]/ul/li")));

                _uiHelper.ScrollToElement(webElement.ElementAt(0));

                return webElement;
            }
        }

        public void RemoveProduct(int productIndex)
        {
            var webElement = Products.ElementAt(productIndex).FindElement(By.ClassName("remove"));

            _uiHelper.ScrollToElement(webElement);

            webElement.Click();
        }

        public void RemoveAllProducts()
        {
            try
            {
                foreach (var product in Products)
                {
                    var webElement = product.FindElement(By.ClassName("remove"));
                    _uiHelper.ScrollToElement(webElement).Click();
                }
            }
            catch
            {
                // ignore..
            }
        }
    }
}