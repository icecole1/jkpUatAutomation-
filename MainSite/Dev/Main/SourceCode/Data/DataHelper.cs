using System;
using System.IO;
using OpenQA.Selenium;
using UAT.MainSite.Automation.Helpers;

namespace UAT.MainSite.Automation.Data
{
    public static class DataHelper
    {
        public static string GetYearInTwoDigits(DateTime dateTime)
        {
            int year = int.Parse(dateTime.Year.ToString().Substring(2));

            return year.ToString();
        }

        public static string GetFullYear(DateTime dateTime)
        {
            int year = int.Parse(dateTime.Year.ToString());

            return year.ToString();
        }

        public static void TakeScreenshot(MainSiteNavigation mainSiteNavigation)
        {
            var assemblyPath = AppDomain.CurrentDomain.BaseDirectory + @"\logs\screenshots\";

            var directoryInfo = new DirectoryInfo(assemblyPath);
            if (!directoryInfo.Exists)
                directoryInfo.Create();

            var fullPath = string.Concat(assemblyPath, new Random().Next(0, 10000), ".jpg");
            var screenshot = ((ITakesScreenshot)mainSiteNavigation.WebDriverManager.WebDriver).GetScreenshot();

            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
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
        public static int GetEGiftCardIndex(int cardValue, Enums.Market market)
        {
            switch (market)
            {
                case Enums.Market.UK:
                case Enums.Market.US:
                case Enums.Market.AU:
                    switch (cardValue)
                    {
                        case 10:
                            return 0;
                        case 20:
                            return 1;
                        case 25:
                            return  2;
                        case 50:
                            return 3;
                        case 75:
                            return 4;
                        case 100:
                            return 5;
                        case 150:
                            return 6;
                        case 200:
                            return 7;
                        case 250:
                            return 8;
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
