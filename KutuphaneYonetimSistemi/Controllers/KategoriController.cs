using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneYonetimSistemi.Models;
using KutuphaneYonetimSistemi.Models.Entity;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori        
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index()
        {
            var kategoriler = db.TblKategori.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TblKategori k)
        {
            db.TblKategori.Add(k); // parametre olarak inputu ekle 
            db.SaveChanges();  // db ye kaydet.
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg=db.TblKategori.Find(id); // id yi bul
            db.TblKategori.Remove(ktg); // bulunan id yi sil  
            db.SaveChanges();    // silinen id yi kaydet.
            return RedirectToAction("Index"); // ındex sayfası tekrar yenilensin.
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TblKategori.Find(id); //id ye göre tablodan seçilen datayı bul.
            return View("KategoriGetir", ktg); // kategorigetir view sayfasında ktg nesnesindeki id yi göster.
        }
        public ActionResult KategoriGuncelle(TblKategori k)
        {
            var ktg=db.TblKategori.Find(k.ID);
            ktg.AD = k.AD;
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}