using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace BankApp.Model
{
    public class Staff
    {
        [JsonProperty(PropertyName = "Id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Branch")]
        public string Branch { get; set; }

        [JsonProperty(PropertyName = "Position")]
        public string Position { get; set; }

        [JsonProperty(PropertyName = "Contact_no")]
        public string Contact_no { get; set; }

        [JsonProperty(PropertyName = "Contact_email")]
        public string Contact_email { get; set; }
    }
}