using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class SortBy
    {
        private readonly WebDriverManager _webDriverManager;

        public SortBy(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        //TODO: assign an id to get a handle on the menu category web elements.
        public IWebElement Button => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='st_plp_viewoptions_sort']/label/a")));
       
        //TODO: assign an id to get a handle on the menu category web elements
        public IReadOnlyCollection<IWebElement> Options => _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(".//*[@id='st_modal_sort_option-list']/li")));

        public IWebElement SelectedOption => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='st_modal_sort_option-list']/li[contains(@class, 'is-selected')]")));

        public Enums.SortBy GetSelectedOption()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                var current = Options.ElementAt(i);

                if (current.GetAttribute("class").Contains("is-selected"))
                {
                    var sortBy = (Enums.SortBy) Enum.ToObject(typeof(Enums.SortBy), i);
                    return sortBy;
                }
            }

            return Enums.SortBy.TopRated;
        }
    }
}
