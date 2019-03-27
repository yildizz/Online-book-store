using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Proje_1
{
    class Kitap:Ürün
    {
        private string yazar;

        public string Yazar
        {
            get
            {
                return yazar;
            }

            set
            {
                yazar = value;
            }
        }
        SqlConnection baglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");
        public override string ÖzellikleriGöster(int id)
        {
            Kitap kitap = new Kitap();

            //kitap bilgilerini veri tabanından çekme
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Table_Kitap where KitapId=@p1", baglanti);
            komut.Parameters.AddWithValue("p1", id);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                kitap.ad = oku["KitapAdı"].ToString();
                kitap.Yazar = oku["KitapYazarı"].ToString();
                kitap.fiyat = Convert.ToDouble(oku["KitapFiyatı"]);
                
            }
            baglanti.Close();
            oku.Close();
            return kitap.ad + Environment.NewLine+ Environment.NewLine + kitap.yazar + Environment.NewLine+ Environment.NewLine + kitap.fiyat+" tl";

        }
        public override double ÜrünFiyatınıÇek(int id)
        {
            double fiyat=0;
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Table_Kitap where KitapId=@p1", baglanti);
            komut.Parameters.AddWithValue("p1", id);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                fiyat = Convert.ToDouble(oku["KitapFiyatı"]);
            }
            baglanti.Close();
            return fiyat;
           
        }
    }
}
