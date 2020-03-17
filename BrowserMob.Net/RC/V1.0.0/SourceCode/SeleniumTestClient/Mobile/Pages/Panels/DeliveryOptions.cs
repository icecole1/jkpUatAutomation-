using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.Mobile.Pages.Modals;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class DeliveryOptions
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public DeliveryOptions(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);

            ClickAndCollectModal = new ClickAndCollectPostcodeModal(_webDriverManager);
            OtherInstructionsPanel = new OtherInstructions(_webDriverManager);
        }

        public enum Type
        {
            Standard,
            RoyalMail,
            Premium,
            Express,
            ExpressNoon,
            ClickAndCollect
        }

        public IWebElement Panel()
        {
            try
            {
                //TODO: assign id to get handle on panel webelement. 
                return _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("coShOptionsRBtnWrapper")));
            }
            catch
            {
                // ignored.
            }

            return null;
        }

        public ClickAndCollectPostcodeModal ClickAndCollectModal { get; set; }

        public OtherInstructions OtherInstructionsPanel { get; set; }

        public IWebElement Next
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("finishedBag")));

                _uiHelper.ScrollToElement(webElement,100);

                return webElement;
            }
        }

        public string ClickAndCollectionLocationText
        {
            get
            { 
                var webElement = Option(Configuration.Market, Type.ClickAndCollect);

                _uiHelper.ScrollToElement(webElement);

                var locationElement = webElement.FindElement(By.XPath("../label/div/ul/li[1]/span"));

                return locationElement.Text;
            }
        }

        public DeliveryOptions AddOtherInstructions(string instructions)
        {
            OtherInstructionsPanel.HasOtherInstructions.Click();
            OtherInstructionsPanel.OtherInstructionsText.SendKeys(instructions);
            OtherInstructionsPanel.Save.Click();

            return this;
        }

        public IWebElement Option(Enums.Market market, Type optionType)
        {
            if (Configuration.Market == market)
            {
                switch (market)
                {
                    case Enums.Market.UK:
                        return UKDeliveryOptions(optionType);
                    case Enums.Market.US:
                        return USDeliveryOptions(optionType);
                    case Enums.Market.DE:
                        return DEDeliveryOptions(optionType);
                    case Enums.Market.FR:
                        return FRDeliveryOptions(optionType);
                    default:
                        return null;
                }
            }

            return null;
        }

        private IWebElement UKDeliveryOptions(Type optionType)
        {
            IWebElement element;
            var optElements = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(".//*[@id='coShoppingBag']/div/div[2]/div/div/a/input")));

            switch (optionType)
            {
                case Type.Standard:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPUK01");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.RoyalMail:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPUK09");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.Express:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPUK02");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.ExpressNoon:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPUK23");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.ClickAndCollect:
                    element = optElements.Last();
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                default:
                    return null;
            }          
        }

        private IWebElement USDeliveryOptions(Type optionType)
        {
            IWebElement element;
            var optElements = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(".//*[@id='coShoppingBag']/div/div[2]/div/div/a/input")));

            switch (optionType)
            {
                case Type.Standard:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPUS05");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.Premium:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPUS28");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.Express:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPUS17");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                default:
                    return null;
            }
        }

        private IWebElement DEDeliveryOptions(Type optionType)
        {
            IWebElement element;
            var optElements = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(".//*[@id='coShoppingBag']/div/div[2]/div/div/a/input")));

            switch (optionType)
            {
                case Type.Standard:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPDE14");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.Express:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPDE26");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.ClickAndCollect:
                    element = optElements.Last();
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                default:
                    return null;
            }
        }

        private IWebElement FRDeliveryOptions(Type optionType)
        {
            IWebElement element;
            var optElements = _webDriverManager.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(".//*[@id='coShoppingBag']/div/div[2]/div/div/a/input")));

            switch (optionType)
            {
                case Type.Standard:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPFR19");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.Premium:
                    element = optElements.First(x => x.GetAttribute("value") == "SHIPFR29");
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                case Type.ClickAndCollect:
                    element = optElements.Last();
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                default:
                    return null;
            }
        }
    }
}
