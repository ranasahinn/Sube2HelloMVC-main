using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sube2.HelloMvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly OkulDbContext _context;

        public StudentController(OkulDbContext context)
        {
            _context = context;
        }

        //öğrenciler listele
        public IActionResult Index()
        {
            var lst = _context.Ogrenciler.Include(o => o.Dersler).ToList();
            return View(lst);
        }
        //geti karşılıyor
        public IActionResult AddStudent()
        {
            return View();
        }
        //veri taban kayıdı http istekği
        [HttpPost]
        public IActionResult AddStudent(Ogrenci ogrenci)
        {
            if (ogrenci != null)
            {
                _context.Ogrenciler.Add(ogrenci);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //öğr düzenleme get isteği
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var ogr = _context.Ogrenciler.Find(id);
            return View(ogr);
        }
        //öğr düzenleme post isteği
        [HttpPost]
        public IActionResult EditStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                _context.Entry(ogr).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //silme
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            var ogr = _context.Ogrenciler.Find(id);
            if (ogr != null)
            {
                _context.Ogrenciler.Remove(ogr);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //ders atama  belirli idye göre atanır 
        [HttpGet]
        public async Task<IActionResult> AssignDers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler
                .Include(o => o.Dersler)
                .FirstOrDefaultAsync(o => o.OgrenciId == id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            var dersler = await _context.Dersler.ToListAsync();
            ViewBag.Dersler = dersler;
            ViewBag.SelectedDersler = ogrenci.Dersler.Select(d => d.Dersid).ToList();
            return View(ogrenci);
        }
        //atamanın gerçekleştiği metot
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignDers(int id, int[] selectedDersler)
        {
            var ogrenci = await _context.Ogrenciler
                .Include(o => o.Dersler)
                .FirstOrDefaultAsync(o => o.OgrenciId == id);

            if (ogrenci == null)
            {
                return NotFound();
            }
            var existingDersler = ogrenci.Dersler.Select(d => d.Dersid).ToList();

            var derslerToAdd = selectedDersler.Except(existingDersler).ToList();

            var derslerToRemove = existingDersler.Except(selectedDersler).ToList();

            foreach (var dersId in derslerToAdd)
            {
                var dersToAdd = await _context.Dersler.FindAsync(dersId);
                if (dersToAdd != null)
                {
                    ogrenci.Dersler.Add(dersToAdd);
                }
            }

            foreach (var dersId in derslerToRemove)
            {
                var dersToRemove = ogrenci.Dersler.FirstOrDefault(d => d.Dersid == dersId);
                if (dersToRemove != null)
                {
                    ogrenci.Dersler.Remove(dersToRemove);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //ders öğr listeler
        public IActionResult ViewAllStudentsDers()
        {
            var students = _context.Ogrenciler.Include(s => s.Dersler).ToList();
            return View(students);
        }
        //ögr detayları görüntüler
        public async Task<IActionResult> Details(int id)
        {
            var ogrenci = await _context.Ogrenciler
                .Include(o => o.Dersler)
                .FirstOrDefaultAsync(o => o.OgrenciId == id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

    }
}
