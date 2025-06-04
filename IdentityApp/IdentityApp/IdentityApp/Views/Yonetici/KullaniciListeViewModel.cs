namespace IdentityApp.ViewModels
{
    public class KullaniciListeViewModel
    {
        public string Id { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Roller { get; set; }
    }
}
