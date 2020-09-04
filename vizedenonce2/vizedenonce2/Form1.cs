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

namespace vizedenonce2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-DEG2CAM;Initial Catalog=ders;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        void listele()
    {
        dt.Clear();
        dt.Columns.Clear();
        dataGridView1.Refresh();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select *From ogrenci", con);
        da.Fill(dt);
        dataGridView1.DataSource = dt;
        con.Close();
    }
        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            ds.Clear();
            da = new SqlDataAdapter("select max (not) from ogrenci", con);
            da.Fill(dt);
            dt.Clear();
            dt.Columns.Clear();
            dataGridView1.Refresh();
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into dersler (ders_adi,ders_sene,giren_id,sinif_id) values (@p1,@p2,@p3,@p4)", con);
            ekle.Parameters.AddWithValue("@p1", textBox1.Text);
            ekle.Parameters.AddWithValue("@p2", textBox2.Text);
            ekle.Parameters.AddWithValue("@p3", textBox3.Text);
            ekle.Parameters.AddWithValue("@p4", textBox4.Text);

            ekle.ExecuteNonQuery();
            con.Close();
            dt.Clear();
            dt.Columns.Clear();
            dataGridView1.Refresh();
            SqlDataAdapter da = new SqlDataAdapter("Select *From dersler", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

    }
}
