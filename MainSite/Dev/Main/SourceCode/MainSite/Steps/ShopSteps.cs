using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UAT.MainSite.Automation.MainSite.Steps
{
    [Binding]
    public class ShopSteps
    {

        private readonly MainSiteNavigation _mainSiteNavigation;

        public ShopSteps()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);


        }


        [Then(@"I am taken to the Shoping Bag page")]
        public void ThenIAmTakenToTheShopingBagPage()
        {

          
            var displayed = _mainSiteNavigation.ShopPage.WooComerceWrapper.Displayed;
            Assert.That(displayed.Equals(true));
        }

    }
}
