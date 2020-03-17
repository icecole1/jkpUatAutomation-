using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Helpers;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class StaffOrderSteps
    {

        private readonly MobileNavigation _mobileNavigation;

        public StaffOrderSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }


        [When(@"I log in using staff details")]
        public void WhenILogInUsingStaffDetails()
        {
            if (!Configuration.Environment.Contains("stage"))
            {
                throw new Exception("StaffOrder test cannot be run on PreProd OR Live enviroments due to security concerns using Live data.");
            }

            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailStaff, CustomerData.PasswordStaff);
        }
        
        [Then(@"The staff toolbar is displayed")]
        public void ThenTheStaffToolbarIsDisplayed()
        {
            Assert.IsTrue(_mobileNavigation.CheckoutPage.Staff.IsDisplayed());
        }

        [When(@"Place a staff order")]
        public void WhenPlaceAStaffOrder()
        {
            _mobileNavigation.CheckoutPage.Staff.ApplyCredit.Click();

            _mobileNavigation.PaymentPage.TermsAcceptedClick()
                                         .PrivacyPolicyClick();

            _mobileNavigation.PaymentPage.PlaceYourOrder.Click();
        }
    }
}
