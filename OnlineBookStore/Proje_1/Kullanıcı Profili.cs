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
    public partial class Kullanıcı_Profili : Form
    {
        public Kullanıcı_Profili()
        {
            InitializeComponent();
        }

   //     public Form1 frm = new Form1();
        public string Rumuz;
        public bool cinsiyet;

        SqlConnection baglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");
        private void Kullanıcı_Profili_Load(object sender, EventArgs e)
        {
            
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * from Table_Login WHERE KullanıcıRumuz=@Rumuz", baglanti);
            komut.Parameters.AddWithValue("Rumuz", Rumuz );
            komut.ExecuteNonQuery();
            SqlDataReader oku = komut.ExecuteReader();

            oku.Read();
            textBox7.Text = oku["KullanıcıId"].ToString();
            textBox1.Text = oku["KullanıcıAd"].ToString();
            textBox2.Text = oku["KullanıcıSoyadı"].ToString();
            textBox4.Text = oku["KullanıcıMeslek"].ToString();
            textBox3.Text = oku["KullanıcıRumuz"].ToString();
            textBox5.Text = oku["KullanıcıŞifre"].ToString();
        
            cinsiyet = (bool)oku["KullanıcıCinsiyet"];
            if (cinsiyet == true)
            {
                radioButton1.Checked = true;
                pictureBox1.Visible = true;
            }
            else
            {
                radioButton2.Checked = true;
                pictureBox2.Visible = true;
            }
            baglanti.Close();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            
            SqlCommand komutgüncelle = new SqlCommand("Update Table_Login set KullanıcıAd=@a1,KullanıcıSoyadı=@a2,KullanıcıCinsiyet=@a3,KullanıcıMeslek=@a4,KullanıcıRumuz=@a5,KullanıcıŞifre=@a6 where KullanıcıId=@a7", baglanti);

            komutgüncelle.Parameters.AddWithValue("@a1", textBox1.Text);
            komutgüncelle.Parameters.AddWithValue("@a2", textBox2.Text);
            if (radioButton1.Checked == true)
            {
                komutgüncelle.Parameters.AddWithValue("@a3", 1);
            }
            else if (radioButton2.Checked == true)
            {
                komutgüncelle.Parameters.AddWithValue("@a3", 0);
            }

            komutgüncelle.Parameters.AddWithValue("@a4", textBox4.Text);
            komutgüncelle.Parameters.AddWithValue("@a5", textBox3.Text);
            komutgüncelle.Parameters.AddWithValue("@a6", textBox5.Text);
            komutgüncelle.Parameters.AddWithValue("@a7", textBox7.Text);


            komutgüncelle.ExecuteNonQuery();
            baglanti.Close();


        }
    }
}
