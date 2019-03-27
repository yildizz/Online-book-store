using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje_1
{
    class Dergi:Ürün
    {
        private string DergiTürü;

        public string DergiTürü1
        {
            get
            {
                return DergiTürü;
            }

            set
            {
                DergiTürü = value;
            }
        }
        SqlConnection baglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");
        public override string ÖzellikleriGöster(int id)
        {
            Dergi dergi = new Dergi();


            //dergi bilgilerini veri tabanından çekme

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Table_Dergi where DergiId=@p1", baglanti);
            komut.Parameters.AddWithValue("p1", id);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                dergi.ad = oku["DergiAdı"].ToString();
                dergi.DergiTürü = oku["DergiTürü"].ToString();
                dergi.fiyat = Convert.ToDouble(oku["DergiFiyatı"]);

            }
            baglanti.Close();
            oku.Close();
            return dergi.ad + Environment.NewLine + Environment.NewLine + dergi.DergiTürü + Environment.NewLine + Environment.NewLine + dergi.fiyat + " tl";
        }
        public override double ÜrünFiyatınıÇek(int id)
        {
            double fiyat = 0;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Table_Dergi where DergiId=@p1", baglanti);
            komut.Parameters.AddWithValue("p1", id);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                fiyat = Convert.ToDouble(oku["DergiFiyatı"]);
            }
            baglanti.Close();
            return fiyat;

        }
    }
}
