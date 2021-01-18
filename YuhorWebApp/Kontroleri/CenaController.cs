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
    public class CenaController : Controller
    {
 
        public ActionResult Create(int artikalID)
        {
            Artikal artikal = BrokerBaze.Sesija().VratiArtikal(artikalID);
            ViewBag.artikalID = artikalID;
            ViewBag.artikal = artikal.naziv;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cena cena)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Artikal artikal = BrokerBaze.Sesija().VratiArtikal(cena.artikalID);
                    Cena novaCena = new Cena
                    {
                        datumOd = cena.datumOd,
                        iznos = cena.iznos,
                        Status = Status.Dodat
                    };
                    artikal.ListaCena.Add(novaCena);
                    string rezultat = BrokerBaze.Sesija().SacuvajArtikal(artikal);
                    if (rezultat.Equals("Uspesno!"))
                        return RedirectToAction("Details", "Artikal", new { artikalID = cena.artikalID });
                    else throw new Exception();
                }
                return View(cena);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da sacuva kupca!" });
            }
        }

        public ActionResult Edit(string artikalID, string datumOd)
        {
            try
            {
                
                    int artikal = Int32.Parse(artikalID);
                    DateTime datum = DateTime.Parse(datumOd);
                    ViewBag.artikalID = artikal;
                    Artikal artikalIzBaze = BrokerBaze.Sesija().VratiArtikal(artikal);
                    ViewBag.artikal = artikalIzBaze.naziv;
                    Cena cenaIzBaze = artikalIzBaze.ListaCena.FirstOrDefault(c => c.datumOd == datum);
                    return View(cenaIzBaze);
                
               
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita cenu!" });
            }
        }

        [HttpPost]
       
        public ActionResult Edit(Cena cena)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Artikal artikalIzBaze = BrokerBaze.Sesija().VratiArtikal(cena.artikalID);
                    Cena cenaIzBaze = artikalIzBaze.ListaCena.FirstOrDefault(c => c.datumOd == cena.datumOd);
                    cenaIzBaze.iznos = cena.iznos;
                    cenaIzBaze.Status = Status.Izmenjen;
                   
                    string rezultat = BrokerBaze.Sesija().SacuvajArtikal(artikalIzBaze);
                    if (rezultat.Equals("Uspesno!"))
                        return RedirectToAction("Details", "Artikal", new { artikalID = cena.artikalID });
                    else throw new Exception();
                }
                return View(cena);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da sacuva cenu!" });
            }
        }

        
        public ActionResult Delete(string artikalID, string datumOd)
        {
            try
            {
                int artikal = Int32.Parse(artikalID);
                DateTime datum = DateTime.Parse(datumOd);
                ViewBag.artikalID = artikal;
                Artikal artikalIzBaze = BrokerBaze.Sesija().VratiArtikal(artikal);
                ViewBag.artikal = artikalIzBaze.naziv;
                Cena cenaIzBaze = artikalIzBaze.ListaCena.FirstOrDefault(c => c.datumOd == datum);
                return View(cenaIzBaze);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita cenu!" });
            }
        }

        [HttpPost]

        public ActionResult Delete(Cena cena)
        {
            try
            {
                Artikal artikalIzBaze = BrokerBaze.Sesija().VratiArtikal(cena.artikalID);
                Cena cenaIzBaze = artikalIzBaze.ListaCena.FirstOrDefault(c => c.datumOd == cena.datumOd);
                cenaIzBaze.iznos = cena.iznos;
                cenaIzBaze.Status = Status.Obrisan;
                string rezultat = BrokerBaze.Sesija().SacuvajArtikal(artikalIzBaze);
                if (rezultat.Equals("Uspesno!"))
                    return RedirectToAction("Details", "Artikal", new { artikalID = cena.artikalID });
                else throw new Exception();
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da obrise cenu!" });
            }
        }
    }
}
