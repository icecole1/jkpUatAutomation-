using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UAT.Mobile.Automation.Mobile.Steps
{
    [Binding]
    public class TagsSteps
    {
        private readonly MobileNavigation _mobileNavigation;

        public TagsSteps()
        {
            _mobileNavigation = new MobileNavigation(Hooks.WebDriverManager);
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _mobileNavigation.GoToHomePage();
        }

        [Then(@"Adobe Target tag should exist on the page")]
        public void ThenAdobeTargetTagShouldExistOnThePage()
        {
            Assert.IsTrue(_mobileNavigation.HomePage.AdobeTargetTag.Enabled);
        }
    }
}
