using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Colorful_Universe_Library.Models.Entity;//Veri tabanındna yararlanabilmek için kütüphanemizi çağırdık.

namespace Colorful_Universe_Library.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Index
        DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();

        public ActionResult Index()
        {
            var values = db.TBLKATEGORI.ToList();
            
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
         public ActionResult AddCategory(TBLKATEGORI c1)
        {
            db.TBLKATEGORI.Add(c1);
            db.SaveChanges();
            return View();
        }

        public ActionResult CategoryDelete(int id)
        {
            var category1 = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(category1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ComeCategory(int id)
        {
            var ctg = db.TBLKATEGORI.Find(id);
            return View("ComeCategory", ctg);
        }

        public ActionResult UpdateCategory(TBLKATEGORI z)
        {
            var ctg = db.TBLKATEGORI.Find(z.ID);
            ctg.AD = z.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}