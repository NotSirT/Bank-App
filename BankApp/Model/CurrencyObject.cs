using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp.Model
{
    public class CurrencyObject
    {
        public string base_curr { get; set; }
        public string date { get; set; }
        public int AUD { get; set; }
        public int GBP { get; set; }
        public int EUR { get; set; }
        public int JPY { get; set; }
        public int USD { get; set; }
    }
}