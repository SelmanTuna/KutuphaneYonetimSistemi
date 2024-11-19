using KutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        KutuphaneDbEntities db = new KutuphaneDbEntities();  

        public ActionResult Index()
        {
            var yazarlar=db.TblYazar.ToList();
            return View(yazarlar);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TblYazar y)
        {
            db.TblYazar.Add(y);
            db.SaveChanges();
            return View(); 
        }
        public ActionResult YazarSil(int id)
        {
            var yzr=db.TblYazar.Find(id);
            db.TblYazar.Remove(yzr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr=db.TblYazar.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TblYazar y)
        {
            var yzr = db.TblYazar.Find(y.ID);
            yzr.AD = y.AD;
            yzr.SOYAD = y.SOYAD;
            yzr.DETAY = y.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}