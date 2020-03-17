using OpenQA.Selenium;

namespace UAT.MainSite.Automation.Helpers
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


        public void ScrollToElement(IWebElement webElement, int offset = 0)
        {
            Scroll(0, webElement.Location.Y + offset);
        }


        public void Scroll(int horizontal, int vertical)
        {
            var jse = (IJavaScriptExecutor)_webDriver;
            jse.ExecuteScript($"scroll({horizontal},{vertical})");

            //_webDriver.ExecuteJavaScript($"scroll({horizontal},{vertical})");
        }
    }
}
