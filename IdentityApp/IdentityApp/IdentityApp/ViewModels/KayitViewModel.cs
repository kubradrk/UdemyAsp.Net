using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels
{
    public class KayitViewModel
    {
        [Required(ErrorMessage = "E-posta girilmelidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ad soyad girilmelidir.")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "Şifre girilmelidir.")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Şifre tekrar girilmelidir.")]
        [DataType(DataType.Password)]
        [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string SifreTekrar { get; set; }
    }
}
