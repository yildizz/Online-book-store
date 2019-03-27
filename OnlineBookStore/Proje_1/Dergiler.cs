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

namespace Proje_1
{
    public partial class Dergiler : Form
    {
        public Dergiler()
        {
            InitializeComponent();
        }
        public string giriskontrol;
        public Form1 frm = new Form1();
        public Alışveriş_Sepeti alısveris = new Alışveriş_Sepeti();


      public  ArrayList fiyattlarıekle = new ArrayList();
        public void FiyattlarıeklemeFonk(double fiyat)
        {
            fiyattlarıekle.Add(fiyat);

        }
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
        public double toplam;
        public double Toplamürüntutarıbul()
        {

            foreach (double fiyat in fiyattlarıekle)
            {
                toplam = toplam + (double)fiyat;
            }
            return toplam;
        }


        Dergi dergi1 = new Dergi();
        Dergi dergi2 = new Dergi();
        private void Dergiler_Load(object sender, EventArgs e)
        {
            label1.Text = dergi1.ÖzellikleriGöster(1);
            label2.Text = dergi2.ÖzellikleriGöster(2);


            // giriş yapılmadığı zaman groupBoxlardaki butonları etkisiz yapma
            if (giriskontrol == "")
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (giriskontrol != "")
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
            frm.label7.Text = alısveris.ürünyaz() + Environment.NewLine + label7.Text ;

            {// satın alınan kitapların toplamını labellara yazıyor
                double toplam;
                double labeldakideger;
                labeldakideger = double.Parse(label6.Text);

                toplam = Toplamürüntutarıbul() + labeldakideger;
                frm.label9.Text = toplam.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alısveris.ürünekleme(satınal(groupBox2));

            FiyattlarıeklemeFonk(dergi1.ÜrünFiyatınıÇek(1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alısveris.ürünekleme(satınal(groupBox3));

            FiyattlarıeklemeFonk(dergi2.ÜrünFiyatınıÇek(2));
        }
    }
}
