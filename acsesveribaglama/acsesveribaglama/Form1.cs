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

namespace acsesveribaglama
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb");
        DataSet ds = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }
        
        void listele ()
        {
            con.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("Select * From tablo1", con);
            adaptr.Fill(ds, "tablo1");
            dataGridView1.DataSource = ds.Tables[0];
            adaptr.Dispose();
            con.Close();
    }
        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO tablo1 (Kimlik,Ad,Soyad,Yas,xx) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + Convert.ToInt32(textBox4.Text) + "','" + textBox5.Text + "')", con);
            komut.ExecuteNonQuery();     //eğer hata yoksa komutu gerçekleştirir
            con.Close();
            MessageBox.Show("Kayıt Tamamlandı");
            ds.Clear();
            listele();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Veriyi Silmek Istediginizden Emin Misiniz?", "", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                con.Open();
                OleDbCommand komut2 = new OleDbCommand("DELETE FROM tablo1 WHERE Kimlik='" + textBox1.Text + "'", con);
                komut2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Silme Tamamlandı");
                ds.Clear();
                listele();
            }
            else
            {
                MessageBox.Show("Silme Islemi Iptal Edildi");
            }            
        }

        



    }
}
