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
using System.Collections;
namespace Proje_1
{
    public partial class Kitaplar : Form
    {
        public Kitaplar()
        {
            InitializeComponent();
        }
       public Form1 frm = new Form1();
        public Giriş grş = new Giriş();
        public string giriskontrol;
     
        public Alışveriş_Sepeti alısveris = new Alışveriş_Sepeti();

        //satın alma
        public string satınal(GroupBox grupbox)
        {
            
            foreach (Control bilgiler in grupbox.Controls)
            {
                if ((bilgiler) is Label)
                {
                    return ((Label)bilgiler).Text;
                }

            }
            return "ürün bilgisi bulunamadı";
        }
        //toplam tutarı hesaplama fiyatları listeye ekliyor
      public  ArrayList fiyattlarıekle = new ArrayList();
        public void FiyattlarıeklemeFonk(double fiyat)
        {
            fiyattlarıekle.Add(fiyat);
            
        }

        public double toplam;
        public double Toplamürüntutarıbul()
        {
         
            foreach (double fiyat in fiyattlarıekle)
            {
                toplam = toplam +(double) fiyat;
            }
            return toplam;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
     //   SqlConnection baglanti = new SqlConnection("data source=LAPTOP-M21SO0LO\\SQLEXPRESS; initial catalog=Proje_VeriTabani;Integrated Security=True;");
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(giriskontrol !="")
            {
                frm.btncıkıs.Visible = true;
                frm.btnprofil.Visible = true;
                frm.btngiris.Visible = false;
                frm.btnuyeol.Visible = false;
                frm.OncekiAlsvrs.Visible = true;
                frm.lblAd.Text = giriskontrol;
            }
           frm.Visible = true;

            //// satın alınan kitapların bilgilerini labellara yazıyor
            ///------   frm.label7.Text =ürünyaz() + Environment.NewLine + lblSatınAlınan.Text + Environment.NewLine;
               frm.label7.Text = alısveris.ürünyaz() + Environment.NewLine + label5.Text ;
           

            {// satın alınan kitapların toplamını labellara yazıyor
                double toplam;
                double labeldakideger;
                labeldakideger = double.Parse(label6.Text);

                toplam = Toplamürüntutarıbul() + labeldakideger;
                frm.label9.Text = toplam.ToString();
            }
        }
        Kitap kitap1 = new Kitap();
        Kitap kitap2 = new Kitap();
        Kitap kitap3 = new Kitap();
        Kitap kitap4 = new Kitap();
        private void Kitaplar_Load(object sender, EventArgs e)
        {

            //kitap oluşturulup yazdırılan kısım
          
           label8.Text=kitap1.ÖzellikleriGöster(1);     
            label7.Text = kitap2.ÖzellikleriGöster(2);
            label1.Text = kitap3.ÖzellikleriGöster(3);
            label9.Text = kitap4.ÖzellikleriGöster(4);


            // giriş yapılmadığı zaman groupBoxlardaki butonları etkisiz yapma
            if (giriskontrol=="")
            {
                foreach (Control grupbox in this.Controls)
                {
                    if ((grupbox) is GroupBox)
                    {
                        foreach (Control buton in grupbox.Controls)
                        {
                            if ((buton) is Button)
                            {               
                                ((Button)buton).Enabled = false;
                            }
                        }
                    }
                }   
            }
            
             
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public double kitaptutar;
        private void button1_Click(object sender, EventArgs e)
        {
            alısveris.ürünekleme(satınal(groupBox5));
          
            FiyattlarıeklemeFonk(kitap2.ÜrünFiyatınıÇek(1));


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            alısveris.ürünekleme(satınal(groupBox4));
            FiyattlarıeklemeFonk(kitap2.ÜrünFiyatınıÇek(2));

           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            alısveris.ürünekleme(satınal(groupBox3));
            FiyattlarıeklemeFonk(kitap3.ÜrünFiyatınıÇek(4));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            alısveris.ürünekleme(satınal(groupBox2));
            FiyattlarıeklemeFonk(kitap4.ÜrünFiyatınıÇek(3));
        }
    }
}
