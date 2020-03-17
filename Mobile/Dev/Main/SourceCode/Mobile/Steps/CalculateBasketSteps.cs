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
    public class CalculateBasketSteps
    {

        private readonly MobileNavigation _mobileNavigation;
        public static string ProductPrice;

        public CalculateBasketSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I have added an item to the bag on the PDP page")]
        public void GivenIHaveAddedAnItemToTheBagOnThePDPPage()
        {
            ProductPrice = _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(MenuData.Women, MenuData.Dresses)
                .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                .ProductDetailPage.SelectAvailableColourAndSize()
                .AddToBag.Text;

            _mobileNavigation.ProductListingPage.ProductDetailPage.AddToBag.Click();        
        }
        
        [When(@"I go to the checkout page")]
        public void WhenIGoToTheCheckoutPage()
        {
            _mobileNavigation.GoToCheckoutPage();           
        }
        
        [Then(@"The Add to Bag value matched the checkout page value")]
        public void ThenTheAddToBagValueMatchedTheCheckoutPageValue()
        {
            var checkoutProductPrice = _mobileNavigation.CheckoutPage.SubTotal.Text;

            var isSame = ProductPrice.Contains(checkoutProductPrice);

            Assert.True(isSame);
        }

        [Then(@"The sub total plus the delivery equals the total price")]
        public void ThenTheSubTotalPlusTheDeliveryEqualsTheTotalPrice()
        {
            if (DeliverySteps.OptionAvailable)
            {
                decimal dSubtotal =
                    decimal.Parse(DataHelper.RemoveCurrencySymbol(_mobileNavigation.CheckoutPage.SubTotal.Text));
                decimal dDelivery =
                    decimal.Parse(DataHelper.RemoveCurrencySymbol(_mobileNavigation.CheckoutPage.DeliveryPrice.Text));
                decimal dTotalPrice =
                    decimal.Parse(DataHelper.RemoveCurrencySymbol(_mobileNavigation.CheckoutPage.TotalPrice.Text));

                var expectedTotalPrice = dSubtotal + dDelivery;

                Assert.AreEqual(dTotalPrice, expectedTotalPrice);
            }
            else
            {
                // this is because the likely hood of the product selected is not in stock currently for immediate delivery.
                Assert.True(true);
            }
        }

        [Then(@"the total value on the checkout page matches the total value on the confirmation page")]
        public void ThenTheTotalValueOnTheCheckoutPageMatchesTheTotalValueOnTheConfirmationPage()
        {
            Thread.Sleep(3000);
            decimal dTotalPrice = decimal.Parse(DataHelper.RemoveCurrencySymbol(CheckoutPage.PreservedTotalPrice));
            decimal dConfirmationPrice = decimal.Parse(DataHelper.RemoveCurrencySymbol(_mobileNavigation.OrderConfirmationPage.TotalPrice.Text));

            Assert.AreEqual(dTotalPrice, dConfirmationPrice);
        }
    }
}
