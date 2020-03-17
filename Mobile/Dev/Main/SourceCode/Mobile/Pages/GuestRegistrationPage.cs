using System;
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

        public bool IsDisplayed()
        {
            try
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("registerPage")));

                return webElement.Count > 0;
            }
            catch
            {
                // ignore...
                return false;
            }
        }

        //TODO: assign id to get handle on panel webelement. 
        public IWebElement TakeMeToOrderSummary
            => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("./html/body/div[1]/div[3]/div/div[1]/div/div[2]/a")));

        public SelectElement DOBDay => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("DateOfBirth_Day"))));

        public SelectElement DOBMonth => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("DateOfBirth_Month"))));

        public IWebElement DOBYear => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("DateOfBirth_Year")));

        public IWebElement SavePreferences => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("coSavePreferences")));

        public IWebElement RegisterMeNow => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("coRegisterRequest")));

        public IWebElement Email => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));

        public IWebElement Password => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Password")));
    }
}
