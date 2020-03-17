using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
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
                .GoToProductListingPage(MenuData.Women, MenuData.Dresses)
                .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                .ProductDetailPage.SelectAvailableColourAndSize()
                .AddToBag.Click();
        }

        [When(@"I place an order as a registered customer")]
        public void WhenIPlaceAnOrderAsARegisteredCustomer()
        {
            _mobileNavigation.GoToCheckoutPage();

            _mobileNavigation.CheckoutPage.DeliveryOption.NextClick();

            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

            _mobileNavigation.CheckoutPage.NextClick();

            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PrivacyPolicyClick()
                .PlaceYourOrder.Click();
        }

        [When(@"I place an order as a guest customer")]
        public void WhenIPlaceAnOrderAsAGuestCustomer()
        {
            PlaceOrderAsGuestCustomer(false);
        }

        private void PlaceOrderAsGuestCustomer(bool newEmail)
        {
            _mobileNavigation.GoToCheckoutPage();

            _mobileNavigation.CheckoutPage.DeliveryOption.NextClick();

            _mobileNavigation.CheckoutPage.Guest.Click();

            _mobileNavigation.CheckoutPage.DeliveryOption.NextClick();

            _mobileNavigation.CheckoutPage.ContactDetails.Populate(newEmail);
            _mobileNavigation.CheckoutPage.ContactDetails.NextClick();

            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Country.SelectByValue(CountryCode.UnitedKingdom);
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.PopulatePostcodeLookup();
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookUpAddress.Click();
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookupResult.SelectByIndex(0);
                    Thread.Sleep(Configuration.MilliSecondsToWait);
                    break;
                case Enums.Market.DE:
                    _mobileNavigation.CheckoutPage.Addresses.BillingAddress.Populate();
                    break;
                default:
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Populate();
                    break;
            }

            new Actions(_mobileNavigation.WebDriverManager.WebDriver)
                .MoveToElement(_mobileNavigation.CheckoutPage.Addresses.UseThisAddress)
                .Perform();

            _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();

            if (Configuration.Market == Enums.Market.US)
            {
                // due to some weird events when running in selenium US needs this code.
                _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();
                _mobileNavigation.CheckoutPage.NextClick();
                _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();
            }

            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PrivacyPolicyClick()
                .PlaceYourOrder.Click();
        }

        [When(@"I log into checkout with (.*) and (.*)")]
        public void WhenILogIntoCheckoutWithAnd(string email, string password)
        {
            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.Login(email, password);
            _mobileNavigation.CheckoutPage.NextClick();
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
            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.Payment.AccountCredit.ApplyCredit.Click();
            _mobileNavigation.CheckoutPage.Payment.TermsAcceptedClick()
                                                  .PrivacyPolicyClick();
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
                _mobileNavigation.GoToHomePage().GoToProductListingPage(MenuData.Women, MenuData.Dresses)
                    .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                    .ProductDetailPage.SelectAvailableColourAndSize()
                    .AddToBag.Click();

                _mobileNavigation.GoToCheckoutPage();
            }
        }

        [When(@"I place an order with (.*) gift voucher")]
        public void WhenIPlaceAnOrderWithGiftVoucher(string giftVoucher)
        {
            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);
            _mobileNavigation.CheckoutPage.NextClick();

            _mobileNavigation.CheckoutPage.Payment.ApplyGiftVoucher.Click();
            _mobileNavigation.CheckoutPage.Payment.GiftVoucher.Number.SendKeys(giftVoucher);
            _mobileNavigation.CheckoutPage.Payment.GiftVoucher.Add.Click();

            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card);
            _mobileNavigation.PaymentPage.TermsAcceptedClick()
                                         .PrivacyPolicyClick()
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
            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);
            _mobileNavigation.CheckoutPage.NextClick();

            _mobileNavigation.CheckoutPage.Payment.ApplyGiftVoucher.Click();
            _mobileNavigation.CheckoutPage.Payment.GiftVoucher.Number.SendKeys(giftVoucher);
            _mobileNavigation.CheckoutPage.Payment.GiftVoucher.Add.Click();
        }

        [When(@"place an order with a valid credit card")]
        public void WhenPlaceAnOrderWithAValidCreditCard()
        {
            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card);
            _mobileNavigation.PaymentPage.TermsAcceptedClick()
                                         .PrivacyPolicyClick()
                                         .PlaceYourOrder.Click();
        }

        [Given(@"I am on the checkout page with 1 or more product\(s\) in my basket")]
        public void GivenIAmOnTheCheckoutPageWithOrMoreProductSInMyBasket()
        {
            GivenIHaveAProductInMyShoppingBasket();
            
            _mobileNavigation.GoToCheckoutPage();
        }

        [Given(@"I am on the checkout page with a (.*) product in my basket")]
        public void GivenIAmOnTheCheckoutPageWithACategorySegmentProductInMyBasket(string segment)
        {
            switch (segment)
            {
                case "baby":
                    _mobileNavigation.GoToHomePage()
                        .GoToProductListingPage(MenuData.Children, MenuData.Accessories)
                        .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                        .ProductDetailPage.SelectAvailableColourAndSize();
                    break;
                case "women":
                    _mobileNavigation.GoToHomePage()
                        .GoToProductListingPage(MenuData.Women, MenuData.Dresses)
                        .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                        .ProductDetailPage.SelectAvailableColourAndSize();
                    break;
                case "men":
                    _mobileNavigation.GoToHomePage()
                        .GoToProductListingPage(MenuData.Men, MenuData.TrousersAndJeans)
                        .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                        .ProductDetailPage.SelectAvailableColourAndSize();
                    break;
                case "clearance":
                    _mobileNavigation.GoToHomePage()
                        .GoToProductListingPage(MenuData.Clearance, MenuData.Women)
                        .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                        .ProductDetailPage.SelectAvailableColourAndSize();
                    break;
                case "blog":
                    _mobileNavigation.GoToHomePage()
                        .GoToProductListingPage(MenuData.Blog)
                        .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                        .ProductDetailPage.SelectAvailableColourAndSize();
                    break;
                case "christmas":
                    _mobileNavigation.GoToHomePage()
                        .GoToProductListingPage(MenuData.Christmas, MenuData.GiftsForHer)
                        .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                        .ProductDetailPage.SelectAvailableColourAndSize();
                    break;
            }


            _mobileNavigation.ProductListingPage.ProductDetailPage.AddToBag.Click();

            _mobileNavigation.GoToCheckoutPage();
            _mobileNavigation.CheckoutPage.NextClick();
        }


        [When(@"I place an order with valid offer code")]
        public void WhenIPlaceAnOrderWithValidOfferCode()
        {
            CheckoutPage.PreservedTotalPrice = _mobileNavigation.CheckoutPage.TotalPrice.Text;

            _mobileNavigation.CheckoutPage.OfferCode.SendKeys(CustomerData.OfferCode);
            _mobileNavigation.CheckoutPage.ApplyCode.Click();

            _mobileNavigation.CheckoutPage.NextClick();

            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

            _mobileNavigation.CheckoutPage.NextClick();

            _mobileNavigation.CheckoutPage.Payment.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PrivacyPolicyClick()
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

        [When(@"I select payment by Open Invoice")]
        public void WhenISelectPaymentByOpenInvoice()
        {
            try
            {
                _mobileNavigation.PaymentPage.OpenInvoiceTab.Click();
            }
            catch
            {
                // ignore...
            }
        }

        [Then(@"The message about Open Invoice not available is displayed")]
        public void ThenTheMessageAboutOpenInvoiceNotAvailableIsDisplayed()
        {
            var isFalse = _mobileNavigation.PaymentPage.OpenInvoiceCreditAvailable();

            Assert.False(isFalse);
        }

        [Then(@"The message about Open Invoice is displayed")]
        public void ThenTheMessageAboutOpenInvoiceIsDisplayed()
        {
            var isTrue = _mobileNavigation.PaymentPage.OpenInvoiceCreditAvailable();

            Assert.True(isTrue);
        }

        [When(@"I place an order as a new guest customer")]
        public void WhenIPlaceAnOrderAsANewGuestCustomer()
        {
            PlaceOrderAsGuestCustomer(true);
        }

        [When(@"I register on the order complete register page")]
        public void WhenIRegisterOnTheOrderCompleteRegisterPage()
        {
            if (Configuration.Market != Enums.Market.DE)
            {
                _mobileNavigation.CheckoutPage.GuestRegistrationPage.Password.SendKeys(CustomerData.Password);
                _mobileNavigation.CheckoutPage.GuestRegistrationPage.RegisterMeNow.Click();

                _mobileNavigation.CheckoutPage.GuestRegistrationPage.DOBDay.SelectByValue(CustomerData.DOBDay);
                _mobileNavigation.CheckoutPage.GuestRegistrationPage.DOBMonth.SelectByValue(CustomerData.DOBMonth);
                _mobileNavigation.CheckoutPage.GuestRegistrationPage.DOBYear.SendKeys(CustomerData.DOBYear);

                _mobileNavigation.CheckoutPage.GuestRegistrationPage.SavePreferences.Click();
            }
        }

        //[When(@"I go to order summary on the order complete register page")]
        //public void WhenIGoToOrderSummaryOnTheOrderCompleteRegisterPage()
        //{
        //    if (Configuration.Market != Enums.Market.DE)
        //    {
        //        _mobileNavigation.CheckoutPage.GuestRegistrationPage.TakeMeToOrderSummary.Click();
        //    }
        //}

        [When(@"I continue without using account credit")]
        public void WhenIContinueWithoutUsingAccountCredit()
        {
            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.Payment.AccountCredit.DontApplyCredit.Click();
        }

        [When(@"I place an order using credit card")]
        public void WhenIPlaceAnOrderUsingCreditCard()
        {
            _mobileNavigation.CheckoutPage.Payment.PopulatePaymentDetails(Payment.PaymentType.Card);

            _mobileNavigation.CheckoutPage.Payment
                .TermsAcceptedClick()
                .PrivacyPolicyClick()
                .PlaceYourOrder.Click();
        }
    }
}
