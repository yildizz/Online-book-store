using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_1
{
    public partial class AyınKitabı : Form
    {
        public AyınKitabı()
        {
            InitializeComponent();
        }

        private void AyınKitabı_Load(object sender, EventArgs e)
        {
            Kitap kitap2 = new Kitap();
            label1.Text = kitap2.ÖzellikleriGöster(2);
        }
       
        private void button2_Click(object sender, EventArgs e)
           
        {
            Kitaplar ktp = new Kitaplar();
            Form1 frm = new Form1();
            this.Hide();
            ktp.ShowDialog();
            frm.Hide();
        }
    }
}
