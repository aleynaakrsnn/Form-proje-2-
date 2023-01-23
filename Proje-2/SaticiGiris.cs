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
    public partial class SaticiGiris : Form
    {
        public SaticiGiris()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Server =10.22.0.23;Database=M07;Integrated Security=true;");

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from SaticiGiris where SaticiAdi=@SaticiAdi and Sifre=@Sifre", con);
          


            cmd.Parameters.AddWithValue("SaticiAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("Sifre", textBox2.Text);
        

            SqlDataReader dr=cmd.ExecuteReader();
       


            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı ", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Siparis go = new Siparis();
                go.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Hatalı Giriş", "HATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                textBox1.Clear();
                textBox2.Clear();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SaticiGiris(SaticiAdi,Sifre,Mail,Telefon) values(@SaticiAdi,@Sifre,@Mail,@Telefon)", con);

            cmd.Parameters.AddWithValue("@SaticiAdi", textBox3.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox4.Text);
            cmd.Parameters.AddWithValue("@Mail", textBox5.Text);
            cmd.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);

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
