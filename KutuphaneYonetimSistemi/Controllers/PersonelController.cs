using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneYonetimSistemi.Models.Entity;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index()
        {
            var persons=db.TblPersonel.ToList();
            return View(persons);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TblPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            else
            {
                db.TblPersonel.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
        }
        public ActionResult PersonelSil(int id)
        {
            var persons=db.TblPersonel.Find(id);
            db.TblPersonel.Remove(persons);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
           var prs=db.TblPersonel.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(TblPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGetir");
            }
            else
            {
                var prs = db.TblPersonel.Find(p.ID);
                prs.PERSONEL = p.PERSONEL;
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
        }
    }
}