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
    public class KupacController : Controller
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

                List<Kupac> kupci = BrokerBaze.Sesija().VratiKupce();
                return View(kupci);
            }
            catch (Exception)
            {

                return View("Error", 
                    new ErrorViewModel { Poruka = "Sistem ne moze da ucita kupce!" });
                
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kupac kupac)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    kupac.Status = Status.Dodat;
                    string rezultat = BrokerBaze.Sesija().SacuvajKupca(kupac);
                    if (rezultat.Equals("Uspesno!"))
                        return RedirectToAction("Index", new { poruka = "Sistem je uspesno sacuvao kupca!" });
                    else throw new Exception();
                }
                return View(kupac);
            }
            catch(Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da sacuva kupca!" });
            }
        }

        public ActionResult Edit(int kupacID)
        {
            try
            {
                Kupac kupac = BrokerBaze.Sesija().VratiKupca(kupacID);
                return View(kupac);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita kupca!" });
            }
        }

        [HttpPost]
     
        public ActionResult Edit(Kupac kupac)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Kupac kupacIzBaze = BrokerBaze.Sesija().VratiKupca(kupac.kupacID);
                    kupacIzBaze.Status = Status.Izmenjen;
                    kupacIzBaze.mb = kupac.mb;
                    kupacIzBaze.naziv = kupac.naziv;
                    kupacIzBaze.pib = kupac.pib;
                    kupacIzBaze.tr = kupac.tr;
                    string rezultat = BrokerBaze.Sesija().SacuvajKupca(kupacIzBaze);
                    if (rezultat.Equals("Uspesno!"))
                        return RedirectToAction("Index", new { poruka = "Sistem je uspesno sacuvao kupca!" });
                    else throw new Exception();
                }
                return View(kupac);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da sacuva kupca!" });
            }
        }

        
        public ActionResult Delete(int kupacID)
        {
            try
            {
                Kupac kupac = BrokerBaze.Sesija().VratiKupca(kupacID);
                return View(kupac);
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da ucita kupca!" });
            }
        }

  
        [HttpPost]
      
        public ActionResult Delete(Kupac kupac)
        {
            try
            {
                Kupac kupacIzBaze = BrokerBaze.Sesija().VratiKupca(kupac.kupacID);
                kupacIzBaze.Status = Status.Obrisan;
                string rezultat = BrokerBaze.Sesija().SacuvajKupca(kupacIzBaze);
                if (rezultat.Equals("Uspesno!"))
                    return RedirectToAction("Index", new { poruka = "Sistem je uspesno obrisao kupca!" });
                else throw new Exception();
            }
            catch (Exception)
            {
                return View("Error",
                     new ErrorViewModel { Poruka = "Sistem ne moze da obrise kupca!" });
            }
        }
    }
}
