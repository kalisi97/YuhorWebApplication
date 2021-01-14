using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using YuhorWebApp.DataAccessLayer;
using YuhorWebApp.Models;

namespace YuhorWebApp.Controllers
{
    public class ArtikalController : Controller
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

                BindingList<Artikal> artikli = BrokerBaze.Sesija().VratiArtikle();
                return View(artikli);
            }
            catch (Exception)
            {

                return View("Error",
                    new ErrorViewModel { Poruka = "Sistem ne moze da ucita artikle!" });

            }
        }

       
        public ActionResult Details(int artikalID)
        {
            try
            {
               
                Artikal artikal = BrokerBaze.Sesija().VratiArtikal(artikalID);
                BindingList<Cena> cene = artikal.ListaCena;
                return View(cene);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita cene za artikal!" });
            }
        }

     
        public ActionResult Create()
        {
            try
            {

                Artikal artikal = new Artikal();
                artikal.ListaCena = new BindingList<Cena>() { 
                    new Cena() { datumOd = DateTime.Now } };
                return View(artikal);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Greska!" });
            }
        }

   
        [HttpPost]
     
        public ActionResult Create(Artikal artikal, Cena cena)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    cena.Status = Status.Dodat;
                    artikal.ListaCena.Add(cena);
                    artikal.Status = Status.Dodat;
                    string rezultat = BrokerBaze.Sesija().SacuvajArtikal(artikal);
                    if(rezultat.Equals("Uspesno!"))
                    {
                      return  RedirectToAction("Index", new { poruka = "Dodat je novi artikal!" });
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
              
                    return View(artikal);
                

            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da kreira artikal!" });
            }
        }

        public ActionResult Edit(int artikalID)
        {
            try
            {
                Artikal artikal = BrokerBaze.Sesija().VratiArtikal(artikalID);
                return View(artikal);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita artikal!" });
            }
        }

      
        [HttpPost]
    
        public ActionResult Edit(Artikal artikal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Artikal artikalIzBaze = BrokerBaze.Sesija().VratiArtikal(artikal.artikalID);
                    artikalIzBaze.naziv = artikal.naziv;
                    artikalIzBaze.pdv = artikal.pdv;
                    artikalIzBaze.rabat = artikal.rabat;
                    artikalIzBaze.Status = Status.Izmenjen;
                    string rezultat = BrokerBaze.Sesija().SacuvajArtikal(artikalIzBaze);
                    if (rezultat.Equals("Uspesno!"))
                        return RedirectToAction("Index", new { poruka = "Sistem je uspesno sacuvao artikal!" });
                    else throw new Exception();
                }

                return View(artikal);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da sacuva artikal!" });
            }
        }

       
        public ActionResult Delete(int artikalID)
        {
            try
            {
                Artikal artikal = BrokerBaze.Sesija().VratiArtikal(artikalID);
                return View(artikal);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita artikal!" });
            }
        }

        [HttpPost]

        public ActionResult Delete(Artikal artikal)
        {
            try
            {
                Artikal artikalIzBaze = BrokerBaze.Sesija().VratiArtikal(artikal.artikalID);
                artikalIzBaze.Status = Status.Obrisan;
                string rezultat = BrokerBaze.Sesija().SacuvajArtikal(artikalIzBaze);
                if (rezultat.Equals("Uspesno!"))
                    return RedirectToAction("Index", new { poruka = "Sistem je uspesno obrisao artikal!" });
                else throw new Exception();
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da obrise artikal!" });
            }
        }
    }
}
