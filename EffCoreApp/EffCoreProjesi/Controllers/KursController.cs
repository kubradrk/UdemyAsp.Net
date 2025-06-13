using Microsoft.AspNetCore.Mvc;
using EffCoreProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace EffCoreProjesi.Controllers
{
    public class KursController : Controller
    {
        private readonly DataContext _context;

        public KursController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kurslar = _context.Kurslar
               .Include(k => k.Ogretmen) // 🔥 Navigation property dahil ediliyor
               .ToList();

            return View(kurslar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                _context.Kurslar.Add(kurs);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kurs);
        }

        public IActionResult Edit(int id)
        {
            var kurs = _context.Kurslar.Find(id);
            if (kurs == null)
                return NotFound();

            return View(kurs);
        }

        [HttpPost]
        public IActionResult Edit(Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                _context.Kurslar.Update(kurs);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kurs);
        }

        public IActionResult Delete(int id)
        {
            var kurs = _context.Kurslar.Find(id);
            if (kurs == null)
                return NotFound();

            return View(kurs);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var kurs = _context.Kurslar.Find(id);
            if (kurs != null)
            {
                _context.Kurslar.Remove(kurs);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
