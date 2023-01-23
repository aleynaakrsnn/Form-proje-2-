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
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server =10.22.0.23;Database=M07;Integrated Security=true;");

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MusteriGiris go = new MusteriGiris();
            go.Show();
            this.Hide();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SaticiGiris go = new SaticiGiris();
            go.Show();
            this.Hide();
        }
    }
}
