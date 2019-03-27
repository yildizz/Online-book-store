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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static Giriş grş = new Giriş();
        public Kullanıcı_Profili profil = new Kullanıcı_Profili();
        public Alışveriş_Sepeti alısveris = new Alışveriş_Sepeti();
        public Müzikler müzikler = new Müzikler();
        public ÖncekiAlışverişler öncekialışveriş = new ÖncekiAlışverişler();

        SqlConnection baglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label8.Parent = pictureBox9;
            label10.Parent = pictureBox10;
            label11.Parent = pictureBox11;
            grş.frm = this;

            lblayınkitabı.Parent = pictureBox2;
            lblayınkitabı.BackColor = Color.Transparent;

           

        }
        private void btngiris_Click(object sender, EventArgs e)
        {
            grş.ShowDialog(); ;

        }




        private void pctrboxbook_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Kitaplar ktp = new Kitaplar();
            ktp.giriskontrol = lblAd.Text;

            ktp.label5.Text = label7.Text;
            ktp.label6.Text = label9.Text;


            //   alısveris.lblSatınAlınan.Text = label7.Text;

            // this.Hide();
            this.Visible = false;

            ktp.Show();
        }

        private void btnprofil_Click(object sender, EventArgs e)
        {
            profil.Rumuz = lblAd.Text;
            profil.ShowDialog();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btncıkıs_Click(object sender, EventArgs e)
        {
            grş.textBox1.Text = "";
            grş.textBox2.Text = "";
            btngiris.Visible = true;
            btnprofil.Visible = false;
            btncıkıs.Visible = false;
            OncekiAlsvrs.Visible = false;
            btnuyeol.Visible = true;
            lblAd.Text = "";
            label7.Text = "";
            
            baglanti.Close();

        }
        public AyınKitabı ayınkitabı = new AyınKitabı();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ayınkitabı.ShowDialog();
        }

        private void btnkaydol_Click(object sender, EventArgs e)
        {
            Kaydol yenikayıt = new Kaydol();
            yenikayıt.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            alısveris.giriskontrolu.Text = lblAd.Text;
            alısveris.giriskontrol = lblAd.Text;

            alısveris.lblSatınAlınan.Text = label7.Text;


            //toplam tutar
            // alısveris.label2.Text = label9.Text + " tl";
            alısveris.label2.Text = label9.Text;
            if (label9.Text != "0")
            {
                alısveris.btnodeme.Visible = true;
            }



            this.Hide();
            alısveris.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            müzikler.giriskontrol = lblAd.Text;
            this.Hide();
            müzikler.Show();


            müzikler.label5.Text = label7.Text;
            müzikler.label6.Text = label9.Text;
        }
        int sayac = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac % 3 == 0)
            {
                panel2.Visible = true;
                panel7.Visible = true;
                panel6.Visible = true;
            }
            if (sayac % 3 == 1)
            {
                panel2.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            Dergiler dergiler = new Dergiler();
            dergiler.giriskontrol = lblAd.Text;
            this.Visible = false;
            dergiler.Show();

            dergiler.label7.Text = label7.Text;
            dergiler.label6.Text = label9.Text;


        }
      

        private void OncekiAlsvrs_Click(object sender, EventArgs e)
        {
            
            //veritabaından önceki alışverişleri çekiyor
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * from  Table_ÖncekiAlışveriş  WHERE KullanıcıAdı=@kullanıcıadı", baglanti);
            komut.Parameters.AddWithValue("kullanıcıadı", lblAd.Text);

            SqlDataAdapter uyarla = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            uyarla.Fill(tablo);
            öncekialışveriş.dataGridView1.DataSource = tablo;
            baglanti.Close();
            
            öncekialışveriş.ShowDialog();

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

