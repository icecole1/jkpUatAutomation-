using OpenQA.Selenium;
using UAT.Mobile.Automation.Data;

namespace UAT.Mobile.Automation.Helpers
{
    public class UIHelper
    {
        private readonly IWebDriver _webDriver;

        public UIHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void DismissModal(IWebElement webElement)
        {
            try
            {
                webElement.FindElement(By.ClassName("acsDeclineButton")).Click();
            }
            catch
            {
                // ignored
            }
        }

        public IWebElement ScrollToElement(IWebElement webElement, int offset = 0)
        {
            Scroll(0, webElement.Location.Y + offset);

            return webElement;
        }

        public void Scroll(int horizontal, int vertical)
        {
            var jse = (IJavaScriptExecutor)_webDriver;
            jse.ExecuteScript($"scroll({horizontal},{vertical})");

            //_webDriver.ExecuteJavaScript($"scroll({horizontal},{vertical})");
        }

        public string GetCountryCodeForCurrentMarket()
        {
            var market = Configuration.Market;

            switch (market)
            {
                case Enums.Market.UK:
                    return CountryCode.UnitedKingdom;
                case Enums.Market.AU:
                    return CountryCode.Australia;
                case Enums.Market.DE:
                    return CountryCode.Germany;
                case Enums.Market.FR:
                    return CountryCode.France;
                case Enums.Market.US:
                    return CountryCode.UnitedStates;
                default:
                    return string.Empty;
            }
        }
    }
}
