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
namespace Eyup_Turkaslan_60180000107
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        OleDbConnection con= new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=asma.accdb");
        public static string kul_ad;
        OleDbCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            kul_ad = textBox1.Text;
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kul where ad='" + kul_ad + "'";
           OleDbDataReader dr = cmd.ExecuteReader();
          
           if (dr.Read())
           {
           Form1 Form1= new Form1();
           Form1.Show();
           con.Close();
           }

           else
           {
               int kazan = 0;
               int kaybet=0;
             
               OleDbCommand ekle = new OleDbCommand();
               ekle.Connection =con;
               ekle.CommandText = "insert into kul(ad, kazan, kaybet) values('" + textBox1.Text + "','" + kazan + "','" + kaybet + "')";
               ekle.ExecuteNonQuery();
               ekle.Dispose();
               con.Close();
               MessageBox.Show("Kayıt işlemi başarılı!");
               Form1 Form1 = new Form1();
               Form1.Show();
               giris giris = new giris();
               giris.Close();
           }

        }
        
    }
}
