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
    public partial class Saticilar : Form
    {
        public Saticilar()
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


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Saticilar(SaticiNo,SaticiAdSoyad,SaticiAdres,SaticiIl,SaticiIlce) values(@SaticiNo,@SaticiAdSoyad,@SaticiAdres,@SaticiIl,@SaticiIlce)", con);


            cmd.Parameters.AddWithValue("@SaticiNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@SaticiAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@SaticiAdres", textBox3.Text);
            cmd.Parameters.AddWithValue("@SaticiIl", textBox4.Text);
            cmd.Parameters.AddWithValue("@SaticiIlce", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Saticilar");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Listele("select * from Saticilar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Saticilar where SaticiNo=@SaticiNo", con);
            cmd.Parameters.AddWithValue("@SaticiNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            Listele("select * from Saticilar");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update Saticilar set SaticiAdSoyad='" + textBox2.Text.ToString() + "',SaticiAdres='" + textBox3.Text.ToString() + "',SaticiIl='" + textBox4.Text.ToString() + "',SaticiIlce='" + textBox5.Text.ToString() + "'where SaticiNo='" + textBox1.Tag + "'", con);

            //tırnakları alanları birbirinden ayırmak için kullanırız.(+) verileri birleştirmek için

            komut.ExecuteNonQuery();
            Listele("select * from Saticilar");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Saticilar where SaticiAdSoyad like '%" + textBox1.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
    }
}
