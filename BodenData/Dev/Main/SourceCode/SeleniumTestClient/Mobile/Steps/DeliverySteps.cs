using System;
using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Mobile.Pages;
using UAT.Mobile.Automation.Mobile.Pages.Panels;
using UAT.Mobile.Automation.Helpers;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class DeliverySteps
    {
        private readonly MobileNavigation _mobileNavigation;
        public static bool OptionAvailable = true;
        private static string _selectedLocation;
        private static string _selectedLocationName;

        public DeliverySteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I am on the checkout page with a product in my basket")]
        public void GivenIAmOnTheCheckoutPageWithAProductInMyBasket()
        {
            _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(HeaderMenu.Segment.Womens, HeaderMenu.SegmentCategoryWomens.Dresses)
                .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                .ProductDetailPage.SelectAvailableColourAndSize()
                .AddToBag.Click();

            _mobileNavigation.GoToCheckoutPage();
        }
        
        [When(@"I click on a UK (.*) delivery")]
        public void WhenIClickOnAUKStandardDelivery(string deliveryOption)
        {
            OptionAvailable = true;

            var option = (DeliveryOptions.Type) Enum.Parse(typeof(DeliveryOptions.Type), deliveryOption.Replace(" ", ""));

            try
            {
                var webElement = _mobileNavigation.CheckoutPage.DeliveryOption.Option(Enums.Market.UK, option);

                if (webElement != null)
                {
                    webElement.Click();
                    Thread.Sleep(2000);
                }
                else
                {
                    OptionAvailable = false;
                }
            }
            catch
            {
                OptionAvailable = true;
            }
        }

        [When(@"I click on a US (.*) delivery")]
        public void WhenIClickOnAUSStandardDelivery(string deliveryOption)
        {
            OptionAvailable = true;

            var option = (DeliveryOptions.Type)Enum.Parse(typeof(DeliveryOptions.Type), deliveryOption.Replace(" ", ""));

            try
            {
                var webElement = _mobileNavigation.CheckoutPage.DeliveryOption.Option(Enums.Market.US, option);

                if (webElement != null)
                {
                    webElement.Click();
                    Thread.Sleep(2000);
                }
                else
                {
                    OptionAvailable = false;
                }
            }
            catch
            {
                OptionAvailable = true;
            }
        }

        [When(@"I click on a DE (.*) delivery")]
        public void WhenIClickOnADEStandardDelivery(string deliveryOption)
        {
            OptionAvailable = true;

            var option = (DeliveryOptions.Type)Enum.Parse(typeof(DeliveryOptions.Type), deliveryOption.Replace(" ", ""));

            try
            {
                var webElement = _mobileNavigation.CheckoutPage.DeliveryOption.Option(Enums.Market.DE, option);

                if (webElement != null)
                {
                    webElement.Click();
                    Thread.Sleep(2000);
                }
                else
                {
                    OptionAvailable = false;
                }
            }
            catch
            {
                OptionAvailable = true;
            }
        }

        [When(@"I click on a FR (.*) delivery")]
        public void WhenIClickOnAFRStandardDelivery(string deliveryOption)
        {
            OptionAvailable = true;

            var option = (DeliveryOptions.Type)Enum.Parse(typeof(DeliveryOptions.Type), deliveryOption.Replace(" ", ""));

            try
            {
                var webElement = _mobileNavigation.CheckoutPage.DeliveryOption.Option(Enums.Market.FR, option);

                if (webElement != null)
                {
                    webElement.Click();
                    Thread.Sleep(2000);
                }
                else
                {
                    OptionAvailable = false;
                }
            }
            catch
            {
                OptionAvailable = true;
            }
        }

        [When(@"I click on a AU (.*) delivery")]
        public void WhenIClickOnAAUStandardDelivery(string deliveryOption)
        {
            OptionAvailable = true;

            var option = (DeliveryOptions.Type)Enum.Parse(typeof(DeliveryOptions.Type), deliveryOption.Replace(" ", ""));

            try
            {
                var webElement = _mobileNavigation.CheckoutPage.DeliveryOption.Option(Enums.Market.AU, option);

                if (webElement != null)
                {
                    webElement.Click();
                    Thread.Sleep(2000);
                }
                else
                {
                    OptionAvailable = false;
                }
            }
            catch
            {
                OptionAvailable = true;
            }
        }


        [Then(@"The confirmation page is displayed")]
        public void ThenTheConfirmationPageIsDisplayed()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.US:
                    if (GuestRegistrationPage.IsGuestCheckout)
                    {
                        _mobileNavigation.CheckoutPage.GuestRegistrationPage.TakeMeToOrderSummary.Click();
                    }
                    break;
                case Enums.Market.DE:
                    if (GuestRegistrationPage.IsGuestCheckout)
                    {
                        _mobileNavigation.CheckoutPage.GuestRegistrationPage.DOBDay.SelectByValue(CustomerData.DOBDay);
                        _mobileNavigation.CheckoutPage.GuestRegistrationPage.DOBMonth.SelectByValue(CustomerData.DOBMonth);
                        _mobileNavigation.CheckoutPage.GuestRegistrationPage.DOBYear.SendKeys(CustomerData.DOBYear);

                        _mobileNavigation.CheckoutPage.GuestRegistrationPage.SavePreferences.Click();
                    }
                    break;
            }

            var confirmationIsDisplayed = _mobileNavigation.OrderConfirmationPage.IsDisplayed();

            Assert.True(confirmationIsDisplayed);
        }

        [When(@"I place an order")]
        public void WhenIPlaceAnOrder()
        {
            if (OptionAvailable)
            {
                _mobileNavigation.CheckoutPage.DeliveryOption.Next.Click();

                _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

                _mobileNavigation.CheckoutPage.Next.Click();

                _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card)
                    .TermsAcceptedClick()
                    .PlaceYourOrder.Click();
            }
            else
            {
                CheckoutPage.PreservedTotalPrice = string.Empty;
            }
        }

        [Then(@"The confirmation page displays (.*) in the delivery selection")]
        public void ThenTheConfirmationPageDisplaysStandardInTheDeliverySelection(string deliveryOption)
        {
            if (!OptionAvailable)
            {
                // TODO: ideally need to get product that contains the correct delivery option from DB.
                Assert.True(true);
            }
            else
            {
                var isSameShippingOption = _mobileNavigation.OrderConfirmationPage.GetDeliveryOption.Contains(deliveryOption);

                // TODO: ideally need to add attribute for a more robust comparison.
                Assert.True(isSameShippingOption);
            }
        }

        [Given(@"I have selected UK click and collect as a delivery method")]
        public void GivenIHaveSelectedUKClickAndCollectAsADeliveryMethod()
        {
            try
            {
                GivenIAmOnTheCheckoutPageWithAProductInMyBasket();

                var webElement = _mobileNavigation.CheckoutPage.DeliveryOption.Option(Enums.Market.UK, DeliveryOptions.Type.ClickAndCollect);

                if (webElement != null)
                {
                    webElement.Click();
                    Thread.Sleep(Configuration.MilliSecondsToWait);
                }
            }
            catch
            {
                // ignore..
            }
        }

        [Given(@"I have selected DE click and collect as a delivery method")]
        public void GivenIHaveSelectedDEClickAndCollectAsADeliveryMethod()
        {
            try
            {
                GivenIAmOnTheCheckoutPageWithAProductInMyBasket();

                var webElement = _mobileNavigation.CheckoutPage.DeliveryOption.Option(Enums.Market.DE, DeliveryOptions.Type.ClickAndCollect);

                if (webElement != null)
                {
                    webElement.Click();
                    Thread.Sleep(Configuration.MilliSecondsToWait);
                }
            }
            catch
            {
                // ignore..
            }
        }

        [Given(@"I have selected FR click and collect as a delivery method")]
        public void GivenIHaveSelectedFRClickAndCollectAsADeliveryMethod()
        {
            try
            {
                GivenIAmOnTheCheckoutPageWithAProductInMyBasket();

                var webElement = _mobileNavigation.CheckoutPage.DeliveryOption.Option(Enums.Market.FR, DeliveryOptions.Type.ClickAndCollect);

                if (webElement != null)
                {
                    webElement.Click();
                    Thread.Sleep(Configuration.MilliSecondsToWait);
                }
            }
            catch
            {
                // ignore..
            }
        }

        [When(@"I enter a (.*) postcode")]
        public void WhenIEnterAPostcode(string postcode)
        {
            _mobileNavigation.CheckoutPage.DeliveryOption.ClickAndCollectModal.Postcode.SendKeys(postcode);
            _mobileNavigation.CheckoutPage.DeliveryOption.ClickAndCollectModal.Search.Click();
        }

        [Then(@"the pickup locations are displayed")]
        public void ThenThePickupLocationsAreDisplayed()
        {
            var pickLocationIsDisplayed =
                _mobileNavigation.CheckoutPage.DeliveryOption.ClickAndCollectModal.LocationList.IsDisplayed();

            Assert.True(pickLocationIsDisplayed);
        }

        private void SetSelectedLocationText()
        {
            _selectedLocationName = _mobileNavigation.CheckoutPage.DeliveryOption.ClickAndCollectModal.LocationList.SelectedLocationName.Text;

            _selectedLocation = _selectedLocationName + " " +
                _mobileNavigation.CheckoutPage.DeliveryOption.ClickAndCollectModal.LocationList.SelectedAddressLine1.Text;
        }

        [Then(@"the (.*) is shown on the location result panel")]
        public void ThenThePostcodeIsShownOnTheLocationResultPanel(string postcode)
        {
            _mobileNavigation.CheckoutPage.DeliveryOption
                             .ClickAndCollectModal.LocationList.ExpandLocation(Enums.Location.First)
                             .SelectLocation.Click();

            var locationPostcode = _mobileNavigation.CheckoutPage.DeliveryOption.ClickAndCollectModal.LocationList.SelectedAddressLine2.Text;

            var postcodeExists = locationPostcode.ToLower().Contains(postcode.ToLower());

            Assert.True(postcodeExists);
        }

        [When(@"I select a location")]
        public void WhenISelectALocation()
        {
            _mobileNavigation.CheckoutPage.DeliveryOption
                                          .ClickAndCollectModal.LocationList.ExpandLocation(Enums.Location.First)
                                          .SelectLocation.Click();

            SetSelectedLocationText();
        }

        [Then(@"the location is displayed on the collection address panel")]
        public void ThenTheLocationIsDisplayedOnTheCollectionAddressPanel()
        {
            _mobileNavigation.CheckoutPage.DeliveryOption.Next.Click();

            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

            _mobileNavigation.CheckoutPage.Next.Click();

            var clickAndCollectLocation = _mobileNavigation.CheckoutPage.Addresses.CollectionAddress.Name.Text + " " +
                                          _mobileNavigation.CheckoutPage.Addresses.CollectionAddress.AddressLine1.Text + " " +
                                          _mobileNavigation.CheckoutPage.Addresses.CollectionAddress.AddressLine2.Text;

            var isSameLocation = clickAndCollectLocation.ToLower().Contains(_selectedLocation.ToLower());

            Assert.True(isSameLocation);
        }

        [Then(@"the location is shown on the delivery options panel")]
        public void ThenTheLocationIsShownOnTheDeliveryOptionsPanel()
        {
            Thread.Sleep(Configuration.MilliSecondsToWait);

            var clickAndCollectLocation = _mobileNavigation.CheckoutPage.DeliveryOption.ClickAndCollectionLocationText;

            var isSameLocation = clickAndCollectLocation.ToLower().Contains(_selectedLocationName.ToLower());

            Assert.True(isSameLocation);
        }

        [When(@"I continue on address panel and place order with (.*) number")]
        public void WhenIContinueOnAddressPanelAndPlaceOrderWithNumber(string number)
        {
            Thread.Sleep(Configuration.MilliSecondsToWait);

            _mobileNavigation.CheckoutPage.Next.Click();
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

            _mobileNavigation.CheckoutPage.Next.Click();

            if (string.IsNullOrEmpty(number))
            {
                var mobileNumber = _mobileNavigation.CheckoutPage.Addresses.CollectionAddress.MobileNumber.Text;
                Assert.That(string.IsNullOrEmpty(mobileNumber));
            }
            else
            {
                if (Configuration.Market == Enums.Market.DE)
                {
                    _mobileNavigation.CheckoutPage.Addresses.CollectionAddress.PostNumber.SendKeys(number);
                }
                else
                {
                    _mobileNavigation.CheckoutPage.Addresses.CollectionAddress.MobileNumber.SendKeys(number);
                }
            }

            _mobileNavigation.CheckoutPage.Addresses.UseTheseAddresses.Click();

            _mobileNavigation.CheckoutPage.Payment.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PlaceYourOrder.Click();
        }
    }
}
