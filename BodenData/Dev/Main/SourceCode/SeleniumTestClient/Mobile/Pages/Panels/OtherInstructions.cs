using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class OtherInstructions
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public OtherInstructions(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        // TODO: assign id to get handle on webelement.
        public IWebElement HasOtherInstructions
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("coOtherInstrBx")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public IWebElement OtherInstructionsText
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("OtherInstructions")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        // TODO: assign id to get handle on webelement.
        public IWebElement Save
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("saveInstructions")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

    }
}
