using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSAppManagement.Models
{
    public class PermissionModel
    {
        [JsonProperty("admin")]
        public bool Admin { get; set; }
        [JsonProperty("push")]
        public bool Push { get; set; }
        [JsonProperty("pull")]
        public bool Pull { get; set; }
    }
}