using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Proje_1
{
    class Müzik : Ürün
    {
        private string sanatçı;

        public string Sanatçı
        {
            get
            {
                return sanatçı;
            }

            set
            {
                sanatçı = value;
            }
        }
        SqlConnection baglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");
        public override string ÖzellikleriGöster(int id)
        {
            Müzik müzik = new Müzik();

            //müzik bilgilerini veri tabanından çekme

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Table_Müzik where MüzikId=@p1", baglanti);
            komut.Parameters.AddWithValue("p1", id);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                müzik.ad = oku["MüzikAd"].ToString();
                müzik.sanatçı = oku["MüzikSanatçı"].ToString();
                müzik.fiyat = Convert.ToDouble(oku["MüzikFiyat"]);

            }
            baglanti.Close();
            oku.Close();
            return müzik.ad + Environment.NewLine + Environment.NewLine + müzik.sanatçı + Environment.NewLine + Environment.NewLine + müzik.fiyat + " tl";
        }


        public override double ÜrünFiyatınıÇek(int id)
        {
            double fiyat = 0;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Table_Müzik where MüzikId=@p1", baglanti);
            komut.Parameters.AddWithValue("p1", id);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                fiyat = Convert.ToDouble(oku["MüzikFiyat"]);
            }
            baglanti.Close();
            return fiyat;

        }
    }
}

