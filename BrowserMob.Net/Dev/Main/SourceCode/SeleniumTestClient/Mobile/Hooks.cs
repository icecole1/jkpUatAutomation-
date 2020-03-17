using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Mobile.Pages;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private static MobileNavigation _mobileNavigation;
        private static WebDriverManager _webDriverManager;

        public static WebDriverManager WebDriverManager
        {
            get
            {
                if (_webDriverManager?.WebDriver == null)
                {
                    _webDriverManager = WebDriverFactory.Get();
                }

                return _webDriverManager;
            }
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
           _mobileNavigation = new MobileNavigation(WebDriverManager);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //WebDriverManager.Teardown();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            GuestRegistrationPage.IsGuestCheckout = false;
            _mobileNavigation.ClearShoppingBag();
        }

        [AfterScenario]
        public void AfterScenario()
        {

        }
    }
}
