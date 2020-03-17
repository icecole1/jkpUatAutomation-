using System;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class Payment : BasePage
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public Payment(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);

            AccountCredit = new AccountCredit(_webDriverManager);
            GiftVoucher = new GiftVoucher(_webDriverManager);
            SavedCardPanel = new SavedCard(_webDriverManager);
        }

        public enum PaymentMode
        {
            Registered = 0,
            Guest = 1,
            New
        }

        public enum PaymentType
        {
            Card = 0,
            PayPal = 1
        }

        public IWebElement Panel()
        {
            try
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("paymentDetails")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
            catch
            {
                // ignored.
            }

            return null;
        }

        // TODO: need id to get handle on web element.
        public IWebElement CreditCardTab => _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='paymentDetails']/div/form/fieldset/div/div[2]/ul/li[1]")));

        // TODO: need id to get handle on web element.
        public IWebElement PayPalTab => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='paymentDetails']/div/form/fieldset/div/div[2]/ul/li[2]")));

        // TODO: need id to get handle on web element.
        public IWebElement OpenInvoiceTab
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='paymentDetails']/div/form/fieldset/div/div[2]/ul/li[3]")));

                new Actions(_webDriverManager.WebDriver)
                    .MoveToElement(webElement)
                    .Perform();
                
                return webElement;
            }
        }

        public IWebElement OpenInvoiceResult => _webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("OpenInvoiceResult")));

        public AccountCredit AccountCredit { get; set; }

        public GiftVoucher GiftVoucher { get; set; }

        // TODO: assign id to get a handle on the termsaccepted webelement.
        public IWebElement ApplyGiftVoucher => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementIsVisible(By.ClassName("coApGftCrdToggle")));

        public IWebElement CardNumber => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("CreditCard_NewCreditCard_CardNumber")));

        public IWebElement SecurityNumber => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("CreditCard_NewCreditCard_SecurityNumber")));

        public IWebElement CardholderName => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("CreditCard_NewCreditCard_CardholderName")));

        public IWebElement ExpiryMonth => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("CreditCard_NewCreditCard_ExpiryMonth")));

        public IWebElement ExpiryYear => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("CreditCard_NewCreditCard_ExpiryYear")));

        public IWebElement ShouldSaveCard => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("CreditCard_ShouldSaveCreditCard")));

        public Payment TermsAcceptedClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("TermsAccepted")));

            _uiHelper.ScrollToElement(webElement);

            Thread.Sleep(1000);

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .Click()
                .Perform();

            return this;
        }

        public Payment PrivacyPolicyClick()
        {
            var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("PrivacyPolicyAccepted")));

            _uiHelper.ScrollToElement(webElement);

            Thread.Sleep(1000);

            new Actions(_webDriverManager.WebDriver).MoveToElement(webElement)
                .Click()
                .Perform();

            return this;
        }

        public IWebElement PlaceYourOrder
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("placeOrder")));

                _uiHelper.ScrollToElement(webElement);

                return webElement;
            }
        }

        public SavedCard SavedCardPanel { get; set; }

        public IWebElement PaymentOption(PaymentType paymentType)
        {
            var paymentTypeIndex = (int) paymentType;
            //TODO: should be assigned id to get handle of paymentoptions webelement.
            return _webDriverManager.WebDriver.FindElement(
                By.XPath($".//*[@id='paymentDetails']/div/form/fieldset/div/div[2]/ul/li[{paymentTypeIndex}]"));
        }

        public Payment PopulatePaymentDetails(PaymentType paymentType)
        {
            if(Panel().Displayed)
            {
                switch (paymentType)
                {
                    case PaymentType.Card:
                        PopulatePaymentDetails();
                        break;
                    case PaymentType.PayPal:
                        break;
                }

                return this;
            }

            return this;
        }

        private void PopulatePaymentDetails()
        {
            // only enable if saved card is persisted for an account.
            //if (SavedCardPanel.Panel() != null)
            //{
            //    SavedCardPanel.SecurityNumber.SendKeys(Card.Visa1_CVV);
            //}
            //else
            //{

            new Actions(_webDriverManager.WebDriver)
                .MoveToElement(CardNumber)
                .Perform();

            // TODO: may need to remove switch, if all markets can use the same card.
            switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                    case Enums.Market.US:
                    case Enums.Market.DE:
                    case Enums.Market.AU:
                    case Enums.Market.FR:
                    CardNumber.SendKeys(Card.Visa1_CardNumber);
                        SecurityNumber.SendKeys(Card.Visa1_CVV);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                CardholderName.SendKeys(Card.CardHolderName);

                var creditCardExpiryMonth = new SelectElement(ExpiryMonth);
                creditCardExpiryMonth.SelectByValue("11");

                var creditCardExpiryYear = new SelectElement(ExpiryYear);
                creditCardExpiryYear.SelectByValue(DataHelper.GetYearInTwoDigits(DateTime.Now.AddYears(2)));
            //}
        }

        public bool IsEmpty()
        {
            var isEmpty = CardNumber.Text.Length == 0;
            if (isEmpty)
                return true;

            isEmpty = SecurityNumber.Text.Length == 0;
            if (isEmpty)
                return true;

            isEmpty = CardholderName.Text.Length == 0;
            return isEmpty;
        }

        public bool OpenInvoiceCreditAvailable()
        {
            try
            {
                // TODO: need to add and id or flag to element to indicate availability.
                return Regex.IsMatch(OpenInvoiceResult.Text, "[0-9]");
            }
            catch
            {
                // ignore...
                return false;
            }
        }
    }
}
