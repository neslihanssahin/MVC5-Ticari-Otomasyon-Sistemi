using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTİcariOtomasyon.Models.Siniflar;

namespace MvcOnlineTİcariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c=new Context();
        public ActionResult Index()
        {
            var urunler=c.Uruns.Where(x=>x.Durum==true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.KategoriAd,
                                               Value=x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
           c.Uruns.Add(u);
           c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger=c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var deger = c.Uruns.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun u)
        {
            var urun=c.Uruns.Find(u.UrunID);
            urun.UrunAd=u.UrunAd;
            urun.Marka=u.Marka;
            urun.Stok=u.Stok;
            urun.AlisFiyati=u.AlisFiyati;
            urun.SatisFiyati = u.SatisFiyati;
            urun.Kategoriid=u.Kategoriid;
            urun.UrunGorsel=u.UrunGorsel;
            urun.Durum=u.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }


    }
}