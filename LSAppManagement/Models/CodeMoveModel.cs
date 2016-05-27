using LSAppManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSAppManagement.Models
{
    public class CodeMoveModel
    {
        public string SHA1 { get; set; }
        public ApplicationModel App { get; set; }
        public string Environment { get; set; }
        public string Comments { get; set; }
    }
}