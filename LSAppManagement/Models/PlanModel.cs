using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSAppManagement.Models
{
    public class PlanModel
    {
        public string Name { get; set; }
        public int Space { get; set; }
        public int PrivateReposCount { get; set; }
    }
}