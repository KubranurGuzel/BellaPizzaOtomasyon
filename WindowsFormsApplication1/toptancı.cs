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
    public partial class toptancı : Form
    {
        public toptancı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-JMR7LFH;Database=pizza;User Id=sa;Password=123456;");
        SqlCommand komut;
        DataSet dset = new DataSet();
        private void toptancı_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dset.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From  toptanci", baglanti);

            adtr.Fill(dset, "toptanci");

            dataGridView1.DataSource = dset.Tables["toptanci"];

            adtr.Dispose();
            baglanti.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("insert into toptanci(firma,mal,miktar,cins,tane_fiyat)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Eklendi");
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from toptanci where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();

                listele();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            adminPaneli admin = new adminPaneli();
            admin.Show();
            this.Hide();
        }
    }
}
