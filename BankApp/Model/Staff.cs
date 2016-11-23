using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BankApp.Model
{
    public class Staff
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Position")]
        public string Position { get; set; }

        [JsonProperty(PropertyName = "Branch")]
        public string Branch { get; set; }

        [JsonProperty(PropertyName = "Position")]
        public string Prosition { get; set; }

        [JsonProperty(PropertyName = "Contact_no")]
        public string Sunday { get; set; }

        [JsonProperty(PropertyName = "Contact_email")]
        public string Contact_email { get; set; }
    }
}