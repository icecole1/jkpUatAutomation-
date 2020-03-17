using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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


        public void SignInButtonClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("ui-btn-hidden")));

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .MoveToElement(webElement)
                .Perform();

            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        public IWebElement SignOutButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logoutButton")));

        public void SignOutButtonClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logoutButton")));

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .MoveToElement(webElement)
                .Perform();

            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }


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

        public bool InvalidLoginMessageIsDisplayed
        {
            get
            {
                try
                {
                    //TODO: assign id to get handle on panel webelement. 
                    var webElement = _webDriverManager.Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("error-summary")));

                    if (webElement.Count > 0)
                    {
                        return true;
                    }

                    return false;
                }
                catch
                {
                    // ignore..
                    return false;
                }
            }
        }

        public LoginPage Populate(string email, string password)
        {
            Email.SendKeys(email);
            Password.SendKeys(password);

            return this;
        }
    }
}
