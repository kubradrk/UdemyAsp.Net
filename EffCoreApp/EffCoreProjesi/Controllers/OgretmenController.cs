using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EffCoreProjesi.Models;

namespace EffCoreProjesi.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly string _connectionString =
            "Server=DESKTOP-45MQEVD\\SQLEXPRESS;Database=EffCoreProjesiDb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

        public IActionResult Index()
        {
            var ogretmenler = new List<Ogretmen>();
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Ogretmenler", con);
            con.Open();
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ogretmenler.Add(new Ogretmen
                {
                    OgretmenId = (int)dr["OgretmenId"],
                    Ad = dr["Ad"].ToString(),
                    Soyad = dr["Soyad"].ToString(),
                    Eposta = dr["Eposta"].ToString(),
                    Telefon = dr["Telefon"].ToString(),
                    BaslamaTarihi = Convert.ToDateTime(dr["BaslamaTarihi"])
                });
            }

            return View(ogretmenler);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ogretmen model)
        {
            using var con = new SqlConnection(_connectionString);
            var query = "INSERT INTO Ogretmenler (Ad, Soyad, Eposta, Telefon, BaslamaTarihi) VALUES (@Ad, @Soyad, @Eposta, @Telefon, @BaslamaTarihi)";
            using var cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Ad", model.Ad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Soyad", model.Soyad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Eposta", model.Eposta ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefon", model.Telefon ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@BaslamaTarihi", model.BaslamaTarihi);

            con.Open();
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Ogretmen ogretmen = null;
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Ogretmenler WHERE OgretmenId = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            using var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ogretmen = new Ogretmen
                {
                    OgretmenId = (int)dr["OgretmenId"],
                    Ad = dr["Ad"].ToString(),
                    Soyad = dr["Soyad"].ToString(),
                    Eposta = dr["Eposta"].ToString(),
                    Telefon = dr["Telefon"].ToString(),
                    BaslamaTarihi = Convert.ToDateTime(dr["BaslamaTarihi"])
                };
            }

            if (ogretmen == null)
                return NotFound();

            return View(ogretmen);
        }

        [HttpPost]
        public IActionResult Edit(Ogretmen model)
        {
            using var con = new SqlConnection(_connectionString);
            var query = "UPDATE Ogretmenler SET Ad = @Ad, Soyad = @Soyad, Eposta = @Eposta, Telefon = @Telefon, BaslamaTarihi = @BaslamaTarihi WHERE OgretmenId = @id";
            using var cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", model.OgretmenId);
            cmd.Parameters.AddWithValue("@Ad", model.Ad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Soyad", model.Soyad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Eposta", model.Eposta ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefon", model.Telefon ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@BaslamaTarihi", model.BaslamaTarihi);

            con.Open();
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Ogretmen ogretmen = null;
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Ogretmenler WHERE OgretmenId = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            using var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ogretmen = new Ogretmen
                {
                    OgretmenId = (int)dr["OgretmenId"],
                    Ad = dr["Ad"].ToString(),
                    Soyad = dr["Soyad"].ToString(),
                    Eposta = dr["Eposta"].ToString(),
                    Telefon = dr["Telefon"].ToString(),
                    BaslamaTarihi = Convert.ToDateTime(dr["BaslamaTarihi"])
                };
            }

            if (ogretmen == null)
                return NotFound();

            return View(ogretmen);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DELETE FROM Ogretmenler WHERE OgretmenId = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");
        }
    }
}