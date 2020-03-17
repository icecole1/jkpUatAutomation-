namespace UAT.MainSite.Automation.Helpers
{
    public class Enums
    {
        public enum CustomerAccountType
        {
            Regular,
            AccountCredit,
            OpenInvoicePos,
            OpenInvoiceNeg,
            ChangeAddress
        }

        public enum Market
        {
            // United Kingdom
            UK = 0,
            // Australia
            AU,
            // United States
            US,
            // Germany
            DE,
            // France
            FR,
            // Europe
            EU,
            // Austria
            AT
        }

        public enum GlobalEMarket
        {
            /// <summary>
            /// Japan
            /// </summary>
            JP,
            /// <summary>
            /// China
            /// </summary>
            CH,
            /// <summary>
            /// South Korea
            /// </summary>
            SK
        }

        public enum Colour
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4
        }

        public enum SizeTypes
        {
            Petite = 1,
            Regular = 2,
            Long = 3
        }

        public enum Sizes
        {
            Six = 1,
            Eight = 2,
            Ten = 3,
            Twelve = 4,
            Fourteen = 5,
            Sixteen = 6,
            Eighteen = 7,
            Twenty = 8,
            TwentyTwo = 9
        }
        
        public enum SortBy
        {
            TopRated = 0,
            OurFavourites,
            AlphabeticalAtoZ,
            AlphabeticalZtoA,
            PriceHighToLow,
            PriceLowToHigh
        }

        public enum LoginCredentialsEnum
        {
            WebCustomer,
            Csa,
            Staff
        }

        public enum HemmingOption
        {
            /// <summary>
            /// No Thanks
            /// </summary>
            NoThanks,
            /// <summary>
            /// Jeans
            /// </summary>
            JEA,
            /// <summary>
            /// Straight
            /// </summary>
            STR
        }

        public enum LegLength
        {
            /// <summary>
            /// 24½ inches
            /// </summary>
            H0000952,
            /// <summary>
            /// 25 inches
            /// </summary>
            H0000953,
            /// <summary>
            /// 25½ inches
            /// </summary>
            H0000954,
            /// <summary>
            /// 26 inches
            /// </summary>
            H0000955,
            /// <summary>
            /// 26½ inches
            /// </summary>
            H0000956,
            /// <summary>
            /// 27 inches
            /// </summary>
            H0000957,
            /// <summary>
            /// 27½ inches
            /// </summary>
            H0000958,
            /// <summary>
            /// 28 inches
            /// </summary>
            H0000959,
            /// <summary>
            /// 28½ inches
            /// </summary>
            H0000960,
            /// <summary>
            /// 29 inches
            /// </summary>
            H0000961,
            /// <summary>
            /// 29½ inches
            /// </summary>
            H0000962,
            /// <summary>
            /// 30 inches
            /// </summary>
            H0001035
        }

        public enum Location
        {
            First,
            Second,
            Third
        }

    }

}
