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
    public partial class kullanıcıEkle : Form
    {
        public kullanıcıEkle()
        {
            InitializeComponent();
        }

        private void kullanıcıEkle_Load(object sender, EventArgs e)
        {
            listele();
        }
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-JMR7LFH;Database=pizza;User Id=sa;Password=123456;");
        SqlCommand komut;
        string kontrol = "";

        DataSet dset = new DataSet();
        string yetki_log = "0";
        string yetki_user = "0";
        string yetki_buy = "0";
        string yetki_stok = "0";
        string yetki_cari = "0";
        string yetki_toptan = "0";
        private byte[] Sifrele(byte[] SifresizVeri, byte[] Key, byte[] IV)

        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(SifresizVeri, 0, SifresizVeri.Length);

            cs.Close();
            byte[] sifrelenmisVeri = ms.ToArray();
            return sifrelenmisVeri;

        }
        
        private byte[] SifreCoz(byte[] SifreliVeri, byte[] Key, byte[] IV)

        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            
            cs.Write(SifreliVeri, 0, SifreliVeri.Length);

            cs.Close();
            
            byte[] SifresiCozulmusVeri = ms.ToArray();
            return SifresiCozulmusVeri;

        }
        public string TextSifrele(string sifrelenecekMetin)

        {

            byte[] sifrelenecekByteDizisi = System.Text.Encoding.Unicode.GetBytes(sifrelenecekMetin);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] {0x49, 0x76, 0x61, 0x6e,0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            byte[] SifrelenmisVeri = Sifrele(sifrelenecekByteDizisi, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(SifrelenmisVeri);

        }
        
        private string password = "1";
        public string TextSifreCoz(string text)

        {
            byte[] SifrelenmisByteDizisi = Convert.FromBase64String(text);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            
            byte[] SifresiCozulmusVeri = SifreCoz(SifrelenmisByteDizisi,pdb.GetBytes(32), pdb.GetBytes(16));
            
            return System.Text.Encoding.Unicode.GetString(SifresiCozulmusVeri);
        }
        void listele()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            dset.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From  kullanici", baglanti);

            adtr.Fill(dset, "kullanici");

            dataGridView1.DataSource = dset.Tables["kullanici"];

            adtr.Dispose();
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into kullanici(adi,soyadi,tel,adres,k_adi,parola,rol,durum) values('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + TextSifrele(textBox6.Text) + "','" + comboBox1.Text + "','" + comboBox2.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                kontrol = comboBox1.Text;
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            if (kontrol == "Müşteri")
            {
                baglanti.Open();
                komut = new SqlCommand("insert into musteriler(adi,soyadi,tel,adres,aciklama) values('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "ekleme" + "','" + "Kullanıcı Ekleme İşlemi Yapılmıştır" + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {

                ;
            }
            if (checkBox1.Checked == true)
            {
                yetki_log = "1";
            }
            else
            {
                yetki_log = "0";
            }
            if (checkBox2.Checked == true)
            {
                yetki_cari = "1";
            }
            else
            {
                yetki_cari = "0";
            }
            if (checkBox3.Checked == true)
            {
                yetki_buy = "1";
            }
            else
            {
                yetki_buy = "0";
            }
            if (checkBox4.Checked == true)
            {
                yetki_stok = "1";
            }
            else
            {
                yetki_stok = "0";
            }
            if (checkBox5.Checked == true)
            {
                yetki_user = "1";
            }
            else
            {
                yetki_user = "0";
            }
            if (checkBox6.Checked == true)
            {
                yetki_toptan = "1";
            }
            else
            {
                yetki_toptan = "0";
            }
            try
            {
                baglanti.Open();



                komut = new SqlCommand("insert into yetki(yetki_log,yetki_user,yetki_buy,yetki_stok,yetki_cari,yetki_toptan,k_adi) values('" + yetki_log + "','" + yetki_user + "','" + yetki_buy + "','" + yetki_stok + "','" + yetki_cari + "','" + yetki_toptan + "','" + textBox5.Text + "')", baglanti);
                komut.ExecuteNonQuery();

                baglanti.Close();
                kontrol = comboBox1.Text;


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }

        
    }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();



            komut = new SqlCommand("update kullanici set adi='" + textBox1.Text + "',soyadi='" + textBox2.Text + "',tel='" + maskedTextBox1.Text + "',adres='" + textBox4.Text + "',k_adi='" + textBox5.Text + "',parola='" + textBox6.Text + "',rol='" + comboBox1.Text + "',durum='" + comboBox2.Text + "'where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşleme Başarıyla Tamamlandı");
            baglanti.Close();
            listele();
            try
            {
                baglanti.Open();



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "güncelleme" + "','" + "Kullanıcı güncelleme İşlemi Yapılmıştır" + "')", baglanti);
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
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from kullanici where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
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



                SqlCommand komut2 = new SqlCommand("insert into log(kullanici_adi,tarih,islem,aciklama) values('" + Form1.giris + "','" + DateTime.Now.ToString() + "','" + "silme" + "','" + "Kullanıcı silme İşlemi Yapılmıştır" + "')", baglanti);
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
            textBox1.Text = dataGridView1.CurrentRow.Cells["adi"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["soyadi"].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["tel"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["k_adi"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["parola"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["rol"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["durum"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            adminPaneli admin = new adminPaneli();
            admin.Show();
            this.Hide();
        }
    }
}
