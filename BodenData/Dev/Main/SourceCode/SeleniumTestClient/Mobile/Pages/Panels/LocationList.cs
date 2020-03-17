using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class LocationList
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public LocationList(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        public bool IsDisplayed()
        {
            var elements = new List<IWebElement>
            {
                //TODO: assign id to get handle on panel webelement. 
                _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("locationList")))
            };

            if (elements.Count > 0)
            {
                return elements.ElementAt(0).Displayed;
            }
            return false;
        }

        private IReadOnlyCollection<IWebElement> ResultSelects
            => _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(".//*[@id='clickAndCollect']/div[3]/.//div[contains(@class, 'coCACPinLabel')]")));

        public IWebElement SelectLocation => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("coCACLocationOptionBtn")));
        
        public IWebElement SelectedLocationName { get; private set; }

        public IWebElement SelectedAddressLine1 { get; private set; }

        public IWebElement SelectedAddressLine2 { get; private set; }

        public LocationList ExpandLocation(Enums.Location location)
        {
            var locationIndex = (int) location;

            var webElement = ResultSelects.ElementAt(locationIndex);

            webElement.Click();

            var parentElement = GetParentResultElement();

            SelectedLocationName = parentElement.FindElement(By.ClassName("coCACLocationName"));
            SelectedAddressLine1 = parentElement.FindElement(By.ClassName("coCACAddressLine1"));
            SelectedAddressLine2 = parentElement.FindElement(By.ClassName("coCACLocationDistance"));

            return this;
        }

        private IWebElement GetParentResultElement()
        {
            var selectWebElements = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("coCACLocationOptionBtn")));

            return selectWebElements.FindElement(By.XPath("../../../.."));
        }
    }
}
