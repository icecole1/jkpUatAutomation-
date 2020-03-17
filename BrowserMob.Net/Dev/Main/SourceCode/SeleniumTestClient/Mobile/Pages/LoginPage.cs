using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class LoginPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;

        public LoginPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(webDriverManager.WebDriver, this);
        }

        public IWebElement Email => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("email")));

        public IWebElement Password => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("passwd")));

        //TODO: assign id to get handle on panel webelement. 
        public IWebElement SignIn => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("ui-btn-hidden")));

        public IWebElement LogoutButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logoutButton")));

        public void Logout()
        {
            //TODO: assign id to get handle on panel webelement. 
            var elements = new List<IWebElement>
            {
                _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("logoutButton")))
            };

            if (elements.Count > 0)
            {
                elements.ElementAt(0).Click();
            }
        }

        public IWebElement CreateAccount => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("createAccount")));

        public LoginPage Populate(string email, string password)
        {
            Email.SendKeys(email);
            Password.SendKeys(password);

            return this;
        }
    }
}
