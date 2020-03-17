using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class SavedCard
    {
        private readonly WebDriverManager _webDriverManager;

        public SavedCard(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        public IWebElement SecurityNumber => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("CreditCard_SavedCreditCard_SecurityNumber")));

        public IWebElement Panel()
        {
            try
            {
                //TODO: assign id to get handle on panel webelement. 
                return _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("coStoredCardWrapper")));
            }
            catch
            {
                // ignored.
            }

            return null;
        }
    }
}
