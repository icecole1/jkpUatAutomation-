using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UAT.MainSite.Automation.MainSite.Steps
{
    [Binding]
    public class OurWorkSteps
    {

        private readonly MainSiteNavigation _mainSiteNavigation;

        public OurWorkSteps()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);


        }


        [Then(@"i am taken to the our work page")]
        public void ThenIAmTakenToTheOurWorkPage()
        {
            Assert.AreEqual(_mainSiteNavigation.OurWorkPage.OurWorkTitle.Text, "Our work");
        }

    }
}
