using LSAppManagement.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSAppManagement.Models
{
    public class CommitModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("sha")]
        public string SHA1 { get; set; }
        [JsonProperty("commit")]
        public CommitDetails Details { get; set; }
        public string Message
        {
            get
            {
                return Details != null ? Details.Message : "";
            }
        }
    }

    public class CommitDetails
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}