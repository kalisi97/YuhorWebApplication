using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YuhorWebApp.DataAccessLayer;
using YuhorWebApp.Models;

namespace YuhorWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
          
            _logger = logger;
        }

        public IActionResult Index()
        {
            #region Kupac
            // kupac crud
            //  List<Kupac> kupci = BrokerBaze.Sesija().VratiKupce();
            // Kupac kupac = BrokerBaze.Sesija().VratiKupca(1);
            /* // autoincrement je, ne setuje mu se id
            Kupac kupac = new Kupac
            {
               // kupacID = 3,
                naziv = "Mercator",
                tr = "22",
                mb = "11",
                pib = "222",
                Status = Status.Dodat
            };
            BrokerBaze.Sesija().SacuvajKupca(kupac);
            */
            /*
            Kupac kupac = BrokerBaze.Sesija().VratiKupca(4);
            kupac.mb = "izmenjen";
            kupac.Status = Status.Izmenjen;
            string poruka = BrokerBaze.Sesija().SacuvajKupca(kupac);
            */
            /*
            Kupac kupac = BrokerBaze.Sesija().VratiKupca(4);
            kupac.Status = Status.Obrisan;
            string poruka = BrokerBaze.Sesija().SacuvajKupca(kupac);
            */
            #endregion

            #region Artikal
            /*
            Artikal artikal = new Artikal
            {
                naziv = "Artikal2",
                pdv = 50,
                rabat = 500,
                Status = Status.Dodat
            };

            Cena cena = new Cena
            {
                Status = Status.Dodat,
                datumOd = DateTime.Now,
                iznos = 900
            };

            artikal.ListaCena = new System.ComponentModel.BindingList<Cena>() { cena };
          
            */
            // Artikal artikal = BrokerBaze.Sesija().VratiArtikal(33);
            /* za izmenu naziva
         //   artikal.naziv = "Izmenjen naziv artikla";
          //  artikal.Status = Status.Izmenjen;
            */
            //za izmenu cene
            /*
            artikal.Status = Status.Izmenjen;
            artikal.ListaCena.ElementAt(0).Status = Status.Izmenjen;
            artikal.ListaCena.ElementAt(0).iznos = 500;

            BrokerBaze.Sesija().SacuvajArtikal(artikal);
            */
            //brisanje cene
            //  artikal.ListaCena.ElementAt(0).Status = Status.Obrisan;
            //   artikal.Status = Status.Izmenjen;
            //brisanje artikla

            /*
            Artikal artikal = BrokerBaze.Sesija().VratiArtikal(34);
            artikal.Status = Status.Obrisan;
            BrokerBaze.Sesija().SacuvajArtikal(artikal);
            */

            //BindingList<Artikal> artikli = BrokerBaze.Sesija().VratiArtikle();
            #endregion

            #region Reklamacija
            /*
            Kupac k1 = BrokerBaze.Sesija().VratiKupca(1);

            Reklamacija reklamacija = new Reklamacija
            {
                datum = DateTime.Now,
                Kupac = k1,
                naziv = "kaca",
                razlog = "dodato",
                Status = Status.Dodat

            };

            Artikal a1 = BrokerBaze.Sesija().VratiArtikal(25);
            StavkaReklamacije stavka = new StavkaReklamacije
            {
                Status = Status.Dodat,
                kolicina = 1,
                razlog = "blabla",

                Artikal = a1
            };

            reklamacija.StavkeReklamacije =
                new BindingList<StavkaReklamacije>() { stavka };

            BrokerBaze.Sesija().SacuvajReklamaciju(reklamacija);
            
          /*
            Artikal a1 = BrokerBaze.Sesija().VratiArtikal(33);
            Reklamacija reklamacija = BrokerBaze.Sesija().VratiReklamaciju(15);
            reklamacija.Status = Status.Dodat;
            StavkaReklamacije stavkaReklamacije = new StavkaReklamacije()
            {
                Artikal = a1,
                Status = Status.Dodat,
                razlog = "zxcv",
                kolicina = 3
            };
            reklamacija.StavkeReklamacije.Add(stavkaReklamacije);
          */
            //    BrokerBaze.Sesija().SacuvajReklamaciju(reklamacija);

            #endregion

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { Poruka = "Greska!" });
        }
    }
}
