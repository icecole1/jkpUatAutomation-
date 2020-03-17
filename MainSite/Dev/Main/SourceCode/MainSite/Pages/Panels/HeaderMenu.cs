using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages.Panels
{
    public class HeaderMenu
    {
        private readonly WebDriverManager _webDriverManager;


        public HeaderMenu(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
            Staff = new StaffOrder(_webDriverManager);
        }

        public enum Segment
        {
            womensBtn,
            mensBtn,
            girlsBtn,
            boysBtn,
            babyBtn,
            childrenBtn,
            ClearanceBtn,
            blogBtn,
            magazineBtn
        }

        public StaffOrder Staff;

        public IWebElement LoginPanel => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("lgvMain_HyperLinkLogin")));

        public IWebElement LoginOutPanel => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("lgvMain_lnkAccountName")));

        public IWebElement SignIn => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementIsVisible(By.Id("lgvMain_LoginButton")));

        public IWebElement LogoutLink => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("lgvMain_LogoutLink")));

        public IWebElement AccountName => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementIsVisible(By.Id("lgvMain_lnkAccountName")));

        public IWebElement ShoppingBag => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("minibag_topBarShoppingBag")));

        public IWebElement SegmentCategory(string segmentCategory)
        {
            string categoryMenuItem = string.Empty;

            if (LoginPage.IsStaffLogin)
            {
                categoryMenuItem =
                    $"./html/body/div[2]/div[3]/div/div[1]/div[3]/div[3]//a[contains(text(), '{segmentCategory}')]";
            }
            else
            {
                categoryMenuItem =
                    $"./html/body/div[1]/div[3]/div/div[1]/div[3]/div[3]//a[contains(text(), '{segmentCategory}')]";
            }

            return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(categoryMenuItem)));
        }

        public IWebElement Segments(Segment menuItem)
        {
            return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(menuItem.ToString())));
        }

        public bool IsLoginOutPanelDisplayed
        {
            get
            {
                try
                {
                    return _webDriverManager.Wait
                        .Until(ExpectedConditions.ElementIsVisible(By.Id("lgvMain_lnkAccountName"))).Displayed;
                }
                catch
                {
                    // ignore...
                    return false;
                }

            }
        }
    }
}