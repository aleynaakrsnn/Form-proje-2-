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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Server =10.22.0.23;Database=M07;Integrated Security=true;");
        SqlConnection con1 = new SqlConnection("Server =10.22.0.23;Database=M07;Integrated Security=true;");

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
            SqlCommand cmd = new SqlCommand("insert into Urunler(UrunNo,UrunAdi,UrunFiyati,KullanimTarihi,UretimTarihi,SaticiNo) values(@UrunNo,@UrunAdi,@UrunFiyati,@KullanimTarihi,@UretimTarihi,@SaticiNo)", con);

            cmd.Parameters.AddWithValue("@UrunAdi", comboBox1.Text);
            cmd.Parameters.AddWithValue("@UrunFiyati", textBox3.Text);
            cmd.Parameters.AddWithValue("@KullanimTarihi", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@UretimTarihi", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@SaticiNo", comboBox2.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Urunler");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update Urunler set UrunAdi='" + comboBox1.Text.ToString() + "',UrunFiyati='" + textBox3.Text.ToString() + "',KullanimTarihi='" + maskedTextBox1.Text.ToString() +"',UretimTarihi='" + maskedTextBox2.Text.ToString() + "',SaticiNo='" + comboBox2.Text.ToString() + "'where UrunNo='" + textBox1.Tag + "'", con);

            //tırnakları alanları birbirinden ayırmak için kullanırız.(+) verileri birleştirmek için

            komut.ExecuteNonQuery();
            Listele("select * from Urunler");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Urunler where UrunNo=@UrunNo", con);
            cmd.Parameters.AddWithValue("@UrunNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            Listele("select * from Urunler");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Urunler where UrunAdi like '%" + comboBox1.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select * from Urunler");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Musteriler go = new Musteriler();
            go.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int adet = Convert.ToInt32(textBox2.Text);
            int fiyat=Convert.ToInt32(textBox3.Text);
            int sonuc = adet * fiyat;
            textBox1.Text = sonuc.ToString();
               

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urunler where UrunAdi=@UrunAdi",con);
            SqlDataReader dr;
            con.Open();
            dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Text = dr["UrunAdi"].ToString();    
            }
            {
                con.Close();
            }
        }

        private void Urunler_Load(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("select * from Satıcı", con);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBox2.Items.Add(dr["SaticiNo"]);

            }
      con.Close();

            SqlCommand cmd1 = new SqlCommand("select * from Urunler", con1);
            con1.Open();

            SqlDataReader dr1;
            dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["UrunAdi"]);

            }
            con1.Close();
        }

    }
}
