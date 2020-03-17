using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAT.Mobile.Automation.Helpers;

namespace UAT.Mobile.Automation.Data
{
    public class ElementIdMapper
    {
        public string LoginHeaderButtonId()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.LoginHeaderButtonId;
                case Enums.Market.FR:
                    return FRMarketElementId.LoginHeaderButtonId;
                case Enums.Market.DE:
                    return DEMarketElementId.LoginHeaderButtonId;
                case Enums.Market.AU:
                    return AUMarketElementId.LoginHeaderButtonId;
                default:
                    return string.Empty;
            }
        }

        public string MenuHeaderButtonId()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.MenuHeaderButtonId;
                case Enums.Market.FR:
                    return FRMarketElementId.MenuHeaderButtonId;
                case Enums.Market.DE:
                    return DEMarketElementId.MenuHeaderButtonId;
                case Enums.Market.AU:
                    return AUMarketElementId.MenuHeaderButtonId;
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
                case Enums.Market.FR:
                    return FRMarketElementId.SignInNowHeaderMenuId;
                case Enums.Market.DE:
                    return DEMarketElementId.SignInNowHeaderMenuId;
                case Enums.Market.AU:
                    return AUMarketElementId.SignInNowHeaderMenuId;
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
                case Enums.Market.FR:
                    return FRMarketElementId.LogOutHeaderButtonId;
                case Enums.Market.DE:
                    return DEMarketElementId.LogOutHeaderButtonId;
                case Enums.Market.AU:
                    return AUMarketElementId.LogOutHeaderButtonId;
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
                case Enums.Market.FR:
                    return FRMarketElementId.SignOutHeaderMenuId;
                case Enums.Market.DE:
                    return DEMarketElementId.SignOutHeaderMenuId;
                case Enums.Market.AU:
                    return AUMarketElementId.SignOutHeaderMenuId;
                default:
                    return string.Empty;
            }
        }

        public string ShoppingBagHeaderButtonId()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.ShoppingBagHeaderButtonId;
                case Enums.Market.FR:
                    return FRMarketElementId.ShoppingBagHeaderButtonId;
                case Enums.Market.DE:
                    return DEMarketElementId.ShoppingBagHeaderButtonId;
                case Enums.Market.AU:
                    return AUMarketElementId.ShoppingBagHeaderButtonId;
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
                case Enums.Market.FR:
                    return FRMarketElementId.SignedInUserTextId;
                case Enums.Market.DE:
                    return DEMarketElementId.SignedInUserTextId;
                case Enums.Market.AU:
                    return AUMarketElementId.SignedInUserTextId;
                default:
                    return string.Empty;
            }
        }


        public string PLPNavigation()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.PLPNavigation;
                case Enums.Market.FR:
                    return FRMarketElementId.PLPNavigation;
                case Enums.Market.DE:
                    return DEMarketElementId.PLPNavigation;
                case Enums.Market.AU:
                    return AUMarketElementId.PLPNavigation;
                default:
                    return string.Empty;
            }
        }

        public string MainMenuSectionId()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return UKMarketElementId.MainMenuSectionId;
                case Enums.Market.FR:
                    return FRMarketElementId.MainMenuSectionId;
                case Enums.Market.DE:
                    return DEMarketElementId.MainMenuSectionId;
                case Enums.Market.AU:
                    return AUMarketElementId.MainMenuSectionId;
                default:
                    return string.Empty;
            }
        }
    }
}
