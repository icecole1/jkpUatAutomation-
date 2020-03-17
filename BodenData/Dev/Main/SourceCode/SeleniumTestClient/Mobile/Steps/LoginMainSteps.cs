using NUnit.Framework;
using TechTalk.SpecFlow;
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
                .GoToLoginPage()
                .LoginPage.CreateAccount.Click();
        }

        [When(@"I complete customer registration")]
        public void WhenICompleteCustomerRegistration()
        {
            _mobileNavigation.RegistrationPage.Populate().Next.Click();
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
            _mobileNavigation.LoginPage.Populate(CustomerData.EmailCreditCard, CustomerData.Password).SignIn.Click();
        }

        [When(@"I enter my account credit credentials to sign in")]
        public void WhenIEnterMyAccountCreditCredentialsToSignIn()
        {
            _mobileNavigation.CheckoutPage.Next.Click();
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailAccountCredit, CustomerData.Password);
        }

        [Then(@"the logout option is displayed")]
        public void TheLogoutOptionIsDisplayed()
        {
            _mobileNavigation.GoToHomePage().GoToLoginPage();

            Assert.True(_mobileNavigation.LoginPage.LogoutButton.Displayed);
        }

    }
}
