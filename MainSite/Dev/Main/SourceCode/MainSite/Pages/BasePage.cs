using UAT.MainSite.Automation.MainSite.Pages.Panels;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages
{
    public class BasePage
    {
        private readonly WebDriverManager _webDriverManager;

        public BasePage(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            Header = new Header(_webDriverManager);
            Footer = new Footer(_webDriverManager);
        }

        public void Quit()
        {
            _webDriverManager.WebDriver.Quit();
        }

        public Header Header { get; }

        public Footer Footer { get; }
    }
}
