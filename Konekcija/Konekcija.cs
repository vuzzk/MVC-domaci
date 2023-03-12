using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVC.Konekcija
{
    public class Konekcija
    {
        public static string Povezi()
        {
            return ConfigurationManager.ConnectionStrings["eshop"].ConnectionString;
        }
    }
}