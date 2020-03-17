using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.MainSite.Automation.MainSite.Pages.Panels;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages
{
    public class AboutUsPage : BasePage

    {
    private readonly WebDriverManager _webDriverManager;
    private object get;

    public AboutUsPage(WebDriverManager webDriverManager) : base(webDriverManager)
    {
        PageFactory.InitElements(webDriverManager.WebDriver, this);
        _webDriverManager = webDriverManager;

    }

        public IWebElement AboutUsPageTitle => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='content']/article/div/div/div/div/section[1]/div[3]/div/div/div/div/div[1]/div/h2")));



    }
}
