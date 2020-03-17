using System;
using System.Linq;
using UAT.MainSite.Automation.Helpers;

namespace UAT.MainSite.Automation.Data
{
    public class DataFactory
    {
        private const string EmailPrefixMain = "bodentestautomation.";
        private const string EmailPrefixMobile = "bodentestautomation-mb.";

        public static string GenerateRandomEmailAddress()
        {
            var emailAddress = string.Concat(EmailPrefixMain, new Random().Next(1, 1000000), "@boden.", Configuration.Market.ToString().ToLower());
            return emailAddress;
        }

        public static string GetComputerNameEmailAddress(string account)
        {
            var email = string.Concat(EmailPrefixMain, Environment.MachineName,"-", account, "@boden.", Configuration.Market.ToString().ToLower());
            return email;
        }

        public static string GetComputerNameEmailAddressForMobile(string account)
        {
            var email = string.Concat(EmailPrefixMobile, Environment.MachineName, "-", account, "@boden.", Configuration.Market.ToString().ToLower());
            return email;
        }

        public static string AppendRandomNumberOntoVariable(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return string.Concat(value, new Random().Next(1, 1000000));        
            }

            return string.Empty;
        }

        public static string LeaveInPorchText()
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                case Enums.Market.AU:
                case Enums.Market.EU:
                case Enums.Market.US:
                    return UKCustomer.LeaveInPorch;
                case Enums.Market.FR:
                    return FRCustomer.LeaveInPorch;
                case Enums.Market.AT:
                case Enums.Market.DE:
                    return DECustomer.LeaveInPorch;
                default:
                    return UKCustomer.LeaveInPorch;
            }
        }
    }
}
