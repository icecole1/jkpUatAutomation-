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

        public RegistrationPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        public IWebElement Title => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("title")));

        public IWebElement FirstName => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("firstName")));

        public IWebElement LastName => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("lastName")));

        //TODO: assign an id to get a handle on the DOBDay web elements.
        public SelectElement DOBDay => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("DOBDay"))));

        //TODO: assign an id to get a handle on the DOBMonth web elements.
        public SelectElement DOBMonth => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("DOBMonth"))));

        //TODO: assign an id to get a handle on the DOBYear web elements.
        public SelectElement DOBYear => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("DOBYear"))));

        public IWebElement EmailAddress => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("email")));

        public IWebElement Password => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("password")));

        public IWebElement Next
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("next")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public RegistrationPage Populate()
        {
            var title = new SelectElement(Title);
            title.SelectByValue(CustomerData.TitleMr);

            FirstName.SendKeys(CustomerData.FirstName);

            LastName.SendKeys(CustomerData.LastName);

            DOBDay.SelectByValue(CustomerData.DOBDay);
            DOBMonth.SelectByValue(CustomerData.DOBMonth);
            DOBYear.SelectByValue(CustomerData.DOBYear);

            EmailAddress.SendKeys(DataHelper.GenerateRandomEmailAddress());

            Password.SendKeys(CustomerData.Password);

            return this;
        }
    }
}
