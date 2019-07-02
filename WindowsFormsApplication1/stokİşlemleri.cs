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
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class stokİşlemleri : Form
    {
        public stokİşlemleri()
        {
            InitializeComponent();
        }
        //string DosyaYolu, DosyaAdi = "";
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-JMR7LFH;Database=pizza;User Id=sa;Password=123456;");
        SqlCommand komut;

        DataSet dset = new DataSet();
    
        void listele()
        {
            textBox1.Text = "";
            listBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

            dset.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from  pizzalar", baglanti);

            adtr.Fill(dset, "pizzalar");

            dataGridView1.DataSource = dset.Tables["pizzalar"];

            adtr.Dispose();
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string icerik = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                icerik += listBox1.Items[i] + " ";
            }
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into pizzalar(pizzaadi,boyutu,icindekiler,satis) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + icerik + "','" + comboBox2.Text + "')", baglanti);
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



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Resim Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from pizzalar where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
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



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Pizza silme İşlemi Yapılmıştır" + "')", baglanti);
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
            try
            {
                baglanti.Open();



                komut = new SqlCommand("update pizzalar set pizzaadi='" + textBox1.Text + "',boyutu='" + comboBox1.Text + "',icindekiler='" + listBox1.Text + "',satis='" + comboBox2.Text + "'where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                listele();
                
            }
            catch
            {

                ;
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToShortDateString() + "','" + "güncelleme" + "','" + "Pizza güncelleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["pizzaadi"].Value.ToString();
            listBox1.Text = dataGridView1.CurrentRow.Cells["icindekiler"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["boyutu"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["satis"].Value.ToString();
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox3.Text);
            comboBox3.Items.Remove(comboBox3.SelectedItem);
            comboBox3.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into icindekiler(icerikadi) values('" + textBox2.Text + "')", baglanti);
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



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "İçerik Ekleme İşlemi Yapılmıştır" + "')", baglanti);
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

                komut = new SqlCommand("delete from icindekiler where icerikadi='" + comboBox4.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox4.Items.Remove(comboBox4.Text);
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "İçerik silme İşlemi Yapılmıştır" + "')", baglanti);
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



                komut = new SqlCommand("insert into icecekler(icecek_adi,aciklama,fiyat) values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox5.Items.Add("İçecek Ad: " + textBox3.Text + " Açıklama: " + textBox4.Text + " Fiyat: " + textBox5.Text);
                textBox2.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "İçecek Ekleme İşlemi Yapılmıştır" + "')", baglanti);
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

                komut = new SqlCommand("delete from icecekler where icecek_adi='" + textBox6.Text + "'", baglanti);
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



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "İçecek silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into ekurunler(ekurunler_adi,aciklama,fiyat) values('" + textBox10.Text + "','" + textBox9.Text + "','" + textBox8.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox6.Items.Add("Ürün Adı: " + textBox10.Text + " Açıklama: " + textBox9.Text + " Fiyat: " + textBox8.Text);


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "EkÜrün Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from ekurunler where ekurunler_adi='" + textBox7.Text + "'", baglanti);
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



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Ek Ürün silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into boyutlar(boyutadi) values('" + textBox11.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox7.Items.Add(textBox11.Text);
                textBox11.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Pizza Boyut Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from boyutlar where boyutadi='" + comboBox7.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox7.Items.Remove(comboBox7.Text);
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Pizza Boyut silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into menuler(menu_adi,aciklama,fiyat) values('" + textBox15.Text + "','" + textBox14.Text + "','" + textBox13.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox8.Items.Add("Menü Adı: " + textBox15.Text + " Açıklama: " + textBox14.Text + " Fiyat: " + textBox13.Text);
                textBox15.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Menü Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from menuler where menu_adi='" + textBox12.Text + "'", baglanti);
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



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Menü silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into boyut_fiyat(pizza_id,boyut_id,fiyat,boyut_adi) values('" + comboBox10.Text + "','" + comboBox11.Text + "','" + textBox17.Text + "','" + textBox18.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                comboBox9.Items.Add("Pizza Id: " + comboBox10.Text + " Boyut Id: " + comboBox11.Text + " Fiyat: " + textBox17.Text);
                textBox17.Text = "";
                comboBox10.Text = "";
                comboBox11.Text = "";

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Pizza Fiyat Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from boyut_fiyat where pizza_id='" + textBox16.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                textBox16.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Pizza Fiyat Silme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from boyutlar where id='" + comboBox11.Text + "'", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    textBox18.Text = oku["boyutadi"].ToString();

                }

                baglanti.Close();



            }
            catch (Exception hata)
            {

                MessageBox.Show("" + hata.Message);
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from pizzalar where id='" + comboBox10.Text + "'", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    textBox19.Text = oku["pizzaadi"].ToString();

                }

                baglanti.Close();



            }
            catch (Exception hata)
            {

                MessageBox.Show("" + hata.Message);
            }
        }

        private void stokİşlemleri_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("Select * from icindekiler", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    comboBox3.Items.Add(oku["icerikadi"].ToString());
                    comboBox4.Items.Add(oku["icerikadi"].ToString());
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
                SqlCommand com = new SqlCommand("Select * from pizzalar", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    comboBox10.Items.Add(oku["id"].ToString());
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
                SqlCommand com = new SqlCommand("Select * from pizza_boyut_fiyat", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    comboBox9.Items.Add(oku["pizza_id"].ToString());
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
                SqlCommand com = new SqlCommand("Select * from menuler", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    comboBox8.Items.Add(oku["menu_adi"].ToString());

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
                SqlCommand com = new SqlCommand("Select * from icecekler", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    comboBox5.Items.Add("İçecek Adı: " + oku["icecek_adi"].ToString() + " Açıklama: " + oku["aciklama"].ToString() + " Fiyat= " + oku["fiyat"].ToString() + " TL");

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
                SqlCommand com = new SqlCommand("Select * from ekurunler", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {
                    comboBox6.Items.Add("EkUrun Adı: " + oku["ekurunler_adi"].ToString() + " Açıklama: " + oku["aciklama"].ToString() + " Fiyat= " + oku["fiyat"].ToString() + " TL");

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
                SqlCommand com = new SqlCommand("Select * from boyutlar", baglanti);

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {

                    comboBox7.Items.Add(oku["boyutadi"].ToString());
                    comboBox1.Items.Add(oku["boyutadi"].ToString());
                    comboBox11.Items.Add(oku["id"].ToString());

                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            baglanti.Close();

            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminPaneli admin = new adminPaneli();
            admin.Show();
            this.Hide();
        }
    }
}
