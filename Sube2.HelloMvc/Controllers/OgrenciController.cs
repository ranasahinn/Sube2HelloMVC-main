using Microsoft.AspNetCore.Mvc;
using Sube2.HelloMvc.Models;
using Sube2.HelloMvc.Models.ViewModels;
using System.Collections.Generic;

namespace Sube2.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult OgrenciDetay(int id)
        {
            var d = new Ders { Dersad = "Matematik", Dersid = 1, Kredi = 3 };
            var ogrt = new Ogretmen { Ad = "Ahmet", Soyad = "Mehmet", Bolum = "Bilgisayar" };

            Ogrenci ogr = null;
            if (id == 1)
            {
                ogr = new Ogrenci();
                ogr.Ad = "Ali";
                ogr.Soyad = "Veli";
                ogr.Numara = 123;
            }
            else if (id == 2)
            {
                ogr = new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = 456 };
            }

            // ViewModel oluşturulur ve gerekli veriler atanır
            var ogrvm = new OgrViewModel { Ders = d, Ogretmen = ogrt, Ogrenci = ogr };

            // ViewModel, ilgili View'e iletilir
            return View(ogrvm);
        }

        public ViewResult OgrenciListe()
        {
            // Örnek öğrenci listesi oluşturulur
            var lst = new List<Ogrenci> {
                new Ogrenci { Ad = "Ali", Soyad = "Veli", Numara = 123 },
                new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = 456 }
            };

            // Liste, ilgili View'e iletilir
            return View(lst);
        }
    }
}
