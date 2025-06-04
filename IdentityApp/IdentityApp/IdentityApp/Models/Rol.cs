using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models
{
    public class Rol : IdentityRole
    {
        public string? Aciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
    }

}
