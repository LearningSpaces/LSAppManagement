using LSAppManagement.Models;
using LSAppManagement.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSAppManagement.Helpers
{
    public class DbFactory
    {
        public static ApplicationDbContext getDb()
        {
            return new ApplicationDbContext(Settings.ConnectionString);
        }
    }
}