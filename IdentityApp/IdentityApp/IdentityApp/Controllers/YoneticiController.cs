using IdentityApp.Models;
using IdentityApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YoneticiController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly RoleManager<Rol> _roleManager;

        public YoneticiController(UserManager<Kullanici> userManager, RoleManager<Rol> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var kullaniciListesi = new List<KullaniciListeViewModel>();

            foreach (var kullanici in _userManager.Users.ToList())
            {
                var roller = await _userManager.GetRolesAsync(kullanici);

                kullaniciListesi.Add(new KullaniciListeViewModel
                {
                    Id = kullanici.Id,
                    AdSoyad = kullanici.AdSoyad,
                    Email = kullanici.Email,
                    UserName = kullanici.UserName,
                    Roller = roller.ToList()
                });
            }

            return View(kullaniciListesi);
        }


        [HttpGet]
        public async Task<IActionResult> Roller(string id)
        {
            var kullanici = await _userManager.FindByIdAsync(id);
            if (kullanici == null)
                return NotFound();

            var roller = _roleManager.Roles.ToList();
            var kullaniciRolleri = await _userManager.GetRolesAsync(kullanici);

            var model = new List<RolAtaViewModel>();

            foreach (var rol in roller)
            {
                model.Add(new RolAtaViewModel
                {
                    RolAdi = rol.Name,
                    SeciliMi = kullaniciRolleri.Contains(rol.Name)
                });
            }

            ViewBag.KullaniciId = kullanici.Id;
            ViewBag.KullaniciAd = kullanici.AdSoyad;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Roller(string id, List<RolAtaViewModel> roller)
        {
            var kullanici = await _userManager.FindByIdAsync(id);
            if (kullanici == null)
                return NotFound();

            var mevcutRoller = await _userManager.GetRolesAsync(kullanici);
            await _userManager.RemoveFromRolesAsync(kullanici, mevcutRoller);

            var secilenRoller = roller.Where(x => x.SeciliMi).Select(x => x.RolAdi).ToList();
            await _userManager.AddToRolesAsync(kullanici, secilenRoller);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Sil(string id)
        {
            var kullanici = await _userManager.FindByIdAsync(id);
            if (kullanici == null)
                return NotFound();

            await _userManager.DeleteAsync(kullanici);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var kullanici = await _userManager.FindByIdAsync(id);
            if (kullanici == null) return NotFound();

            var model = new EditUserViewModel
            {
                Id = kullanici.Id,
                AdSoyad = kullanici.AdSoyad,
                Email = kullanici.Email,
                UserName = kullanici.UserName
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var kullanici = await _userManager.FindByIdAsync(model.Id);
            if (kullanici == null) return NotFound();

            kullanici.AdSoyad = model.AdSoyad;
            kullanici.Email = model.Email;
            kullanici.UserName = model.UserName;

            var result = await _userManager.UpdateAsync(kullanici);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

    }
}
