using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAT.MainSite.Automation.Helpers;

namespace UAT.MainSite.Automation.Data
{
    public class ElementIdMapper
    {
        public string LoginHeaderButtonId()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.LoginHeaderButtonId;
                case Enums.Market.US:
                    return USMarketElementId.LoginHeaderButtonId;
                case Enums.Market.FR:
                    return FRMarketElementId.LoginHeaderButtonId;
                case Enums.Market.DE:
                    return DEMarketElementId.LoginHeaderButtonId;
                case Enums.Market.AT:
                    return ATMarketElementId.LoginHeaderButtonId;
                case Enums.Market.AU:
                    return AUMarketElementId.LoginHeaderButtonId;
                case Enums.Market.EU:
                    return EUMarketElementId.LoginHeaderButtonId;
                default:
                    return string.Empty;
            }
        }

   

        public string SignInNowHeaderButtonId()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.SignInNowHeaderMenuId;
                case Enums.Market.US:
                    return USMarketElementId.SignInNowHeaderMenuId;
                case Enums.Market.FR:
                    return FRMarketElementId.SignInNowHeaderMenuId;
                case Enums.Market.DE:
                    return DEMarketElementId.SignInNowHeaderMenuId;
                case Enums.Market.AT:
                    return ATMarketElementId.SignInNowHeaderMenuId;
                case Enums.Market.AU:
                    return AUMarketElementId.SignInNowHeaderMenuId;
                case Enums.Market.EU:
                    return EUMarketElementId.SignInNowHeaderMenuId;
                default:
                    return string.Empty;
            }
        }

        public string LogOutHeaderButtonId()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.LogOutHeaderButtonId;
                case Enums.Market.US:
                    return USMarketElementId.LoginHeaderButtonId;
                case Enums.Market.FR:
                    return FRMarketElementId.LogOutHeaderButtonId;
                case Enums.Market.DE:
                    return DEMarketElementId.LogOutHeaderButtonId;
                case Enums.Market.AT:
                    return ATMarketElementId.LogOutHeaderButtonId;
                case Enums.Market.AU:
                    return AUMarketElementId.LogOutHeaderButtonId;
                case Enums.Market.EU:
                    return EUMarketElementId.LogOutHeaderButtonId;
                default:
                    return string.Empty;
            }
        }

        public string SignOutHeaderButtonId()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.SignOutHeaderMenuId;
                case Enums.Market.US:
                    return USMarketElementId.SignOutHeaderMenuId;
                case Enums.Market.FR:
                    return FRMarketElementId.SignOutHeaderMenuId;
                case Enums.Market.DE:
                    return DEMarketElementId.SignOutHeaderMenuId;
                case Enums.Market.AT:
                    return ATMarketElementId.SignOutHeaderMenuId;
                case Enums.Market.AU:
                    return AUMarketElementId.SignOutHeaderMenuId;
                case Enums.Market.EU:
                    return EUMarketElementId.SignOutHeaderMenuId;
                default:
                    return string.Empty;
            }
        }

        public string AddressBookButtonId()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.AddressBookButtonId;
                case Enums.Market.US:
                    return USMarketElementId.AddressBookButtonId;
                case Enums.Market.FR:
                    return FRMarketElementId.AddressBookButtonId;
                case Enums.Market.DE:
                    return DEMarketElementId.AddressBookButtonId;
                case Enums.Market.AT:
                    return ATMarketElementId.AddressBookButtonId;
                case Enums.Market.AU:
                    return AUMarketElementId.AddressBookButtonId;
                case Enums.Market.EU:
                    return EUMarketElementId.AddressBookButtonId;
                default:
                    return string.Empty;
            }
        }

        public string SignedInUserText()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.SignedInUserTextId;
                case Enums.Market.US:
                    return USMarketElementId.SignedInUserTextId;
                case Enums.Market.FR:
                    return FRMarketElementId.SignedInUserTextId;
                case Enums.Market.DE:
                    return DEMarketElementId.SignedInUserTextId;
                case Enums.Market.AT:
                    return ATMarketElementId.SignedInUserTextId;
                case Enums.Market.AU:
                    return AUMarketElementId.SignedInUserTextId;
                case Enums.Market.EU:
                    return EUMarketElementId.SignedInUserTextId;
                default:
                    return string.Empty;
            }
        }


        public string PlpNavigation()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.PlpNavigation;
                case Enums.Market.US:
                    return USMarketElementId.PlpNavigation;
                case Enums.Market.FR:
                    return FRMarketElementId.PlpNavigation;
                case Enums.Market.DE:
                    return DEMarketElementId.PlpNavigation;
                case Enums.Market.AT:
                    return ATMarketElementId.PlpNavigation;
                case Enums.Market.AU:
                    return AUMarketElementId.PlpNavigation;
                case Enums.Market.EU:
                    return EUMarketElementId.PlpNavigation;
                default:
                    return string.Empty;
            }
        }

        public string MiniBagTopBarShoppingBag()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.MiniBagTopBarShoppingBag;
                case Enums.Market.US:
                    return USMarketElementId.MiniBagTopBarShoppingBag;
                case Enums.Market.FR:
                    return FRMarketElementId.MiniBagTopBarShoppingBag;
                case Enums.Market.AT:
                    return ATMarketElementId.MiniBagTopBarShoppingBag;
                case Enums.Market.AU:
                    return AUMarketElementId.MiniBagTopBarShoppingBag;
                case Enums.Market.DE:
                    return DEMarketElementId.MiniBagTopBarShoppingBag;
                case Enums.Market.EU:
                    return EUMarketElementId.MiniBagTopBarShoppingBag;
                default:
                    return string.Empty;
            }
        }

        public string CheckoutFromMiniBagButton()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.CheckoutFromMiniBagButton;
                case Enums.Market.US:
                    return USMarketElementId.CheckoutFromMiniBagButton;
                case Enums.Market.FR:
                    return FRMarketElementId.CheckoutFromMiniBagButton;
                case Enums.Market.AT:
                    return ATMarketElementId.CheckOutFromMiniBagButton;
                case Enums.Market.AU:
                    return AUMarketElementId.CheckOutFromMiniBagButton;
                case Enums.Market.DE:
                    return DEMarketElementId.CheckOutFromMiniBagButton;
                case Enums.Market.EU:
                    return EUMarketElementId.CheckOutFromMiniBagButton;
                default:
                    return string.Empty;
            }
        }
    }

}
