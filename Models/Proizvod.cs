using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace MVC.Models
{
    public class Proizvod
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Proizvodjac { get; set; }
        public decimal Cena { get; set; }

        public Proizvod() { }

        public Proizvod(DataRow proizvod)
        {
            Id = (int)proizvod["Id"];
            Naziv = proizvod["Naziv"].ToString();
            Proizvodjac = proizvod["Proizvodjac"].ToString();
            Cena = (decimal)proizvod["Cena"];
        }
    }
}