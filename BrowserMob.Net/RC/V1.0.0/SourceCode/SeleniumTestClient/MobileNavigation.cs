using System.Threading;
using UAT.Mobile.Automation.Mobile.Pages;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages.Modals;
using UAT.Mobile.Automation.Mobile.Pages.Panels;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation
{
    public class MobileNavigation
    {
        private static WebDriverManager _webDriverManager;
        public readonly UIHelper UIHelper;

        public readonly LoginPage LoginPage;
        public readonly HomePage HomePage;
        public readonly RegistrationPage RegistrationPage;
        public readonly FeedbackModal FeedbackModal;
        public readonly MonetateModal MonetateModal;
        public readonly ProductListingPage ProductListingPage;
        public readonly ProductDetailPage ProductDetailPage;
        public readonly CheckoutPage CheckoutPage;
        public readonly Payment PaymentPage;
        public readonly OrderConfirmationPage OrderConfirmationPage;
        public readonly PayPalLoginPage PayPalLoginPage;
        public readonly PayPalLoginOptionPage PayPalLoginOptionPage;

        public WebDriverManager WebDriverManager => _webDriverManager;

        public MobileNavigation(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;

            UIHelper = new UIHelper(_webDriverManager.WebDriver);

            LoginPage = new LoginPage(_webDriverManager);
            HomePage = new HomePage(_webDriverManager);
            RegistrationPage = new RegistrationPage(_webDriverManager);
            FeedbackModal = new FeedbackModal(_webDriverManager);
            MonetateModal = new MonetateModal(_webDriverManager);
            ProductListingPage = new ProductListingPage(_webDriverManager);
            ProductDetailPage = new ProductDetailPage(_webDriverManager);
            CheckoutPage = new CheckoutPage(_webDriverManager);
            PaymentPage = new Payment(_webDriverManager);
            OrderConfirmationPage = new OrderConfirmationPage(_webDriverManager);
            PayPalLoginPage = new PayPalLoginPage(_webDriverManager);
            PayPalLoginOptionPage = new PayPalLoginOptionPage(_webDriverManager);
        }

        public MobileNavigation ClearShoppingBag(bool loggedInBag = false, string email = "", string password = "")
        {
            if (!loggedInBag)
            {
                GoToHomePage();

                var clearBagUrl = string.Concat(Configuration.Environment, Constant.ClearBagURLSuffix);

                _webDriverManager.WebDriver.Navigate().GoToUrl(clearBagUrl);
                _webDriverManager.WebDriver.Navigate().Back();
            }
            else
            {
                GoToHomePage().HomePage.HeaderMenus.LoginLogo.Click();
            
                LoginPage.Email.SendKeys(email);
                LoginPage.Password.SendKeys(password);
                LoginPage.SignIn.Click();

                var clearBagUrl = string.Concat(Configuration.Environment, Constant.ClearBagURLSuffix);

                _webDriverManager.WebDriver.Navigate().GoToUrl(clearBagUrl);
                _webDriverManager.WebDriver.Navigate().Back();        
            }

            _webDriverManager.WebDriver.Manage().Cookies.DeleteAllCookies();
            return this;
        }

        public MobileNavigation GoToHomePage()
        {
            _webDriverManager.WebDriver.Navigate().GoToUrl(Configuration.Environment);

            return this;
        }

        public MobileNavigation GoToLoginPage()
        {
            HomePage.HeaderMenus.LoginLogo.Click();

            return this;
        }

        public void GoToCheckoutPage()
        {
            try
            {
                //if (ProductDetailPage.CheckoutNotification.IsDisplayed())
                //{
                    ProductDetailPage.CheckoutNotification.GotoCheckout.Click();
                //}
                //else
                //{
                //    ProductDetailPage.HeaderMenus.ShoppingBag.Click();
                //}
            }
            catch
            {
                // ignore..
                Thread.Sleep(1000);

                ProductDetailPage.HeaderMenus.ShoppingBag?.Click();
            }
        }

        public MobileNavigation GoToProductDetailPage(string styleCode)
        {
            _webDriverManager.WebDriver.Navigate().GoToUrl(string.Concat(Configuration.Environment, "/", styleCode));

            return this;
        }

        public MobileNavigation GoToProductListingPage(HeaderMenu.Segment mainMenu, HeaderMenu.SegmentCategoryWomens categoryWomens)
        {
            UIHelper.ScrollToElement(HomePage.HeaderMenus.MainMenu, 200).Click();

            if (HomePage.HeaderMenus.SegmentCategoryWomensMenuItem(categoryWomens).Displayed)
            {
                HomePage.HeaderMenus.SegmentCategoryWomensMenuItem(categoryWomens).Click();
            }
            else
            {
                HomePage.HeaderMenus.Segments(mainMenu).Click();
                HomePage.HeaderMenus.SegmentCategoryWomensMenuItem(categoryWomens).Click();
            }

            return this;
        }

        public MobileNavigation GoToProductListingPage(HeaderMenu.Segment mainMenu, HeaderMenu.SegmentCategoryMens categoryMens)
        {
            HomePage.HeaderMenus.MainMenu.Click();

            if (HomePage.HeaderMenus.SegmentCategoryMensMenuItem(categoryMens).Displayed)
            {
                HomePage.HeaderMenus.SegmentCategoryMensMenuItem(categoryMens).Click();
            }
            else
            {
                HomePage.HeaderMenus.Segments(mainMenu).Click();
                HomePage.HeaderMenus.SegmentCategoryMensMenuItem(categoryMens).Click();
            }

            return this;
        }

        public MobileNavigation GoToProductListingPage(HeaderMenu.Segment mainMenu, HeaderMenu.SegmentCategoryClearance categoryClearance)
        {
            HomePage.HeaderMenus.MainMenu.Click();

            if (HomePage.HeaderMenus.SegmentCategoryClearanceMenuItem(categoryClearance).Displayed)
            {
                HomePage.HeaderMenus.SegmentCategoryClearanceMenuItem(categoryClearance).Click();
            }
            else
            {
                HomePage.HeaderMenus.Segments(mainMenu).Click();
                HomePage.HeaderMenus.SegmentCategoryClearanceMenuItem(categoryClearance).Click();
            }

            return this;
        }
    }
}
