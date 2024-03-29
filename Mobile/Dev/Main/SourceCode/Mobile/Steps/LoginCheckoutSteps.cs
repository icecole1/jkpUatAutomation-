﻿using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages;
using UAT.Mobile.Automation.Mobile.Pages.Panels;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class LoginCheckoutSteps
    {
        private readonly MobileNavigation _mobileNavigation;

        public LoginCheckoutSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I am on the guest checkout page with a product in my basket")]
        public void GivenIAmOnTheGuestCheckoutPageWithAProductInMyBasket()
        {
            _mobileNavigation.GoToProductListingPage(MenuData.Women, MenuData.Dresses);
            _mobileNavigation.ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First);
            _mobileNavigation.ProductListingPage.ProductDetailPage.SelectAvailableColourAndSize();
            _mobileNavigation.ProductListingPage.ProductDetailPage.AddToBag.Click();

            _mobileNavigation.GoToCheckoutPage();
            _mobileNavigation.CheckoutPage.DeliveryOption.NextClick();
            _mobileNavigation.CheckoutPage.Guest.Click();
        }

        [When(@"I click next to continue to contact details")]
        public void WhenIClickNextToContinueToContactDetails()
        {
            _mobileNavigation.CheckoutPage.NextClick();
        }

        [Then(@"The contact details are empty")]
        public void ThenTheContactDetailsAreEmpty()
        {
            var isEmpty = _mobileNavigation.CheckoutPage.ContactDetails.AreContactDetailsEmpty();

            Assert.True(isEmpty);
        }

        [When(@"I continue onto the checkout billing details section")]
        public void WhenIContinueOntoTheCheckoutBillingDetailsSection()
        {
            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.ContactDetails.Populate();
            _mobileNavigation.CheckoutPage.ContactDetails.NextClick();

            _mobileNavigation.CheckoutPage.Addresses.EnterSeperateBillingAddress.Click();
        }

        [Then(@"The billing details are empty")]
        public void ThenTheBillingDetailsAreEmpty()
        {
            bool isEmpty;

            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    // TODO: remove this line, once the locale bug is fixed.
                    _mobileNavigation.CheckoutPage.Addresses.BillingAddress.Country.SelectByValue(CountryCode.UnitedKingdom);

                    var isDisplayed = _mobileNavigation.CheckoutPage.Addresses.BillingAddress.LookUpAddress.Displayed;
                    Assert.True(isDisplayed);
                    break;
                default:
                    isEmpty = _mobileNavigation.CheckoutPage.Addresses.BillingAddress.IsEmpty();
                    Assert.True(isEmpty);
                    break;
            }
        }

        [When(@"I continue onto the checkout payment details section")]
        public void WhenIContinueOntoTheCheckoutPaymentDetailsSection()
        {
            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.ContactDetails.Populate();
            _mobileNavigation.CheckoutPage.ContactDetails.NextClick();

            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    // TODO: remove this line, once the locale bug is fixed.
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Country.SelectByValue(CountryCode.UnitedKingdom);

                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.PopulatePostcodeLookup();
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookUpAddress.Click();
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.LookupResult.SelectByIndex(0);
                    break;
                case Enums.Market.DE:
                    _mobileNavigation.CheckoutPage.Addresses.BillingAddress.Populate();
                    //_mobileNavigation.CheckoutPage.Addresses.UseTheseAddresses.Click();
                    break;
                default:
                    _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Populate();
                    break;
            }

            _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();

            if (Configuration.Market == Enums.Market.US)
            {
                // due to some weird events when running in selenium US needs this code.
                _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();
                _mobileNavigation.CheckoutPage.NextClick();
                _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();
            }
        }

        [Then(@"The payment details are empty")]
        public void ThenThePaymentDetailsAreEmpty()
        {
            var isEmpty = _mobileNavigation.CheckoutPage.Payment.IsEmpty();

            Assert.True(isEmpty);
        }
    }
}
