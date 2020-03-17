using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.MainSite.Automation.Helpers;
using UAT.MainSite.Automation.MainSite.Pages.Panels;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages
{
    public class FreeStuffPage: BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private object get;
        private readonly UIHelper _uiHelper;

        public FreeStuffPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            PageFactory.InitElements(webDriverManager.WebDriver, this);
            _webDriverManager = webDriverManager;
            _uiHelper = new UIHelper(_webDriverManager.WebDriver);

        }


        public IWebElement FreeStuffTitle => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\'content\']/article/div/div/div/div/section[1]/div/div/div/div/div/div[1]/div/h2")));

        public void FreeStuffHeader()
        {

            try
            {


                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(
                    By.Id("19b46fe")));

                new Actions(_webDriverManager.WebDriver)
                    .MoveToElement(webElement)
                    .Build()
                    .Perform();

                //var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
                //jse.ExecuteScript("arguments[0].click();", webElement);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
