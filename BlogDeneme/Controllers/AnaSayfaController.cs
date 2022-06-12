using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogDeneme.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace BlogDeneme.Controllers
{
    [AllowAnonymous]

    public class AnaSayfaController : Controller
    {

        BlogDenemeEntities db = new BlogDenemeEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialBlogSlider()
        {
            var deger = db.Tbl_Blog.Take(3).Where(x => x.DURUM == true).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
        }

        public PartialViewResult PartialBloglar(Tbl_BlogKategori p, int sayfa = 1, string ara = "")
        {
            var deger = from x in db.Tbl_Blog.Where(x => x.DURUM == true).OrderByDescending(x => x.ID) select x;
            if (!string.IsNullOrEmpty(ara))
            {
                deger = deger.Where(x => x.BASLIK.ToLower().Contains(ara));
            }

            return PartialView(deger.ToList().ToPagedList(sayfa, 10));
        }

        public ActionResult BlogDetay(int id)
        {
            var deger = db.Tbl_Blog.Where(x => x.ID == id).ToList();

            var yorum = db.Tbl_BlogYorum.Where(x => x.BLOGID == id).Count().ToString();
            ViewBag.dgr = yorum;

            return View(deger);
        }

        public PartialViewResult PartialYazar()
        {
            var deger = db.Tbl_Yazar.ToList();
            return PartialView(deger);
        }

        public PartialViewResult PartialBlogYorum(int id)
        {
            var deger = db.Tbl_BlogYorum.Where(x => x.BLOGID == id).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
        }

        [HttpGet]
        public PartialViewResult PartialYorumYaz()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialYorumYaz(Tbl_BlogYorum p)
        {
            var deger = db.Tbl_Blog.Find(p.ID);
            p.BLOGID = deger.ID;
            p.TARIH = DateTime.Now;
            db.Tbl_BlogYorum.Add(p);
            db.SaveChanges();
            return PartialView("Index");
        }

        public PartialViewResult PartialSonYazilarim()
        {
            var deger = db.Tbl_Blog.Take(5).Where(x => x.DURUM == true).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
        }

        public PartialViewResult PartialKategoriler()
        {
            var deger = db.Tbl_BlogKategori.Where(x => x.DURUM == true).ToList();
            return PartialView(deger);
        }

        public PartialViewResult PartialGaleri()
        {
            var deger = db.Tbl_Galeri.ToList();
            return PartialView(deger);
        }

        public PartialViewResult PartialSosyalMedya()
        {
            var deger = db.Tbl_SosyalMedya.ToList();
            return PartialView(deger);
        }

        public PartialViewResult PartialFooterSosyalMedya()
        {
            var deger = db.Tbl_SosyalMedya.ToList();
            return PartialView(deger);
        }

        public PartialViewResult BlogKategoriler()
        {
            var deger = db.Tbl_BlogKategori.Where(x => x.DURUM == true).ToList();
            return PartialView(deger);
        }

        public ActionResult Kategori(Tbl_BlogKategori t, int id, int sayfa = 1)
        {
            Tbl_BlogKategori k = db.Tbl_BlogKategori.Find(t.ID);
            var deger = db.Tbl_Blog.Where(x => x.KATEGORI == id && k.DURUM == true).OrderByDescending(x => x.ID).ToList().ToPagedList(sayfa, 8);
            return View(deger);
        }
    }
}