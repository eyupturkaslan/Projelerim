using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace sinavhazirlikfinal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\eyupc\\Documents\\xd.accdb");
        DataSet ds = new DataSet();
        OleDbCommand cmd;
        OleDbDataReader da;
        DataTable dt;

        public void oglistele()
        {
          //  dt.Clear();
            //dt.Columns.Clear();
            //dataGridView1.Refresh();
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select *From orenci", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oglistele();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("Select *From orenci", con);
            ds = new DataSet();
            da.Fill(ds,"tablo");
            dataGridView1.DataSource = ds.Tables["tablo"];
            con.Close();
        }
    }
}
