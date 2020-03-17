using UAT.Mobile.Automation.Data;

namespace UAT.Mobile.Automation.Helpers
{
    public static class CustomerData
    {
        public static string EmailCreditCard
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.EmailCreditCard;
                    case Enums.Market.AU:
                        return AUCustomer.EmailCreditCard;
                    case Enums.Market.US:
                        return USCustomer.EmailCreditCard;
                    case Enums.Market.DE:
                        return DECustomer.EmailCreditCard;
                    case Enums.Market.FR:
                        return FRCustomer.EmailCreditCard;
                    default:
                        return null;
                }
            }
        }

        public static string EmailAccountCredit
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.EmailAccountCredit;
                    case Enums.Market.AU:
                        return AUCustomer.EmailAccountCredit;
                    case Enums.Market.US:
                        return USCustomer.EmailAccountCredit;
                    case Enums.Market.DE:
                        return DECustomer.EmailAccountCredit;
                    case Enums.Market.FR:
                        return FRCustomer.EmailAccountCredit;
                    default:
                        return null;
                }
            }
        }

        public static string EmailChangeAddress
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.EmailChangeAddress;
                    case Enums.Market.AU:
                        return AUCustomer.EmailChangeAddress;
                    case Enums.Market.US:
                        return USCustomer.EmailChangeAddress;
                    case Enums.Market.DE:
                        return DECustomer.EmailChangeAddress;
                    case Enums.Market.FR:
                        return FRCustomer.EmailChangeAddress;
                    default:
                        return null;
                }
            }
        }

        public static string Password
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.Password;
                    case Enums.Market.AU:
                        return AUCustomer.Password;
                    case Enums.Market.US:
                        return USCustomer.Password;
                    case Enums.Market.DE:
                        return DECustomer.Password;
                    case Enums.Market.FR:
                        return FRCustomer.Password;
                    default:
                        return null;
                }
            }
        }

        public static string TitleMr
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.TitleMr;
                    case Enums.Market.AU:
                        return AUCustomer.TitleMr;
                    case Enums.Market.US:
                        return USCustomer.TitleMr;
                    case Enums.Market.DE:
                        return DECustomer.TitleMr;
                    case Enums.Market.FR:
                        return FRCustomer.TitleMr;
                    default:
                        return null;
                }
            }
        }

        public static string FirstName
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.Firstname;
                    case Enums.Market.AU:
                        return AUCustomer.Firstname;
                    case Enums.Market.US:
                        return USCustomer.Firstname;
                    case Enums.Market.DE:
                        return DECustomer.Firstname;
                    case Enums.Market.FR:
                        return FRCustomer.Firstname;
                    default:
                        return null;
                }
            }
        }

        public static string LastName
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.Lastname;
                    case Enums.Market.AU:
                        return AUCustomer.Lastname;
                    case Enums.Market.US:
                        return USCustomer.Lastname;
                    case Enums.Market.DE:
                        return DECustomer.Lastname;
                    case Enums.Market.FR:
                        return FRCustomer.Lastname;
                    default:
                        return null;
                }
            }
        }

        public static string DOBDay
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.DOBDay;
                    case Enums.Market.AU:
                        return AUCustomer.DOBDay;
                    case Enums.Market.US:
                        return USCustomer.DOBDay;
                    case Enums.Market.DE:
                        return DECustomer.DOBDay;
                    case Enums.Market.FR:
                        return FRCustomer.DOBDay;
                    default:
                        return null;
                }
            }
        }

        public static string DOBMonth
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.DOBMonth;
                    case Enums.Market.AU:
                        return AUCustomer.DOBMonth;
                    case Enums.Market.US:
                        return USCustomer.DOBMonth;
                    case Enums.Market.DE:
                        return DECustomer.DOBMonth;
                    case Enums.Market.FR:
                        return FRCustomer.DOBMonth;
                    default:
                        return null;
                }
            }
        }

        public static string DOBYear
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.DOBYear;
                    case Enums.Market.AU:
                        return AUCustomer.DOBYear;
                    case Enums.Market.US:
                        return USCustomer.DOBYear;
                    case Enums.Market.DE:
                        return DECustomer.DOBYear;
                    case Enums.Market.FR:
                        return FRCustomer.DOBYear;
                    default:
                        return null;
                }
            }
        }

        public static string PhoneNumber
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.PhoneNumber;
                    case Enums.Market.AU:
                        return AUCustomer.PhoneNumber;
                    case Enums.Market.US:
                        return USCustomer.PhoneNumber;
                    case Enums.Market.DE:
                        return DECustomer.PhoneNumber;
                    case Enums.Market.FR:
                        return FRCustomer.PhoneNumber;
                    default:
                        return null;
                }
            }
        }

        public static string AddressLine1
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.AddressLine1;
                    case Enums.Market.AU:
                        return AUCustomer.AddressLine1;
                    case Enums.Market.US:
                        return USCustomer.AddressLine1;
                    case Enums.Market.DE:
                        return DECustomer.AddressLine1;
                    case Enums.Market.FR:
                        return FRCustomer.AddressLine1;
                    default:
                        return null;
                }
            }
        }

        public static string OfferCode
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.OfferCode;
                    case Enums.Market.AU:
                        return AUCustomer.OfferCode;
                    case Enums.Market.US:
                        return USCustomer.OfferCode;
                    case Enums.Market.DE:
                        return DECustomer.OfferCode;
                    case Enums.Market.FR:
                        return FRCustomer.OfferCode;
                    default:
                        return null;
                }
            }
        }

        public static string AddressLine2
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.AddressLine2;
                    case Enums.Market.AU:
                        return AUCustomer.AddressLine2;
                    case Enums.Market.US:
                        return USCustomer.AddressLine2;
                    case Enums.Market.DE:
                        return DECustomer.AddressLine2;
                    case Enums.Market.FR:
                        return FRCustomer.AddressLine2;
                    default:
                        return null;
                }
            }
        }

        public static string AddressLine3
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.AddressLine3;
                    case Enums.Market.AU:
                        return AUCustomer.AddressLine3;
                    case Enums.Market.US:
                        return USCustomer.AddressLine3;
                    case Enums.Market.DE:
                        return DECustomer.AddressLine3;
                    case Enums.Market.FR:
                        return FRCustomer.AddressLine3;
                    default:
                        return null;
                }
            }
        }

        public static string AddressLine4
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.AddressLine4;
                    case Enums.Market.AU:
                        return AUCustomer.AddressLine4;
                    case Enums.Market.US:
                        return USCustomer.AddressLine4;
                    case Enums.Market.DE:
                        return DECustomer.AddressLine4;
                    case Enums.Market.FR:
                        return FRCustomer.AddressLine4;
                    default:
                        return null;
                }
            }
        }

        public static string AddressLine5
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.AddressLine5;
                    case Enums.Market.AU:
                        return AUCustomer.AddressLine5;
                    case Enums.Market.US:
                        return USCustomer.AddressLine5;
                    case Enums.Market.DE:
                        return DECustomer.AddressLine5;
                    case Enums.Market.FR:
                        return FRCustomer.AddressLine5;
                    default:
                        return null;
                }
            }
        }

        public static string Country
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.Country;
                    case Enums.Market.AU:
                        return AUCustomer.Country;
                    case Enums.Market.US:
                        return USCustomer.Country;
                    case Enums.Market.DE:
                        return DECustomer.Country;
                    case Enums.Market.FR:
                        return FRCustomer.Country;
                    default:
                        return null;
                }
            }
        }

        public static string Postcode
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.Postcode;
                    case Enums.Market.AU:
                        return AUCustomer.Postcode;
                    case Enums.Market.US:
                        return USCustomer.ZipCode;
                    case Enums.Market.DE:
                        return DECustomer.Postcode;
                    case Enums.Market.FR:
                        return FRCustomer.Postcode;
                    default:
                        return null;
                }
            }
        }

        public static string City
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.City;
                    case Enums.Market.AU:
                        return AUCustomer.City;
                    case Enums.Market.US:
                        return USCustomer.City;
                    case Enums.Market.DE:
                        return DECustomer.City;
                    case Enums.Market.FR:
                        return FRCustomer.City;
                    default:
                        return null;
                }
            }
        }

        public static string State
        {
            get
            {
                switch (Configuration.Market)
                {
                    case Enums.Market.UK:
                        return UKCustomer.State;
                    case Enums.Market.AU:
                        return AUCustomer.State;
                    case Enums.Market.US:
                        return USCustomer.State;
                    case Enums.Market.DE:
                        return DECustomer.State;
                    case Enums.Market.FR:
                        return FRCustomer.State;
                    default:
                        return null;
                }
            }
        }
    }
}
