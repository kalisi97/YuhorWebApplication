using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using YuhorWebApp.DataAccessLayer;
using YuhorWebApp.Models;

namespace YuhorWebApp.Controllers
{
    public class ReklamacijaController : Controller
    {

        public ActionResult Index(string poruka)
        {
            try
            {
                if (!string.IsNullOrEmpty(poruka))
                {
                    ViewBag.Poruka = poruka;
                }
                else ViewBag.Poruka = String.Empty;

                BindingList<Reklamacija> reklamacije = BrokerBaze.Sesija().VratiReklamacije();
                return View(reklamacije);
            }
            catch (Exception)
            {

                return View("Error",
                    new ErrorViewModel { Poruka = "Sistem ne moze da ucita reklamacije!" });

            }
        }

        public ActionResult Details(int brojReklamacije)
        {
            try
            {

                Reklamacija reklamacija = BrokerBaze.Sesija().VratiReklamaciju(brojReklamacije);
                BindingList<StavkaReklamacije> stavke = reklamacija.StavkeReklamacije;
                return View(stavke);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita stavke reklamacije!" });
            }
        }

        
        public ActionResult Create()
        {
            Reklamacija reklamacija = new Reklamacija() { datum = DateTime.Now};
            reklamacija.StavkeReklamacije.Add(new StavkaReklamacije { });
            KupacDropDownList();
            ArtikalDropDownList();
            return View(reklamacija);
        }


      
        [HttpPost]
       
        public JsonResult Create([FromBody] Object reklamacija)
        {
            try
            {
                string reklamacijaZaDeserijalizaciju = reklamacija.ToString();
                Reklamacija r = Newtonsoft.Json.JsonConvert.DeserializeObject<Reklamacija>(reklamacijaZaDeserijalizaciju);
                Kupac kupac = BrokerBaze.Sesija().VratiKupca(r.kupacID);
                Reklamacija novaReklamacija = new Reklamacija
                {
                    datum = r.datum,
                    naziv = r.naziv,
                    razlog = r.razlog,
                    Kupac = kupac,
                    kupacID = kupac.kupacID,
                    Status = Status.Dodat
                };

                BindingList<StavkaReklamacije> stavke = new BindingList<StavkaReklamacije>();

                foreach(StavkaReklamacije s in r.StavkeReklamacije)
                {
                    Artikal artikal = BrokerBaze.Sesija().VratiArtikal(s.artikalID);

                    StavkaReklamacije novaStavka = new StavkaReklamacije

                    {
                        Status = Status.Dodat,
                        razlog = s.razlog,
                        kolicina = s.kolicina,
                        Artikal = artikal,
                        artikalID = artikal.artikalID
                    };

                    stavke.Add(novaStavka);
                }

                novaReklamacija.StavkeReklamacije = stavke;

                string rezultat = BrokerBaze.Sesija().SacuvajReklamaciju(novaReklamacija);

                if (rezultat.Equals("Uspesno!")) return Json("Reklamacija sacuvana!");
                else return Json("Greska!");

            }
            catch (Exception)
            {

                return Json("Doslo je do greske prilikom unosa!");
            }
        }

        public ActionResult Edit(int brojReklamacije)
        {
            try
            {
                Reklamacija reklamacija = BrokerBaze.Sesija().VratiReklamaciju(brojReklamacije);
                KupacDropDownList(reklamacija.Kupac.kupacID);
                return View(reklamacija);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita reklamaciju!" });
            }
        }


        private void ArtikalDropDownList(object selektovaniArtikal = null)
        {

            var artikalQuery = from k in BrokerBaze.Sesija().VratiArtikle()
                               select k;
            ViewBag.artikalID = new SelectList(artikalQuery, "artikalID", "naziv", selektovaniArtikal);
        }

        private void KupacDropDownList(object selektovaniKupac = null)
        {
            var kupacQuery = from k in BrokerBaze.Sesija().VratiKupce()
                             select k;
            ViewBag.kupacID = new SelectList(kupacQuery, "kupacID", "naziv", selektovaniKupac);
        }

        [HttpPost]

        public ActionResult Edit(Reklamacija reklamacija)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Reklamacija reklamacijaIzBaze = BrokerBaze.Sesija().VratiReklamaciju(reklamacija.brojReklamacije);
                    reklamacijaIzBaze.naziv = reklamacija.naziv;
                    reklamacijaIzBaze.datum = reklamacija.datum;
                    reklamacijaIzBaze.razlog = reklamacija.razlog;
                    reklamacijaIzBaze.kupacID = reklamacija.kupacID;
                    reklamacijaIzBaze.Status = Status.Izmenjen;
                    string rezultat = BrokerBaze.Sesija().SacuvajReklamaciju(reklamacijaIzBaze);
                    if (rezultat.Equals("Uspesno!"))
                        return RedirectToAction("Index", new { poruka = "Sistem je uspesno sacuvao reklamaciju!" });
                    else throw new Exception();
                }
                return View(reklamacija);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da sacuva reklamaciju!" });
            }
        }

        public ActionResult Delete(int brojReklamacije)
        {
            try
            {
                Reklamacija reklamacija = BrokerBaze.Sesija().VratiReklamaciju(brojReklamacije);
                KupacDropDownList(reklamacija.Kupac.kupacID);
                return View(reklamacija);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita reklamaciju!" });
            }
        }

        [HttpPost]

        public ActionResult Delete(Reklamacija reklamacija)
        {
            try
            {
                Reklamacija reklamacijaIzBaze = BrokerBaze.Sesija().VratiReklamaciju(reklamacija.brojReklamacije);
                reklamacijaIzBaze.Status = Status.Obrisan;
                string rezultat = BrokerBaze.Sesija().SacuvajReklamaciju(reklamacijaIzBaze);
                if (rezultat.Equals("Uspesno!"))
                    return RedirectToAction("Index", new { poruka = "Sistem je uspesno obrisao reklamaciju!" });
                else throw new Exception();
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da obrise reklamaciju!" });
            }
        }
    }
}
