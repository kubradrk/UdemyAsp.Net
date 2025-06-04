using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<Rol> _roleManager;

        public RolesController(RoleManager<Rol> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roller = _roleManager.Roles.ToList();
            return View(roller);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string rolAdi)
        {
            if (string.IsNullOrWhiteSpace(rolAdi))
            {
                ModelState.AddModelError("", "Rol adı boş olamaz.");
                return View();
            }

            var result = await _roleManager.CreateAsync(new Rol { Name = rolAdi });

            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var hata in result.Errors)
            {
                ModelState.AddModelError("", hata.Description);
            }

            return View();
        }
    }
}
