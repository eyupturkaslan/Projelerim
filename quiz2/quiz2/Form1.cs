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

namespace quiz2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-DEG2CAM;Initial Catalog=quiz2;Integrated Security=True");
        DataSet ds = new DataSet();
        void doldur()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select id,d1,d2,sonuc From tablo", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        void doldur2()
        {
            con.Open();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter("SELECT d1,d2, (d1 + d2) AS sonuc Where d1=@p1 and d2=@p2 FROM tablo", con);
            das.Fill(dts);
            dataGridView1.DataSource = dts;
           con.Close();
        }
        void doldur3()
        {
            con.Open();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter("SELECT d1,d2, (d1 - d2) AS sonuc FROM tablo", con);

            das.Fill(dts);
            dataGridView1.DataSource = dts;
            con.Close();
        }
        void doldur4()
        {
            con.Open();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter("SELECT d1,d2, (d1 % d2) AS sonuc FROM tablo", con);

            das.Fill(dts);
            dataGridView1.DataSource = dts;
            con.Close();
        }
        void doldur5()
        {
            con.Open();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter("SELECT d1,2, (d1 * d2) AS sonuc FROM tablo", con);

            das.Fill(dts);
            dataGridView1.DataSource = dts;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tablo (d1,d2) values (@p1,@p2)", con);
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();


            doldur();
            if (label1.Text == "+")
            {
                doldur2();
            }
            else if (label1.Text == "-")
            {
                doldur3();

            }
            else if (label1.Text == "/")
            {
                doldur4();
            }
            else if (label1.Text == "*")
            {
                doldur5();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "+";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "-";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "/";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "*";
        }
    }
}
