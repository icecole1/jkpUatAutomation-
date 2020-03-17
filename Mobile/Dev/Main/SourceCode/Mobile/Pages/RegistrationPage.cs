using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class RegistrationPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public static string NewAccountName { get; private set; }

        public RegistrationPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        public IWebElement Title => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("title")));

        public IWebElement FirstName => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("firstName")));

        public IWebElement LastName => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("lastName")));

        public IWebElement ConfirmAge => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ageConfirmed")));

        //TODO: assign an id to get a handle on the DOBDay web elements.
        public SelectElement DOBDay => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("DOBDay"))));

        //TODO: assign an id to get a handle on the DOBMonth web elements.
        public SelectElement DOBMonth => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("DOBMonth"))));

        //TODO: assign an id to get a handle on the DOBYear web elements.
        public SelectElement DOBYear => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("DOBYear"))));

        public IWebElement EmailAddress => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("email")));

        public IWebElement Password => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("password")));

        public IWebElement ConfirmPassword => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("confirmPassword")));

        public void NextClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("next")));
            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        public RegistrationPage Populate(string email, string password)
        {
            var title = new SelectElement(Title);
            title.SelectByValue(CustomerData.TitleMr);

            NewAccountName = string.Concat(CustomerData.FirstName, Environment.MachineName);
            FirstName.SendKeys(NewAccountName);

            LastName.SendKeys(CustomerData.LastName);

            ConfirmAge.Click();

            DOBDay.SelectByValue(CustomerData.DOBDay);
            DOBMonth.SelectByValue(CustomerData.DOBMonth);
            DOBYear.SelectByValue(CustomerData.DOBYear);

            EmailAddress.SendKeys(email);

            Password.SendKeys(CustomerData.Password);
            ConfirmPassword.SendKeys(CustomerData.Password);

            return this;
        }
    }
}
