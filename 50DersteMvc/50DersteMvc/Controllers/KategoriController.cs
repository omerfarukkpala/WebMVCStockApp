using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50DersteMvc.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace _50DersteMvc.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcStokEntitiess db = new DbMvcStokEntitiess();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBL_KATEGORILER.ToList();
            var degerler = db.TBL_KATEGORILER.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBL_KATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TBL_KATEGORILER.Find(id);
            db.TBL_KATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_KATEGORILER.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult Guncelle(TBL_KATEGORILER p1)
        {
            var ktg = db.TBL_KATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIADI = p1.KATEGORIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}