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

        // Yetkisiz eriþim olursa gösterilecek sayfa (isteðe baðlý)
        [AllowAnonymous]
        public IActionResult ErisimYok()
        {
            return View();
        }

    }
}
