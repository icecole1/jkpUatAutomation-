using System;
using UAT.Mobile.Automation.Helpers;

namespace UAT.Mobile.Automation.Data
{
    public static class DataHelper
    {
        public static string GenerateRandomEmailAddress()
        {
            // Gets email address from config and then injects a random number before the @ to ensure the email address is unique 
            var s = UKCustomer.EmailCreditCard;

            if (s != null)
            {
                var emailSegments = s.Split('@');
                var emailAddress = String.Concat("bodentestautomation.", new Random().Next(1, 1000000), "@", emailSegments[1]);
                return emailAddress;
            }

            return String.Empty;
        }

        public static string GetYearInTwoDigits(DateTime dateTime)
        {
            var year = Int32.Parse(dateTime.Year.ToString().Substring(2));

            return year.ToString();
        }

        public static string RemoveCurrencySymbol(string value)
        {
            var tempString = value.Replace("£", "");
            tempString = tempString.Replace("$", "");
            tempString = tempString.Replace("€", "");
            tempString = tempString.Replace("+", "");
            tempString = tempString.Replace("GBP", "");
            tempString = tempString.Replace("USD", "");
            tempString = tempString.Replace("EUR", "");

            return tempString.Trim();
        }

        public static int GetGiftCardIndex(int cardValue, Enums.Market market)
        {
            if (market == Enums.Market.US)
            {
                switch (cardValue)
                {
                    case 25:
                        return 0;
                    case 50:
                        return 1;
                    case 75:
                        return 2;
                    case 100:
                        return 3;
                    case 250:
                        return 4;
                    default:
                        return 0;
                }
            }
            else
            {
                switch (cardValue)
                {
                    case 10:
                        return 0;
                    case 20:
                        return 1;
                    case 50:
                        return 2;
                    case 100:
                        return 3;
                    default:
                        return 0;
                }
            }      
        }
    }
}
