using System.Collections.Generic;
using System.Linq;
using AutomationData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages.Panels;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class ProductListingPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;

        public ProductListingPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            ProductDetailPage = new ProductDetailPage(_webDriverManager);

            SortBy = new SortBy(_webDriverManager);

            TrouserHemmingRepository = new TrouserHemmingRepository(Configuration.LogDbConnectionString);
        }

        public enum SelectProductIndex
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4,
            Fifth = 5,
            Sixth = 6,
            SecondRow = 7,
            Random = 99
        }

        public TrouserHemmingRepository TrouserHemmingRepository { get; set; }

        public ProductDetailPage ProductDetailPage { get; set; }

        public SortBy SortBy { get; set; }

        public IList<Product> Products()
        {
            IList<Product> products = new List<Product>();

            _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ProductListController")));

            //TODO: assign an id to get a handle on the product list web elements.
            var productElements = _webDriverManager.WebDriver.FindElements(By.XPath("//*[@id='product-items']/div[1]/div"));

            for (int i = 0; i < productElements.Count; i++)
            {
                products.Add(new Product(_webDriverManager,i));
            }

            return products;
        }

        public ProductListingPage SelectProduct(SelectProductIndex productIndex)
        {
            var product = new Product(_webDriverManager, (int) productIndex);

            _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(product.Link)).Click();

            return this;
        }

        public ProductListingPage SelectGiftCard()
        {
            var webElements = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(".//*[@id='product-items']/div[1]/div/div")));

            IWebElement giftCard;
            
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    giftCard = webElements.FirstOrDefault(x => x.GetAttribute("id") == "product-item-VOUCH-ERS");
                    break;
                case Enums.Market.US:
                    giftCard = webElements.FirstOrDefault(x => x.GetAttribute("id") == "product-item-GG001-GCD");
                    break;
                default:
                    giftCard = null;
                    break;
            }
              
            giftCard?.Click();

            return this;
        }

        public bool IsDisplayed()
        {
            List<IWebElement> elements = new List<IWebElement>();
            elements.Add(_webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ProductListController"))));

            if (elements.Count > 0)
            {
                return elements.ElementAt(0).Displayed;
            }
            return false;
        }


        public IWebElement ModelView()
        {
            return _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("st_plp_viewoptions_viewby_Styles")));
        }
    }
}
