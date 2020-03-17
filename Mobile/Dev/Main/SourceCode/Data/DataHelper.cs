using System;
using UAT.Mobile.Automation.Helpers;

namespace UAT.Mobile.Automation.Data
{
    public static class DataHelper
    {
        private const string EmailPrefix = "bodentestautomation-mb.";

        public static string GenerateRandomEmailAddress()
        {
            var emailAddress = string.Concat(EmailPrefix, new Random().Next(1, 1000000), "@boden.", Configuration.Market.ToString().ToLower());
            return emailAddress;
        }

        public static string GetComputerNameEmailAddress(string account)
        {
            var email = string.Concat(EmailPrefix, Environment.MachineName, "-", account, "@boden.", Configuration.Market.ToString().ToLower());
            return email;
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
            tempString = tempString.Replace("AUD", "");

            return tempString.Trim();
        }

        public static int GetGiftCardIndex(int cardValue, Enums.Market market)
        {
            switch (market)
            {
                case Enums.Market.US:
                case Enums.Market.AU:
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
                default:
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
