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
using Microsoft.VisualBasic;

namespace WindowsFormsApplication1
{
    public partial class siparişİşlemleri : Form
    {
        public siparişİşlemleri()
        {
            InitializeComponent();
        }
        public static string fisid = "";
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-JMR7LFH;Database=pizza;User Id=sa;Password=123456;");
        SqlCommand komut;
        DataSet dset = new DataSet();
        string tutar;
        string mad;
        string msoyad;
        private void siparişİşlemleri_Load(object sender, EventArgs e)
        {
            listele();
            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from siparis_durum", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {


                    comboBox4.Items.Add(oku["id"].ToString());

                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            baglanti.Close();
            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from musteriler", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {


                    comboBox2.Items.Add(oku["id"].ToString());

                }
            }

            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            baglanti.Close(); try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from siparis_liste ORDER BY id DESC", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {


                    comboBox6.Items.Add(oku["id"].ToString());

                }
            }

            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            baglanti.Close();
            /*  try
              {
                  baglanti.Open();
                  SqlCommand com = new SqlCommand("Select * from kullanici", baglanti);

                  SqlDataReader oku = com.ExecuteReader();
                  while (oku.Read())
                  {


                      comboBox3.Items.Add(oku["id"].ToString());

                  }
              }
              catch (Exception hata)
              {

                  MessageBox.Show(hata.Message);
              }
              baglanti.Close();*/
        }
        void listele()
        {
            baglanti.Close();
            comboBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            //comboBox3.Text = "";

            dset.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From  siparisler", baglanti);

            adtr.Fill(dset, "siparisler");

            dataGridView1.DataSource = dset.Tables["siparisler"];

            adtr.Dispose();
            baglanti.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into siparisler(siparis_liste,iskonta,musteri_id,siparis_tarihi,para_alinma_tarihi,teslim_tarihi,tutar,kullanici_id,durum_id,alindi) values('" + comboBox6.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox1.Text + "','" + comboBox4.Text + "','" + textBox6.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Sipariş  Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
           
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from siparisler where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();

                listele();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Sipariş silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string durumgirisi = Interaction.InputBox("Sipariş Durumu Girişi", "Lütfen Durum Giriniz.");
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into siparis_durum(durum) values('" + durumgirisi + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");

                baglanti.Close();
                listele();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Sipariş Durumu Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
            listele();
            comboBox4.Items.Clear();
            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from siparis_durum", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {


                    comboBox4.Items.Add(oku["id"].ToString());

                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox3.Text = DateTime.Now.ToString();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox4.Text = DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from siparis_liste WHERE id='" + comboBox6.Text + "'", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {
                    textBox2.Text = oku["siparis_tarihi"].ToString();
                    tutar = oku["tutar"].ToString();
                    textBox8.Text = oku["k_adi"].ToString();
                    textBox5.Text = oku["tutar"].ToString();
                    mad = oku["musteri_adi"].ToString();
                    msoyad = oku["musteri_soyadi"].ToString();

                }
                baglanti.Close();
                textBox7.Text = mad + " " + msoyad;
                
                baglanti.Open();
                SqlCommand com2 = new SqlCommand("Select * from musteriler WHERE adi='" + mad + "'and soyadi='" + msoyad + "'", baglanti);

                SqlDataReader oku2 = com2.ExecuteReader();
                while (oku2.Read())
                {
                    comboBox2.Text = oku2["id"].ToString();
                    
                }
                baglanti.Close();


                baglanti.Open();
                SqlCommand com3 = new SqlCommand("Select * from kullanici WHERE k_adi='" + textBox8.Text + "'", baglanti);

                SqlDataReader oku3 = com3.ExecuteReader();
                while (oku3.Read())
                {
                    textBox1.Text = oku3["id"].ToString();
                }
                baglanti.Close();
            }

            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = (double.Parse(tutar) - ((double.Parse(comboBox1.Text) / 100) * double.Parse(tutar))).ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from siparis_durum WHERE id='" + comboBox4.Text + "'", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    textBox6.Text = oku["durum"].ToString();

                }
                baglanti.Close();
            }

            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fisid = comboBox2.Text;
            fis fisler = new fis();
            fisler.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            adminPaneli admin = new adminPaneli();
            admin.Show();
            this.Hide();
        }
    }

    class Interaction
    {
        internal static string InputBox(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
