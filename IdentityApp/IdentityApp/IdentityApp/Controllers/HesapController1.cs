using IdentityApp.Models;
using IdentityApp.Services;
using IdentityApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    public class HesapController : Controller
    {
        private readonly UserManager<Kullanici> _kullaniciYoneticisi;
        private readonly SignInManager<Kullanici> _girisYoneticisi;

        public HesapController(UserManager<Kullanici> kullaniciYoneticisi, SignInManager<Kullanici> girisYoneticisi)
        {
            _kullaniciYoneticisi = kullaniciYoneticisi;
            _girisYoneticisi = girisYoneticisi;
        }

        [HttpGet]
        public IActionResult Giris() => View();

        [HttpPost]
        public async Task<IActionResult> Giris(GirisViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var kullanici = await _kullaniciYoneticisi.FindByEmailAsync(model.Email);
            if (kullanici == null)
            {
                ModelState.AddModelError("", "E-posta bulunamadı.");
                return View(model);
            }

            var sonuc = await _girisYoneticisi.PasswordSignInAsync(kullanici, model.Sifre, false, true);

            if (sonuc.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Giriş başarısız.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Kayit() => View();

        [HttpPost]
        public async Task<IActionResult> Kayit(KayitViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var yeniKullanici = new Kullanici
            {
                UserName = model.Email,
                Email = model.Email,
                AdSoyad = model.AdSoyad
            };

            var sonuc = await _kullaniciYoneticisi.CreateAsync(yeniKullanici, model.Sifre);

            if (sonuc.Succeeded)
            {
                await _girisYoneticisi.SignInAsync(yeniKullanici, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var hata in sonuc.Errors)
            {
                ModelState.AddModelError("", hata.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult SifremiUnuttum() => View();

        [HttpPost]
        public async Task<IActionResult> SifremiUnuttum(string email, [FromServices] EmailService emailService)
        {
            var user = await _kullaniciYoneticisi.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View();
            }

            var token = await _kullaniciYoneticisi.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("SifreYenile", "Hesap", new { email = email, token = token }, Request.Scheme);
            await emailService.SendEmailAsync(email, "Şifre Yenileme", $"<a href='{link}'>Şifrenizi yenilemek için tıklayın</a>");

            ViewBag.Mesaj = "Şifre yenileme bağlantısı e-posta adresinize gönderildi.";
            return View();
        }

        [HttpGet]
        public IActionResult SifreYenile(string email, string token)
        {
            return View(new SifreYenileViewModel { Email = email, Token = token });
        }

        [HttpPost]
        public async Task<IActionResult> SifreYenile(SifreYenileViewModel model)
        {
            var user = await _kullaniciYoneticisi.FindByEmailAsync(model.Email);
            if (user == null)
                return NotFound();

            var result = await _kullaniciYoneticisi.ResetPasswordAsync(user, model.Token, model.Sifre);
            if (result.Succeeded)
                return RedirectToAction("Giris");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        public async Task<IActionResult> Cikis()
        {
            await _girisYoneticisi.SignOutAsync();
            return RedirectToAction("Giris", "Hesap");
        }
    }
}
