using System.Linq;
using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Steps
{
    [Binding]
    public class ContactUsPageSteps
    {
        private readonly MainSiteNavigation _mainSiteNavigation;

        public ContactUsPageSteps()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);
        }

        [Then(@"i am taken to the contact us page")]
        public void ThenIAmTakenToTheContactUsPage()
        {
           Assert.True(_mainSiteNavigation.ContactUsPage.ContactUsPageTitle.Text.Equals("Contact us")); 
        }

    }
}
