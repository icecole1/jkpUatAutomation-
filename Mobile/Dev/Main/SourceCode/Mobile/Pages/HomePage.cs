using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class HomePage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;

        public HomePage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(webDriverManager.WebDriver, this);
        }

        public IWebElement AdobeTargetTag => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//script[contains(@src, 'bundles/adobetarget.js')]")));
    }
}
