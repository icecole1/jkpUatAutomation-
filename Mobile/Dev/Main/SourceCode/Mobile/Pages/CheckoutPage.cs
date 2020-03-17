using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Mobile.Pages.Panels;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages
{
    public class CheckoutPage : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public CheckoutPage(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);

            DeliveryOption = new DeliveryOptions(_webDriverManager);
            ShoppingBag = new ShoppingBag(_webDriverManager);
            ContactDetails = new ContactDetails(_webDriverManager);
            Addresses = new Addresses(_webDriverManager);
            AddressCollapsed = new AddressesCollapsed(_webDriverManager);
            Payment = new Payment(_webDriverManager);
            GuestRegistrationPage = new GuestRegistrationPage(_webDriverManager);
            Staff = new Staff(_webDriverManager);
        }

        public IWebElement ContinueShopping => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.ClassName("coReturnUrl")));

        public IWebElement Email => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("Email")));

        public IWebElement Password => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("Password")));

        public IWebElement TotalValue => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.ClassName("coPListTotal")));

        public IWebElement SignIn => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("signIn")));

        public IWebElement OfferCode
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("code")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public IWebElement ApplyCode
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='coOfferCode']/div/form/div[1]/div/div/button")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public IWebElement Guest
        {
            get
            {
                GuestRegistrationPage.IsGuestCheckout = true;

                return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("coGuestButton")));
            }
        }

        public void FinishedContactClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("finishedContact")));
            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        public IWebElement PayPal => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("payPalCheckout")));

        public bool StockWarningDisplayed
        {
            get
            {
                try
                {
                    var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("coSbMsgStockWarning")));

                    _uiHelper.ScrollToElement(webElement);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IWebElement SubTotal
        {
            get
            {
                //var staleElement = true;
                //IWebElement webElement = null;

                //while (staleElement)
                //{
                //    try
                //    {
                        
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("shoppinBagSubtotal")));

                new Actions(_webDriverManager.WebDriver)
                    .MoveToElement(webElement)
                    .Perform();

                //        staleElement = false;
                //    }
                //    catch (StaleElementReferenceException e)
                //    {
                //        staleElement = true;
                //    }
                //}

                return webElement;
            }
        }

        public IWebElement DeliveryPrice
        {
            get
            {
                var staleElement = true;
                IWebElement webElement = null;

                while (staleElement)
                {
                    try
                    {
                        //TODO: assign id to get handle on shipping web element..
                        webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='coShoppingBag']/div/div[4]/p[3]/span")));

                        staleElement = false;

                        _uiHelper.ScrollToElement(webElement);
                    }
                    catch (StaleElementReferenceException e)
                    {
                        staleElement = true;
                    }
                }

                return webElement;
            }
        }       

        public static string PreservedTotalPrice { get; set; }

        public IWebElement TotalPrice
        {
            get
            {
                var staleElement = true;
                IWebElement webElement = null;

                while (staleElement)
                {
                    try
                    {
                        webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("shoppingBagTotalPrice")));

                        staleElement = false;

                        _uiHelper.ScrollToElement(webElement);
                    }
                    catch (StaleElementReferenceException e)
                    {
                        staleElement = true;
                    }
                }

                return webElement;
            }
        }

        public ContactDetails ContactDetails { get; }

        public Addresses Addresses { get; }

        public AddressesCollapsed AddressCollapsed { get; }

        public Payment Payment { get; }

        public GuestRegistrationPage GuestRegistrationPage { get; }

        public Staff Staff { get; }

        public void NextClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("finishedBag")));
            var jse = (IJavaScriptExecutor)_webDriverManager.WebDriver;
            jse.ExecuteScript("arguments[0].click();", webElement);
        }

        public DeliveryOptions DeliveryOption { get; set; }

        public ShoppingBag ShoppingBag { get; set; }

        public decimal GetTotalValue
        {
            get
            {
                var html = TotalValue.FindElement(By.TagName("span")).Text.Replace("£", "");
                return Convert.ToDecimal(html);
            }
        }

        public void Login(string emailAddress = "", string password = "")
        {
            Email.SendKeys(emailAddress);

            Password.SendKeys(password);

            SignIn.Click();

            PreservedTotalPrice = TotalPrice.Text;
        }
    }
}
