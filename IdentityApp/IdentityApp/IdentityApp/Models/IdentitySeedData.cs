using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace IdentityApp.Models
{
    public static class IdentitySeedData
    {
        public static async Task SeedAsync(IServiceProvider hizmetSaglayici)
        {
            var userManager = hizmetSaglayici.GetRequiredService<UserManager<Kullanici>>();
            var roleManager = hizmetSaglayici.GetRequiredService<RoleManager<Rol>>();

            string adminEmail = "admin@gmail.com";
            string adminPassword = "admin123";
            string[] roller = { "Admin", "Kullanici" };

            // Rolleri oluştur
            foreach (var rol in roller)
            {
                if (!await roleManager.RoleExistsAsync(rol))
                {
                    await roleManager.CreateAsync(new Rol { Name = rol });
                }
            }

            // Admin kullanıcıyı oluştur
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new Kullanici
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    AdSoyad = "Yönetici Hesabı",
                    EmailConfirmed = true
                };

                var sonuc = await userManager.CreateAsync(admin, adminPassword);

                if (sonuc.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
