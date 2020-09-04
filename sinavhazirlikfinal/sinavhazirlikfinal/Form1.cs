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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\eyupc\\Documents\\xd.accdb");
        DataSet ds = new DataSet();
        OleDbCommand cmd;
        OleDbDataReader dr;
        public void sifredogrula()
        {
            string ad = textBox1.Text;
            string sifre = textBox2.Text;
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from giris where k_adi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form2 f2 = new Form2();
                f2.Show();
                Form1 f1 = new Form1();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yannis");
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sifredogrula();
        }
     
    }

        }
    

