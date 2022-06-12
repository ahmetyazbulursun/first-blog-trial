using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogDeneme.Models.Entity;

namespace BlogDeneme.Controllers
{
    [AllowAnonymous]

    public class iletisimController : Controller
    {

        BlogDenemeEntities db = new BlogDenemeEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Mesajlar p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            p.TARIH = DateTime.Now;
            p.DURUM = true;
            db.Tbl_Mesajlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialGaleri()
        {
            var deger = db.Tbl_Galeri.ToList();
            return PartialView(deger);
        }
    }
}