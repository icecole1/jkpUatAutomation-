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
    public class HomePage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private object get;
        private readonly UIHelper _uiHelper;

        public HomePage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            PageFactory.InitElements(webDriverManager.WebDriver, this);
            _webDriverManager = webDriverManager;
            _uiHelper = new UIHelper(_webDriverManager.WebDriver);

        }

        public IWebElement AboutMenuButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("menu-item-34")));

        public IWebElement OurWorkMenuButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("menu-item-28")));

        //public IWebElement BuyTheEbookButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("42fca68d")));

        public IWebElement ShopMenuButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("menu-item-30")));

        public IWebElement BlogMenuButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("menu-item-567")));

        public IWebElement FreeStuffMenuButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("menu-item-31")));

        public IWebElement ContactUsMenuButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("menu-item-33")));

        public IWebElement BuyTheEbookButton
        {
            get
            {
                IWebElement webElement = null;

                webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".elementor-button-icon.elementor-align-icon-left")));
                _uiHelper.ScrollToElement(webElement);

                //_preservedTotalPrice = webElement.Text;

                return webElement;
            }
        }


        public bool SharePannelIsDisplayed()
        {
            try
            {
                var webElement = _webDriverManager.Wait.Until(
                    ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("ytp-share-panel-inner-content")));

                if (webElement.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                // ignore..
                return false;
            }

        }

        public IWebElement SwitchToYoutubbeIFrame()
        {

            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("elementor-video-iframe")));
            _webDriverManager.WebDriver.SwitchTo().Frame(webElement);

            return webElement;
        }

        public void PlayButtonClick()
        {

            try
            {
                SwitchToYoutubbeIFrame();

                var webElement = _webDriverManager.Wait.Until(
                    ExpectedConditions.ElementIsVisible(By.ClassName("ytp-large-play-button ytp-button")));

                new Actions(_webDriverManager.WebDriver)
                    .MoveToElement(webElement)
                    .Perform();

                webElement.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShareButtonClick()
        {

            try
            {
                SwitchToYoutubbeIFrame();

                var webElement = _webDriverManager.Wait.Until(
                    ExpectedConditions.ElementToBeClickable(By.ClassName("ytp-share-icon")));

                new Actions(_webDriverManager.WebDriver)
                    .MoveToElement(webElement)
                    .Perform();

                webElement.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
      }

        public void PlayInFullScreenButton()
        {

            try
            {


                var webElement = _webDriverManager.Wait.Until(
                    ExpectedConditions.ElementToBeClickable(By.ClassName("ytp-fullscreen-button")));

                new Actions(_webDriverManager.WebDriver)
                    .MoveToElement(webElement)
                    .Build()
                    .Perform();

                var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
                jse.ExecuteScript("arguments[0].click();", webElement);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void JoinMailinglistButton()
        {

            try
            {


                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//*[@id='content']/article/div/div/div/div/section[7]/div/div/div[2]/div/div/div/div/div/a")));

                new Actions(_webDriverManager.WebDriver)
                    .MoveToElement(webElement)
                    .Build()
                    .Perform();

                var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
                jse.ExecuteScript("arguments[0].click();", webElement);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FaceBookShareButton()
        {

            try
            {


                var webElement =
                    _webDriverManager.Wait.Until(
                        ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='content']/article/div/div/div/div/section[5]/div/div/div[4]/div/div/div[2]/div/ul/li[2]/a")));

                new Actions(_webDriverManager.WebDriver)
                    .MoveToElement(webElement)
                    .Perform();

                webElement.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void TwitterShareButton()
                    {

                        try
                        {


                            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='content']/article/div/div/div/div/section[5]/div/div/div[4]/div/div/div[2]/div/ul/li[1]")));

                            new Actions(_webDriverManager.WebDriver)
                                .MoveToElement(webElement)
                                .Perform();

                            webElement.Click();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
        }

        public IWebElement ProgressBarValue => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ytp-time-current")));

        public string ExitFullScreen => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("ytp-fullscreen-button"))).GetAttribute("Title");

        public IWebElement MailinglistPage => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("templateContainer")));

        public IWebElement DonateButton => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='post-31']/div[2]/div[2]/div[5]/div/div/div[1]/div[4]/div/div[2]/div/div/form/p[3]/input")));

        public IWebElement TwitterSignInPage => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("update-form")));

    }
    
    }



