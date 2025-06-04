using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels
{
    public class GirisViewModel
    {
        [Required(ErrorMessage = "E-posta boş geçilemez.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}
