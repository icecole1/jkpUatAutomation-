using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UAT.Mobile.Automation.Helpers;
using UAT.Mobile.Automation.WebDriver;

namespace UAT.Mobile.Automation.Mobile.Pages.Panels
{
    // TODO: this entire class and its dependecies need to be refactored once menu Id's have been added to mobile website.
    public class HeaderMenu
    {
        private readonly WebDriverManager _webDriverManager;

        public HeaderMenu(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
            PageFactory.InitElements(_webDriverManager.WebDriver, this);
        }

        public enum Segment
        {
            Womens = 0,
            Mens = 1,
            Childrens = 2,
            Clearance = 3,
            Blog = 4
        }

        private int GetSegmentCategoryWomensIndex(SegmentCategoryWomens segmentCategoryWomens)
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return MapUKSegmentCategoryWomens(segmentCategoryWomens);
                case Enums.Market.AU:
                    return MapAUSegmentCategoryWomens(segmentCategoryWomens);
                case Enums.Market.US:
                    return MapUSSegmentCategoryWomens(segmentCategoryWomens);
                case Enums.Market.DE:
                    return MapDESegmentCategoryWomens(segmentCategoryWomens);
                case Enums.Market.FR:
                    return MapFRSegmentCategoryWomens(segmentCategoryWomens);
                default:
                    return 0;
            }
        }

        private int MapUKSegmentCategoryWomens(SegmentCategoryWomens segmentCategoryWomens)
        {
            switch (segmentCategoryWomens)
            {
                case SegmentCategoryWomens.ExploreWomens:
                    return 0;
                case SegmentCategoryWomens.NewIn:
                    return 1;
                case SegmentCategoryWomens.Accessories:
                    return 2;
                case SegmentCategoryWomens.CoatsAndJackets:
                    return 3;
                case SegmentCategoryWomens.Dresses:
                    return 4;
                case SegmentCategoryWomens.Handbags:
                    return 5;
                case SegmentCategoryWomens.Jeans:
                    return 6;
                case SegmentCategoryWomens.Knitwear:
                    return 7;
                case SegmentCategoryWomens.Nightwear:
                    return 8;
                case SegmentCategoryWomens.PetiteRange:
                    return 9;
                case SegmentCategoryWomens.ShirtsAndBlouses:
                    return 10;
                case SegmentCategoryWomens.ShoesAndBoots:
                    return 11;
                case SegmentCategoryWomens.Shorts:
                    return 12;
                case SegmentCategoryWomens.Skirts:
                    return 13;
                case SegmentCategoryWomens.Swimwear:
                    return 14;
                case SegmentCategoryWomens.TopAndTShirts:
                    return 15;
                case SegmentCategoryWomens.Trousers:
                    return 16;
                case SegmentCategoryWomens.TunicsAndKaftans:
                    return 17;
                case SegmentCategoryWomens.ViewAll:
                    return 18;
                case SegmentCategoryWomens.WorkwearRange:
                    return 19;
                case SegmentCategoryWomens.GiftVouchers:
                    return 20;
                case SegmentCategoryWomens.Clearance:
                    return 21;
                case SegmentCategoryWomens.TopRated:
                    return 22;
                case SegmentCategoryWomens.HolidayShop:
                    return 23;
                default:
                    return 0;
            }
        }

        private int MapUSSegmentCategoryWomens(SegmentCategoryWomens segmentCategoryWomens)
        {
            switch (segmentCategoryWomens)
            {
                case SegmentCategoryWomens.ExploreWomens:
                    return 0;
                case SegmentCategoryWomens.NewIn:
                    return 1;
                case SegmentCategoryWomens.Accessories:
                    return 2;
                case SegmentCategoryWomens.CoatsAndJackets:
                    return 3;
                case SegmentCategoryWomens.Dresses:
                    return 4;
                case SegmentCategoryWomens.Handbags:
                    return 5;
                case SegmentCategoryWomens.Jeans:
                    return 6;
                case SegmentCategoryWomens.Nightwear:
                    return 7;
                case SegmentCategoryWomens.Pants:
                    return 8;
                case SegmentCategoryWomens.PetiteRange:
                    return 9;
                case SegmentCategoryWomens.ShirtsAndBlouses:
                    return 10;
                case SegmentCategoryWomens.ShoesAndBoots:
                    return 11;
                case SegmentCategoryWomens.Shorts:
                    return 12;
                case SegmentCategoryWomens.Skirts:
                    return 13;
                case SegmentCategoryWomens.Sweaters:
                    return 14;
                case SegmentCategoryWomens.Swimwear:
                    return 15;
                case SegmentCategoryWomens.TopAndTShirts:
                    return 16;
                case SegmentCategoryWomens.TunicsAndKaftans:
                    return 17;
                case SegmentCategoryWomens.ViewAll:
                    return 18;
                case SegmentCategoryWomens.WorkwearRange:
                    return 19;
                case SegmentCategoryWomens.GiftVouchers:
                    return 20;
                case SegmentCategoryWomens.Clearance:
                    return 21;
                case SegmentCategoryWomens.TopRated:
                    return 22;
                case SegmentCategoryWomens.HolidayShop:
                    return 23;
                default:
                    return 0;
            }
        }

        private int MapDESegmentCategoryWomens(SegmentCategoryWomens segmentCategoryWomens)
        {
            switch (segmentCategoryWomens)
            {
                case SegmentCategoryWomens.ExploreWomens:
                    return 0;
                case SegmentCategoryWomens.NewIn:
                    return 1;
                case SegmentCategoryWomens.Accessories:
                    return 2;
                case SegmentCategoryWomens.ViewAll:
                    return 3;
                case SegmentCategoryWomens.Swimwear:
                    return 4;
                case SegmentCategoryWomens.Blazer:
                    return 5;
                case SegmentCategoryWomens.Handbags:
                    return 6;
                case SegmentCategoryWomens.ShirtsAndBlouses:
                    return 7;
                case SegmentCategoryWomens.Pants:
                    return 8;
                case SegmentCategoryWomens.Jeans:
                    return 9;
                case SegmentCategoryWomens.Dresses:
                    return 10;
                case SegmentCategoryWomens.CoatsAndJackets:
                    return 11;
                case SegmentCategoryWomens.WorkwearRange:
                    return 12;
                case SegmentCategoryWomens.Nightwear:
                    return 13;
                case SegmentCategoryWomens.TopAndTShirts:
                    return 14;
                case SegmentCategoryWomens.PetiteRange:
                    return 15;
                case SegmentCategoryWomens.Skirts:
                    return 16;
                case SegmentCategoryWomens.ShoesAndBoots:
                    return 17;
                case SegmentCategoryWomens.Shorts:
                    return 18;
                case SegmentCategoryWomens.Knitwear:
                    return 19;
                case SegmentCategoryWomens.TunicsAndKaftans:
                    return 20;
                case SegmentCategoryWomens.Clearance:
                    return 21;
                case SegmentCategoryWomens.TopRated:
                    return 22;
                case SegmentCategoryWomens.HolidayShop:
                    return 23;
                default:
                    return 0;
            }
        }

        private int MapFRSegmentCategoryWomens(SegmentCategoryWomens segmentCategoryWomens)
        {
            switch (segmentCategoryWomens)
            {
                case SegmentCategoryWomens.ExploreWomens:
                    return 0;
                case SegmentCategoryWomens.NewIn:
                    return 1;
                case SegmentCategoryWomens.Accessories:
                    return 2;
                case SegmentCategoryWomens.ShoesAndBoots:
                    return 3;
                case SegmentCategoryWomens.ShirtsAndBlouses:
                    return 4;
                case SegmentCategoryWomens.Nightwear:
                    return 5;
                case SegmentCategoryWomens.WorkwearRange:
                    return 6;
                case SegmentCategoryWomens.Jeans:
                    return 7;
                case SegmentCategoryWomens.Skirts:
                    return 8;
                case SegmentCategoryWomens.Swimwear:
                    return 9;
                case SegmentCategoryWomens.CoatsAndJackets:
                    return 10;
                case SegmentCategoryWomens.Pants:
                    return 11;
                case SegmentCategoryWomens.PetiteRange:
                    return 12;
                case SegmentCategoryWomens.Dresses:
                    return 13;
                case SegmentCategoryWomens.Handbags:
                    return 14;
                case SegmentCategoryWomens.Shorts:
                    return 15;
                case SegmentCategoryWomens.TopAndTShirts:
                    return 16;
                case SegmentCategoryWomens.ViewAll:
                    return 17;
                case SegmentCategoryWomens.Knitwear:
                    return 18;
                case SegmentCategoryWomens.TunicsAndKaftans:
                    return 19;
                case SegmentCategoryWomens.GiftVouchers:
                    return 20;
                case SegmentCategoryWomens.Clearance:
                    return 21;
                case SegmentCategoryWomens.TopRated:
                    return 22;
                case SegmentCategoryWomens.HolidayShop:
                    return 23;
                default:
                    return 0;
            }
        }

        private int MapAUSegmentCategoryWomens(SegmentCategoryWomens segmentCategoryWomens)
        {
            switch (segmentCategoryWomens)
            {
                case SegmentCategoryWomens.ExploreWomens:
                    return 0;
                case SegmentCategoryWomens.NewIn:
                    return 1;
                case SegmentCategoryWomens.Accessories:
                    return 2;
                case SegmentCategoryWomens.CoatsAndJackets:
                    return 3;
                case SegmentCategoryWomens.Dresses:
                    return 4;
                case SegmentCategoryWomens.Handbags:
                    return 5;
                case SegmentCategoryWomens.Jeans:
                    return 6;
                case SegmentCategoryWomens.Knitwear:
                    return 7;
                case SegmentCategoryWomens.Nightwear:
                    return 8;
                case SegmentCategoryWomens.PetiteRange:
                    return 9;
                case SegmentCategoryWomens.ShirtsAndBlouses:
                    return 10;
                case SegmentCategoryWomens.ShoesAndBoots:
                    return 11;
                case SegmentCategoryWomens.Shorts:
                    return 12;
                case SegmentCategoryWomens.Skirts:
                    return 13;
                case SegmentCategoryWomens.Swimwear:
                    return 14;
                case SegmentCategoryWomens.TopAndTShirts:
                    return 15;
                case SegmentCategoryWomens.Trousers:
                    return 16;
                case SegmentCategoryWomens.TunicsAndKaftans:
                    return 17;
                case SegmentCategoryWomens.ViewAll:
                    return 18;
                case SegmentCategoryWomens.WorkwearRange:
                    return 19;
                case SegmentCategoryWomens.GiftVouchers:
                    return 20;
                case SegmentCategoryWomens.Clearance:
                    return 21;
                case SegmentCategoryWomens.TopRated:
                    return 22;
                case SegmentCategoryWomens.HolidayShop:
                    return 23;
                default:
                    return 0;
            }
        }

        public enum SegmentCategoryWomens
        {
            ExploreWomens = 0,
            NewIn,
            Accessories,
            CoatsAndJackets,
            Dresses,
            Handbags,
            Knitwear,
            Loungewear,
            Nightwear,
            PetiteRange,
            ShirtsAndBlouses,
            ShoesAndBoots,
            Shorts,
            Skirts,
            SpecialOffer,
            Swimwear,
            TopAndTShirts,
            Trousers,
            TunicsAndKaftans,
            ViewAll,
            WorkwearRange,
            GiftVouchers,
            Clearance,
            TopRated,
            HolidayShop,
            Jeans,
            Pants,
            Sweaters,
            Blazer
        }

        private int GetSegmentCategoryMensIndex(SegmentCategoryMens segmentCategoryMens)
        {
            switch (Configuration.Market)
            {
                case Enums.Market.UK:
                    return MapUKSegmentCategoryMens(segmentCategoryMens);
                case Enums.Market.AU:
                    return MapAUSegmentCategoryMens(segmentCategoryMens);
                case Enums.Market.US:
                    return MapUSSegmentCategoryMens(segmentCategoryMens);
                case Enums.Market.DE:
                    return MapDESegmentCategoryMens(segmentCategoryMens);
                case Enums.Market.FR:
                    return MapFRSegmentCategoryMens(segmentCategoryMens);
                default:
                    return 0;
            }
        }

        private int MapUKSegmentCategoryMens(SegmentCategoryMens segmentCategoryMens)
        {
            switch (segmentCategoryMens)
            {
                case SegmentCategoryMens.ExploreMens:
                    return 0;
                case SegmentCategoryMens.NewIn:
                    return 1;
                case SegmentCategoryMens.Accessories:
                    return 2;
                case SegmentCategoryMens.CoatsAndJackets:
                    return 3;
                case SegmentCategoryMens.Knitwear:
                    return 4;
                case SegmentCategoryMens.NightwearAndUnderwear:
                    return 5;
                case SegmentCategoryMens.Shirts:
                    return 6;
                case SegmentCategoryMens.ShoesAndBoots:
                    return 7;
                case SegmentCategoryMens.Shorts:
                    return 8;
                case SegmentCategoryMens.Sweats:
                    return 9;
                case SegmentCategoryMens.TopsAndPolo:
                    return 10;
                case SegmentCategoryMens.TrousersAndJeans:
                    return 11;
                case SegmentCategoryMens.ViewAll:
                    return 12;
                case SegmentCategoryMens.GiftVouchers:
                    return 13;
                case SegmentCategoryMens.Clearance:
                    return 14;
                case SegmentCategoryMens.TopRated:
                    return 15;
                case SegmentCategoryMens.MensHolidayShop:
                    return 16;
                case SegmentCategoryMens.MadeInBritain:
                    return 17;
                default:
                    return 0;
            }
        }

        private int MapUSSegmentCategoryMens(SegmentCategoryMens segmentCategoryMens)
        {
            switch (segmentCategoryMens)
            {
                case SegmentCategoryMens.ExploreMens:
                    return 0;
                case SegmentCategoryMens.NewIn:
                    return 1;
                case SegmentCategoryMens.Accessories:
                    return 2;
                case SegmentCategoryMens.CoatsAndJackets:
                    return 3;
                case SegmentCategoryMens.NightwearAndUnderwear:
                    return 4;
                case SegmentCategoryMens.TrousersAndJeans:
                    return 5;
                case SegmentCategoryMens.Shirts:
                    return 6;
                case SegmentCategoryMens.ShoesAndBoots:
                    return 7;
                case SegmentCategoryMens.Shorts:
                    return 8;
                case SegmentCategoryMens.Knitwear:
                    return 9;
                case SegmentCategoryMens.Sweats:
                    return 10;
                case SegmentCategoryMens.TopsAndPolo:
                    return 11;
                case SegmentCategoryMens.ViewAll:
                    return 12;
                case SegmentCategoryMens.GiftVouchers:
                    return 13;
                case SegmentCategoryMens.Clearance:
                    return 14;
                case SegmentCategoryMens.TopRated:
                    return 15;
                case SegmentCategoryMens.MensHolidayShop:
                    return 16;
                case SegmentCategoryMens.MadeInBritain:
                    return 17;
                default:
                    return 0;
            }
        }

        private int MapDESegmentCategoryMens(SegmentCategoryMens segmentCategoryMens)
        {
            switch (segmentCategoryMens)
            {
                case SegmentCategoryMens.ExploreMens:
                    return 0;
                case SegmentCategoryMens.NewIn:
                    return 1;
                case SegmentCategoryMens.Accessories:
                    return 2;
                case SegmentCategoryMens.ViewAll:
                    return 3;
                case SegmentCategoryMens.Shirts:
                    return 4;
                case SegmentCategoryMens.TrousersAndJeans:
                    return 5;
                case SegmentCategoryMens.CoatsAndJackets:
                    return 6;
                case SegmentCategoryMens.NightwearAndUnderwear:
                    return 7;
                case SegmentCategoryMens.ShoesAndBoots:
                    return 8;
                case SegmentCategoryMens.Shorts:
                    return 9;
                case SegmentCategoryMens.Knitwear:
                    return 10;
                case SegmentCategoryMens.Sweats:
                    return 11;
                case SegmentCategoryMens.TopsAndPolo:
                    return 12;
                case SegmentCategoryMens.Clearance:
                    return 13;
                case SegmentCategoryMens.TopRated:
                    return 14;
                case SegmentCategoryMens.MensHolidayShop:
                    return 15;
                case SegmentCategoryMens.MadeInBritain:
                    return 16;
                default:
                    return 0;
            }
        }

        private int MapFRSegmentCategoryMens(SegmentCategoryMens segmentCategoryMens)
        {
            switch (segmentCategoryMens)
            {
                case SegmentCategoryMens.ExploreMens:
                    return 0;
                case SegmentCategoryMens.NewIn:
                    return 1;
                case SegmentCategoryMens.Accessories:
                    return 2;
                case SegmentCategoryMens.ShoesAndBoots:
                    return 3;
                case SegmentCategoryMens.Shirts:
                    return 4;
                case SegmentCategoryMens.CoatsAndJackets:
                    return 5;
                case SegmentCategoryMens.TrousersAndJeans:
                    return 6;
                case SegmentCategoryMens.NightwearAndUnderwear:
                    return 7;
                case SegmentCategoryMens.Shorts:
                    return 8;
                case SegmentCategoryMens.Sweats:
                    return 9;
                case SegmentCategoryMens.TopsAndPolo:
                    return 10;
                case SegmentCategoryMens.ViewAll:
                    return 11;
                case SegmentCategoryMens.Knitwear:
                    return 12;
                case SegmentCategoryMens.GiftVouchers:
                    return 13;
                case SegmentCategoryMens.Clearance:
                    return 14;
                case SegmentCategoryMens.TopRated:
                    return 15;
                case SegmentCategoryMens.MensHolidayShop:
                    return 16;
                case SegmentCategoryMens.MadeInBritain:
                    return 16;
                default:
                    return 0;
            }
        }

        private int MapAUSegmentCategoryMens(SegmentCategoryMens segmentCategoryMens)
        {
            switch (segmentCategoryMens)
            {
                case SegmentCategoryMens.ExploreMens:
                    return 0;
                case SegmentCategoryMens.NewIn:
                    return 1;
                case SegmentCategoryMens.Accessories:
                    return 2;
                case SegmentCategoryMens.CoatsAndJackets:
                    return 3;
                case SegmentCategoryMens.Knitwear:
                    return 4;
                case SegmentCategoryMens.NightwearAndUnderwear:
                    return 5;
                case SegmentCategoryMens.Shirts:
                    return 6;
                case SegmentCategoryMens.ShoesAndBoots:
                    return 7;
                case SegmentCategoryMens.Shorts:
                    return 8;
                case SegmentCategoryMens.Sweats:
                    return 9;
                case SegmentCategoryMens.TopsAndPolo:
                    return 10;
                case SegmentCategoryMens.TrousersAndJeans:
                    return 11;
                case SegmentCategoryMens.ViewAll:
                    return 12;
                case SegmentCategoryMens.GiftVouchers:
                    return 13;
                case SegmentCategoryMens.Clearance:
                    return 14;
                case SegmentCategoryMens.TopRated:
                    return 15;
                case SegmentCategoryMens.MensHolidayShop:
                    return 16;
                case SegmentCategoryMens.MadeInBritain:
                    return 16;
                default:
                    return 0;
            }
        }

        public enum SegmentCategoryMens
        {
            ExploreMens = 0,
            NewIn ,
            Accessories,
            CoatsAndJackets,
            Knitwear,
            NightwearAndUnderwear,
            Shirts,
            ShoesAndBoots,
            Shorts,
            Sweats,
            Swimwear,
            TopsAndPolo,
            TrousersAndJeans,
            ViewAll,
            GiftVouchers,
            Clearance,
            TopRated,
            MensHolidayShop,
            MadeInBritain,
            Workwear,
            Jeans
        }

        public enum SegmentCategoryClearance
        {
            Clerance = 0,
            Women = 1,
            Men = 2,
            Girls = 3,
            Boys = 4,
            Baby = 5
        }

        #region Segments

        //TODO: assign id to get a handle on mainmenu button.
        public IWebElement MainMenu =>_webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mbHeaderMenu")));
        
        //TODO: assign id to get a handle on loginlogo button.
        public IWebElement LoginLogo => _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mbHeaderAccount")));

        //TODO: assign id to get a handle on shoppingbag button.
        public IWebElement ShoppingBag
        {
            get
            {
                try
                {
                    Thread.Sleep(1000);
                    return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mbHeaderShoppingBag")));
                }
                catch
                {
                    // ignore..
                }

                return null;
            }
        }
        
        //TODO: assign an id to get a handle on the menu web elements.
        private IList<IWebElement> Segments()
        {
            _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='header']/div[2]/div/ul[1]/li")));

            return _webDriverManager.WebDriver.FindElements(By.XPath("//*[@id='header']/div[2]/div/ul[1]/li"));
        }

        //TODO: assign an id to get a handle on the menu category web elements.
        private IList<IWebElement> SegmentCategories()
        {
            _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.XPath(".//*[@id='header']/div[2]/div/div/div/div/div/ul[1]/li")));

            return _webDriverManager.WebDriver.FindElements(By.XPath(".//*[@id='header']/div[2]/div/div/div/div/div/ul[1]/li"));
        }

        public IWebElement Segments(Segment segment)
        {
            var menuIndex = (int) segment;

            return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(Segments()[menuIndex]));
        }

        public IWebElement SegmentCategoryWomensMenuItem(SegmentCategoryWomens segmentCategoryWomens)
        {
            var menuIndex = GetSegmentCategoryWomensIndex(segmentCategoryWomens);

            return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(SegmentCategories()[menuIndex]));
        }

        public IWebElement SegmentCategoryMensMenuItem(SegmentCategoryMens segmentCategoryMens)
        {
            var menuIndex = GetSegmentCategoryMensIndex(segmentCategoryMens);

            return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(SegmentCategories()[menuIndex]));
        }

        public IWebElement SegmentCategoryClearanceMenuItem(SegmentCategoryClearance segmentCategoryClearance)
        {
            var menuIndex = (int) segmentCategoryClearance;

            return _webDriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(SegmentCategories()[menuIndex]));
        }

        #endregion
    }
}
