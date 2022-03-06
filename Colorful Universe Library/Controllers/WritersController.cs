using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Colorful_Universe_Library.Models.Entity;

namespace Colorful_Universe_Library.Controllers
{
    public class WritersController : Controller
    {
        // GET: Writers
        DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();
        public ActionResult Index()
        {
            var writer = db.TBLYAZAR.ToList();
            return View(writer);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(TBLYAZAR y)
        {
            var wrt = db.TBLYAZAR.Add(y);
            db.SaveChanges();
            return View();

        }

        public ActionResult DeleteWriter(int id)
        {
            var wrt = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(wrt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ComeWriter(int id)
        {
            var wrt = db.TBLYAZAR.Find(id);
            return View("ComeWriter", wrt);
        }

        public ActionResult UpdateWriter(TBLYAZAR z)
        {
            var wrt = db.TBLYAZAR.Find(z.ID);
            wrt.AD = z.AD;
            wrt.SOYAD = z.SOYAD;
            wrt.DETAY = z.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}