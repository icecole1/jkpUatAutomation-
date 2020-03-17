using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.MainSite.Automation.Data;
using UAT.MainSite.Automation.Helpers;
using UAT.MainSite.Automation.WebDriver;

namespace UAT.MainSite.Automation.MainSite.Pages.Panels
{
    public class Header
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly ElementIdMapper _elementIdMapper;
        private readonly MenuIdMapper _menuIdMapper;

        public Header(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

      

            _elementIdMapper = new ElementIdMapper();
            _menuIdMapper = new MenuIdMapper();
        }

        public enum Segment
        {

            Home,
            AudioDramas,
            AboutUs,
            OurWork,
            Shop,
            ProductionBlog,
            ContactUs
        }

        public IWebElement Segments(Segment menuItem)
        {
            //return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='01545295987']//li[1]")));
            return _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//li[@id='{_menuIdMapper.GetMenuId(menuItem)}']")));

        }


    }
}