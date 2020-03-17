using System.Threading;
using System.Web.UI.WebControls.WebParts;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        public MobileNavigation ClearShoppingBag(string email = "", string password = "")
        {
            GoToHomePage();

            var clearBagUrl = string.Concat(Configuration.Environment, Constant.ClearBagURLSuffix);

            _webDriverManager.WebDriver.Navigate().GoToUrl(clearBagUrl);
            _webDriverManager.WebDriver.Manage().Cookies.DeleteAllCookies();
            _webDriverManager.WebDriver.Navigate().Back();

            _webDriverManager.WebDriver.Navigate().Refresh();

            if (!string.IsNullOrEmpty(email))
            {
                LoginClearShoppingBagLogout(email, password);
            }
            else
            {
                
                LoginClearShoppingBagLogout(CustomerData.EmailCreditCard, CustomerData.Password);
                LoginClearShoppingBagLogout(CustomerData.EmailAccountCredit, CustomerData.Password);

                switch (Configuration.Market)
                {
                    case Enums.Market.DE:
                        if (!Configuration.UsePreprod)
                        {
                            LoginClearShoppingBagLogout(CustomerData.EmailOpenInvoiceNeg, CustomerData.Password);
                            LoginClearShoppingBagLogout(CustomerData.EmailOpenInvoicePos, CustomerData.Password);
                        }
                        break;
                }
            }

            return this;
        }

        private void LoginClearShoppingBagLogout(string email, string password)
        {
           // GoToHomePage().HomePage.HeaderMenus.MenuButton.Click();
            GoToHomePage().HomePage.HeaderMenus.MenuButtonClick();
            HomePage.HeaderMenus.LoginButtonClick();
            HomePage.HeaderMenus.SignInNowButtonClick();

            LoginPage.Email.SendKeys(email);
            LoginPage.Password.SendKeys(password);
            LoginPage.SignInButtonClick();

            var clearBagUrl = string.Concat(Configuration.Environment, Constant.ClearBagURLSuffix);

            _webDriverManager.WebDriver.Navigate().GoToUrl(clearBagUrl);
            _webDriverManager.WebDriver.Navigate().Back();

            HomePage.HeaderMenus.MenuButtonClick();
            HomePage.HeaderMenus.LogoutButtonClick();
            HomePage.HeaderMenus.SignOutNowButtonClick();
        }

        public MobileNavigation GoToHomePage()
        {
            _webDriverManager.WebDriver.Navigate().GoToUrl(Configuration.Environment);

            return this;
        }

        public MobileNavigation GoToLoginPage()
        {
            GoToHomePage().HomePage.HeaderMenus.MenuButtonClick();
            HomePage.HeaderMenus.LoginButtonClick();
            return this;
        }

        public void GoToCheckoutPage()
        {
            ProductDetailPage.HeaderMenus.ShoppingBagClick();
        }

        public MobileNavigation GoToProductDetailPage(string styleCode)
        {
            _webDriverManager.WebDriver.Navigate().GoToUrl(string.Concat(Configuration.Environment, "/", styleCode));

            return this;
        }

        public MobileNavigation GoToProductListingPage(string mainMenu, string category = null)
        {
            HomePage.HeaderMenus.SegmentCategory(mainMenu, category);
           
            return this;
        }
    }
}
