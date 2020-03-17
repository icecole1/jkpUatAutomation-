using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages;
using UAT.Mobile.Automation.Mobile.Steps;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private static MobileNavigation _mobileNavigation;
        private static WebDriverManager _webDriverManager;
        private string _screenShotFileName;

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

            // Reset static variables.
            DeliverySteps.OptionAvailable = true;
            CheckoutPage.PreservedTotalPrice = string.Empty;
            CalculateBasketSteps.ProductPrice = string.Empty;

            //Keyboard.SendKeyDown(Keyboard.KeyCode.CONTROL);
            //Keyboard.SendKeyDown(Keyboard.KeyCode.SHIFT);
            //Keyboard.SendKeyPress(Keyboard.KeyCode.KEY_M);
            //Keyboard.SendKeyUp(Keyboard.KeyCode.CONTROL);
            //Keyboard.SendKeyUp(Keyboard.KeyCode.SHIFT);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
           WebDriverManager.Teardown();
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
            if (TestContext.CurrentContext.Result.Outcome.Status == ResultState.Failure.Status)
            {
                // Take screenshot
                var path = string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\logs\screenshots\");

                var directoryInfo = new DirectoryInfo(path);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }

                var fullPath = string.Concat(path, _screenShotFileName);
                var screenshot = ((ITakesScreenshot)_webDriverManager.WebDriver).GetScreenshot();

                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
            }
        }

        private void DeleteScreenShot()
        {
            if (_screenShotFileName != string.Empty)
            {
                var filePath = string.Concat(AppDomain.CurrentDomain.BaseDirectory + @"\logs\screenshots\", _screenShotFileName);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}
