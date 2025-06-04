using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<Kullanici, Rol, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> secenekler)
            : base(secenekler)
        {
        }
    }
}
