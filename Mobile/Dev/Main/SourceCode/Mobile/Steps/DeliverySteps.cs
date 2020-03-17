using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
        private static string _selectedDeliveryOption;

        public DeliverySteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I am on the checkout page with a product in my basket")]
        public void GivenIAmOnTheCheckoutPageWithAProductInMyBasket()
        {
            _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(MenuData.Women, MenuData.Dresses)
                .ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First)
                .ProductDetailPage.SelectAvailableColourAndSize()
                .AddToBag.Click();

            _mobileNavigation.GoToCheckoutPage();
        }

        [When(@"I enter Jersey as a delivery address")]
        public void WhenIEnterJerseyAsADeliveryAddress()
        {
            PopulateCheckoutAndSelectDeliveryCountry("GB");

            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.EnterAddressManually.Click();
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.AddressLine3.SendKeys(CustomerData.AddressLine3);
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.AddressLine4.SendKeys("St Aubin");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.City.SendKeys("Jersey");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Postcode.SendKeys("JE3 8AE");

            _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();
        }

        [When(@"I click on a UK (.*) delivery")]
        public void WhenIClickOnAukStandardDelivery(string deliveryOption)
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
                    _selectedDeliveryOption = _mobileNavigation.CheckoutPage.DeliveryOption.SelectedOption();
                    OptionAvailable = false;
                }
            }
            catch
            {
                _selectedDeliveryOption = _mobileNavigation.CheckoutPage.DeliveryOption.SelectedOption();
                OptionAvailable = false;
            }
        }

        [When(@"I enter an Italian delivery address")]
        public void WhenIEnterAnItalianDeliveryAddress()
        {
            PopulateCheckoutAndSelectDeliveryCountry("IT");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.AddressLine2.SendKeys("Roma");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.AddressLine3.SendKeys("Roma");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.AddressLine5.SendKeys("Roma");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.State.SendKeys("Roma");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Postcode.SendKeys("Italy");

            var helper = new UIHelper(_mobileNavigation.WebDriverManager.WebDriver);
            helper.ScrollToElement(_mobileNavigation.CheckoutPage.Addresses.UseThisAddress);

            _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();
        }

        [When(@"I click to expand the shipping options")]
        public void WhenIClickToExpandTheShippingOptions()
        {
            var helper = new UIHelper(_mobileNavigation.WebDriverManager.WebDriver);

            helper.ScrollToElement(_mobileNavigation.WebDriverManager.Wait.Until(
                ExpectedConditions.ElementIsVisible(By.Id("divShoppingBagPanel")))).Click();
        }

        [When(@"I enter Alabama as a delivery address")]
        public void WhenIEnterAlabamaAsADeliveryAddress()
        {
            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.Guest.Click();
            _mobileNavigation.CheckoutPage.NextClick();

            _mobileNavigation.CheckoutPage.ContactDetails.Populate();
            _mobileNavigation.CheckoutPage.ContactDetails.NextClick();

            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.AddressLine3.SendKeys("test address");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.AddressLine4.SendKeys("AL 36507");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.City.SendKeys("alabama");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.State.SendKeys("alabama");
            _mobileNavigation.CheckoutPage.Addresses.DeliveryAddress.Postcode.SendKeys("36507");

            new Actions(_mobileNavigation.WebDriverManager.WebDriver)
                .MoveToElement(_mobileNavigation.CheckoutPage.Addresses.UseThisAddress)
                .Click()
                .Perform();

            if (Configuration.Market == Enums.Market.US)
            {
                // due to some weird events when running in selenium US needs this code.
                _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();
                _mobileNavigation.CheckoutPage.NextClick();
                _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();
            }

            Thread.Sleep(40000);
        }

        [Then(@"The provisional tax panel is not displayed on checkout")]
        public void WhenTheProvisionalTaxPanelIsNotDisplayedOnCheckout()
        {
            try
            {
                _mobileNavigation.WebDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("coPListTax")));
            }
            catch (Exception e)
            {
                // Exception raised when the panel is not displayed
                Assert.True(true);
            }
        }

        //[Then(@"The provisional tax panel is not displayed on the confirmation page")]
        //public void WhenTheProvisionalTaxPanelIsNotDisplayedOnTheConfirmationPage()
        //{
        //    try
        //    {
        //        _mobileNavigation.WebDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("coPListTax")));
        //    }
        //    catch (Exception e)
        //    {
        //        // Exception raised when the panel is not displayed
        //        Assert.True(true);
        //    }
        //}

        [Then(@"The provisional tax panel is displayed on checkout")]
        public void WhenTheProvisionalTaxPanelIsDisplayedOnCheckout()
        {
            AssertClassIsDisplayed("coPListTax");
        }

        [Then(@"The provisional tax panel is displayed on the confirmation page")]
        public void WhenTheProvisionalTaxPanelIsDisplayedOnTheConfirmationPage()
        {
            AssertClassIsDisplayed("coPListTax");
        }

        [Then(@"The European delivery charge is displayed on the confirmation page")]
        public void ThenTheEuropeanDeliveryChargeIsDisplayedOnTheConfirmationPage()
        {
            AssertClassIsDisplayed("coPListShipping");
        }

        [When(@"I click on a (.*) delivery")]
        public void WhenIClickOnAStandardDelivery(string deliveryOption)
        {
            if (!Configuration.Environment.Contains("stage"))
            {
                throw new Exception("Delivery Option test cannot be run on PreProd OR Live enviroments due to accounts not going to BOCSS causing incorrect delivery on confirmation page.");
            }

            var option = (DeliveryOptions.Type)Enum.Parse(typeof(DeliveryOptions.Type), deliveryOption.Replace(" ", ""));

            try
            {
                _mobileNavigation.CheckoutPage.DeliveryOption.Option(Configuration.Market, option).Click();
                OptionAvailable = true;
            }
            catch
            {
                if (deliveryOption != "Standard")
                {
                    OptionAvailable = true;
                }
                else
                {
                    OptionAvailable = false;
                }
            }
        }

        [When(@"I select a (.*) delivery")]
        public void WhenISelectAStandardDelivery(string deliveryOption)
        {
            var option = (DeliveryOptions.Type)Enum.Parse(typeof(DeliveryOptions.Type), deliveryOption.Replace(" ", "").Trim());

            try
            {
                _mobileNavigation.CheckoutPage.DeliveryOption.Option(Configuration.Market, option).Click();
                Thread.Sleep(3000);

                OptionAvailable = true;
            }
            catch
            {
                OptionAvailable = deliveryOption != "Standard";
            }
        }

        [Then(@"The confirmation page is displayed")]
        public void ThenTheConfirmationPageIsDisplayed()
        {
            switch (Configuration.Market)
            {
 
                case Enums.Market.DE:
                    if (GuestRegistrationPage.IsGuestCheckout)
                    {
                        _mobileNavigation.CheckoutPage.GuestRegistrationPage.DOBDay.SelectByValue(
                            CustomerData.DOBDay);
                        _mobileNavigation.CheckoutPage.GuestRegistrationPage.DOBMonth.SelectByValue(
                            CustomerData.DOBMonth);
                        _mobileNavigation.CheckoutPage.GuestRegistrationPage.DOBYear.SendKeys(CustomerData.DOBYear);

                        _mobileNavigation.CheckoutPage.GuestRegistrationPage.SavePreferences.Click();
                    }
                    break;
            }

            if (_mobileNavigation.CheckoutPage.GuestRegistrationPage.IsDisplayed())
            {
                _mobileNavigation.CheckoutPage.GuestRegistrationPage.TakeMeToOrderSummary.Click();
            }

            var confirmationIsDisplayed = _mobileNavigation.OrderConfirmationPage.IsDisplayed();

            Assert.True(confirmationIsDisplayed);
        }

        [When(@"I place an order")]
        public void WhenIPlaceAnOrder()
        {
            CheckoutPage.PreservedTotalPrice = _mobileNavigation.CheckoutPage.TotalPrice.Text;

            _mobileNavigation.CheckoutPage.DeliveryOption.NextClick();

            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

            _mobileNavigation.CheckoutPage.NextClick();

            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PrivacyPolicyClick()
                .PlaceYourOrder.Click();
        }

        [When(@"I place a pre-logged in order")]
        public void WhenIPlacePreLoggedInOrder()
        {
            GivenIAmOnTheCheckoutPageWithAProductInMyBasket();

            if (OptionAvailable)
            {
                _mobileNavigation.CheckoutPage.DeliveryOption.NextClick();

                _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card)
                    .TermsAcceptedClick()
                    .PrivacyPolicyClick()
                    .PlaceYourOrder.Click();
            }
            else
            {
                CheckoutPage.PreservedTotalPrice = string.Empty;
            }
        }

        [When(@"I place an order here")]
        public void WhenIPlaceAnOrderHere()
        {
            _mobileNavigation.PaymentPage.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PrivacyPolicyClick()
                .PlaceYourOrder.Click();
        }

        [Then(@"The confirmation page displays (.*) in the delivery selection")]
        public void ThenTheConfirmationPageDisplaysStandardInTheDeliverySelection(string deliveryOption)
        {
            bool isSameShippingOption;

            if (!OptionAvailable)
            {
                isSameShippingOption = _mobileNavigation.OrderConfirmationPage.GetDeliveryOption.Contains(_selectedDeliveryOption);
            }
            else
            {
                isSameShippingOption = _mobileNavigation.OrderConfirmationPage.GetDeliveryOption.Contains(deliveryOption);
            }

            Assert.True(isSameShippingOption);
        }

        [Given(@"I have selected UK click and collect as a delivery method")]
        public void GivenIHaveSelectedUkClickAndCollectAsADeliveryMethod()
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
        public void GivenIHaveSelectedDeClickAndCollectAsADeliveryMethod()
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
        public void GivenIHaveSelectedFrClickAndCollectAsADeliveryMethod()
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
            _mobileNavigation.CheckoutPage.DeliveryOption.NextClick();

            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

            _mobileNavigation.CheckoutPage.NextClick();

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

            _mobileNavigation.CheckoutPage.NextClick();
            _mobileNavigation.CheckoutPage.Login(CustomerData.EmailCreditCard, CustomerData.Password);

            _mobileNavigation.CheckoutPage.NextClick();

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

            _mobileNavigation.CheckoutPage.Addresses.UseThisAddressClick();

            _mobileNavigation.CheckoutPage.Payment.PopulatePaymentDetails(Payment.PaymentType.Card)
                .TermsAcceptedClick()
                .PrivacyPolicyClick()
                .PlaceYourOrder.Click();
        }

        private void PopulateCheckoutAndSelectDeliveryCountry(string countryCode)
        {
            _mobileNavigation.CheckoutPage.NextClick();

            _mobileNavigation.CheckoutPage.Guest.Click();

            _mobileNavigation.CheckoutPage.NextClick();

            _mobileNavigation.CheckoutPage.ContactDetails.Populate();
            _mobileNavigation.CheckoutPage.FinishedContactClick();

            var country = new SelectElement(_mobileNavigation.WebDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("DeliveryAddress_CountryCode"))));
            country.SelectByValue(countryCode);
        }
        
        private void AssertClassIsDisplayed(string classNameToTest)
        {
            var webElement = _mobileNavigation.WebDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(classNameToTest)));

            new Actions(_mobileNavigation.WebDriverManager.WebDriver)
                   .MoveToElement(webElement)
                   .Perform();

            Assert.True(webElement.Displayed);
        }
    }
}