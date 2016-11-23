using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BankApp.Model
{
    public class Curr_Conv
    {
        [JsonProperty(PropertyName = "Currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "Bank_Buys")]
        public string Bank_Buys { get; set; }

        [JsonProperty(PropertyName = "Bank_Sells")]
        public string Bank_Sells { get; set; }
        
    }
}