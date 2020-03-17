using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class LoginMainSteps
    {
        private readonly MobileNavigation _mobileNavigation;

        public LoginMainSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I am on the customer registration page")]
        public void GivenIAmOnTheCustomerRegistrationPage()
        {
            _mobileNavigation.GoToHomePage()
                .GoToLoginPage();

            _mobileNavigation.HomePage.HeaderMenus.SignInNowButtonClick();

            _mobileNavigation.LoginPage.CreateAccount.Click();
        }

        [When(@"I complete customer registration")]
        public void WhenICompleteCustomerRegistration()
        {
            var email = DataHelper.GenerateRandomEmailAddress();
            _mobileNavigation.RegistrationPage.Populate(email, CustomerData.Password).NextClick();
        }

        [Then(@"The customer account is created")]
        public void ThenTheCustomerAccountIsCreated()
        {
            // TODO: Would be better if the new regisered user name or email was visible on page to validate against.
            var expectedUrl = string.Concat(Configuration.Environment, "/?new_user=y");
            Assert.AreEqual(expectedUrl, _mobileNavigation.WebDriverManager.WebDriver.Url);
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _mobileNavigation.GoToHomePage()
                .GoToLoginPage();
        }

        [When(@"I enter my credentials to sign in")]
        public void WhenIEnterMyCredentialsToSignIn()
        {
            Thread.Sleep(2000);
            //_mobileNavigation.HomePage.HeaderMenus.LoginButtonClick();
            _mobileNavigation.HomePage.HeaderMenus.SignInNowButtonClick();
            _mobileNavigation.LoginPage.Populate(CustomerData.EmailCreditCard, CustomerData.Password).SignInButtonClick();
        }

        [When(@"I enter my account credit credentials to sign in")]
        public void WhenIEnterMyAccountCreditCredentialsToSignIn()
        {
            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailAccountCredit, CustomerData.Password);
        }

        [Then(@"the logout option is displayed")]
        public void TheLogoutOptionIsDisplayed()
        {
            _mobileNavigation.GoToHomePage().GoToLoginPage();

            Assert.True(_mobileNavigation.HomePage.HeaderMenus.SignOutNowButton.Displayed);
        }

        [Given(@"I enter my negative account credit credentials to sign")]
        public void GivenIEnterMyNegativeAccountCreditCredentialsToSignIn()
        {
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailOpenInvoiceNeg, CustomerData.Password);
            _mobileNavigation.CheckoutPage.NextClick();
        }

        [Given(@"I enter my positive account credit credentials to sign")]
        public void GivenIEnterMyPositiveAccountCreditCredentialsToSignIn()
        {
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailOpenInvoicePos, CustomerData.Password);
            _mobileNavigation.CheckoutPage.NextClick();
        }
    }
}
