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


namespace WindowsFormsApplication1
{
    public partial class fis : Form
    {
        public fis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-JMR7LFH;Database=pizza;User Id=sa;Password=123456;");
        SqlCommand komut;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            Font myFont = new Font("Calibri", 28);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);

            //logo için
            e.Graphics.DrawImage(Properties.Resources.fis, 50, 10);

            //Bu kısımda sipariş formu yazısını ve çizgileri yazdırıyorum
            e.Graphics.DrawLine(myPen, 120, 120, 750, 120);
            e.Graphics.DrawLine(myPen, 120, 180, 750, 180);
            e.Graphics.DrawString("Fiş", myFont, sbrush, 300, 120);


            myFont = new Font("Calibri", 9, FontStyle.Bold);
            e.Graphics.DrawString("Sipariş Liste", myFont, sbrush, 50, 200);
            e.Graphics.DrawString("İskonta", myFont, sbrush, 120, 200);
            e.Graphics.DrawString("Müşteri ID", myFont, sbrush, 200, 200);
            e.Graphics.DrawString("Sipariş Tarihi", myFont, sbrush, 280, 200);

            e.Graphics.DrawString("Tutar", myFont, sbrush, 400, 200);
            //            e.Graphics.DrawString("Kullanıcı ID", myFont, sbrush, 800, 328);
            //          e.Graphics.DrawString("Durum ID", myFont, sbrush, 900, 328);
            //        e.Graphics.DrawString("ALINDI", myFont, sbrush, 1000, 328);

            e.Graphics.DrawLine(myPen, 50, 125, 770, 125);

            int y = 250;

            StringFormat myStringFormat = new StringFormat();
            myStringFormat.Alignment = StringAlignment.Far;


            foreach (ListViewItem lvi in listView1.Items)
            {
                e.Graphics.DrawString(lvi.SubItems[0].Text, myFont, sbrush, 70, y, myStringFormat);
                e.Graphics.DrawString(lvi.SubItems[1].Text, myFont, sbrush, 140, y, myStringFormat);
                e.Graphics.DrawString(lvi.SubItems[2].Text, myFont, sbrush, 220, y, myStringFormat);
                e.Graphics.DrawString(lvi.SubItems[3].Text, myFont, sbrush, 340, y, myStringFormat);
                e.Graphics.DrawString(lvi.SubItems[4].Text, myFont, sbrush, 420, y, myStringFormat);



            }

            e.Graphics.DrawLine(myPen, 50, 125, 770, 125);
        }
        private void fis_Load(object sender, EventArgs e)
        {
            try
            {
                printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[5];
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }


            string kad = "";

            baglanti.Open();
            SqlCommand com = new SqlCommand("Select * from siparisler where musteri_id='" + siparişİşlemleri.fisid + "'", baglanti);

            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                kad = dr["musteri_id"].ToString();
            }
            baglanti.Close();
            try
            {
                baglanti.Open();
                SqlCommand comm = new SqlCommand("Select * from siparisler where musteri_id='" + kad + "'ORDER BY id DESC", baglanti);

                SqlDataReader drr = comm.ExecuteReader();
                if (drr.Read())
                {
                    ListViewItem item = new ListViewItem(drr["siparis_liste"].ToString());
                    item.SubItems.Add(drr["iskonta"].ToString());
                    item.SubItems.Add(drr["musteri_id"].ToString());
                    item.SubItems.Add(drr["siparis_tarihi"].ToString());
                    item.SubItems.Add(drr["tutar"].ToString());
                    item.SubItems.Add(drr["durum_id"].ToString());
                    item.SubItems.Add(drr["alindi"].ToString());
                    listView1.Items.Add(item);

                }
            }

            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            baglanti.Close();
            printPreviewDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult pdr = printDialog1.ShowDialog();
            if (pdr == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }
    }
}
