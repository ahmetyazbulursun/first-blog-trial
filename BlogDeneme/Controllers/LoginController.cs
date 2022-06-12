using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogDeneme.Models.Entity;

namespace BlogDeneme.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {

        BlogDenemeEntities db = new BlogDenemeEntities();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            var deger = db.Tbl_Admin.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.PAROLA == p.PAROLA);

            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.KULLANICIADI, false);
                Session["KULLANICIADI"] = deger.KULLANICIADI.ToString();
                return RedirectToAction("BlogIslemleri", "Vitrin");
            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}