using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class adminPaneli : Form
    {
        public adminPaneli()
        {
            InitializeComponent();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_user == "1")
            {

                kullanıcıEkle kullanici = new kullanıcıEkle();
                kullanici.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_stok == "1")
            {

                stokİşlemleri stok = new stokİşlemleri();
                stok.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_cari == "1")
            {

                CariYönetim cari = new CariYönetim();
                cari.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_toptan == "1")
            {

                toptancı toptan = new toptancı();
                toptan.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_buy == "1")
            {

                siparişİşlemleri siparis = new siparişİşlemleri();
                siparis.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void kullanıcıİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_user == "1")
            {

                kullanıcıEkle kullanici = new kullanıcıEkle();
                kullanici.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void stokİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_stok == "1")
            {

                stokİşlemleri stok = new stokİşlemleri();
                stok.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void cariYönetimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_cari == "1")
            {

                CariYönetim cari = new CariYönetim();
                cari.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void siparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_buy == "1")
            {

                siparişİşlemleri siparis = new siparişİşlemleri();
                siparis.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void toptancıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.yetki_toptan == "1")
            {

                toptancı toptan = new toptancı();
                toptan.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yetkiniz Bulunmamaktadır");
            }
        }

        private void adminPaneli_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
