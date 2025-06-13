using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController: Controller 
    {
        public IActionResult Index()
        {

            int saat = DateTime.Now.Hour;

            ViewData["Selamlama"] = saat > 12 ? "İyi Günler":"Günaydın, Kübra";
            int UserCount = Repository.Users.Where(info=> info.WillAttend == true).Count();

            var meetingInfo = new MeetingInfo() 
            {
                Id = 1,
                Location = "Kayseri Ekm Kültür Merkezi",
                Date = new DateTime(2024, 01, 20, 20, 30, 0),
                NumberOfPeople = UserCount
            };

            return View(meetingInfo);
        }
    }
}