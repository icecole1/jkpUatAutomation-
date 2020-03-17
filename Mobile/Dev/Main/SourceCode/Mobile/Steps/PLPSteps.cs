using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages.Panels;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class PLPSteps
    {
        private readonly MobileNavigation _mobileNavigation;

        public PLPSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I am on the default product listing page")]
        public void GivenIAmOnTheDefaultProductListingPage()
        {
            _mobileNavigation.GoToProductListingPage(MenuData.Women, MenuData.Dresses);
        }

        [Then(@"The page displays products")]
        public void ThenThePageDisplaysProducts()
        {
            var isProductListDisplayed =  _mobileNavigation.ProductListingPage.IsDisplayed();

            Assert.True(isProductListDisplayed);
        }

        [Then(@"The model view is selected by default")]
        public void ThenTheModelViewIsSelectedByDefault()
        {
            var modelViewIsEnabled = _mobileNavigation.ProductListingPage.ModelView().Enabled;

            Assert.True(modelViewIsEnabled);
        }
        
        [Then(@"The sort by has the our favourites selected by default")]
        public void ThenTheSortByHasTheOurFavouritesSelectedByDefault()
        {
            _mobileNavigation.ProductListingPage.SortBy.Button.Click();
            var selectedOption = _mobileNavigation.ProductListingPage.SortBy.GetSelectedOption();

            Assert.AreEqual(Enums.SortBy.OurFavourites, selectedOption);
        }
    }
}
