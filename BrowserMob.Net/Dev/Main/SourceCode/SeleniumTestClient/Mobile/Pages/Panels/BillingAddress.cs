using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Data;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    public class BillingAddress
    {
        private readonly WebDriverManager _webDriverManager;
        private readonly UIHelper _uiHelper;

        public BillingAddress(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);

            _uiHelper = new UIHelper(_webDriverManager.WebDriver);
        }

        public void PopulatePostcodeLookup()
        {
            LookupPostcode.SendKeys(UKCustomer.Postcode);
        }

        // TODO: make unique for billing and delivery
        public IWebElement LookUpAddress => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("AddressLookUpSearch")));

        public SelectElement LookupResult => new SelectElement(_webDriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("LookupResult"))));

        //TODO: assign id to get handle on shipping web element..
        public IWebElement EnterAddressManually
        {
            get
            {
                Thread.Sleep(3000);
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("coChangeAddressEntrytoManual")));

                return webElement;
            }
        }

        public IWebElement AddNewAddress
        {
            get
            {
                var webElement = _webDriverManager.Wait.Until(ExpectedConditions.ElementExists(By.Id("coActionNewBillingAddress")));

                _uiHelper.ScrollToElement(webElement, 200);

                return webElement;
            }
        }

        public SelectElement Country => new SelectElement(_webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_CountryCode"))));

        public IWebElement AddressLine1 => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_AddressLine1")));

        public IWebElement AddressLine2 => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_AddressLine2")));

        public IWebElement AddressLine3 => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_AddressLine3")));

        public IWebElement AddressLine4 => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_AddressLine4")));

        public IWebElement AddressLine5 => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_AddressLine5")));

        public IWebElement Town => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_AddressLine5")));

        public IWebElement City => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_AddressLine5")));

        public IWebElement State => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_AddressLine6")));

        public IWebElement Postcode => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_Postcode")));

        public IWebElement ZipCode => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_Postcode")));

        public IWebElement LookupPostcode => _webDriverManager.Wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id("BillingAddress_AddressLookup_PostCode")));

        private bool CheckUKAddressIsEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine1);
            var isEmpty = AddressLine1.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine2.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = Town.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = Postcode.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            return true;
        }

        private bool CheckAUAddressIsEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine1);
            var isEmpty = AddressLine1.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine2.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine3.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine4.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine5.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = Postcode.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            return true;
        }

        private bool CheckUSAddressIsEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine3);
            var isEmpty = AddressLine3.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine4.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = City.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = State.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = ZipCode.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            return true;
        }

        private bool CheckDEAddressIsEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine1);
            var isEmpty = AddressLine1.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine2.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine3.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine4.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = Postcode.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            return true;
        }

        private bool CheckFRAddressIsEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine1);
            var isEmpty = AddressLine1.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine2.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine3.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = AddressLine4.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = City.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            isEmpty = Postcode.GetAttribute("value").Length == 0;
            if (!isEmpty)
                return false;

            return true;
        }

        public bool IsEmpty()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return CheckUKAddressIsEmpty();
                case Enums.Market.AU:
                    return CheckAUAddressIsEmpty();
                case Enums.Market.US:
                    return CheckUSAddressIsEmpty();
                case Enums.Market.DE:
                    return CheckDEAddressIsEmpty();
                case Enums.Market.FR:
                    return CheckFRAddressIsEmpty();
                default:
                    return true;
            }
        }

        private bool CheckUKAddressIsNotEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine1);
            //var isEmpty = AddressLine1.GetAttribute("value").Length == 0;
            //if (!isEmpty)
            //    return false;

            var isEmpty = AddressLine3.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            //isEmpty = AddressLine4.GetAttribute("value").Length == 0;
            //if (isEmpty)
            //    return false;

            isEmpty = Town.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = Postcode.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            return true;
        }

        private bool CheckAUAddressIsNotEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine1);
            var isEmpty = AddressLine1.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine2.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine3.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine4.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine5.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = Postcode.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            return true;
        }

        private bool CheckUSAddressIsNotEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine3);
            var isEmpty = AddressLine3.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine4.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = City.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = State.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = ZipCode.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            return true;
        }

        private bool CheckDEAddressIsNotEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine1);
            var isEmpty = AddressLine1.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine2.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine3.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine4.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = Postcode.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            return true;
        }

        private bool CheckFRAddressIsNotEmpty()
        {
            _uiHelper.ScrollToElement(AddressLine1);
            var isEmpty = AddressLine1.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine2.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine3.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = AddressLine4.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = City.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            isEmpty = Postcode.GetAttribute("value").Length == 0;
            if (isEmpty)
                return false;

            return true;
        }

        public bool IsNotEmpty()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return CheckUKAddressIsNotEmpty();
                case Enums.Market.AU:
                    return CheckAUAddressIsNotEmpty();
                case Enums.Market.US:
                    return CheckUSAddressIsNotEmpty();
                case Enums.Market.DE:
                    return CheckDEAddressIsNotEmpty();
                case Enums.Market.FR:
                    return CheckFRAddressIsNotEmpty();
                default:
                    return true;
            }
        }

        public void Populate()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    Country.SelectByValue(CountryCode.UnitedKingdom);

                    AddressLine1.SendKeys(CustomerData.AddressLine1);
                    AddressLine3.SendKeys(CustomerData.AddressLine3);
                    Town.SendKeys(CustomerData.City);
                    Postcode.SendKeys(CustomerData.Postcode);
                    break;
                case Enums.Market.US:
                    AddressLine3.SendKeys(CustomerData.AddressLine3);
                    AddressLine4.SendKeys(CustomerData.AddressLine4);
                    City.SendKeys(CustomerData.City);
                    State.SendKeys(CustomerData.State);
                    ZipCode.SendKeys(CustomerData.Postcode);
                    break;
                case Enums.Market.AU:
                    AddressLine1.SendKeys(CustomerData.AddressLine1);
                    AddressLine2.SendKeys(CustomerData.AddressLine2);
                    AddressLine3.SendKeys(CustomerData.AddressLine3);
                    AddressLine4.SendKeys(CustomerData.AddressLine4);
                    AddressLine5.SendKeys(CustomerData.State);
                    Postcode.SendKeys(CustomerData.Postcode);
                    break;
                case Enums.Market.DE:
                    AddressLine1.SendKeys(CustomerData.AddressLine1);
                    AddressLine2.SendKeys(CustomerData.AddressLine2);
                    AddressLine3.SendKeys(CustomerData.AddressLine3);
                    AddressLine4.SendKeys(CustomerData.AddressLine4);
                    Postcode.SendKeys(CustomerData.Postcode);
                    break;
                case Enums.Market.FR:
                    AddressLine1.SendKeys(CustomerData.AddressLine1);
                    AddressLine2.SendKeys(CustomerData.AddressLine2);
                    AddressLine3.SendKeys(CustomerData.AddressLine3);
                    AddressLine4.SendKeys(CustomerData.AddressLine4);
                    City.SendKeys(CustomerData.City);
                    Postcode.SendKeys(CustomerData.Postcode);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
