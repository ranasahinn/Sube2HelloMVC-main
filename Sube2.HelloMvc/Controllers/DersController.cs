using Microsoft.AspNetCore.Mvc;
using Sube2.HelloMvc.Models;
using System.Linq;

namespace Sube2.HelloMvc.Controllers
{
    public class DersController : Controller
    {
        private readonly OkulDbContext _context;

        public DersController(OkulDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dersler = _context.Dersler.ToList();
            return View(dersler);
        }

        public IActionResult AddDers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDers(Ders ders)
        {
            if (ders != null)
            {
                _context.Dersler.Add(ders);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditDers(int id)
        {
            var ders = _context.Dersler.Find(id);
            return View(ders);
        }

        [HttpPost]
        public IActionResult EditDers(Ders ders)
        {
            if (ders != null)
            {
                _context.Entry(ders).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteDers(int id)
        {
            var ders = _context.Dersler.Find(id);
            if (ders != null)
            {
                _context.Dersler.Remove(ders);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
