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
    
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }
        public Form1 frm = new Form1();
     
        private void Giriş_Load(object sender, EventArgs e)
        {
            
        }
        SqlConnection baglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");
        private void btngirisyap_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Table_Login where KullanıcıRumuz=@p1 and KullanıcıŞifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader oku = komut.ExecuteReader();

            if (oku.Read())
            {
                this.Hide();

                frm.Show();
                frm.btnprofil.Visible = true;
                frm.btngiris.Visible = false;
                frm.btncıkıs.Visible = true;
                frm.btnuyeol.Visible = false;
                frm.OncekiAlsvrs.Visible = true;
                frm.lblAd.Text = oku["KullanıcıRumuz"].ToString();
                baglanti.Close();

               
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");

            }
             baglanti.Close();
           

           

        }
        private void Giriş_Load_1(object sender, EventArgs e)
        {

        }
    }
}
          
        


