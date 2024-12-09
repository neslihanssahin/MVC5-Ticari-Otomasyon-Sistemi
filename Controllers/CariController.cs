using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTİcariOtomasyon.Models.Siniflar;

namespace MvcOnlineTİcariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Caris.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari p)
        {
            p.Durum = true;
            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cr = c.Caris.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            var cari = c.Caris.Find(id);
            return View("CariGuncelle", cari);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cari d)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGuncelle");
            }
            var cr = c.Caris.Find(d.CariID);
            cr.CariAd = d.CariAd;
            cr.CariSoyad = d.CariSoyad;
            cr.CariSehir = d.CariSehir;
            cr.CariMail = d.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {

            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr=c.Caris.Where(x=>x.CariID == id).Select(y=>y.CariAd + " "+ y.CariSoyad).FirstOrDefault();
            ViewBag.cari=cr;
            return View(degerler);
        }

    }
}