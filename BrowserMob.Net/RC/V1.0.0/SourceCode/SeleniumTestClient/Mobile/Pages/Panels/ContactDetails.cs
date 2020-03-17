using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class ContactDetails
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public ContactDetails(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        public IWebElement CustomerTitle => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("CustomerTitle")));

        public IWebElement FirstName => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("FirstName")));

        public IWebElement LastName => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("LastName")));

        public IWebElement Email => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Email")));

        public IWebElement PhoneNumber => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("PhoneNumber")));

        public IWebElement Next => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("finishedContact")));

        public IWebElement Password => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Password")));

        public IWebElement DontWishToShare
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='contactDetails']/div/form/fieldset/div/label[6]/div[1]/label")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        } 

        public IWebElement AgeOfConsentYes => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AgeOfConsentBlockCheckBox']/div[1]/label")));

        public IWebElement AgeOfConsentNo => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AgeOfConsentBlockCheckBox']/div[3]/label")));

        public bool AreContactDetailsEmpty()
        {
            var isEmpty = !CustomerTitle.Selected;

            if (isEmpty)
                return true;

            isEmpty = FirstName.Text.Length == 0;
            if (isEmpty)
                return true;

            isEmpty = LastName.Text.Length == 0;
            if (isEmpty)
                return true;

            isEmpty = Email.Text.Length == 0;
            if (isEmpty)
                return true;

            isEmpty = PhoneNumber.Text.Length == 0;
            if (isEmpty)
                return true;

            return false;
        }

        public void Populate()
        {
            if (Configuration.Market == Enums.Market.DE)
            {
                FirstName.SendKeys(CustomerData.FirstName);
                LastName.SendKeys(CustomerData.LastName);
                Email.SendKeys(DataHelper.GenerateRandomEmailAddress());
                Password.SendKeys(CustomerData.Password);
                PhoneNumber.SendKeys(CustomerData.PhoneNumber);

                DontWishToShare.Click();
                AgeOfConsentYes.Click();
            }
            else
            {
                FirstName.SendKeys(CustomerData.FirstName);
                LastName.SendKeys(CustomerData.LastName);
                Email.SendKeys(CustomerData.EmailCreditCard);
                PhoneNumber.SendKeys(CustomerData.PhoneNumber);
            }
        }
    }
}