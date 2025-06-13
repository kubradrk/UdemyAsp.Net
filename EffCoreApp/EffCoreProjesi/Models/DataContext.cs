using EffCoreProjesi.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Ogrenci> Ogrenciler { get; set; }
    public DbSet<Ogretmen> Ogretmenler { get; set; }
    public DbSet<Kurs> Kurslar { get; set; }
    public DbSet<KursKayit> KursKayitlari { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Öğretmen başlangıç verisi
        modelBuilder.Entity<Ogretmen>().HasData(
            new Ogretmen { OgretmenId = 1, Ad = "Ayşe", Soyad = "Yılmaz", Eposta = "ayse.yilmaz@example.com", Telefon = "0555 123 45 67", BaslamaTarihi = new DateTime(2023, 10, 1) },
            new Ogretmen { OgretmenId = 2, Ad = "Mehmet", Soyad = "Kara", Eposta = "mehmet.kara@example.com", Telefon = "0532 456 78 90", BaslamaTarihi = new DateTime(2023, 9, 15) },
            new Ogretmen { OgretmenId = 3, Ad = "Elif", Soyad = "Demir", Eposta = "elif.demir@example.com", Telefon = "0506 111 22 33", BaslamaTarihi = new DateTime(2023, 8, 20) },
            new Ogretmen { OgretmenId = 4, Ad = "Ahmet", Soyad = "Şahin", Eposta = "ahmet.sahin@example.com", Telefon = "0544 333 22 11", BaslamaTarihi = new DateTime(2023, 7, 5) },
            new Ogretmen { OgretmenId = 5, Ad = "Zeynep", Soyad = "Aslan", Eposta = "zeynep.aslan@example.com", Telefon = "0530 876 54 32", BaslamaTarihi = new DateTime(2023, 6, 12) },
            new Ogretmen { OgretmenId = 6, Ad = "Kemal", Soyad = "Aydın", Eposta = "kemal.aydin@example.com", Telefon = "0553 345 67 89", BaslamaTarihi = new DateTime(2023, 11, 5) },
            new Ogretmen { OgretmenId = 7, Ad = "Fatma", Soyad = "Güneş", Eposta = "fatma.gunes@example.com", Telefon = "0541 234 56 78", BaslamaTarihi = new DateTime(2023, 5, 30) },
            new Ogretmen { OgretmenId = 8, Ad = "Yusuf", Soyad = "Kılıç", Eposta = "yusuf.kilic@example.com", Telefon = "0539 999 88 77", BaslamaTarihi = new DateTime(2023, 11, 10) }
        );

        // Kurs verisi (OgretmenAdSoyad kaldırıldı)
        modelBuilder.Entity<Kurs>().HasData(
            new Kurs { KursId = 1, Baslik = "Yazılım Geliştirme", OgretmenId = 1 },
            new Kurs { KursId = 2, Baslik = "Veri Tabanı", OgretmenId = 2 }
        );
        modelBuilder.Entity<KursKayit>().HasData(
    new KursKayit
    {
        KayitId = 1,
        OgrenciId = 1, // Veritabanında bu ID'de öğrenci olduğundan emin ol!
        KursId = 1,
        KayitTarihi = new DateTime(2024, 10, 1)
    },
    new KursKayit
    {
        KayitId = 2,
        OgrenciId = 2,
        KursId = 2,
        KayitTarihi = new DateTime(2024, 10, 5)
    },
    new KursKayit
    {
        KayitId = 3,
        OgrenciId = 3,
        KursId = 1,
        KayitTarihi = new DateTime(2024, 10, 7)
    }
);


        modelBuilder.Entity<KursKayit>().HasKey(k => k.KayitId);
    }
}
