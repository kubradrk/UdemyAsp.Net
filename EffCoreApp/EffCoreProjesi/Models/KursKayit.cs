using EffCoreProjesi.Models;

namespace EffCoreProjesi.Models
{
    public class KursKayit
    {
        public int KayitId { get; set; }

        public int OgrenciId { get; set; }
        public Ogrenci? Ogrenci { get; set; }

        public int KursId { get; set; }
        public Kurs? Kurs { get; set; }

        public DateTime KayitTarihi { get; set; }
    }
}
