using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages;
using UAT.Mobile.Automation.Mobile.Pages.Panels;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class PaymentSteps
    {
        private readonly MobileNavigation _mobileNavigation;

        public PaymentSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I have a product in my shopping basket")]
        public void GivenIHaveAProductInMyShoppingBasket()
        {
            _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(HeaderMenu.Segment.Womens, HeaderMenu.SegmentCategoryWomens.Dresses)
                .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                .ProductDetailPage.SelectAvailableColourAndSize()
                .AddToBag.Click();
        }

        [When(@"I place an order as a registered customer")]
        public void WhenIPlaceAnOrderAsARegisteredCustomer()
        {
            _mobileNavigation.GoToCheckoutPage();

            _mobileNavigation.CheckoutPage.DeliveryOption.Next.Click();

            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

            _mobileNavigation.CheckoutPage.Next.Click();

            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PlaceYourOrder.Click();
        }

        [When(@"I place an order as a guest customer")]
        public void WhenIPlaceAnOrderAsAGuestCustomer()
        {
            _mobileNavigation.GoToCheckoutPage();

            _mobileNavigation.CheckoutPage.DeliveryOption.Next.Click();

            _mobileNavigation.CheckoutPage.Guest.Click();

            _mobileNavigation.CheckoutPage.DeliveryOption.Next.Click();

            _mobileNavigation.CheckoutPage.ContactDetails.Populate();
            _mobileNavigation.CheckoutPage.ContactDetails.Next.Click();

            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Country.SelectByValue(CountryCode.UnitedKingdom);
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.PopulatePostcodeLookup();
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookUpAddress.Click();
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookupResult.SelectByIndex(0);
                    break;
                case Enums.Market.DE:
                    _mobileNavigation.CheckoutPage.Addresses.BillingAddress.Populate();
                    _mobileNavigation.CheckoutPage.Addresses.UseTheseAddresses.Click();
                    break;
                default:
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Populate();
                    break;
            }

            _mobileNavigation.CheckoutPage.Addresses.UseTheseAddresses.Click();

            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PlaceYourOrder.Click();
        }

        [When(@"I log into checkout with (.*) and (.*)")]
        public void WhenILogIntoCheckoutWithAnd(string email, string password)
        {
            _mobileNavigation.CheckoutPage.Next.Click();
            _mobileNavigation.CheckoutPage.Login(email, password);
            _mobileNavigation.CheckoutPage.Next.Click();
        }

        [Then(@"The account credit panel is displayed")]
        public void ThenTheAccountCreditPanelIsDisplayed()
        {
            var isDisplayed = _mobileNavigation.CheckoutPage.Payment.AccountCredit.IsDisplayed();

            Assert.True(isDisplayed);
        }

        [When(@"I click apply account credit to this order")]
        public void WhenIClickApplyAccountCreditToThisOrder()
        {
            _mobileNavigation.CheckoutPage.Next.Click();
            _mobileNavigation.CheckoutPage.Payment.AccountCredit.ApplyCredit.Click();
            _mobileNavigation.CheckoutPage.Payment.TermsAcceptedClick();
        }

        [When(@"I click place order using account credit")]
        public void WhenIClickPlaceOrderUsingAccountCredit()
        {
            _mobileNavigation.CheckoutPage.Payment.PlaceYourOrder.Click();
        }

        [Given(@"I am on the (.*) checkout page and have 1 or more items in my basket")]
        public void GivenIAmOnTheUKCheckoutPageAndHaveOrMoreItemsInMyBasket(string market)
        {
            var _market = (Enums.Market) Enum.Parse(typeof(Enums.Market), market);

            if (Configuration.Market == _market)
            {
                _mobileNavigation.GoToHomePage().GoToProductListingPage(HeaderMenu.Segment.Womens, HeaderMenu.SegmentCategoryWomens.Dresses)
                    .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                    .ProductDetailPage.SelectAvailableColourAndSize()
                    .AddToBag.Click();

                _mobileNavigation.GoToCheckoutPage();
            }
        }

        [When(@"I place an order with (.*) gift voucher")]
        public void WhenIPlaceAnOrderWithGiftVoucher(string giftVoucher)
        {
            _mobileNavigation.CheckoutPage.Next.Click();
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);
            _mobileNavigation.CheckoutPage.Next.Click();

            _mobileNavigation.CheckoutPage.Payment.ApplyGiftVoucher.Click();
            _mobileNavigation.CheckoutPage.Payment.GiftVoucher.Number.SendKeys(giftVoucher);
            _mobileNavigation.CheckoutPage.Payment.GiftVoucher.Add.Click();

            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card);
            _mobileNavigation.PaymentPage.TermsAcceptedClick()
                .PlaceYourOrder.Click();
        }

        [Then(@"I am taken to the order confirmation page")]
        public void ThenIAmTakenToTheOrderConfirmationPage()
        {
            var orderConfirmationDisplayed = _mobileNavigation.OrderConfirmationPage.IsDisplayed();

            Assert.True(orderConfirmationDisplayed);
        }

        [When(@"I add a (.*)")]
        public void WhenIAddAGiftVoucher(string giftVoucher)
        {
            _mobileNavigation.CheckoutPage.Next.Click();
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);
            _mobileNavigation.CheckoutPage.Next.Click();

            _mobileNavigation.CheckoutPage.Payment.ApplyGiftVoucher.Click();
            _mobileNavigation.CheckoutPage.Payment.GiftVoucher.Number.SendKeys(giftVoucher);
            _mobileNavigation.CheckoutPage.Payment.GiftVoucher.Add.Click();
        }

        [When(@"place an order with a valid credit card")]
        public void WhenPlaceAnOrderWithAValidCreditCard()
        {
            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card);
            _mobileNavigation.PaymentPage.TermsAcceptedClick()
                .PlaceYourOrder.Click();
        }

        [Given(@"I am on the checkout page with 1 or more product\(s\) in my basket")]
        public void GivenIAmOnTheCheckoutPageWithOrMoreProductSInMyBasket()
        {
            GivenIHaveAProductInMyShoppingBasket();
            
            _mobileNavigation.GoToCheckoutPage();
        }

        [When(@"I place an order with valid offer code")]
        public void WhenIPlaceAnOrderWithValidOfferCode()
        {
            CheckoutPage.PreservedTotalPrice = _mobileNavigation.CheckoutPage.TotalPrice.Text;

            _mobileNavigation.CheckoutPage.OfferCode.SendKeys(CustomerData.OfferCode);
            _mobileNavigation.CheckoutPage.ApplyCode.Click();

            _mobileNavigation.CheckoutPage.Next.Click();

            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

            _mobileNavigation.CheckoutPage.Next.Click();

            _mobileNavigation.CheckoutPage.Payment.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PlaceYourOrder.Click();
        }

        [Then(@"The checkout page is displayed with the (.*) applied to the total")]
        public void ThenTheCheckoutPageIsDisplayedWithThePercentAppliedToTheTotal(int percent)
        {
            var totalPrice = decimal.Parse(DataHelper.RemoveCurrencySymbol(_mobileNavigation.CheckoutPage.TotalPrice.Text));
            var originalPrice = decimal.Parse(DataHelper.RemoveCurrencySymbol(CheckoutPage.PreservedTotalPrice));

            var offerPrice = (originalPrice - (originalPrice * percent));

            Assert.AreEqual(offerPrice, totalPrice);
        }
    }
}
