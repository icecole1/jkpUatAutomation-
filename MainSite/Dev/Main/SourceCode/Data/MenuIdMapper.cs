using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAT.MainSite.Automation.Helpers;
using UAT.MainSite.Automation.MainSite.Pages.Panels;

namespace UAT.MainSite.Automation.Data
{
    public class MenuIdMapper
    {

        public string GetMenuId(Header.Segment segment)
        {
            switch (segment)
            {
                case Header.Segment.Home:
                    return Menu.Home;
                case Header.Segment.AudioDramas:
                    return Menu.AudioDramas;
                case Header.Segment.AboutUs:
                    return Menu.AboutUs;
                case Header.Segment.OurWork:
                    return Menu.OurWork;
                case Header.Segment.Shop:
                    return Menu.Shop;
                case Header.Segment.ProductionBlog:
                    return Menu.ProductionBlog;
                case Header.Segment.ContactUs:
                    return Menu.ContactUs;

                default:
                    return string.Empty;
            }
        }
    }
}

//private string HomeMenuId()
        //{
        //    switch (Configuration.Market)
        //    {
        //        case Enums.Market.FR:
        //            return Menu.Home;

        //        default:
        //            return string.Empty;
        //    }
        //}

//        private string AudioDramasMenuId()
//        {
//            switch (Configuration.Market)
//            {
//                case Enums.Market.FR:
//                    return Menu.AudioDramas;

//                default:
//                    return string.Empty;
//            }
//        }

//        private string AboutUsMenuId()
//        {
//            switch (Configuration.Market)
//            {
//                case Enums.Market.FR:
//                    return Menu.AboutUs;

//                default:
//                    return string.Empty;
//            }
//        }

//        private string OurWorkMenuId()
//        {
//            switch (Configuration.Market)
//            {
//                case Enums.Market.FR:
//                    return Menu.OurWork;

//                default:
//                    return string.Empty;
//            }
//        }

//        private string ShopMenuId()
//        {
//            switch (Configuration.Market)
//            {
//                case Enums.Market.FR:
//                    return Menu.Shop;

//                default:
//                    return string.Empty;
//            }
//        }

//        private string ProductionBlogMenuId()
//        {
//            switch (Configuration.Market)
//            {
//                case Enums.Market.FR:
//                    return Menu.Shop;

//                default:
//                    return string.Empty;

//            }
//        }

//        private string ContactUsMenuId()
//        {
//            switch (Configuration.Market)
//            {
//                case Enums.Market.FR:
//                    return Menu.ContactUs;

//                default:
//                    return string.Empty;
//            }

//        }
//    }
//}

