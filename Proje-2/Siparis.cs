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
    public partial class Siparis : Form
    {
        public Siparis()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select * from Siparis");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Siparis(SiparisNo,SiparisAdi,SiparisAdresi,SiparisAdet,SiparisFiyat,UrunNo,Tutar) values(@SiparisNo,@SiparisAdi,@SiparisAdi,@SiparisAdresi,@SiparisAdet,@SiparisFiyat,@UrunNo,@Tutar)", con);


            cmd.Parameters.AddWithValue("@SiparisNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@SiparisAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("@SiparisAdresi", textBox3.Text);
            cmd.Parameters.AddWithValue("@SipariAdet", textBox4.Text);
            cmd.Parameters.AddWithValue("@SiparisFiyat", textBox6.Text);
            cmd.Parameters.AddWithValue("@UrunNo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Tutar", textBox5.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Siparis");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update Siparis set SiparisAdi='" + textBox2.Text.ToString() + "',SiparisAdresi='" + textBox3.Text.ToString() + "',SiparisAdet='" + textBox4.Text.ToString() +"',SiparisFiyat='" + textBox6.Text.ToString() + "',UrunNo='" + comboBox1.Text.ToString() + "',Tutar='" + textBox5.Text.ToString() + "'where SiparisNo='" + textBox1.Tag + "'", con);

            //tırnakları alanları birbirinden ayırmak için kullanırız.(+) verileri birleştirmek için

            komut.ExecuteNonQuery();
            Listele("select * from Siparis");
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Siparis where SiparisNo=@SiparisNo", con);
            cmd.Parameters.AddWithValue("@SiparisNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            Listele("select * from Siparis");
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Siparis where SiparisAdi like '%" + textBox1.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox4.Text); 
            int b = Convert.ToInt32(textBox6.Text);
            int sonuc = a * b;
            textBox5.Text=sonuc.ToString();
           

           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Rapor git = new Rapor();
            git.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GirisEkrani git = new GirisEkrani();
            git.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
