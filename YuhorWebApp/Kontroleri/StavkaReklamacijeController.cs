using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuhorWebApp.DataAccessLayer;
using YuhorWebApp.Models;

namespace YuhorWebApp.Controllers
{
    public class StavkaReklamacijeController : Controller
    {




        public ActionResult Create(int brojReklamacije)
        {
            Reklamacija reklamacija = BrokerBaze.Sesija().VratiReklamaciju(brojReklamacije);
            ViewBag.brojReklamacije = brojReklamacije;
            ViewBag.reklamacija = reklamacija.naziv;
            ArtikalDropDownList();
            return View();
        }

        private void ArtikalDropDownList(object selektovaniArtikal = null)
        {

            var artikalQuery = from k in BrokerBaze.Sesija().VratiArtikle()
                             select k;
            ViewBag.artikalID = new SelectList(artikalQuery, "artikalID", "naziv", selektovaniArtikal);
        }

        [HttpPost]
        public ActionResult Create(StavkaReklamacije stavka)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Reklamacija reklamacija = BrokerBaze.Sesija().VratiReklamaciju(stavka.brojReklamacije);
                    Artikal artikal = BrokerBaze.Sesija().VratiArtikal(stavka.artikalID);
                    StavkaReklamacije novaStavka = new StavkaReklamacije
                    {
                        Status = Status.Dodat,
                        kolicina = stavka.kolicina,
                        razlog = stavka.razlog,
                        artikalID = stavka.artikalID,
                        Artikal = artikal
                    };
                    reklamacija.StavkeReklamacije.Add(novaStavka);
                    string rezultat = BrokerBaze.Sesija().SacuvajReklamaciju(reklamacija);
                    if (rezultat.Equals("Uspesno!"))
                        return RedirectToAction("Details", "Reklamacija", new { brojReklamacije = reklamacija.brojReklamacije });
                    else throw new Exception();
                }
                return View(stavka);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da sacuva stavku!" });
            }
        }

        public ActionResult Edit(string brojReklamacije, string stavka)
        {
            try
            {
                int reklamacija = Int32.Parse(brojReklamacije);
                int rb = Int32.Parse(stavka);
                ViewBag.brojReklamacije = reklamacija;
                Reklamacija reklamacijaIzBaze = BrokerBaze.Sesija().VratiReklamaciju(reklamacija);
                ViewBag.reklamacija = reklamacijaIzBaze.naziv;
                StavkaReklamacije stavkaIzBaze = reklamacijaIzBaze.StavkeReklamacije.FirstOrDefault(c => c.rb == rb);
                ArtikalDropDownList(stavkaIzBaze.Artikal.artikalID);
                return View(stavkaIzBaze);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita stavku!" });
            }
        }

        [HttpPost]

        public ActionResult Edit(StavkaReklamacije stavkaReklamacije)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Reklamacija reklamacijaIzBaze = BrokerBaze.Sesija().VratiReklamaciju(stavkaReklamacije.brojReklamacije);
                    StavkaReklamacije stavkaReklamacijeIzBaze = reklamacijaIzBaze.StavkeReklamacije.FirstOrDefault(c => c.rb == stavkaReklamacije.rb);
                    stavkaReklamacijeIzBaze.kolicina = stavkaReklamacije.kolicina;
                    stavkaReklamacijeIzBaze.razlog = stavkaReklamacije.razlog;
                    stavkaReklamacijeIzBaze.artikalID = stavkaReklamacije.artikalID;
                    stavkaReklamacijeIzBaze.Artikal = BrokerBaze.Sesija().VratiArtikal(stavkaReklamacije.artikalID);
                    stavkaReklamacijeIzBaze.Status = Status.Izmenjen;

                    string rezultat = BrokerBaze.Sesija().SacuvajReklamaciju(reklamacijaIzBaze);
                    if (rezultat.Equals("Uspesno!"))
                        return RedirectToAction("Details", "Reklamacija", new { brojReklamacije = stavkaReklamacije.brojReklamacije });
                    else throw new Exception();
                }
                return View(stavkaReklamacije);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da sacuva cenu!" });
            }
        }
        public ActionResult Delete(string brojReklamacije, string stavka)
        {
            try
            {
                int reklamacija = Int32.Parse(brojReklamacije);
                int rb = Int32.Parse(stavka);
                ViewBag.brojReklamacije = reklamacija;
                Reklamacija reklamacijaIzBaze = BrokerBaze.Sesija().VratiReklamaciju(reklamacija);
                ViewBag.reklamacija = reklamacijaIzBaze.naziv;
                StavkaReklamacije stavkaIzBaze = reklamacijaIzBaze.StavkeReklamacije.FirstOrDefault(c => c.rb == rb);
                ArtikalDropDownList(stavkaIzBaze.Artikal.artikalID);
                return View(stavkaIzBaze);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita stavku!" });
            }
        }

        [HttpPost]

        public ActionResult Delete(StavkaReklamacije stavkaReklamacije)
        {
            try
            {
                Reklamacija reklamacijaIzBaze = BrokerBaze.Sesija().VratiReklamaciju(stavkaReklamacije.brojReklamacije);
                StavkaReklamacije stavkaReklamacijeIzBaze = reklamacijaIzBaze.StavkeReklamacije.FirstOrDefault(c => c.rb == stavkaReklamacije.rb);
               
                stavkaReklamacijeIzBaze.Status = Status.Obrisan;

                string rezultat = BrokerBaze.Sesija().SacuvajReklamaciju(reklamacijaIzBaze);
                if (rezultat.Equals("Uspesno!"))
                    return RedirectToAction("Details", "Reklamacija", new { brojReklamacije = stavkaReklamacije.brojReklamacije });
                else throw new Exception();
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da obrise stavku!" });
            }
        }


    }
}
