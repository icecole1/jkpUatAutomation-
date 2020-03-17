using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class Product
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly int _productIndex;

        public Product(WebDriverManager webDriverManager, int productIndex)
        {
            _webDriverManager = webDriverManager;
            _productIndex = productIndex;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        //TODO: assign an id to get a handle on the image webelement.
        public IWebElement Image => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='product-items']/div[1]/div[{_productIndex}]/div/div[1]/a/img")));

        //TODO: assign an id to get a handle on the link webelement.
        public IWebElement Link => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id='product-items']/div[1]/div[{_productIndex}]/div/div[1]/a")));
    }
}
