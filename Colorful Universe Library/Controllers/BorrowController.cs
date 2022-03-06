using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Colorful_Universe_Library.Models.Entity;

namespace Colorful_Universe_Library.Controllers
{
    public class BorrowController : Controller
    {
        // GET: Borrow

        DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();


        //public ActionResult Index()
        //{
        //    var act = db.TBLHAREKET.ToList();
        //    return View(act);
        //}

        [HttpPost]
        public ActionResult BorrowBook(TBLHAREKET h)
        {
            var bk = db.TBLKITAP.Where(h1 => h1.ID == h.TBLKITAP.ID).FirstOrDefault();
            var usr = db.TBLUYELER.Where(h1 => h1.ID == h.TBLUYELER.ID).FirstOrDefault();
            var prsnl = db.TBLPERSONEL.Where(h1 => h1.ID == h.TBLPERSONEL.ID).FirstOrDefault();
            h.TBLKITAP = bk;
            h.TBLUYELER = usr;
            h.TBLPERSONEL = prsnl;
            var action = db.TBLHAREKET.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BorrowBook()
        {
            List<SelectListItem> v1 = (from i in db.TBLKITAP
                                       select new SelectListItem
                                       {
                                           Text = i.AD,
                                           Value = i.ID.ToString()
                                       }).ToList();
            ViewBag.vle1 = v1;

            List<SelectListItem> v2 = (from i in db.TBLUYELER
                                       select new SelectListItem
                                       {
                                           Text = i.AD,
                                           Value = i.ID.ToString()
                                       }).ToList();
            ViewBag.vle2 = v2;

            List<SelectListItem> v3 = (from i in db.TBLPERSONEL
                                       select new SelectListItem
                                       {
                                           Text = i.PERSONEL,
                                           Value = i.ID.ToString()
                                       }).ToList();
            ViewBag.vle3 = v3;

            return View();
        }
    }
}