using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;


namespace Proje_1
{
    public partial class Alışveriş_Sepeti : Form
    {
        public Alışveriş_Sepeti()
        {
            InitializeComponent();
        }
        static public Form1 frm = new Form1();
        public string giriskontrol;

        //  alışverişsepeti Kullanıcısepeti = new alışverişsepeti();
        public ArrayList sepet = new ArrayList();
        // ekleme 
        public void ürünekleme(string yeniürün)
        {

            sepet.Add(yeniürün);
        }

        public string yaz;
        public string ürünyaz()
        {
            foreach (string ürün in sepet)
            {
                //yaz = yaz + Environment.NewLine + ürün + Environment.NewLine + "- - - - - - - - - - - - - -";
                yaz = yaz+ Environment.NewLine + ürün + Environment.NewLine + "-";


            }
            return yaz;

        }
        //toplam tutarı hesaplama fiyatları listeye ekliyor
        public ArrayList fiyattlarıekle = new ArrayList();
        public void FiyattlarıeklemeFonk(double fiyat)
        {
            fiyattlarıekle.Add(fiyat);

        }

        public double toplam;
        public double Toplamürüntutarıbul()
        {

            foreach (double fiyat in fiyattlarıekle)
            {
                toplam = toplam + (double)fiyat;
            }
            return toplam;
        }


        Kullanıcı_Profili profil = new Kullanıcı_Profili();
        SqlConnection baglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");
        private void Alışveriş_Sepeti_Load(object sender, EventArgs e)
        {
            //kullanıcı profil resmini gösterme
            if (giriskontrolu.Text != "")
            {
                baglanti.Open();

                bool cinsiyet;
                SqlCommand komut = new SqlCommand("Select * from Table_Login WHERE KullanıcıRumuz=@Rumuz", baglanti);
                komut.Parameters.AddWithValue("Rumuz", giriskontrolu.Text);
                komut.ExecuteNonQuery();
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                cinsiyet = (bool)oku["KullanıcıCinsiyet"];
                if (cinsiyet == true)
                {

                    pictureBox1.Visible = true;
                }
                else
                {

                    pictureBox2.Visible = true;
                }
                baglanti.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            button2.Visible = true;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //alışverişi iptal etme
            sepet.Clear();
            frm.label7.Text = "";

            lblSatınAlınan.Text = null;
            label2.Text = "0";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //geri butonu kısmı

            if (giriskontrol != "")
            {
                frm.btncıkıs.Visible = true;
                frm.btnprofil.Visible = true;
                frm.OncekiAlsvrs.Visible = true;
                frm.btnuyeol.Visible = false;
                frm.btngiris.Visible = false;
                frm.btnuyeol.Visible = false;
                frm.lblAd.Text = giriskontrol;
                
            }


            //// satın alınan kitapların bilgilerini labellara yazıyor
            ///------   frm.label7.Text =ürünyaz() + Environment.NewLine + lblSatınAlınan.Text + Environment.NewLine;
            frm.label7.Text = ürünyaz()  + lblSatınAlınan.Text;

            {// satın alınan kitapların toplamını labellara yazıyor
                double toplam;
                double labeldakideger = 0;
                labeldakideger = double.Parse(label2.Text);

                toplam = Toplamürüntutarıbul() + labeldakideger;
                frm.label9.Text = toplam.ToString();
            }



            frm.Show();
            this.Visible = false;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //alışverişi tamamla kısmı
            char[] ayrac = { '-' };
            string[] parcalar;
            parcalar = lblSatınAlınan.Text.Split(ayrac);

            int indeks = 0;
            foreach (string parca in parcalar)
            {
                indeks++;
            }
            
            baglanti.Open();
            

            for (int i = 0; i < indeks; i++)
            { 
                SqlCommand komut = new SqlCommand("insert into Table_ÖncekiAlışveriş (KullanıcıAdı,ÜrünBilgileri) values (@p1,@p2)", baglanti);
            
                komut.Parameters.AddWithValue("@p1", giriskontrolu.Text);
                komut.Parameters.AddWithValue("@p2", parcalar[i]);
               komut.ExecuteNonQuery();
            }
             
            baglanti.Close();
         DialogResult tamam=   MessageBox.Show("SİPARİŞİNİZ ALINDI EN KISA SÜREDE KARGOYA VERİLECEKTİR.","Bilgilendirme Penceresi", MessageBoxButtons.OK,MessageBoxIcon.Information);
         
             sepet.Clear();
            frm.label7.Text = "";

            lblSatınAlınan.Text = null;
            label2.Text = "0";
        }
    }
}


