using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class GiftVoucher : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public GiftVoucher(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        public IWebElement Number
            => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("giftVoucherNumber")));

        // TODO: assign id to get a handle on the termsaccepted webelement.
        public IWebElement Add
            => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("coAddGftCrdCd")));
    }
}
