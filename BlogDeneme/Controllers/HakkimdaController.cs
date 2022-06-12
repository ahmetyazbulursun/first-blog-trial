using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogDeneme.Models.Entity;

namespace BlogDeneme.Controllers
{
    [AllowAnonymous]

    public class HakkimdaController : Controller
    {

        BlogDenemeEntities db = new BlogDenemeEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialBilgiler()
        {
            var deger = db.Tbl_Hakkimda.ToList();
            return PartialView(deger);
        }

        public PartialViewResult PartialGaleri()
        {
            var deger = db.Tbl_Galeri.ToList();
            return PartialView(deger);
        }
    }
}