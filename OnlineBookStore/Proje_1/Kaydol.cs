using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_1
{
    public partial class Kaydol : Form
    {
        public Kaydol()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");

        private void Kaydol_Load(object sender, EventArgs e)
        {

        }

        private void btnuye_Click(object sender, EventArgs e)
        {
            SqlConnection yenibaglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");
            yenibaglanti.Open();
            // kullanıcı adının daha önce kullanılmamış olması kontrol ediliyor
            SqlCommand kontrolet = new SqlCommand("Select KullanıcıRumuz from Table_Login where KullanıcıRumuz=@oncekiadlar", yenibaglanti);
            kontrolet.Parameters.AddWithValue("@oncekiadlar", textBox3.Text);
            kontrolet.ExecuteNonQuery();
            SqlDataReader oku = kontrolet.ExecuteReader();

            if (oku.Read())
            {
                MessageBox.Show("Geçersiz Kullanıcı ad! Yeni kullanıcı adı alınız.");
                yenibaglanti.Close(); 
            }


            else
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Table_Login (KullanıcıAd,KullanıcıSoyadı,KullanıcıCinsiyet,KullanıcıMeslek,KullanıcıRumuz,KullanıcıŞifre) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
                if (checkBox1.Checked != true)
                {
                    MessageBox.Show(" Kullanım koşulları kabul edilmedi.");

                }
                else
                {

                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@p3", 1);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@p3", 0);
                    }
                    komut.Parameters.AddWithValue("@p4", textBox4.Text);
                    komut.Parameters.AddWithValue("@p6", textBox5.Text);
                    komut.Parameters.AddWithValue("@p5", textBox3.Text);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt başarıyla tamamlandı.Devam etmek için giriş yapınız.");

                }
                baglanti.Close();

            }

        }
    }
}

