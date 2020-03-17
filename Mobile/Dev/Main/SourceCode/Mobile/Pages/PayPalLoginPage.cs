using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class PayPalLoginPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;

        public PayPalLoginPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(webDriverManager.WebDriver, this);
        }

        public bool IsDisplayed()
        {
            try
            {
                _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("login")));

                IReadOnlyCollection<IWebElement> elements = _webDriverManager.WebDriver.FindElements(By.Id("login"));

                if (elements.Count > 0)
                {
                    return elements.ElementAt(0).Displayed;
                }
            }
            catch
            {
                _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("baslLoginButtonContainer")));

                IReadOnlyCollection<IWebElement> elements = _webDriverManager.WebDriver.FindElements(By.Id("baslLoginButtonContainer"));

                if (elements.Count > 0)
                {
                    return elements.ElementAt(0).Displayed;
                }
            }

            return false;
        }

        public IWebElement LoginPanel => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("iframe[title='PayPal - Log In']")));

        public IWebElement TotalPrice => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='transactionCart']/span[2]/format-currency/span")));

        public IWebElement Email => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("email")));

        public IWebElement Password => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("password")));

        public IWebElement Login => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnLogin")));
    }
}
