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
    public partial class CariYönetim : Form
    {
        public CariYönetim()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-JMR7LFH;Database=pizza;User Id=sa;Password=123456;");
        SqlCommand komut;
        private void CariYönetim_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from giderler", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    comboBox2.Items.Add("Açıklama= " + oku["aciklama"].ToString() + " Kategori= " + oku["kategori"].ToString() + " tutar= " + oku["tutar"].ToString());

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
                SqlCommand com = new SqlCommand("Select * from gelirler", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    comboBox5.Items.Add("Açıklama= " + oku["aciklama"].ToString() + " Kategori= " + oku["kategori"].ToString() + " tutar= " + oku["tutar"].ToString());

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
                SqlCommand com = new SqlCommand("Select * from giderkategori", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {


                    comboBox4.Items.Add(oku["kategori"].ToString());
                }
                textBox2.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            baglanti.Close();

            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from gelirkategori", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {


                    comboBox1.Items.Add(oku["kategori"].ToString());
                    comboBox3.Items.Add(oku["kategori"].ToString());
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            baglanti.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into giderkategori(kategori) values('" + textBox2.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox4.Items.Add(textBox2.Text);
                textBox2.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Gider Kategori Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from giderkategori where kategori='" + comboBox4.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox4.Items.Remove(comboBox4.Text);
                textBox2.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Gider Kategori silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into gelirkategori(kategori) values('" + textBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Gelir Kategori Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from gelirkategori where kategori='" + comboBox4.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox1.Items.Remove(comboBox1.Text);
                textBox1.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Gelir Kategori silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into gelirler(aciklama,kategori,tutar) values('" + textBox3.Text + "','" + comboBox3.Text + "','" + textBox5.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox5.Items.Add("Aciklama: " + textBox3.Text + " Kategori: " + comboBox3.Text + " Tutar: " + textBox5.Text);

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Gelir Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from gelirler where aciklama='" + textBox6.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                textBox6.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Gelir silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into giderler(aciklama,kategori,tutar) values('" + textBox10.Text + "','" + textBox9.Text + "','" + textBox8.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox2.Items.Add("Aciklama: " + textBox10.Text + " Kategori: " + textBox9.Text + " Tutar: " + textBox8.Text);

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Gider Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from giderler where aciklama='" + textBox7.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                textBox7.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Gider silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
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
