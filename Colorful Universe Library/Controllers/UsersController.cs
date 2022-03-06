using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Colorful_Universe_Library.Models.Entity;

namespace Colorful_Universe_Library.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users

        DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();
        public ActionResult Index(int Sayfa = 1)
        {
            var usr = db.TBLUYELER.ToList().ToPagedList(Sayfa,4);
            return View(usr);
        }

        [HttpPost]
        public ActionResult AddUser(TBLUYELER u)
        {
            if (!ModelState.IsValid)
            {
                return View("AddUser");
            }
            var usr1 = db.TBLUYELER.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult AddUser()
        {
            return View();  
        }

        public ActionResult DeleteUser(int id)
        {
            var usr2 = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(usr2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ComeUser(int id)
        {
            var usr3 = db.TBLUYELER.Find(id);
            return View("ComeUser", usr3);
        }

        public ActionResult UpdateUser(TBLUYELER u)
        {
            var usr4 = db.TBLUYELER.Find(u.ID);

            if (!ModelState.IsValid)
            {
                return View("ComeUser");
            }

            usr4.AD = u.AD;
            usr4.SOYAD = u.SOYAD;
            usr4.MAIL = u.MAIL;
            usr4.KULLANICIADI = u.KULLANICIADI;
            usr4.SIFRE = u.SIFRE;
            usr4.TELEFON = u.TELEFON;
            usr4.OKUL = u.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}