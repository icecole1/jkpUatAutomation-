using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UAT.MainSite.Automation.MainSite.Steps
{
    [Binding]
    public class FreeStuffStepscs
    {
        private readonly MainSiteNavigation _mainSiteNavigation;

        public FreeStuffStepscs()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);


        }


        [Then(@"i am taken to the free stuff page")]
        public void ThenIAmTakenToTheFreeStuffPage()
        {

         
            
          Assert.True(_mainSiteNavigation.FreeStuffPage.FreeStuffTitle.Text.Contains("Free stuff")); 
        }



    }
}
