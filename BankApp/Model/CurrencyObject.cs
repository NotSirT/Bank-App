using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.MobileServices;
namespace BankApp.Model
{
    public class CurrencyObject
    {
        public class Rates
        {
            public string AUD { get; set; }
            public string GBP { get; set; }
            public string EUR { get; set; }
            public string JPY { get; set; }
            public string USD { get; set; }


        }
        public class RootObject
        {
            public Rates rates { get; set; }

        }
    }
}