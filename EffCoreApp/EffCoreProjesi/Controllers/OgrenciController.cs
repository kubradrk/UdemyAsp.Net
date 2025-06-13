using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EffCoreProjesi.Models;

namespace EffCoreProjesi.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly string _connectionString =
            "Server=DESKTOP-45MQEVD\\SQLEXPRESS;Database=EffCoreProjesiDb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

        // Listeleme
        public IActionResult Index()
        {
            var ogrenciler = new List<Ogrenci>();
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Ogrenciler", con);
            con.Open();
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ogrenciler.Add(new Ogrenci
                {
                    OgrenciId = (int)dr["OgrenciId"],
                    OgrenciAd = dr["OgrenciAd"].ToString(),
                    OgrenciSoyad = dr["OgrenciSoyad"].ToString(),
                    Eposta = dr["Eposta"].ToString(),
                    Telefon = dr["Telefon"].ToString(),
                    KayitTarihi = Convert.ToDateTime(dr["KayitTarihi"])
                });
            }

            return View(ogrenciler);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ogrenci model)
        {
            using var con = new SqlConnection(_connectionString);
            var query = "INSERT INTO Ogrenciler (OgrenciAd, OgrenciSoyad, Eposta, Telefon, KayitTarihi) VALUES (@Ad, @Soyad, @Eposta, @Telefon, GETDATE())";
            using var cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Ad", model.OgrenciAd ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Soyad", model.OgrenciSoyad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Eposta", model.Eposta ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefon", model.Telefon ?? (object)DBNull.Value);

            con.Open();
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Ogrenci ogrenci = null;
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Ogrenciler WHERE OgrenciId = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            using var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ogrenci = new Ogrenci
                {
                    OgrenciId = (int)dr["OgrenciId"],
                    OgrenciAd = dr["OgrenciAd"].ToString(),
                    OgrenciSoyad = dr["OgrenciSoyad"].ToString(),
                    Eposta = dr["Eposta"].ToString(),
                    Telefon = dr["Telefon"].ToString(),
                    KayitTarihi = Convert.ToDateTime(dr["KayitTarihi"])
                };
            }

            if (ogrenci == null)
                return NotFound();

            return View(ogrenci);
        }

        [HttpPost]
        public IActionResult Edit(Ogrenci model)
        {
            using var con = new SqlConnection(_connectionString);
            var query = "UPDATE Ogrenciler SET OgrenciAd = @Ad, OgrenciSoyad = @Soyad, Eposta = @Eposta, Telefon = @Telefon WHERE OgrenciId = @id";
            using var cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", model.OgrenciId);
            cmd.Parameters.AddWithValue("@Ad", model.OgrenciAd ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Soyad", model.OgrenciSoyad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Eposta", model.Eposta ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefon", model.Telefon ?? (object)DBNull.Value);

            con.Open();
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Ogrenci ogrenci = null;
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Ogrenciler WHERE OgrenciId = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            using var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ogrenci = new Ogrenci
                {
                    OgrenciId = (int)dr["OgrenciId"],
                    OgrenciAd = dr["OgrenciAd"].ToString(),
                    OgrenciSoyad = dr["OgrenciSoyad"].ToString(),
                    Eposta = dr["Eposta"].ToString(),
                    Telefon = dr["Telefon"].ToString(),
                    KayitTarihi = Convert.ToDateTime(dr["KayitTarihi"])
                };
            }

            if (ogrenci == null)
                return NotFound();

            return View(ogrenci);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DELETE FROM Ogrenciler WHERE OgrenciId = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");
        }
    }
}
