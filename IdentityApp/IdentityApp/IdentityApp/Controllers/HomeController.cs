using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Yetkisiz eri�im olursa g�sterilecek sayfa (iste�e ba�l�)
        [AllowAnonymous]
        public IActionResult ErisimYok()
        {
            return View();
        }

    }
}
