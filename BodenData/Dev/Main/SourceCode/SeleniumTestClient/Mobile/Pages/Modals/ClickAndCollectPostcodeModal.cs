using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Mobile.Pages.Panels;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Modals
{
    public class ClickAndCollectPostcodeModal
    {
        private readonly WebDriverManager _webDriverManager;

        public ClickAndCollectPostcodeModal(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            LocationList = new LocationList(_webDriverManager);
        }

        public LocationList LocationList { get; }

        public bool IsDisplayed()
        {
            var elements = new List<IWebElement>
            {
                _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("clickAndCollect")))
            };

            if (elements.Count > 0)
            {
                return elements.ElementAt(0).Displayed;
            }
            return false;
        }

        public IWebElement Postcode
            => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("location")));

        public IWebElement Search
            => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cacSearch")));

    }
}
