using System.ComponentModel.DataAnnotations.Schema;

namespace EffCoreProjesi.Models
{
    public class Kurs
    {
        public int KursId { get; set; }
        public string? Baslik { get; set; }

        public int OgretmenId { get; set; }
        public Ogretmen? Ogretmen { get; set; }

        [NotMapped]
        public string? OgretmenAdSoyad => Ogretmen != null ? $"{Ogretmen.Ad} {Ogretmen.Soyad}" : "";
        public ICollection<KursKayit>? KursKayitlari { get; set; }

    }
}
