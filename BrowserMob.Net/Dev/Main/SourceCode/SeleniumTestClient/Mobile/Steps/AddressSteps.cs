using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages;
using UAT.Mobile.Automation.Mobile.Pages.Panels;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class AddressSteps
    {
        private readonly MobileNavigation _mobileNavigation;
        private static string _postcode;

        public AddressSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I am on the address panel")]
        public void GivenIAmOnTheAddressPanel()
        {
            _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(HeaderMenu.Segment.Womens, HeaderMenu.SegmentCategoryWomens.Dresses)
                .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                .ProductDetailPage.SelectAvailableColourAndSize()
                .AddToBag.Click();

            _mobileNavigation.GoToCheckoutPage();

            _mobileNavigation.CheckoutPage.Next.Click();

            _mobileNavigation.CheckoutPage.Guest.Click();
            _mobileNavigation.CheckoutPage.Next.Click();
            _mobileNavigation.CheckoutPage.ContactDetails.Populate();
            _mobileNavigation.CheckoutPage.ContactDetails.Next.Click();   
        }

        [When(@"I enter a postcode lookup and select an address")]
        public void WhenIEnterAPostcodeLookupAndSelectAnAddress()
        {
            if (Configuration.Market == Enums.Market.UK)
            {
                // TODO: remove this line, once the locale bug is fixed.
                _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Country.SelectByValue(CountryCode.UnitedKingdom);

                _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.PopulatePostcodeLookup();
                _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookUpAddress.Click();
                _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookupResult.SelectByIndex(0);
            }
        }

        [Then(@"the address details are auto populated")]
        public void ThenTheAddressDetailsAreAutoPopulated()
        {
            var isPopulated = _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.IsNotEmpty();

            Assert.True(isPopulated);
        }

        [When(@"I manually populate the checkout delivery details")]
        public void WhenIManuallyPopulateTheCheckoutDeliveryDetails()
        {
            _mobileNavigation.CheckoutPage.Next.Click();
            _mobileNavigation.CheckoutPage.Guest.Click();

            _mobileNavigation.CheckoutPage.DeliveryOption.Next.Click();

            _mobileNavigation.CheckoutPage.ContactDetails.Populate();
            _mobileNavigation.CheckoutPage.ContactDetails.Next.Click();

            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    var countryCode = _mobileNavigation.UIHelper.GetCountryCodeForCurrentMarket();
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Country.SelectByValue(countryCode);
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.EnterAddressManually.Click();
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Populate();
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
        }

        [When(@"I continue through checkout and place the order")]
        public void WhenIContinueThroughCheckoutAndPlaceTheOrder()
        {
            _mobileNavigation.CheckoutPage.Payment.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PlaceYourOrder.Click();
        }

        [When(@"I log into my existing customer account")]
        public void WhenILogIntoMyExistingCustomerAccount()
        {
            _mobileNavigation.CheckoutPage.Next.Click();
            _mobileNavigation.CheckoutPage.Login(UKCustomer.EmailChangeAddress, UKCustomer.Password);
        }

        [When(@"I change my billing address")]
        public void WhenIChangeMyBillingAddress()
        {
            _mobileNavigation.CheckoutPage.Addresses.ChangeAddress.Click();

            _mobileNavigation.CheckoutPage.Addresses.BillingAddress.AddNewAddress.Click();

            if (Configuration.Market == Enums.Market.UK)
            {
                // TODO: remove this line, once the locale bug is fixed.
                _mobileNavigation.CheckoutPage.Addresses.BillingAddress.Country.SelectByValue(CountryCode.UnitedKingdom);

                _mobileNavigation.CheckoutPage.Addresses.BillingAddress.PopulatePostcodeLookup();
                _mobileNavigation.CheckoutPage.Addresses.BillingAddress.LookUpAddress.Click();
                _mobileNavigation.CheckoutPage.Addresses.BillingAddress.LookupResult.SelectByIndex(0);
                _mobileNavigation.CheckoutPage.Addresses.UseTheseAddresses.Click();

                _postcode = _mobileNavigation.CheckoutPage.Addresses.BillingAddress.Postcode.Text;
            }
        }

        [Then(@"The new billing address shows in the collapsed Address box")]
        public void ThenTheNewBillingAddressShowsInTheCollapsedAddressBox()
        {
            _mobileNavigation.UIHelper.ScrollToElement(_mobileNavigation.CheckoutPage.Addresses.ChangeAddress, -400);

            var changedAddress = _mobileNavigation.CheckoutPage.AddressCollapsed.BillingAddress.Text;

            var isChanged = changedAddress.Contains(_postcode);

            Assert.True(isChanged);   
        }

        [When(@"I change my delivery Address")]
        public void WhenIChangeMyDeliveryAddress()
        {
            _mobileNavigation.CheckoutPage.Addresses.ChangeAddress.Click();
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.AddNewAddress.Click();

            if (Configuration.Market == Enums.Market.UK)
            {
                // TODO: remove this line, once the locale bug is fixed.
                _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Country.SelectByValue(CountryCode.UnitedKingdom);

                _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.PopulatePostcodeLookup();
                _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookUpAddress.Click();
                _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookupResult.SelectByIndex(0);
                _mobileNavigation.CheckoutPage.Addresses.UseTheseAddresses.Click();

                _postcode = _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Postcode.Text;
            }
        }

        [Then(@"The new delivery address shows in the collapsed address box")]
        public void ThenTheNewDeliveryAddressShowsInTheCollapsedAddressBox()
        {
            _mobileNavigation.UIHelper.ScrollToElement(_mobileNavigation.CheckoutPage.Addresses.ChangeAddress, -400);

            var changedAddress = _mobileNavigation.CheckoutPage.AddressCollapsed.DeliveryAddress.Text;

            var isChanged = changedAddress.Contains(_postcode);

            Assert.True(isChanged);
        }
    }
}
