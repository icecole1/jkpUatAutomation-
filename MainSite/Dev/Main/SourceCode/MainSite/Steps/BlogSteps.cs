using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UAT.MainSite.Automation.MainSite.Steps
{
    [Binding]
    public class BlogSteps
    {
        private readonly MainSiteNavigation _mainSiteNavigation;

        public BlogSteps()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);


        }


        [Then(@"I am taken to the blog page")]
        public void ThenIAmTakenToTheBlogPage()
        {
          Assert.True(_mainSiteNavigation.BlogPage.ItStartsWithBlogSnippet.Displayed);  
        }

    }
}
