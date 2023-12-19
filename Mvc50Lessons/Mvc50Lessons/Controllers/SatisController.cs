using _50DersteMvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _50DersteMvc.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        DbMvcStokEntitiess db = new DbMvcStokEntitiess();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBL_SATISLAR p)
        {
            db.TBL_SATISLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}