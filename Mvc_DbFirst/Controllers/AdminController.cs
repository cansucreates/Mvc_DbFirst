using Mvc_DbFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_DbFirst.Controllers
{
    public class AdminController : Controller
    {

        Mvc_dbFirstEntities db = new Mvc_dbFirstEntities();

        // GET: Admin
        public ActionResult Index() // Listeleme
        {
            return View(db.Urunlers.ToList());
        }

        // Kaydetme işlemleri için sayfa kontrolleri

        [HttpGet]
        public ActionResult Kaydet() // boş bir form sayfası açması için
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kaydet(Urunler urun)
        {
            db.Urunlers.Add(urun);
            db.SaveChanges();
            // return View(); // bu şekilde yaparsak sayfa yenilenir ve boş form sayfası açılır
            return RedirectToAction("Index"); // bu şekilde yaparsak sayfa yenilenmez ve listeleme sayfasına yönlendirilir
        }


        // Güncelleme işlemleri için sayfa kontrolleri

        [HttpGet] // güncelleme işlemi için id bilgisini almak için
        public ActionResult Edit(int id) // boş bir form sayfası açması için
        {
            var sonuc = db.Urunlers.Where(x => x.id == id).FirstOrDefault(); // id'ye göre veriyi getir
            return View(sonuc);
        }

        [HttpPost]
        public ActionResult Edit(int id, Urunler urun)
        {
            db.Urunlers.AddOrUpdate(urun); // güncelleme işlemi
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Silme işlemleri için sayfa kontrolleri

        // direk silmek için (viewsız)
        /* public ActionResult Delete(int id)
        {
            var sonuc = db.Urunlers.Where(x => x.id == id).FirstOrDefault(); // id'ye göre veriyi getir
            db.Urunlers.Remove(sonuc); // silme işlemi
            db.SaveChanges();
            return RedirectToAction("Index");
        } */

        // silme işlemi için onay sayfası açmak için
        [HttpGet]
        public ActionResult Delete(int id) 
        {
            var sonuc = db.Urunlers.Where(x => x.id == id).FirstOrDefault(); // id'ye göre veriyi getir
            return View(sonuc);
        }

        [HttpPost]
        public ActionResult Delete(int id, Urunler urun)
        {
            var sonuc = db.Urunlers.Where(x => x.id == id).FirstOrDefault(); // id'ye göre veriyi getir
            db.Urunlers.Remove(sonuc); // silme işlemi
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}