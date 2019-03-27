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
    public partial class Müzikler : Form
    {
        public Müzikler()
        {
            InitializeComponent();
        }
        public string giriskontrol;
        public Alışveriş_Sepeti alısveris = new Alışveriş_Sepeti();



        public ArrayList fiyattlarıekle = new ArrayList();

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


        Müzik müzik1 = new Müzik();
        Müzik müzik2 = new Müzik();
        private void Müzikler_Load(object sender, EventArgs e)
        {
            //müzik oluşturulup yazdırılan kısım

            label1.Text = müzik1.ÖzellikleriGöster(1);
            label7.Text = müzik2.ÖzellikleriGöster(2);

            // giriş yapılmadığı zaman groupBoxlardaki butonları etkisiz yapma
            if (giriskontrol =="")
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
            Form1 frm1 = new Form1();
            this.Hide();
            if (giriskontrol != "")
            {
                frm1.btncıkıs.Visible = true;
                frm1.btnprofil.Visible = true;
                frm1.btngiris.Visible = false;
                frm1.btnuyeol.Visible = false;
                frm1.OncekiAlsvrs.Visible = true;
                frm1.lblAd.Text = giriskontrol;
            }
            frm1.Visible = true;

            //// satın alınan kitapların bilgilerini labellara yazıyor
            ///------   frm.label7.Text =ürünyaz() + Environment.NewLine + lblSatınAlınan.Text + Environment.NewLine;
            frm1.label7.Text = alısveris.ürünyaz() + Environment.NewLine + label5.Text;

            {// satın alınan kitapların toplamını labellara yazıyor
                double toplam;
                double labeldakideger;
                labeldakideger = double.Parse(label6.Text);

                toplam = Toplamürüntutarıbul() + labeldakideger;
                frm1.label9.Text = toplam.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alısveris.ürünekleme(satınal(groupBox2));
           
            FiyattlarıeklemeFonk(müzik1.ÜrünFiyatınıÇek(1));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            alısveris.ürünekleme(satınal(groupBox3));
           
            FiyattlarıeklemeFonk(müzik2.ÜrünFiyatınıÇek(2));
        }
    }
}
