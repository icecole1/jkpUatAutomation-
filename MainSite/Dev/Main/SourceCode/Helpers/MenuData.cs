using UAT.MainSite.Automation.Data;

namespace UAT.MainSite.Automation.Helpers
{
    public static class MenuData
    {
        public static string Accessories
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Accessories;
                    case Enums.Market.AU:
                        return AUMenu.Accessories;
                    case Enums.Market.US:
                        return USMenu.Accessories;
                    case Enums.Market.DE:
                        return DEMenu.Accessories;
                    case Enums.Market.FR:
                        return FRMenu.Accessories;
                    case Enums.Market.EU:
                        return EUMenu.Accessories;
                    case Enums.Market.AT:
                        return ATMenu.Accessories;
                    default:
                        return null;
                }
            }
        }

        public static string AllBabys
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.AllBabys;
                    case Enums.Market.AU:
                        return AUMenu.AllBabys;
                    case Enums.Market.US:
                        return USMenu.AllBabys;
                    case Enums.Market.DE:
                        return DEMenu.AllBabys;
                    case Enums.Market.FR:
                        return FRMenu.AllBabys;
                    case Enums.Market.EU:
                        return EUMenu.AllBabys;
                    case Enums.Market.AT:
                        return ATMenu.AllBabys;
                    default:
                        return null;
                }
            }
        }

        public static string AllBoys
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.AllBoys;
                    case Enums.Market.AU:
                        return AUMenu.AllBoys;
                    case Enums.Market.US:
                        return USMenu.AllBoys;
                    case Enums.Market.DE:
                        return DEMenu.AllBoys;
                    case Enums.Market.FR:
                        return FRMenu.AllBoys;
                    case Enums.Market.EU:
                        return EUMenu.AllBoys;
                    case Enums.Market.AT:
                        return ATMenu.AllBoys;
                    default:
                        return null;
                }
            }
        }

        public static string AllGirls
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.AllGirls;
                    case Enums.Market.AU:
                        return AUMenu.AllGirls;
                    case Enums.Market.US:
                        return USMenu.AllGirls;
                    case Enums.Market.DE:
                        return DEMenu.AllGirls;
                    case Enums.Market.FR:
                        return FRMenu.AllGirls;
                    case Enums.Market.EU:
                        return EUMenu.AllGirls;
                    case Enums.Market.AT:
                        return ATMenu.AllGirls;
                    default:
                        return null;
                }
            }
        }

        public static string Baby
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Baby;
                    case Enums.Market.AU:
                        return AUMenu.Baby;
                    case Enums.Market.US:
                        return USMenu.Baby;
                    case Enums.Market.DE:
                        return DEMenu.Baby;
                    case Enums.Market.FR:
                        return FRMenu.Baby;
                    case Enums.Market.EU:
                        return EUMenu.Baby;
                    case Enums.Market.AT:
                        return ATMenu.Baby;
                    default:
                        return null;
                }
            }
        }

        public static string BabyBodenBoys
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.BabyBodenBoys;
                    case Enums.Market.AU:
                        return AUMenu.BabyBodenBoys;
                    case Enums.Market.US:
                        return USMenu.BabyBodenBoys;
                    case Enums.Market.DE:
                        return DEMenu.BabyBodenBoys;
                    case Enums.Market.FR:
                        return FRMenu.BabyBodenBoys;
                    case Enums.Market.EU:
                        return EUMenu.BabyBodenBoys;
                    case Enums.Market.AT:
                        return ATMenu.BabyBodenBoys;
                    default:
                        return null;
                }
            }
        }

        public static string BabyBodenGirls
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.BabyBodenGirls;
                    case Enums.Market.AU:
                        return AUMenu.BabyBodenGirls;
                    case Enums.Market.US:
                        return USMenu.BabyBodenGirls;
                    case Enums.Market.DE:
                        return DEMenu.BabyBodenGirls;
                    case Enums.Market.FR:
                        return FRMenu.BabyBodenGirls;
                    case Enums.Market.EU:
                        return EUMenu.BabyBodenGirls;
                    case Enums.Market.AT:
                        return ATMenu.BabyBodenGirls;
                    default:
                        return null;
                }
            }
        }

        public static string BabysFirstChristmas
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.BabysFirstChristmas;
                    case Enums.Market.AU:
                        return AUMenu.BabysFirstChristmas;
                    case Enums.Market.US:
                        return USMenu.BabysFirstChristmas;
                    case Enums.Market.DE:
                        return DEMenu.BabysFirstChristmas;
                    case Enums.Market.FR:
                        return FRMenu.BabysFirstChristmas;
                    case Enums.Market.EU:
                        return EUMenu.BabysFirstChristmas;
                    case Enums.Market.AT:
                        return ATMenu.BabysFirstChristmas;
                    default:
                        return null;
                }
            }
        }

        public static string Blog
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Blog;
                    case Enums.Market.AU:
                        return AUMenu.Blog;
                    case Enums.Market.US:
                        return USMenu.Blog;
                    case Enums.Market.DE:
                        return DEMenu.Blog;
                    case Enums.Market.FR:
                        return FRMenu.Blog;
                    case Enums.Market.EU:
                        return EUMenu.Blog;
                    case Enums.Market.AT:
                        return ATMenu.Blog;
                    default:
                        return null;
                }
            }
        }

        public static string BodenAndCowshed
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.BodenAndCowshed;
                    case Enums.Market.AU:
                        return AUMenu.BodenAndCowshed;
                    case Enums.Market.US:
                        return USMenu.BodenAndCowshed;
                    case Enums.Market.DE:
                        return DEMenu.BodenAndCowshed;
                    case Enums.Market.FR:
                        return FRMenu.BodenAndCowshed;
                    case Enums.Market.EU:
                        return EUMenu.BodenAndCowshed;
                    case Enums.Market.AT:
                        return ATMenu.BodenAndCowshed;
                    default:
                        return null;
                }
            }
        }

        public static string Boys
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Boys;
                    case Enums.Market.AU:
                        return AUMenu.Boys;
                    case Enums.Market.US:
                        return USMenu.Boys;
                    case Enums.Market.DE:
                        return DEMenu.Boys;
                    case Enums.Market.FR:
                        return FRMenu.Boys;
                    case Enums.Market.EU:
                        return EUMenu.Boys;
                    case Enums.Market.AT:
                        return ATMenu.Boys;
                    default:
                        return null;
                }
            }
        }

        public static string CashmereShop
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.CashmereShop;
                    case Enums.Market.AU:
                        return AUMenu.CashmereShop;
                    case Enums.Market.US:
                        return USMenu.CashmereShop;
                    case Enums.Market.DE:
                        return DEMenu.CashmereShop;
                    case Enums.Market.FR:
                        return FRMenu.CashmereShop;
                    case Enums.Market.EU:
                        return EUMenu.CashmereShop;
                    case Enums.Market.AT:
                        return ATMenu.CashmereShop;
                    default:
                        return null;
                }
            }
        }

        public static string Children
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Children;
                    case Enums.Market.AU:
                        return AUMenu.Children;
                    case Enums.Market.US:
                        return USMenu.Children;
                    case Enums.Market.DE:
                        return DEMenu.Children;
                    case Enums.Market.FR:
                        return FRMenu.Children;
                    case Enums.Market.EU:
                        return EUMenu.Children;
                    case Enums.Market.AT:
                        return ATMenu.Children;
                    default:
                        return null;
                }
            }
        }

        public static string Christmas
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Christmas;
                    case Enums.Market.AU:
                        return AUMenu.Christmas;
                    case Enums.Market.US:
                        return USMenu.Christmas;
                    case Enums.Market.DE:
                        return DEMenu.Christmas;
                    case Enums.Market.FR:
                        return FRMenu.Christmas;
                    case Enums.Market.EU:
                        return EUMenu.Christmas;
                    case Enums.Market.AT:
                        return ATMenu.Christmas;
                    default:
                        return null;
                }
            }
        }

        public static string ChristmasDayDressing
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.ChristmasDayDressing;
                    case Enums.Market.AU:
                        return AUMenu.ChristmasDayDressing;
                    case Enums.Market.US:
                        return USMenu.ChristmasDayDressing;
                    case Enums.Market.DE:
                        return DEMenu.ChristmasDayDressing;
                    case Enums.Market.FR:
                        return FRMenu.ChristmasDayDressing;
                    case Enums.Market.EU:
                        return EUMenu.ChristmasDayDressing;
                    case Enums.Market.AT:
                        return ATMenu.ChristmasDayDressing;
                    default:
                        return null;
                }
            }
        }

        public static string ChristmasKnits
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.ChristmasKnits;
                    case Enums.Market.AU:
                        return AUMenu.ChristmasKnits;
                    case Enums.Market.US:
                        return USMenu.ChristmasKnits;
                    case Enums.Market.DE:
                        return DEMenu.ChristmasKnits;
                    case Enums.Market.FR:
                        return FRMenu.ChristmasKnits;
                    case Enums.Market.EU:
                        return EUMenu.ChristmasKnits;
                    case Enums.Market.AT:
                        return ATMenu.ChristmasKnits;
                    default:
                        return null;
                }
            }
        }

        public static string Clearance
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Clearance;
                    case Enums.Market.AU:
                        return AUMenu.Clearance;
                    case Enums.Market.US:
                        return USMenu.Clearance;
                    case Enums.Market.DE:
                        return DEMenu.Clearance;
                    case Enums.Market.FR:
                        return FRMenu.Clearance;
                    case Enums.Market.EU:
                        return EUMenu.ChristmasKnits;
                    case Enums.Market.AT:
                        return ATMenu.ChristmasKnits;
                    default:
                        return null;
                }
            }
        }

        public static string CoatsAndJackets
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.CoatsAndJackets;
                    case Enums.Market.AU:
                        return AUMenu.CoatsAndJackets;
                    case Enums.Market.US:
                        return USMenu.CoatsAndJackets;
                    case Enums.Market.DE:
                        return DEMenu.CoatsAndJackets;
                    case Enums.Market.FR:
                        return FRMenu.CoatsAndJackets;
                    case Enums.Market.EU:
                        return EUMenu.CoatsAndJackets;
                    case Enums.Market.AT:
                        return ATMenu.CoatsAndJackets;
                    default:
                        return null;
                }
            }
        }

        public static string Dresses
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.DressesCategoryId;
                    case Enums.Market.AU:
                        return AUMenu.DressesCategoryId;
                    case Enums.Market.US:
                        return USMenu.DressesCategoryId;
                    case Enums.Market.DE:
                        return DEMenu.DressesCategoryId;
                    case Enums.Market.FR:
                        return FRMenu.DressesCategoryId;
                    case Enums.Market.EU:
                        return EUMenu.DressesCategoryId;
                    case Enums.Market.AT:
                        return ATMenu.DressesCategoryId;
                    default:
                        return null;
                }
            }
        }

        public static string GiftVouchers
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.GiftVouchers;
                    case Enums.Market.AU:
                        return AUMenu.GiftVouchers;
                    case Enums.Market.US:
                        return USMenu.GiftVouchers;
                    case Enums.Market.DE:
                        return DEMenu.GiftVouchers;
                    case Enums.Market.FR:
                        return FRMenu.GiftVouchers;
                    case Enums.Market.EU:
                        return EUMenu.GiftVouchers;
                    case Enums.Market.AT:
                        return ATMenu.GiftVouchers;
                    default:
                        return null;
                }
            }
        }

        public static string Gifting
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Gifting;
                    case Enums.Market.AU:
                        return AUMenu.Gifting;
                    case Enums.Market.US:
                        return USMenu.Gifting;
                    case Enums.Market.DE:
                        return DEMenu.Gifting;
                    case Enums.Market.FR:
                        return FRMenu.Gifting;
                    case Enums.Market.EU:
                        return EUMenu.Gifting;
                    case Enums.Market.AT:
                        return ATMenu.Gifting;
                    default:
                        return null;
                }
            }
        }

        public static string GiftsForBoys
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.GiftsForBoys;
                    case Enums.Market.AU:
                        return AUMenu.GiftsForBoys;
                    case Enums.Market.US:
                        return USMenu.GiftsForBoys;
                    case Enums.Market.DE:
                        return DEMenu.GiftsForBoys;
                    case Enums.Market.FR:
                        return FRMenu.GiftsForBoys;
                    case Enums.Market.EU:
                        return EUMenu.GiftsForBoys;
                    case Enums.Market.AT:
                        return ATMenu.GiftsForBoys;
                    default:
                        return null;
                }
            }
        }

        public static string GiftsForGirls
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.GiftsForGirls;
                    case Enums.Market.AU:
                        return AUMenu.GiftsForGirls;
                    case Enums.Market.US:
                        return USMenu.GiftsForGirls;
                    case Enums.Market.DE:
                        return DEMenu.GiftsForGirls;
                    case Enums.Market.FR:
                        return FRMenu.GiftsForGirls;
                    case Enums.Market.EU:
                        return EUMenu.GiftsForGirls;
                    case Enums.Market.AT:
                        return ATMenu.GiftsForGirls;
                    default:
                        return null;
                }
            }
        }

        public static string GiftsForHer
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.GiftsForHer;
                    case Enums.Market.AU:
                        return AUMenu.GiftsForHer;
                    case Enums.Market.US:
                        return USMenu.GiftsForHer;
                    case Enums.Market.DE:
                        return DEMenu.GiftsForHer;
                    case Enums.Market.FR:
                        return FRMenu.GiftsForHer;
                    case Enums.Market.EU:
                        return EUMenu.GiftsForHer;
                    case Enums.Market.AT:
                        return ATMenu.GiftsForHer;
                    default:
                        return null;
                }
            }
        }

        public static string GiftsForHim
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.GiftsForHim;
                    case Enums.Market.AU:
                        return AUMenu.GiftsForHim;
                    case Enums.Market.US:
                        return USMenu.GiftsForHim;
                    case Enums.Market.DE:
                        return DEMenu.GiftsForHim;
                    case Enums.Market.FR:
                        return FRMenu.GiftsForHim;
                    case Enums.Market.EU:
                        return EUMenu.GiftsForHim;
                    case Enums.Market.AT:
                        return ATMenu.GiftsForHim;
                    default:
                        return null;
                }
            }
        }

        public static string GiftsForHome
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.GiftsForHome;
                    case Enums.Market.AU:
                        return AUMenu.GiftsForHome;
                    case Enums.Market.US:
                        return USMenu.GiftsForHome;
                    case Enums.Market.DE:
                        return DEMenu.GiftsForHome;
                    case Enums.Market.FR:
                        return FRMenu.GiftsForHome;
                    case Enums.Market.EU:
                        return EUMenu.GiftsForHome;
                    case Enums.Market.AT:
                        return ATMenu.GiftsForHome;
                    default:
                        return null;
                }
            }
        }

        public static string Girls
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Girls;
                    case Enums.Market.AU:
                        return AUMenu.Girls;
                    case Enums.Market.US:
                        return USMenu.Girls;
                    case Enums.Market.DE:
                        return DEMenu.Girls;
                    case Enums.Market.FR:
                        return FRMenu.Girls;
                    case Enums.Market.EU:
                        return EUMenu.Girls;
                    case Enums.Market.AT:
                        return ATMenu.Girls;
                    default:
                        return null;
                }
            }
        }

        public static string Handbags
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Handbags;
                    case Enums.Market.AU:
                        return AUMenu.Handbags;
                    case Enums.Market.US:
                        return USMenu.Handbags;
                    case Enums.Market.DE:
                        return DEMenu.Handbags;
                    case Enums.Market.FR:
                        return FRMenu.Handbags;
                    case Enums.Market.EU:
                        return EUMenu.Handbags;
                    case Enums.Market.AT:
                        return ATMenu.Handbags;
                    default:
                        return null;
                }
            }
        }

        public static string Homeware
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Homeware;
                    case Enums.Market.AU:
                        return AUMenu.Homeware;
                    case Enums.Market.US:
                        return USMenu.Homeware;
                    case Enums.Market.DE:
                        return DEMenu.Homeware;
                    case Enums.Market.FR:
                        return FRMenu.Homeware;
                    case Enums.Market.EU:
                        return EUMenu.Homeware;
                    case Enums.Market.AT:
                        return ATMenu.Homeware;
                    default:
                        return null;
                }
            }
        }

        public static string Jeans
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Jeans;
                    case Enums.Market.AU:
                        return AUMenu.Jeans;
                    case Enums.Market.US:
                        return USMenu.Jeans;
                    case Enums.Market.DE:
                        return DEMenu.Jeans;
                    case Enums.Market.FR:
                        return FRMenu.Jeans;
                    case Enums.Market.EU:
                        return EUMenu.Jeans;
                    case Enums.Market.AT:
                        return ATMenu.Jeans;
                    default:
                        return null;
                }
            }
        }

        public static string JohnnieBBoys
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.JohnnieBBoys;
                    case Enums.Market.AU:
                        return AUMenu.JohnnieBBoys;
                    case Enums.Market.US:
                        return USMenu.JohnnieBBoys;
                    case Enums.Market.DE:
                        return DEMenu.JohnnieBBoys;
                    case Enums.Market.FR:
                        return FRMenu.JohnnieBBoys;
                    case Enums.Market.EU:
                        return EUMenu.JohnnieBBoys;
                    case Enums.Market.AT:
                        return ATMenu.JohnnieBBoys;
                    default:
                        return null;
                }
            }
        }

        public static string JohnnieBGirls
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.JohnnieBGirls;
                    case Enums.Market.AU:
                        return AUMenu.JohnnieBGirls;
                    case Enums.Market.US:
                        return USMenu.JohnnieBGirls;
                    case Enums.Market.DE:
                        return DEMenu.JohnnieBGirls;
                    case Enums.Market.FR:
                        return FRMenu.JohnnieBGirls;
                    case Enums.Market.EU:
                        return EUMenu.JohnnieBGirls;
                    case Enums.Market.AT:
                        return ATMenu.JohnnieBGirls;
                    default:
                        return null;
                }
            }
        }

        public static string Knitware
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Knitware;
                    case Enums.Market.AU:
                        return AUMenu.Knitware;
                    case Enums.Market.US:
                        return USMenu.Knitware;
                    case Enums.Market.DE:
                        return DEMenu.Knitware;
                    case Enums.Market.FR:
                        return FRMenu.Knitware;
                    case Enums.Market.EU:
                        return EUMenu.Knitware;
                    case Enums.Market.AT:
                        return ATMenu.Knitware;
                    default:
                        return null;
                }
            }
        }

        public static string Leggings
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Leggings;
                    case Enums.Market.AU:
                        return AUMenu.Leggings;
                    case Enums.Market.US:
                        return USMenu.Leggings;
                    case Enums.Market.DE:
                        return DEMenu.Leggings;
                    case Enums.Market.FR:
                        return FRMenu.Leggings;
                    case Enums.Market.EU:
                        return EUMenu.Leggings;
                    case Enums.Market.AT:
                        return ATMenu.Leggings;
                    default:
                        return null;
                }
            }
        }

        public static string Men
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.MenMenuId;
                    case Enums.Market.AU:
                        return AUMenu.MenMenuId;
                    case Enums.Market.US:
                        return USMenu.MenMenuId;
                    case Enums.Market.DE:
                        return DEMenu.MenMenuId;
                    case Enums.Market.FR:
                        return FRMenu.MenMenuId;
                    case Enums.Market.EU:
                        return EUMenu.MenMenuId;
                    case Enums.Market.AT:
                        return ATMenu.MenMenuId;
                    default:
                        return null;
                }
            }
        }

        public static string MiniBodenBoys
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.MiniBodenBoys;
                    case Enums.Market.AU:
                        return AUMenu.MiniBodenBoys;
                    case Enums.Market.US:
                        return USMenu.MiniBodenBoys;
                    case Enums.Market.DE:
                        return DEMenu.MiniBodenBoys;
                    case Enums.Market.FR:
                        return FRMenu.MiniBodenBoys;
                    case Enums.Market.EU:
                        return EUMenu.MiniBodenBoys;
                    case Enums.Market.AT:
                        return ATMenu.MiniBodenBoys;
                    default:
                        return null;
                }
            }
        }

        public static string MiniBodenGirls
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.MiniBodenGirls;
                    case Enums.Market.AU:
                        return AUMenu.MiniBodenGirls;
                    case Enums.Market.US:
                        return USMenu.MiniBodenGirls;
                    case Enums.Market.DE:
                        return DEMenu.MiniBodenGirls;
                    case Enums.Market.FR:
                        return FRMenu.MiniBodenGirls;
                    case Enums.Market.EU:
                        return EUMenu.MiniBodenGirls;
                    case Enums.Market.AT:
                        return ATMenu.MiniBodenGirls;
                    default:
                        return null;
                }
            }
        }

        public static string NewBorn
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Newborn;
                    case Enums.Market.AU:
                        return AUMenu.Newborn;
                    case Enums.Market.US:
                        return USMenu.Newborn;
                    case Enums.Market.DE:
                        return DEMenu.Newborn;
                    case Enums.Market.FR:
                        return FRMenu.Newborn;
                    case Enums.Market.EU:
                        return EUMenu.Newborn;
                    case Enums.Market.AT:
                        return ATMenu.Newborn;
                    default:
                        return null;
                }
            }
        }

        public static string Nightwear
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Nightwear;
                    case Enums.Market.AU:
                        return AUMenu.Nightwear;
                    case Enums.Market.US:
                        return USMenu.Nightwear;
                    case Enums.Market.DE:
                        return DEMenu.Nightwear;
                    case Enums.Market.FR:
                        return FRMenu.Nightwear;
                    case Enums.Market.EU:
                        return EUMenu.Nightwear;
                    case Enums.Market.AT:
                        return ATMenu.Nightwear;
                    default:
                        return null;
                }
            }
        }

        public static string NightwearAndUnderwear
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.NightwearAndUnderwear;
                    case Enums.Market.AU:
                        return AUMenu.NightwearAndUnderwear;
                    case Enums.Market.US:
                        return USMenu.NightwearAndUnderwear;
                    case Enums.Market.DE:
                        return DEMenu.NightwearAndUnderwear;
                    case Enums.Market.FR:
                        return FRMenu.NightwearAndUnderwear;
                    case Enums.Market.EU:
                        return EUMenu.NightwearAndUnderwear;
                    case Enums.Market.AT:
                        return ATMenu.NightwearAndUnderwear;
                    default:
                        return null;
                }
            }
        }

        public static string Partywear
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Partywear;
                    case Enums.Market.AU:
                        return AUMenu.Partywear;
                    case Enums.Market.US:
                        return USMenu.Partywear;
                    case Enums.Market.DE:
                        return DEMenu.Partywear;
                    case Enums.Market.FR:
                        return FRMenu.Partywear;
                    case Enums.Market.EU:
                        return EUMenu.Partywear;
                    case Enums.Market.AT:
                        return ATMenu.Partywear;
                    default:
                        return null;
                }
            }
        }

        public static string PetiteRange
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.PetiteRange;
                    case Enums.Market.AU:
                        return AUMenu.PetiteRange;
                    case Enums.Market.US:
                        return USMenu.PetiteRange;
                    case Enums.Market.DE:
                        return DEMenu.PetiteRange;
                    case Enums.Market.FR:
                        return FRMenu.PetiteRange;
                    case Enums.Market.EU:
                        return EUMenu.PetiteRange;
                    case Enums.Market.AT:
                        return ATMenu.PetiteRange;
                    default:
                        return null;
                }
            }
        }

        public static string RompersAndPlaySets
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.RompersAndPlaySets;
                    case Enums.Market.AU:
                        return AUMenu.RompersAndPlaySets;
                    case Enums.Market.US:
                        return USMenu.RompersAndPlaySets;
                    case Enums.Market.DE:
                        return DEMenu.RompersAndPlaySets;
                    case Enums.Market.FR:
                        return FRMenu.RompersAndPlaySets;
                    case Enums.Market.EU:
                        return EUMenu.RompersAndPlaySets;
                    case Enums.Market.AT:
                        return ATMenu.RompersAndPlaySets;
                    default:
                        return null;
                }
            }
        }

        public static string Sale
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Sale;
                    case Enums.Market.AU:
                        return AUMenu.Sale;
                    case Enums.Market.US:
                        return USMenu.Sale;
                    case Enums.Market.DE:
                        return DEMenu.Sale;
                    case Enums.Market.FR:
                        return FRMenu.Sale;
                    case Enums.Market.EU:
                        return EUMenu.Sale;
                    case Enums.Market.AT:
                        return ATMenu.Sale;
                    default:
                        return null;
                }
            }
        }

        public static string Shirts
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Shirts;
                    case Enums.Market.AU:
                        return AUMenu.Shirts;
                    case Enums.Market.US:
                        return USMenu.Shirts;
                    case Enums.Market.DE:
                        return DEMenu.Shirts;
                    case Enums.Market.FR:
                        return FRMenu.Shirts;
                    case Enums.Market.EU:
                        return EUMenu.Shirts;
                    case Enums.Market.AT:
                        return ATMenu.Shirts;
                    default:
                        return null;
                }
            }
        }

        public static string ShirtsAndBlouses
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.ShirtsAndBlouses;
                    case Enums.Market.AU:
                        return AUMenu.ShirtsAndBlouses;
                    case Enums.Market.US:
                        return USMenu.ShirtsAndBlouses;
                    case Enums.Market.DE:
                        return DEMenu.ShirtsAndBlouses;
                    case Enums.Market.FR:
                        return FRMenu.ShirtsAndBlouses;
                    case Enums.Market.EU:
                        return EUMenu.ShirtsAndBlouses;
                    case Enums.Market.AT:
                        return ATMenu.ShirtsAndBlouses;
                    default:
                        return null;
                }
            }
        }

        public static string ShoesAndBoots
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.ShoesAndBoots;
                    case Enums.Market.AU:
                        return AUMenu.ShoesAndBoots;
                    case Enums.Market.US:
                        return USMenu.ShoesAndBoots;
                    case Enums.Market.DE:
                        return DEMenu.ShoesAndBoots;
                    case Enums.Market.FR:
                        return FRMenu.ShoesAndBoots;
                    case Enums.Market.EU:
                        return EUMenu.ShoesAndBoots;
                    case Enums.Market.AT:
                        return ATMenu.ShoesAndBoots;
                    default:
                        return null;
                }
            }
        }

        public static string ShopByBrand
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.ShopByBrand;
                    case Enums.Market.AU:
                        return AUMenu.ShopByBrand;
                    case Enums.Market.US:
                        return USMenu.ShopByBrand;
                    case Enums.Market.DE:
                        return DEMenu.ShopByBrand;
                    case Enums.Market.FR:
                        return FRMenu.ShopByBrand;
                    case Enums.Market.EU:
                        return EUMenu.ShopByBrand;
                    case Enums.Market.AT:
                        return ATMenu.ShopByBrand;
                    default:
                        return null;
                }
            }
        }

        public static string Shorts
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Shorts;
                    case Enums.Market.AU:
                        return AUMenu.Shorts;
                    case Enums.Market.US:
                        return USMenu.Shorts;
                    case Enums.Market.DE:
                        return DEMenu.Shorts;
                    case Enums.Market.FR:
                        return FRMenu.Shorts;
                    case Enums.Market.EU:
                        return EUMenu.Shorts;
                    case Enums.Market.AT:
                        return ATMenu.Shorts;
                    default:
                        return null;
                }
            }
        }

        public static string Skirts
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Skirts;
                    case Enums.Market.AU:
                        return AUMenu.Skirts;
                    case Enums.Market.US:
                        return USMenu.Skirts;
                    case Enums.Market.DE:
                        return DEMenu.Skirts;
                    case Enums.Market.FR:
                        return FRMenu.Skirts;
                    case Enums.Market.EU:
                        return EUMenu.Skirts;
                    case Enums.Market.AT:
                        return ATMenu.Skirts;
                    default:
                        return null;
                }
            }
        }

        public static string Sportswear
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Sportswear;
                    case Enums.Market.AU:
                        return AUMenu.Sportswear;
                    case Enums.Market.US:
                        return USMenu.Sportswear;
                    case Enums.Market.DE:
                        return DEMenu.Sportswear;
                    case Enums.Market.FR:
                        return FRMenu.Sportswear;
                    case Enums.Market.EU:
                        return EUMenu.Sportswear;
                    case Enums.Market.AT:
                        return ATMenu.Sportswear;
                    default:
                        return null;
                }
            }
        }

        public static string SweatShirtsAndFleeces
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.SweatShirtsAndFleeces;
                    case Enums.Market.AU:
                        return AUMenu.SweatShirtsAndFleeces;
                    case Enums.Market.US:
                        return USMenu.SweatShirtsAndFleeces;
                    case Enums.Market.DE:
                        return DEMenu.SweatShirtsAndFleeces;
                    case Enums.Market.FR:
                        return FRMenu.SweatShirtsAndFleeces;
                    case Enums.Market.EU:
                        return EUMenu.SweatShirtsAndFleeces;
                    case Enums.Market.AT:
                        return ATMenu.SweatShirtsAndFleeces;
                    default:
                        return null;
                }
            }
        }

        public static string Sweats
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Sweats;
                    case Enums.Market.AU:
                        return AUMenu.Sweats;
                    case Enums.Market.US:
                        return USMenu.Sweats;
                    case Enums.Market.DE:
                        return DEMenu.Sweats;
                    case Enums.Market.FR:
                        return FRMenu.Sweats;
                    case Enums.Market.EU:
                        return EUMenu.Sweats;
                    case Enums.Market.AT:
                        return ATMenu.Sweats;
                    default:
                        return null;
                }
            }
        }

        public static string Swimwear
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Swimwear;
                    case Enums.Market.AU:
                        return AUMenu.Swimwear;
                    case Enums.Market.US:
                        return USMenu.Swimwear;
                    case Enums.Market.DE:
                        return DEMenu.Swimwear;
                    case Enums.Market.FR:
                        return FRMenu.Swimwear;
                    case Enums.Market.EU:
                        return EUMenu.Swimwear;
                    case Enums.Market.AT:
                        return ATMenu.Swimwear;
                    default:
                        return null;
                }
            }
        }

        public static string TopRated
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.TopRated;
                    case Enums.Market.AU:
                        return AUMenu.TopRated;
                    case Enums.Market.US:
                        return USMenu.TopRated;
                    case Enums.Market.DE:
                        return DEMenu.TopRated;
                    case Enums.Market.FR:
                        return FRMenu.TopRated;
                    case Enums.Market.EU:
                        return EUMenu.TopRated;
                    case Enums.Market.AT:
                        return ATMenu.TopRated;
                    default:
                        return null;
                }
            }
        }

        public static string TopsAndPolos
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.TopsAndPolos;
                    case Enums.Market.AU:
                        return AUMenu.TopsAndPolos;
                    case Enums.Market.US:
                        return USMenu.TopsAndPolos;
                    case Enums.Market.DE:
                        return DEMenu.TopsAndPolos;
                    case Enums.Market.FR:
                        return FRMenu.TopsAndPolos;
                    case Enums.Market.EU:
                        return EUMenu.TopsAndPolos;
                    case Enums.Market.AT:
                        return ATMenu.TopsAndPolos;
                    default:
                        return null;
                }
            }
        }

        public static string TopsAndTShirts
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.TopsAndTShirts;
                    case Enums.Market.AU:
                        return AUMenu.TopsAndTShirts;
                    case Enums.Market.US:
                        return USMenu.TopsAndTShirts;
                    case Enums.Market.DE:
                        return DEMenu.TopsAndTShirts;
                    case Enums.Market.FR:
                        return FRMenu.TopsAndTShirts;
                    case Enums.Market.EU:
                        return EUMenu.TopsAndTShirts;
                    case Enums.Market.AT:
                        return ATMenu.TopsAndTShirts;
                    default:
                        return null;
                }
            }
        }

        public static string Trousers
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Trousers;
                    case Enums.Market.AU:
                        return AUMenu.Trousers;
                    case Enums.Market.US:
                        return USMenu.Trousers;
                    case Enums.Market.DE:
                        return DEMenu.Trousers;
                    case Enums.Market.FR:
                        return FRMenu.Trousers;
                    case Enums.Market.EU:
                        return EUMenu.Trousers;
                    case Enums.Market.AT:
                        return ATMenu.Trousers;
                    default:
                        return null;
                }
            }
        }

        public static string TrousersAndJeans
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.TrousersAndJeans;
                    case Enums.Market.AU:
                        return AUMenu.TrousersAndJeans;
                    case Enums.Market.US:
                        return USMenu.TrousersAndJeans;
                    case Enums.Market.DE:
                        return DEMenu.TrousersAndJeans;
                    case Enums.Market.FR:
                        return FRMenu.TrousersAndJeans;
                    case Enums.Market.EU:
                        return EUMenu.TrousersAndJeans;
                    case Enums.Market.AT:
                        return ATMenu.TrousersAndJeans;
                    default:
                        return null;
                }
            }
        }

        public static string TunicsAndKaftans
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.TunicsAndKaftans;
                    case Enums.Market.AU:
                        return AUMenu.TunicsAndKaftans;
                    case Enums.Market.US:
                        return USMenu.TunicsAndKaftans;
                    case Enums.Market.DE:
                        return DEMenu.TunicsAndKaftans;
                    case Enums.Market.FR:
                        return FRMenu.TunicsAndKaftans;
                    case Enums.Market.EU:
                        return EUMenu.TunicsAndKaftans;
                    case Enums.Market.AT:
                        return ATMenu.TunicsAndKaftans;
                    default:
                        return null;
                }
            }
        }

        public static string Underwear
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.Underwear;
                    case Enums.Market.AU:
                        return AUMenu.Underwear;
                    case Enums.Market.US:
                        return USMenu.Underwear;
                    case Enums.Market.DE:
                        return DEMenu.Underwear;
                    case Enums.Market.FR:
                        return FRMenu.Underwear;
                    case Enums.Market.EU:
                        return EUMenu.Underwear;
                    case Enums.Market.AT:
                        return ATMenu.Underwear;
                    default:
                        return null;
                }
            }
        }

        public static string ViewAll
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.ViewAll;
                    case Enums.Market.AU:
                        return AUMenu.ViewAll;
                    case Enums.Market.US:
                        return USMenu.ViewAll;
                    case Enums.Market.DE:
                        return DEMenu.ViewAll;
                    case Enums.Market.FR:
                        return FRMenu.ViewAll;
                    case Enums.Market.EU:
                        return EUMenu.ViewAll;
                    case Enums.Market.AT:
                        return ATMenu.ViewAll;
                    default:
                        return null;
                }
            }
        }

        public static string Women
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.WomenMenuId;
                    case Enums.Market.AU:
                        return AUMenu.WomenMenuId;
                    case Enums.Market.US:
                        return USMenu.WomenMenuId;
                    case Enums.Market.DE:
                        return DEMenu.WomenMenuId;
                    case Enums.Market.FR:
                        return FRMenu.WomenMenuId;
                    case Enums.Market.EU:
                        return EUMenu.WomenMenuId;
                    case Enums.Market.AT:
                        return ATMenu.WomenMenuId;
                    default:
                        return null;
                }
            }
        }

        public static string WorkwearRange
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKMenu.WorkwearRange;
                    case Enums.Market.AU:
                        return AUMenu.WorkwearRange;
                    case Enums.Market.US:
                        return USMenu.WorkwearRange;
                    case Enums.Market.DE:
                        return DEMenu.WorkwearRange;
                    case Enums.Market.FR:
                        return FRMenu.WorkwearRange;
                    case Enums.Market.EU:
                        return EUMenu.WorkwearRange;
                    case Enums.Market.AT:
                        return ATMenu.WorkwearRange;
                    default:
                        return null;
                }
            }
        }
    }
}
