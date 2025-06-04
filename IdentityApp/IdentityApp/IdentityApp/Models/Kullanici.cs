using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models
{
    public class Kullanici : IdentityUser
    {
        public string? AdSoyad { get; set; }
    }
}
