using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Modals
{
    public class HemmingModal
    {
        private readonly WebDriverManager _webDriverManager;

        public HemmingModal(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        public bool IsDisplayed()
        {
            //TODO: assign id to get handle on panel webelement. 
            var elements = new List<IWebElement>
            {
                _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("pdpHemmingContainer")))
            };

            if (elements.Count > 0)
            {
                return elements.ElementAt(0).Displayed;
            }
            return false;
        }

        //TODO: assign an id to get a handle on the HemmingOption web elements.
        public SelectElement LegLength => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='JEA']/label/select"))));


        //TODO: assign id to get handle on panel webelement. 
        public void UpdateClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("pdpHemmingModal_AddToBagButton")));
            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        public void SelectOption(Enums.HemmingOption hemmingOption)
        {
            var options = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Name("H")));

            if (hemmingOption == Enums.HemmingOption.NoThanks)
            {
                options.First(x => x.GetAttribute("value") == "").Click();
            }
            else
            {
                options.First(x => x.GetAttribute("value") == hemmingOption.ToString()).Click();  
            }
        }
    }
}
