using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages;
using UAT.Mobile.Automation.Mobile.Pages.Panels;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class PDPSteps
    {
        private readonly MobileNavigation _mobileNavigation;

        public PDPSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I am on the product description page")]
        public void GivenIAmOnTheProductDescriptionPage()
        {
            _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(HeaderMenu.Segment.Womens, HeaderMenu.SegmentCategoryWomens.Dresses);

            _mobileNavigation.ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First);
        }

        [When(@"I select a product")]
        public void WhenISelectAProduct()
        {
            _mobileNavigation.ProductListingPage.ProductDetailPage.SelectAvailableColourAndSize();
        }

        [Then(@"The add to basket button is enabled")]
        public void ThenTheAddToBasketButtonIsEnabled()
        {
            var isEnabled = _mobileNavigation.ProductListingPage.ProductDetailPage.AddToBag.Enabled;

            Assert.True(isEnabled);
        }

        [When(@"I click the add to bag button")]
        public void WhenIClickTheAddToBagButton()
        {
            _mobileNavigation.ProductListingPage.ProductDetailPage.AddToBag.Click();
        }

        [Then(@"The the bag overlay is displayed")]
        public void ThenTheTheBagOverlayIsDisplayed()
        {
            var overlayIsDisplayed =
                _mobileNavigation.ProductListingPage.ProductDetailPage.CheckoutNotification.IsDisplayed();

            Assert.True(overlayIsDisplayed);
        }

        [Given(@"I am on a hemming item product page")]
        public void GivenIAmOnAHemmingItemProductPage()
        {
            if (Configuration.Market == Enums.Market.UK)
            {
                var hemmingProductCode = _mobileNavigation.ProductListingPage.TrouserHemmingRepository.GetProductCode();

                _mobileNavigation.GoToHomePage()
                    .GoToProductDetailPage(hemmingProductCode)
                    .ProductDetailPage.SelectAvailableColourAndSize();
            }
        }


        [Then(@"The trouser hemming modal is displayed")]
        public void ThenTheTrouserHemmingModalIsDisplayed()
        {
            if (Configuration.Market == Enums.Market.UK)
            {
                var hemmingModalIsDisplayed = _mobileNavigation.ProductDetailPage.HemmingModal.IsDisplayed();

                Assert.True((hemmingModalIsDisplayed));
            }
        }

        [When(@"I select a hemming option")]
        public void WhenISelectAHemmingOption()
        {
            Thread.Sleep(Configuration.MilliSecondsToWait);
            _mobileNavigation.ProductDetailPage.HemmingModal.SelectOption(Enums.HemmingOption.JEA);
            _mobileNavigation.ProductListingPage.ProductDetailPage.HemmingModal.LegLength.SelectByValue(Enums.LegLength
                .H0000952.ToString());

            _mobileNavigation.ProductListingPage.ProductDetailPage.HemmingModal.Update.Click();
        }

        [Then(@"the selected hemming item is added to the basket")]
        public void ThenTheSelectedHemmingItemIsAddedToTheBasket()
        {
            if (Configuration.Market == Enums.Market.UK)
            {
                Thread.Sleep(Configuration.MilliSecondsToWait);
                _mobileNavigation.ProductDetailPage.HeaderMenus.ShoppingBag.Click();

                var productsInShoppingBag = _mobileNavigation.CheckoutPage.ShoppingBag.Products.Count;

                Assert.AreEqual(1, productsInShoppingBag);
            }
        }
    }
}
