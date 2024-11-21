using KutuphaneYonetimSistemi.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class UyelerController : Controller
    {
        // GET: Uyeler
        KutuphaneDbEntities db = new KutuphaneDbEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var uyeler=db.TblUyeler.ToList();
            var uyeler = db.TblUyeler.ToList().ToPagedList(sayfa, 5);
            return View(uyeler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TblUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            else
            {
                db.TblUyeler.Add(p);
                db.SaveChanges();
                return View();
            }            
        }
        public ActionResult UyeSil(int id)
        {
            var uye=db.TblUyeler.Find(id);
            db.TblUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye=db.TblUyeler.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TblUyeler p)
        {
            var uye=db.TblUyeler.Find(p.ID);
            //db.TblUyeler.Add(uye);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.SIFRE = p.SIFRE;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}