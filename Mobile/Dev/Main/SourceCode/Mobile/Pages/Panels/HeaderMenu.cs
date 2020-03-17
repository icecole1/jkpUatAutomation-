using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    // TODO: this entire class and its dependecies need to be refactored once menu Id's have been added to mobile website.
    public class HeaderMenu
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly ElementIdMapper _elementIdMapper;

        public HeaderMenu(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _elementIdMapper = new ElementIdMapper();
        }

        public void MenuButtonClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='{_elementIdMapper.MenuHeaderButtonId()}']/div/div[1]/div/button")));

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .MoveToElement(webElement)
                .Perform();

            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }


        public void LoginButtonClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='{_elementIdMapper.LoginHeaderButtonId()}']/div/div[2]/div/div/div[1]/div/button")));

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .MoveToElement(webElement)
                .Perform();

            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        public void SignInNowButtonClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='{_elementIdMapper.SignInNowHeaderButtonId()}']/ul/li[1]/a")));

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .MoveToElement(webElement)
                .Perform();

            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        public void LogoutButtonClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='{_elementIdMapper.LogOutHeaderButtonId()}']/div/div[2]/div/div/div[1]/div/button")));

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .MoveToElement(webElement)
                .Perform();

            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        public IWebElement SignOutNowButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='{_elementIdMapper.SignOutHeaderButtonId()}']/ul/li[1]/a")));
        
        public void SignOutNowButtonClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='{_elementIdMapper.SignOutHeaderButtonId()}']/ul/li[1]/a")));

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .MoveToElement(webElement)
                .Perform();

            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        //TODO: assign id to get a handle on shoppingbag button.
        public void ShoppingBagClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='{_elementIdMapper.ShoppingBagHeaderButtonId()}']/div/div[2]/div/button")));

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .MoveToElement(webElement)
                .Perform();

            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        // Had to change menu selection to navigate via url, due to menu behaviour change of collapse when mouse hover is not within control boundar.
        public void SegmentCategory(string segment, string segmentCategory)
        {
            if (segmentCategory.ToLower() == MenuData.GiftVouchers.ToLower())
            {
                segment = "boden";
            }

            var url = Configuration.Environment + $"/{segment}-{segmentCategory}";

            _webDriverManager.WebDriver.Navigate().GoToUrl(url);
        }

        //public IWebElement Segments(string segment)
        //{
        //    var mainMenuItem = $".//*[@id='{_elementIdMapper.MainMenuSectionId()}']/ul/li//a/span[contains(text(), '{segment}')]/..";

        //    var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(mainMenuItem)));

        //    new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
        //        .MoveToElement(webElement)
        //        .Perform();

        //    return webElement;
        //}

        //public IWebElement SegmentCategory(string segmentCategory)
        //{
        //    var categoryMenuItem = $".//*[@id='header']/div[3]/div/ul/li//a[contains(text(), '{segmentCategory}')]";

        //    var webElement =  _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(categoryMenuItem)));

        //    new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
        //        .MoveToElement(webElement)
        //        .Perform();

        //    return webElement;
        //}
    }
}
