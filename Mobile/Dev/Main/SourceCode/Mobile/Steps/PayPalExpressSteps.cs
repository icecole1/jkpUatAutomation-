using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages;
using UAT.Mobile.Automation.Mobile.Pages.Panels;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class PayPalExpressSteps
    {
        private readonly MobileNavigation _mobileNavigation;

        public PayPalExpressSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I am on the checkout page with a product in the basket")]
        public void GivenIAmOnTheCheckoutPageWithAProductInTheBasket()
        {
            _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(MenuData.Women, MenuData.Dresses)
                .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                .ProductDetailPage.SelectAvailableColourAndSize();

            _mobileNavigation.ProductDetailPage.AddToBag.Click();

            _mobileNavigation.GoToCheckoutPage();

            CheckoutPage.PreservedTotalPrice = _mobileNavigation.CheckoutPage.TotalPrice.Text;

            _mobileNavigation.CheckoutPage.NextClick();
        }
        
        [When(@"I click on PayPal Express")]
        public void WhenIClickOnPayPalExpress()
        {
            _mobileNavigation.CheckoutPage.PayPal.Click();
        }
        
        [Then(@"the price on the checkout page matches the price on the Paylap Login Screen")]
        public void ThenThePriceOnTheCheckoutPageMatchesThePriceOnThePaylapLoginScreen()
        {
            Thread.Sleep(Configuration.MilliSecondsToWait);

            decimal checkoutTotalPrice = decimal.Parse(DataHelper.RemoveCurrencySymbol(CheckoutPage.PreservedTotalPrice));
            decimal paypalTotalPrice = decimal.Parse(DataHelper.RemoveCurrencySymbol(_mobileNavigation.PayPalLoginPage.TotalPrice.Text));

            Assert.AreEqual(checkoutTotalPrice, paypalTotalPrice);
        }

        [Given(@"I am on PayPal login page")]
        public void GivenIAmOnPayPalLoginPage()
        {
            GivenIAmOnTheCheckoutPageWithAProductInTheBasket();
            WhenIClickOnPayPalExpress();
        }

        [When(@"I log into PayPal")]
        public void WhenILogIntoPayPal()
        {
            if (_mobileNavigation.PayPalLoginOptionPage.PayPalLoginPage.IsDisplayed())
            {
                _mobileNavigation.WebDriverManager.WebDriver.SwitchTo().Frame(_mobileNavigation.PayPalLoginPage.LoginPanel);

                _mobileNavigation.PayPalLoginOptionPage.PayPalLoginPage.Email.SendKeys(PayPal.TEMPLIVEEmail);
                _mobileNavigation.PayPalLoginOptionPage.PayPalLoginPage.Password.SendKeys(PayPal.TEMPLIVEPassword);
                _mobileNavigation.PayPalLoginOptionPage.PayPalLoginPage.Login.Click();
            }
        }

        [Then(@"the Price on the login page matches the price on the PayPal checkout page")]
        public void ThenThePriceOnTheLoginPageMatchesThePriceOnThePayPalCheckoutPage()
        {
            Thread.Sleep(Configuration.MilliSecondsToWait);
            //_mobileNavigation.WebDriverManager.WebDriver.Navigate().Refresh();

            decimal checkoutTotalPrice = decimal.Parse(DataHelper.RemoveCurrencySymbol(CheckoutPage.PreservedTotalPrice));
            decimal paypalTotalPrice = decimal.Parse(DataHelper.RemoveCurrencySymbol(_mobileNavigation.PayPalLoginPage.TotalPrice.Text));

            Assert.AreEqual(checkoutTotalPrice, paypalTotalPrice);
        }
    }
}
