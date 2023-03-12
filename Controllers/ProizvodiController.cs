using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.Konekcija;
using System.Security.Principal;
using System.Net.Http;
using System.Web.UI;

namespace MVC.Controllers
{
    public class ProizvodiController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unesi()
        {
            return View();
        }

        public ActionResult SacuvajPodatke(Proizvod proizvodi)
        {
            using (SqlConnection kon = new SqlConnection(Konekcija.Konekcija.Povezi()))
            {
                using (SqlCommand kom = new SqlCommand("INSERT INTO proizvodi VALUES ('" + proizvodi.Naziv + "', '" + proizvodi.Proizvodjac + "', " + proizvodi.Cena + ")", kon))
                {
                    if (kon.State != ConnectionState.Open) kon.Open();
                    kom.ExecuteNonQuery();
                }
            }

            return RedirectToAction("TabelaCveca");
        }

        public ActionResult TabelaCveca()
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            using (SqlConnection kon = new SqlConnection(Konekcija.Konekcija.Povezi()))
            {
                using (SqlCommand kom = new SqlCommand("SELECT * FROM cvet", kon))
                {
                    if (kon.State != ConnectionState.Open) kon.Open();

                    SqlDataReader drProizvod = kom.ExecuteReader();
                    DataTable dtProizvod = new DataTable();
                    dtProizvod.Load(drProizvod);

                    foreach (DataRow ProizvodSlog in dtProizvod.Rows) proizvodi.Add(new Proizvod(ProizvodSlog));
                }
            }

            return View(proizvodi);
        }
    }
}