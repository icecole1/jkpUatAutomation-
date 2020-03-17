using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Modals
{
    public class MonetateModal
    {
        private readonly WebDriverManager _webDriverManager;

        public MonetateModal(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(webDriverManager.WebDriver, this);
        }
        
        [FindsBy(How = How.Id, Using = "monetate_lightbox_mask")]
        public IWebElement LightboxMask;

        [FindsBy(How = How.Id, Using = "monetate_lightbox_content")]
        public IWebElement LightboxContent;

        public void CloseIfDisplayed()
        {
            try
            {
                if (LightboxMask.Displayed)
                {
                    _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(LightboxMask))
                        .Click();

                    _webDriverManager.WebDriver.Navigate().Refresh();
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}
