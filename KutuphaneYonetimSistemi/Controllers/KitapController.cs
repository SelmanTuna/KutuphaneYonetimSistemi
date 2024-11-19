using KutuphaneYonetimSistemi.Models;
using KutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap        
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index()
        {
            var kitaplar = db.TblKitap.ToList();
            return View(kitaplar);
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TblKitap p)
        {
            var ktg = db.TblKategori.Where(k => k.ID == p.TblKategori.ID).FirstOrDefault();
            var yzr = db.TblYazar.Where(y => y.ID == p.TblYazar.ID).FirstOrDefault();
            p.TblKategori = ktg;
            p.TblYazar = yzr;
            db.TblKitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var ktb = db.TblKitap.Find(id);
            db.TblKitap.Remove(ktb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktb = db.TblKitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("KitapGetir", ktb);
        }
        
    }
}