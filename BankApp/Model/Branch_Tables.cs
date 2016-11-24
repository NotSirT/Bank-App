using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace BankApp.Model
{
    public class Branch_Tables
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "Monday")]
        public string Monday { get; set; }

        [JsonProperty(PropertyName = "Tuesday")]
        public string Tuesday { get; set; }

        [JsonProperty(PropertyName = "Wednesday")]
        public string Wednesday { get; set; }

        [JsonProperty(PropertyName = "Thursday")]
        public string Thursday { get; set; }

        [JsonProperty(PropertyName = "Friday")]
        public string Friday { get; set; }

        [JsonProperty(PropertyName = "Saturday")]
        public string Saturday { get; set; }

        [JsonProperty(PropertyName = "Sunday")]
        public string Sunday { get; set; }

        [JsonProperty(PropertyName = "Location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "_24_7_deposit")]
        public string _24_7_deposit { get; set; }

        [JsonProperty(PropertyName = "Coin_deposit")]
        public string Coin_deposit { get; set; }

    }
}