using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Modals
{
    public class FeedbackModal
    {
        private readonly WebDriverManager _webDriverManager;

        public FeedbackModal(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        [FindsBy(How = How.ClassName, Using = "acsClassicInner")]
        public IWebElement LightboxContent;

        [FindsBy(How = How.ClassName, Using = "acsDeclineButton")]
        public IWebElement DeclineButton;

        public void CloseIfDisplayed()
        {
            try
            {
                _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("acsClassicInner")));

                if (LightboxContent.Displayed)
                {
                    _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(DeclineButton))
                        .Click();
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}
