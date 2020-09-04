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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmdb;
        public void arizlistele()
        {
            con = new SqlConnection("Data Source=DESKTOP-DEG2CAM\\SQLEXPRESS01;Initial Catalog=techno;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("Select *From ariza_tablo", con);
            cmdb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "ariza_tablo");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public void guncelle()
        {
         
            da.Update(ds, "ariza_tablo");
            MessageBox.Show("Kayıt güncellendi");
        }
        private void cikis()
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
        public void silme()
        {
            DialogResult dialog = MessageBox.Show("Veriyi Silmek Istediginizden Emin Misiniz?", "", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                con.Open();
                string sql = "DELETE FROM ariza_tablo WHERE a_id=@p1";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@p1", Convert.ToInt32(textBox2.Text));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Silme Islemi Iptal Edildi");
            }
        }
        private void guncelletex()
        {
            da = new SqlDataAdapter("Select *from ariza_tablo where a_id like '" + textBox1.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "mus_ariza");
            dataGridView1.DataSource = ds.Tables["mus_ariza"];
            con.Close();
        }
        private void cikisfonk()
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
        private void button2_Click(object sender, EventArgs e)
        {
            arizlistele();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            guncelle();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            cikis();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            cikisfonk();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            silme();
            arizlistele();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            guncelletex();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            arizlistele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Close();
        }
    }
}
