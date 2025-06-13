using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EffCoreProjesi.Models;

namespace EffCoreProjesi.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly DataContext _context;

        public KursKayitController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kayitlar = _context.KursKayitlari
                .Include(k => k.Kurs)
                .Include(k => k.Ogrenci)
                .ToList();

            return View(kayitlar);
        }

        public IActionResult Create()
        {
            ViewBag.Kurslar = _context.Kurslar
                .Select(k => new { k.KursId, k.Baslik })
                .ToList();

            ViewBag.Ogrenciler = _context.Ogrenciler
                .Select(o => new { o.OgrenciId, AdSoyad = o.OgrenciAd + " " + o.OgrenciSoyad })
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(KursKayit model)
        {
            if (ModelState.IsValid)
            {
                model.KayitTarihi = DateTime.Now;
                _context.KursKayitlari.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var kayit = _context.KursKayitlari
                .Include(k => k.Kurs)
                .Include(k => k.Ogrenci)
                .FirstOrDefault(k => k.KayitId == id);

            if (kayit == null)
                return NotFound();

            return View(kayit);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var kayit = _context.KursKayitlari.Find(id);
            if (kayit != null)
            {
                _context.KursKayitlari.Remove(kayit);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
