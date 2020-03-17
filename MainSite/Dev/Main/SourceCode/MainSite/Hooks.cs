using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UAT.MainSite.Automation.Helpers;
using UAT.MainSite.Automation.MainSite.Pages;
using UAT.MainSite.Automation.WebDriver;
using TestContext = NUnit.Framework.TestContext;

namespace UAT.MainSite.Automation.MainSite
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private static MainSiteNavigation _mainSiteNavigation;
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

       

        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebDriverManager.Teardown();
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
