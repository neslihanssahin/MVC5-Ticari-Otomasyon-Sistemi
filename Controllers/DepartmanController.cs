using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTİcariOtomasyon.Models.Siniflar;
namespace MvcOnlineTİcariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    c.Departmans.Add(d);
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
            return View(d);
        }

        public ActionResult DepartmanSil(int id)
        {
            var dpr = c.Departmans.Find(id);
            c.Departmans.Remove(dpr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmanGüncelle(int id)
        {
            var dpr = c.Departmans.Find(id);
            return View("DepartmanGüncelle", dpr);
        }
        [HttpPost]
        public ActionResult DepartmanGüncelle(Departman d)
        {
            var dpr = c.Departmans.Find(d.DepartmanID);
            dpr.DepartmanAdı = d.DepartmanAdı;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAdı).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}