using OpenQA.Selenium.Interactions;
using UAT.MainSite.Automation.MainSite.Pages;
using UAT.MainSite.Automation.MainSite.Pages.Panels;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation
{
    public class MainSiteNavigation
    {
        private static WebDriverManager _webDriverManager;

        //public readonly LoginPage LoginPage;
        public readonly HomePage HomePage;
        public readonly AboutUsPage AboutUsPage;
        public readonly UDOMNgPdpPage UdomNgPdpPage;
        public readonly OurWorkPage OurWorkPage;
        public readonly ShopPage ShopPage;
        public readonly BlogPage BlogPage;
        public readonly FreeStuffPage FreeStuffPage;
        public readonly ContactUsPage ContactUsPage;


        //public readonly ProductDetailPage ProductDetailPage;
        //public readonly CheckoutPage CheckoutPage;
        //public readonly Payment PaymentPage;
        //public readonly OrderConfirmationPage OrderConfirmationPage;
        //public readonly GuestRegistrationPage GuestRegistrationPage;
        //public readonly MyAccountPage MyAccountPage;


        public WebDriverManager WebDriverManager => _webDriverManager;

        public MainSiteNavigation(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;

            //LoginPage = new LoginPage(_webDriverManager);
            HomePage = new HomePage(_webDriverManager);
            AboutUsPage = new AboutUsPage(_webDriverManager);
            UdomNgPdpPage = new UDOMNgPdpPage(_webDriverManager);
            OurWorkPage = new OurWorkPage(_webDriverManager);
            ShopPage = new ShopPage(_webDriverManager);
            BlogPage = new BlogPage(_webDriverManager);
            FreeStuffPage = new FreeStuffPage(_webDriverManager);
            ContactUsPage = new ContactUsPage(_webDriverManager);


            //RegistrationPage = new RegistrationPage(_webDriverManager);
            //ProductListingPage = new ProductListingPage(_webDriverManager);
            //ProductDetailPage = new ProductDetailPage(_webDriverManager);
            //CheckoutPage = new CheckoutPage(_webDriverManager);
            //PaymentPage = new Payment(_webDriverManager);
            //OrderConfirmationPage = new OrderConfirmationPage(_webDriverManager);
            //GuestRegistrationPage = new GuestRegistrationPage(_webDriverManager);
            //MyAccountPage = new MyAccountPage(_webDriverManager);
            //CheckoutFromMiniBag = new CheckoutFromMiniBag(_webDriverManager);
        }

        public MainSiteNavigation GoToHomePage()
        {
            {
                //WebDriverManager.WebDriver.Navigate().GoToUrl(Configuration.HttpsEnvironment);
                WebDriverManager.WebDriver.Navigate().GoToUrl(Configuration.Environment);
            }

            return this;
        }

        public MainSiteNavigation GoToMenuPage(Header.Segment mainMenu)
        {
            Actions action = new Actions(WebDriverManager.WebDriver);

            action.MoveToElement(HomePage.Header.Segments(mainMenu)).Click().Build().Perform();



            return this;
        }
    }

}





