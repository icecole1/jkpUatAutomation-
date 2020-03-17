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
    public class ShoppingBasketSteps
    {
        private readonly MobileNavigation _mobileNavigation;

        public ShoppingBasketSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [When(@"I add (.*) products")]
        public void WhenIAddProducts(int numberOfItems)
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                _mobileNavigation.ProductListingPage.ProductDetailPage.SelectAvailableColourAndSize()
                    .AddToBag.Click();

                Thread.Sleep(Configuration.MilliSecondsToWait);
            }

            _mobileNavigation.ProductDetailPage.HeaderMenus.ShoppingBag.Click();
        }

        [Then(@"The checkout page contains (.*) products")]
        public void ThenTheCheckoutPageContainsProducts(int numberOfItems)
        {
            if (_mobileNavigation.CheckoutPage.StockWarningDisplayed)
            {
                Assert.True(true);
            }
            else
            {
                var productsInShoppingBag = _mobileNavigation.CheckoutPage.ShoppingBag.Products.Count;

                Assert.AreEqual(numberOfItems, productsInShoppingBag);
            }
        }

        [Given(@"I have a (.*) UK gift card in the basket")]
        public void GivenIHaveAUKGiftCardInTheBasketForMarket(int cardValue)
        {
            _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(HeaderMenu.Segment.Womens, HeaderMenu.SegmentCategoryWomens.GiftVouchers)
                .ProductListingPage.SelectGiftCard()
                .ProductDetailPage.SelectGiftCardValue(Enums.Market.UK, cardValue)
                .AddToBag.Click();         
        }

        [Given(@"I have a (.*) US gift card in the basket")]
        public void GivenIHaveAUSGiftCardInTheBasketForMarket(int cardValue)
        {
            _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(HeaderMenu.Segment.Womens, HeaderMenu.SegmentCategoryWomens.GiftVouchers)
                .ProductListingPage.SelectGiftCard()
                .ProductDetailPage.SelectGiftCardValue(Enums.Market.US, cardValue)
                .AddToBag.Click();
        }

        [Given(@"I have a (.*) AU gift card in the basket")]
        public void GivenIHaveAAUGiftCardInTheBasketForMarket(int cardValue)
        {
            _mobileNavigation.GoToHomePage()
                .GoToProductListingPage(HeaderMenu.Segment.Womens, HeaderMenu.SegmentCategoryWomens.GiftVouchers)
                .ProductListingPage.SelectGiftCard()
                .ProductDetailPage.SelectGiftCardValue(Enums.Market.AU, cardValue)
                .AddToBag.Click();
        }

        [Then(@"The basket sub total value is (.*)")]
        public void ThenTheBasketSubTotalValueIs(int cardValue)
        {
            var dSubtotal = decimal.Parse(DataHelper.RemoveCurrencySymbol(_mobileNavigation.CheckoutPage.SubTotal.Text));
            var dCardValue = decimal.Parse(string.Concat(cardValue, ".00"));
            Assert.AreEqual(dCardValue, dSubtotal);           
        }

        [Given(@"I am on the checkout page and have (.*) product\(s\) in the basket")]
        public void GivenIAmOnTheCheckoutPageAndHaveProductsInTheBasket(int numberOfItems)
        {
            _mobileNavigation.GoToHomePage()
                 .GoToProductListingPage(HeaderMenu.Segment.Womens, HeaderMenu.SegmentCategoryWomens.Dresses);

            _mobileNavigation.ProductListingPage.SelectProduct(ProductListingPage.SelectProductIndex.First);

            WhenIAddProducts(numberOfItems);
        }

        [When(@"I remove (.*) product\(s\)")]
        public void WhenIRemoveProducts(int numberOfItems)
        {
            _mobileNavigation.CheckoutPage.ShoppingBag.RemoveProduct(numberOfItems);
            Thread.Sleep(Configuration.MilliSecondsToWait);
        }

        [Then(@"I have (.*) product\(s\) in the basket")]
        public void ThenIHaveProductsInTheBasket(int numberOfitems)
        {
            var itemsInBasket = _mobileNavigation.CheckoutPage.ShoppingBag.Products.Count;

            Assert.AreEqual(numberOfitems, itemsInBasket);
        }

        [When(@"I remove all products from the basket")]
        public void WhenIRemoveAllProductsFromTheBag()
        {
            _mobileNavigation.CheckoutPage.ShoppingBag.RemoveAllProducts();
        }

        [Then(@"The basket is empty")]
        public void ThenTheBasketIsEmpty()
        {
            var isEmpty = _mobileNavigation.CheckoutPage.ShoppingBag.IsEmpty.Displayed;

            Assert.True(isEmpty);
        }

    }
}
