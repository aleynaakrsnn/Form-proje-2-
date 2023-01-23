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

namespace Proje_2
{
    public partial class MusteriGiris : Form
    {
        public MusteriGiris()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server =10.22.0.23;Database=M07;Integrated Security=true;");

        private void button1_Click(object sender, EventArgs e)
        {
             
            con.Open();
            
            SqlCommand cmd = new SqlCommand("select * from MusteriGiris where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", con);
            cmd.Parameters.AddWithValue("KullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("Sifre",textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                MessageBox.Show("Tebrikler!!Başarılı giriş yaptınız.");
                Urunler git = new Urunler();
                git.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
                textBox1.Clear();
                textBox2.Clear();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into MusteriGiris(KullaniciAdi,Sifre,Mail,Telefon) values(@KullaniciAdi,@Sifre,@Mail,@Telefon)", con);

            cmd.Parameters.AddWithValue("KullaniciAdi", textBox3.Text);
            cmd.Parameters.AddWithValue("Sifre", textBox4.Text);
            cmd.Parameters.AddWithValue("Mail", textBox5.Text);
            cmd.Parameters.AddWithValue("Telefon", maskedTextBox1.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            groupBox1.Visible = true;
            textBox1.Text = textBox3.Text;
            textBox2.Text = textBox4.Text;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GirisEkrani git = new GirisEkrani();
            git.Show();
            this.Hide();
        }
    }
}
