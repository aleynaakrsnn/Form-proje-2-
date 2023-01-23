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
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=.;Database=m00;uid=sa;pwd=1234");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("select SiparisAdet,SiparisFiyat,UrunAdi from Siparis s inner join Urunler u on s.UrunNo=u.UrunNo", baglanti);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource=doldur;    
            baglanti.Close();    
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Saticilar where SaticiAdres='ataşehir' order by SaticiAdSoyad desc", baglanti);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglanti.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select MusteriAdSoyad,MusteriTelefon,SiparisFiyat,SiparisAdet from Siparis s inner join Musteriler m on s.SiparisNo=m.SiparisNo", baglanti);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglanti.Close();
        }

        private void Rapor_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urunler where UrunAdi='pasta' order by UrunFiyati desc", baglanti);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglanti.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
