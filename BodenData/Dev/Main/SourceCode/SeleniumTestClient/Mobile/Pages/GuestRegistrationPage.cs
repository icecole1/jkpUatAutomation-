using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class GuestRegistrationPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        public static bool IsGuestCheckout;

        public GuestRegistrationPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(webDriverManager.WebDriver, this);
        }

        //TODO: assign id to get handle on panel webelement. 
        public IWebElement TakeMeToOrderSummary
            => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("./html/body/div[1]/div[2]/div/div[1]/div/div[2]/a")));

        public SelectElement DOBDay => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("DateOfBirth_Day"))));

        public SelectElement DOBMonth => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("DateOfBirth_Month"))));

        public IWebElement DOBYear => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("DateOfBirth_Year")));

        public IWebElement SavePreferences => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("coSavePreferences")));
    }
}
