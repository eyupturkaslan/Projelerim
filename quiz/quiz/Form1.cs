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
namespace quiz
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=Database21.accdb");
        DataSet ds = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }
       

        void listele1()
        {

            con.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("Select * From Tablo1", con);
            adaptr.Fill(ds, "Tablo1");
            dataGridView1.DataSource = ds.Tables[0];
            adaptr.Dispose();
            con.Close();

        }
        void listele2()
        {

            con.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("Select * From Tablo2", con);
            adaptr.Fill(ds, "Tablo2");
            dataGridView2.DataSource = ds.Tables[1];
            adaptr.Dispose();
            con.Close();

        }
        void listele3()
        {

            con.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("Select * From Tablo3", con);
            adaptr.Fill(ds, "Tablo3");
            dataGridView3.DataSource = ds.Tables[2];
            adaptr.Dispose();
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            listele1();
            listele2();
            listele3();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO Tablo2 (tc,ad,soyad,gelir,id,k_id) VALUES ('" + textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" +Convert.ToInt32(textBox4.Text) +"','"+ textBox5.Text + "','" + textBox6.Text + "')", con);
            komut.ExecuteNonQuery();     //eğer hata yoksa komutu gerçekleştirir
            con.Close();
            MessageBox.Show("Kayıt Tamamlandı");
            ds.Clear();
            listele1();
            listele2();
            listele3();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Veriyi Silmek Istediginizden Emin Misiniz?", "", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                con.Open();
                OleDbCommand komut2 = new OleDbCommand("DELETE FROM Tablo2 WHERE tc='" +textBox1.Text+ "'", con);
                komut2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Silme Tamamlandı");
                ds.Clear();
                listele1();
                listele2();
                listele3();


            }
            else
            {
                MessageBox.Show("Silme Islemi Iptal Edildi");
            } 
           

        }

        private void button4_Click(object sender, EventArgs e) //En yüksek krediyi 3. datagride ekler 
        {
            con.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("SELECT MAX (miktar) from Tablo3", con);
            adaptr.Fill(ds, "Tablo3");
            dataGridView3.DataSource = ds.Tables[2];
            adaptr.Dispose();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e) //tc kimlik bilgisi çekilen müşteriyi datagrid1 de banka ismini yazdırır.
        {
            con.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("SELECT Tablo1.bank_adi,Tablo2.ad,Tablo2.soyad FROM Tablo1,Tablo2 WHERE Tablo1.id=Tablo2.id AND tc='" + textBox1.Text + "'", con);
            adaptr.Fill(ds, "Tablo2");
            dataGridView1.DataSource = ds.Tables[0];
            adaptr.Dispose();
            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)//kredi tablosundaki kredilerin toplamını datagrid3 e yazdırır.
        {
            con.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter(" SELECT SUM(miktar) FROM Tablo3", con);
            adaptr.Fill(ds, "Tablo3");
            dataGridView3.DataSource = ds.Tables[2];
            adaptr.Dispose();
            con.Close();
          
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) //datagrid 2 ye müşterilerin aldığı krediyi sıralar ismiyle birlikte.
        {
            con.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("SELECT Tablo3.tip,Tablo2.tc, Tablo2.ad,Tablo2.soyad FROM Tablo2,Tablo3 WHERE Tablo3.k_id=Tablo2.k_id", con);
            adaptr.Fill(ds, "Tablo2");
            dataGridView2.DataSource = ds.Tables[1];
            adaptr.Dispose();
            con.Close();
        }


    }

}
