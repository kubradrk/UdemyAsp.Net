namespace EffCoreProjesi.Models
{
    public class Ogrenci
    {
        public int OgrenciId { get; set; }
        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyad { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        public DateTime KayitTarihi { get; set; }

        public string AdSoyad => $"{OgrenciAd} {OgrenciSoyad}";
        public ICollection<KursKayit>? KursKayitlari { get; set; }

    }

}
