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
    public class VitrinController : Controller
    {

        BlogDenemeEntities db = new BlogDenemeEntities();

        public ActionResult BlogIslemleri(int sayfa = 1)
        {
            var deger = db.Tbl_Blog.ToList().Where(x => x.DURUM == true).OrderByDescending(x => x.ID).ToPagedList(sayfa, 6);
            return View(deger);
        }

        public ActionResult BlogYorum(int id, int sayfa = 1)
        {
            var deger = db.Tbl_BlogYorum.Where(x => x.BLOGID == id).ToList().ToPagedList(sayfa, 5);
            return View(deger);
        }

        public ActionResult YorumSil(int id)
        {
            var deger = db.Tbl_BlogYorum.Find(id);
            db.Tbl_BlogYorum.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("BlogIslemleri");
        }

        public ActionResult TumYorumlar(int sayfa = 1)
        {
            var deger = db.Tbl_BlogYorum.OrderByDescending(x => x.ID).ToList().ToPagedList(sayfa, 7);
            return View(deger);
        }

        public ActionResult BlogSil(int id)
        {
            var deger = db.Tbl_Blog.Find(id);
            db.Tbl_Blog.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("BlogIslemleri");
        }

        [HttpGet]
        public ActionResult BlogEkle()
        {
            List<SelectListItem> kategori = (from x in db.Tbl_BlogKategori.Where(x => x.DURUM == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = kategori;

            return View();
        }

        [HttpPost]
        public ActionResult BlogEkle(Tbl_Blog p)
        {

            var kategori = db.Tbl_BlogKategori.Where(x => x.ID == p.Tbl_BlogKategori.ID).FirstOrDefault();

            p.Tbl_BlogKategori = kategori;
            p.DURUM = true;
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_Blog.Add(p);
            db.SaveChanges();
            return RedirectToAction("BlogIslemleri");
        }

        public ActionResult BlogGetir(int id)
        {
            var deger = db.Tbl_Blog.Find(id);

            List<SelectListItem> kategori = (from x in db.Tbl_BlogKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = kategori;

            return View("BlogGetir", deger);
        }

        
        public ActionResult BlogGuncelle(Tbl_Blog p)
        {
            var deger = db.Tbl_Blog.Find(p.ID);
            var kategori = db.Tbl_BlogKategori.Where(x => x.ID == p.Tbl_BlogKategori.ID).FirstOrDefault();

            deger.YAZAR = p.YAZAR;
            deger.RESIM = p.RESIM;
            deger.BASLIK = p.BASLIK;
            deger.ICERIK = p.ICERIK;
            deger.KATEGORI = kategori.ID;

            db.SaveChanges();
            return RedirectToAction("BlogIslemleri");
        }

        public ActionResult KategoriIslemleri(int sayfa = 1)
        {
            var deger = db.Tbl_BlogKategori.Where(x => x.DURUM == true).ToList().ToPagedList(sayfa, 7);
            return View(deger);
        }

        public ActionResult KategoriSil(Tbl_BlogKategori p)
        {
            Tbl_BlogKategori t = db.Tbl_BlogKategori.Find(p.ID);
            t.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("KategoriIslemleri");
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Tbl_BlogKategori p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            p.DURUM = true;
            db.Tbl_BlogKategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("KategoriIslemleri");
        }

        public ActionResult KategoriGetir(int id)
        {
            var deger = db.Tbl_BlogKategori.Find(id);
            return View("KategoriGetir", deger);
        }

        public ActionResult KategoriGuncelle(Tbl_BlogKategori p)
        {
            var deger = db.Tbl_BlogKategori.Find(p.ID);

            deger.AD = p.AD;

            db.SaveChanges();
            return RedirectToAction("KategoriIslemleri");
        }

        public ActionResult HakkimdaIslemleri()
        {
            var deger = db.Tbl_Hakkimda.ToList();
            return View(deger);
        }

        public ActionResult HakkimdaGetir(int id)
        {
            var deger = db.Tbl_Hakkimda.Find(id);
            return View("HakkimdaGetir", deger);
        }

        public ActionResult HakkimdaGuncelle(Tbl_Hakkimda p)
        {
            var deger = db.Tbl_Hakkimda.Find(p.ID);

            deger.BASLIK = p.BASLIK;
            deger.YAZI1 = p.YAZI1;
            deger.YAZI2 = p.YAZI2;
            deger.FOTOGRAF = p.FOTOGRAF;

            db.SaveChanges();
            return RedirectToAction("HakkimdaIslemleri");
        }

        public ActionResult IletisimIslemleri(int sayfa = 1)
        {
            var deger = db.Tbl_Mesajlar.Where(x => x.DURUM == true).ToList().ToPagedList(sayfa, 5);
            return View(deger);
        }

        public ActionResult MesajOkundu(Tbl_Mesajlar p)
        {
            Tbl_Mesajlar t = db.Tbl_Mesajlar.Find(p.ID);
            t.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("IletisimIslemleri");
        }

        public ActionResult MesajDetay(int id)
        {
            var deger = db.Tbl_Mesajlar.Find(id);
            return View("MesajDetay", deger);
        }

        public ActionResult Profilim(int sayfa = 1)
        {
            var deger = db.Tbl_Admin.ToList().ToPagedList(sayfa, 5);
            return View(deger);
        }

        public ActionResult AdminSil(int id)
        {
            var deger = db.Tbl_Admin.Find(id);
            db.Tbl_Admin.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Profilim");
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(Tbl_Admin p)
        {
            db.Tbl_Admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Profilim");
        }

        public ActionResult AdminGetir(int id)
        {
            var deger = db.Tbl_Admin.Find(id);
            return View("AdminGetir", deger);
        }

        public ActionResult AdminGuncelle(Tbl_Admin p)
        {
            var deger = db.Tbl_Admin.Find(p.ID);

            deger.KULLANICIADI = p.KULLANICIADI;
            deger.PAROLA = p.PAROLA;

            db.SaveChanges();
            return RedirectToAction("Profilim");
        }

        public ActionResult YazarIslemleri()
        {
            var deger = db.Tbl_Yazar.ToList();
            return View(deger);
        }

        public ActionResult YazarGetir(int id)
        {
            var deger = db.Tbl_Yazar.Find(id);
            return View("YazarGetir", deger);
        }

        public ActionResult YazarGuncelle(Tbl_Yazar p)
        {
            var deger = db.Tbl_Yazar.Find(p.ID);

            deger.ADSOYAD = p.ADSOYAD;
            deger.ICERIK = p.ICERIK;
            deger.RESIM = p.RESIM;

            db.SaveChanges();
            return RedirectToAction("YazarIslemleri");
        }

        public ActionResult GaleriIslemleri(int sayfa = 1)
        {
            var deger = db.Tbl_Galeri.OrderByDescending(x => x.ID).ToList().ToPagedList(sayfa, 5);
            return View(deger);
        }

        public ActionResult ResimSil(int id)
        {
            var deger = db.Tbl_Galeri.Find(id);
            db.Tbl_Galeri.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("GaleriIslemleri");
        }

        [HttpGet]
        public ActionResult ResimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimEkle(Tbl_Galeri p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Tbl_Galeri.Add(p);
            db.SaveChanges();
            return RedirectToAction("GaleriIslemleri");
        }

        public ActionResult ResimGetir(int id)
        {
            var deger = db.Tbl_Galeri.Find(id);
            return View("ResimGetir", deger);
        }

        public ActionResult ResimGuncelle(Tbl_Galeri p)
        {
            var deger = db.Tbl_Galeri.Find(p.ID);

            deger.RESIM = p.RESIM;

            db.SaveChanges();
            return RedirectToAction("GaleriIslemleri");
        }

        public ActionResult SosyalMedyaIslemleri()
        {
            var deger = db.Tbl_SosyalMedya.ToList();
            return View(deger);
        }

        public ActionResult HesapSil(int id)
        {
            var deger = db.Tbl_SosyalMedya.Find(id);
            db.Tbl_SosyalMedya.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("SosyalMedyaIslemleri");
        }

        [HttpGet]
        public ActionResult HesapEkle()
        {
            List<SelectListItem> kategori = (from x in db.Tbl_SosyalMedyaIkon.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString()
                                             }
                                            ).ToList();
            ViewBag.dgr = kategori;

            return View();
        }

        [HttpPost]
        public ActionResult HesapEkle(Tbl_SosyalMedya p)
        {
            var ikon = db.Tbl_SosyalMedyaIkon.Where(x => x.ID == p.Tbl_SosyalMedyaIkon.ID).FirstOrDefault();

            p.Tbl_SosyalMedyaIkon = ikon;
            db.Tbl_SosyalMedya.Add(p);
            db.SaveChanges();
            return RedirectToAction("SosyalMedyaIslemleri");
        }

        public ActionResult HesapGetir(int id)
        {
            var deger = db.Tbl_SosyalMedya.Find(id);

            List<SelectListItem> kategori = (from x in db.Tbl_SosyalMedyaIkon.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString()
                                             }
                                            ).ToList();
            ViewBag.dgr = kategori;

            return View("HesapGetir", deger);
        }

        public ActionResult HesapGuncelle(Tbl_SosyalMedya p)
        {
            var deger = db.Tbl_SosyalMedya.Find(p.ID);
            var ikon = db.Tbl_SosyalMedyaIkon.Where(x => x.ID == p.Tbl_SosyalMedyaIkon.ID).FirstOrDefault();

            deger.AD = p.AD;
            deger.IKON = ikon.ID;
            deger.LINK = p.LINK;

            db.SaveChanges();
            return RedirectToAction("SosyalMedyaIslemleri");
        }

        public ActionResult Ikonlar(int sayfa = 1)
        {
            var deger = db.Tbl_SosyalMedyaIkon.ToList().ToPagedList(sayfa, 5);
            return View(deger);
        }

        public ActionResult IkonSil (int id)
        {
            var deger = db.Tbl_SosyalMedyaIkon.Find(id);
            db.Tbl_SosyalMedyaIkon.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Ikonlar");
        }

        [HttpGet]
        public ActionResult IkonEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IkonEkle(Tbl_SosyalMedyaIkon p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Tbl_SosyalMedyaIkon.Add(p);
            db.SaveChanges();
            return RedirectToAction("SosyalMedyaIslemleri");
        }

        public ActionResult IkonGetir(int id)
        {
            var deger = db.Tbl_SosyalMedyaIkon.Find(id);
            return View("IkonGetir", deger);
        }

        public ActionResult IkonGuncelle(Tbl_SosyalMedyaIkon p)
        {
            var deger = db.Tbl_SosyalMedyaIkon.Find(p.ID);

            deger.AD = p.AD;
            deger.IKON = p.IKON;

            db.SaveChanges();
            return RedirectToAction("Ikonlar");
        }
    }
}