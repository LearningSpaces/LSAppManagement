using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LSAppManagement.Models
{
    public class Settings
    {
        private static string UserName = "app_mgmt_account";
        private static string Password = "password123";

        public static string WebserviceCredentials = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(UserName + ":" + Password));
        public static string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=LearningSpaces;Integrated Security=False;User ID=AppManagement;Password=p3rryth3pl@t;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
    }
}