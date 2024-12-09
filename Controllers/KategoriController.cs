using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTİcariOtomasyon.Models.Siniflar;

namespace MvcOnlineTİcariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context c=new Context();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler =c.Kategoris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    c.Kategoris.Add(k);
                    c.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Hata mesajı görüntüleme veya loglama işlemi yapılabilir
                    ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                }
            }

            // Hata durumunda form yeniden gösterilir
            return View(k);
        }


        public ActionResult KategoriSil(int id)
        {
            var ktg=c.Kategoris.Find(id);  
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGüncelle(int id)
        {
            var ktg = c.Kategoris.Find(id);
            return View("KategoriGüncelle",ktg);
        }
        [HttpPost]
        public ActionResult KategoriGüncelle(Kategori k)
        {
            var ktg = c.Kategoris.Find(k.KategoriID);
            ktg.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}