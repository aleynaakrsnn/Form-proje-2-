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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Server =10.22.0.23;Database=M07;Integrated Security=true;");

        public void Listele(string sorgu)
        {
            SqlDataAdapter dr = new SqlDataAdapter(sorgu, con);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Musteriler(MusteriNo,MusteriAdSoyad,MusteriTelefon,SiparisNo) values(@MusteriNo,@MusteriAdSoyad,@MusteriTelefon,@SiparisNo)", con);


            cmd.Parameters.AddWithValue("@MusteriNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@MusteriAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@MusteriTelefon", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@SiparisNo", comboBox1.Text);
    
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Musteriler");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select * from Saticilar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Musteriler where MusteriNo=@MusteriNo", con);
            cmd.Parameters.AddWithValue("@MusteriNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            Listele("select * from Musteriler");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update Musteriler set MusteriAdSoyad='" + textBox2.Text.ToString() + "',MusteriTelefon='" + maskedTextBox1.Text.ToString() + "',SiparisNo='" + comboBox1.Text.ToString()  + "'where MusteriNo='" + textBox1.Tag + "'", con);

            //tırnakları alanları birbirinden ayırmak için kullanırız.(+) verileri birleştirmek için

            komut.ExecuteNonQuery();
            Listele("select * from Musteriler");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Musteriler where MusteriAdSoyad like '%" + textBox1.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Siparis go = new Siparis();
            go.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Urunler go = new Urunler();
            go.Show();
            this.Hide();
        
    }
    }
}
