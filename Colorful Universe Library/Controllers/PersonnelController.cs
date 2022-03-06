using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Colorful_Universe_Library.Models.Entity;

namespace Colorful_Universe_Library.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: Personnel

        DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();
        public ActionResult Index()
        {
            var pr = db.TBLPERSONEL.ToList();
            return View(pr);
        }

        [HttpPost]
        public ActionResult AddPersonnel(TBLPERSONEL p)
        {

            if (!ModelState.IsValid)
            {
                return View("AddPersonnel");
            }
            var pr1 = db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult AddPersonnel()
        {
            return View();
        }


        public ActionResult DeletePersonnel(int id)
        {
            var pr2 = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(pr2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ComePersonnel(int id)
        {
            var pr3 = db.TBLPERSONEL.Find(id);
            return View("ComePersonnel", pr3);
        }

        public ActionResult UpdatePersonnel(TBLPERSONEL p)
        {
            var pr4 = db.TBLPERSONEL.Find(p.ID);
            pr4.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}