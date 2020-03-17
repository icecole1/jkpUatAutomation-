using System.Linq;
using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UAT.MainSite.Automation.MainSite.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private readonly MainSiteNavigation _mainSiteNavigation;

        public HomePageSteps()
        {
            _mainSiteNavigation = new MainSiteNavigation(Hooks.WebDriverManager);


        }
    
        [When(@"I select join mailing list")]
        public void WhenISelectJoinMailingList()
        {
            _mainSiteNavigation.HomePage.JoinMailinglistButton();
        }

        [Then(@"you are taken to the join mailing list page")]
        public void ThenYouAreTakenToTheJoinMailingListPage()
        {
           Assert.True(_mainSiteNavigation.HomePage.MailinglistPage.Displayed); 
        }

        [When(@"I select the donate button")]
        public void WhenISelectTheDonateButton()
        {
            _mainSiteNavigation.HomePage.DonateButton.Click();
        }

        [When(@"I select the facebook tell a friend button")]
        public void WhenISelectTheFacebookTellAFriendButton()
        {
            
            _mainSiteNavigation.HomePage.FaceBookShareButton();
        }

        [When(@"I select the twitter tell a friend button")]
        public void WhenISelectTheTwitterTellAFriendButton()
        {
            _mainSiteNavigation.HomePage.TwitterShareButton();

            _mainSiteNavigation.WebDriverManager.WebDriver.SwitchTo()
                .Window(_mainSiteNavigation.WebDriverManager.WebDriver.WindowHandles.Last());
        }

        [Then(@"a new window is opened for twitter sign in")]
        public void ThenANewWindowIsOpenedForTwitterSignIn()
        {
            Thread.Sleep(2000);

            

            
            Assert.IsTrue(_mainSiteNavigation.HomePage.TwitterSignInPage.Text.ToLower().Contains("tweet"));
        }

        [When(@"i select the about button")]
        public void WhenISelectTheAboutButton()
        {
            _mainSiteNavigation.HomePage.AboutMenuButton.Click();
        }


        [Then(@"i am taken to the about us page")]
        public void ThenIAmTakenToTheAboutUsPage()
        {
           Assert.True(_mainSiteNavigation.AboutUsPage.AboutUsPageTitle.Text.ToLower().Contains("about us")); 
        }

        [When(@"I select the buy this ebook button")]
        public void WhenISelectTheBuyThisEbookButton()
        {
            _mainSiteNavigation.HomePage.BuyTheEbookButton.Click();
        }


        [When(@"i select the our work button on the menu bar")]
        public void WhenISelectTheOurWorkButtonOnTheMenuBar()
        {
            _mainSiteNavigation.HomePage.OurWorkMenuButton.Click();
        }

        [When(@"I select the shop button on the menu bar")]
        public void WhenISelectTheShopButtonOnTheMenuBar()
        {
            _mainSiteNavigation.HomePage.ShopMenuButton.Click();
        }


        [When(@"I select the blog button on the menu bar")]
        public void WhenISelectTheBlogButtonOnTheMenuBar()
        {
            _mainSiteNavigation.HomePage.BlogMenuButton.Click();
        }

        [When(@"i select the free stuff button on the menu bar")]
        public void WhenISelectTheFreeStuffButtonOnTheMenuBar()
        {
            _mainSiteNavigation.HomePage.FreeStuffMenuButton.Click();
        }

        [When(@"i select the contact us button")]
        public void WhenISelectTheContactUsButton()
        {
            _mainSiteNavigation.HomePage.ContactUsMenuButton.Click();
        }
    }
}

