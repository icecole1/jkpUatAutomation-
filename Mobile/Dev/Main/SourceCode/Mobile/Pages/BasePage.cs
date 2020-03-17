using UAT.Mobile.Automation.Mobile.Pages.Panels;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class BasePage
    {
        public BasePage(WebDriverManager webDriverManager)
        {
            HeaderMenus = new HeaderMenu(webDriverManager);
        }

        public HeaderMenu HeaderMenus { get; }
    }
}
