using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Colorful_Universe_Library.Models.Entity;

namespace Colorful_Universe_Library.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books

        DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();

        public ActionResult Index(string p)
        {
            var book = from k in db.TBLKITAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                book = book.Where(m => m.AD.Contains(p));
            }
           // var book = db.TBLKITAP.ToList();
           return View(book.ToList());
        }


        [HttpPost]
        public ActionResult AddBook(TBLKITAP c1)
        {
            var ctg = db.TBLKATEGORI.Where(c => c.ID == c1.TBLKATEGORI.ID).FirstOrDefault();
            var wrt = db.TBLYAZAR.Where(k => k.ID == c1.TBLYAZAR.ID).FirstOrDefault();
            c1.TBLKATEGORI = ctg;
            c1.TBLYAZAR = wrt;
            var value = db.TBLKITAP.Add(c1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]

        public ActionResult AddBook()
        {
            List<SelectListItem> value1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();

            ViewBag.vl2 = value1;

            List<SelectListItem> value2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vl3 = value2;
            return View();
        }

        public ActionResult DeleteBook(int id)
        {
            var book1 = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(book1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ComeBook(int id)
        {
            var book2 = db.TBLKITAP.Find(id);
            List<SelectListItem> value1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();

            ViewBag.vl2 = value1;

            List<SelectListItem> value2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vl3 = value2;
            return View("ComeBook", book2);
        }

        public ActionResult UpdateBook(TBLKITAP c2)
        {
            var book3 = db.TBLKITAP.Find(c2.ID);
            book3.AD = c2.AD;
            var ctg = db.TBLKATEGORI.Where(k => k.ID == c2.TBLKATEGORI.ID).FirstOrDefault();
            var wrt = db.TBLYAZAR.Where(k => k.ID == c2.TBLYAZAR.ID).FirstOrDefault();
            book3.TBLKATEGORI = ctg;
            book3.TBLYAZAR = wrt;
            book3.YAYINEVI = c2.YAYINEVI;
            book3.BASIMYIL = c2.BASIMYIL;
            book3.SAYFASAYISI = c2.SAYFASAYISI;

            db.SaveChanges();
            return RedirectToAction("Index");
           
        }


    }
}