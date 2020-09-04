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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        public void muslistele()
        {
            ds.Clear();
            dataGridView1.Refresh();
            con = new SqlConnection("Data Source=DESKTOP-DEG2CAM\\SQLEXPRESS01;Initial Catalog=techno;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("Select *From mus_tablo", con);
            ds = new DataSet();
            da.Fill(ds, "mus_tablo");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public void arizlistele()
        {
            ds.Clear();
            dataGridView1.Refresh();
            con = new SqlConnection("Data Source=DESKTOP-DEG2CAM\\SQLEXPRESS01;Initial Catalog=techno;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("Select *From ariza_tablo", con);
            ds = new DataSet();
            da.Fill(ds, "ariza_tablo");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void detay()
        {
            ds.Clear();
            dataGridView1.Refresh();
            con.Open();
            da = new SqlDataAdapter("Select mus_adi,mus_soyadi,mus_tel,a_adi,urun_adi,gelis,cikis,aciklama,fiyat,mus_tablo.mus_id as Musteri_No From mus_tablo inner join ariza_tablo on ariza_tablo.a_id=mus_tablo.mus_ano", con);
            ds = new DataSet();
            da.Fill(ds, "mus_tablo");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void cikisbtn()
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
        private void kapatma()
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
            muslistele();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            arizlistele();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            detay();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-DEG2CAM\\SQLEXPRESS01;Initial Catalog=techno;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("Select *From mus_tablo", con);
            ds = new DataSet();
            da.Fill(ds, "mus_tablo");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            cikisbtn();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            kapatma();
        }
    }
}