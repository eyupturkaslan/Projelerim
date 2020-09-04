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
namespace Technointouch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      SqlConnection con;
      SqlCommand cmd;
      SqlDataReader dr;
         private void kapama()
         {
             DialogResult sonuc;
             sonuc = MessageBox.Show("Kapatmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             if (sonuc == DialogResult.No)
             {
                 //MessageBox.Show("");// hiçbir işlem yaptırmıyorum
             }
             if (sonuc == DialogResult.Yes)
             {
                 this.Close();
                 Application.Exit();
             }
         }
        private void button1_Click(object sender, EventArgs e)
        {
            giris();
        }
        private void giris()
        {
            string ad = textBox1.Text;
            string sifre = textBox2.Text;
            con = new SqlConnection("Data Source=DESKTOP-DEG2CAM\\SQLEXPRESS01;Initial Catalog=techno;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM giris where k_adi='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.HasRows)
            {
                while (dr.Read())
                { 
                if (dr["yetki"].ToString()== "admin")
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                else if (dr["yetki"].ToString()== "calisan")
                {
                    Form8 f8 = new Form8();
                    f8.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                }
            }
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            kapama();
        }
    }
}
