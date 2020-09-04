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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmdb;
        public void muslistele()
        {
            con = new SqlConnection("Data Source=DESKTOP-DEG2CAM\\SQLEXPRESS01;Initial Catalog=techno;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("Select *From mus_tablo", con);
            cmdb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "mus_tablo");
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }
        public void guncelle()
        {
            da.Update(ds, "mus_tablo");
            MessageBox.Show("Kayıt güncellendi");
            muslistele();
        }
        private void guncelletex()
        {
            con.Open();
            da = new SqlDataAdapter("Select *from mus_tablo where mus_adi like '" + textBox1.Text + "%'", con);
            ds = new DataSet();
            da.Fill(ds, "mus_tablo");
            dataGridView2.DataSource = ds.Tables["mus_tablo"];
            con.Close();
        }
      public void silme()
        {
            DialogResult dialog = MessageBox.Show("Veriyi Silmek Istediginizden Emin Misiniz?", "", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                con.Open();
                string sql = "DELETE FROM mus_tablo WHERE mus_id=@p1";
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
      private void detay()
      {
          ds.Clear();
          dataGridView2.Refresh();
          con.Open();
          da = new SqlDataAdapter("Select mus_adi,mus_soyadi,mus_tel,a_adi,urun_adi,gelis,cikis,aciklama,fiyat,mus_tablo.mus_id as Musteri_No From mus_tablo inner join ariza_tablo on ariza_tablo.a_id=mus_tablo.mus_ano", con);
          cmdb = new SqlCommandBuilder(da);
          ds = new DataSet();
          da.Fill(ds, "mus_tablo");
          dataGridView2.DataSource = ds.Tables[0];
          con.Close();
      }
      private void cikisbtn()
      {
          Form1 f1 = new Form1();
          f1.Show();
          this.Close();
      }
      private void anasayfa()
      {
          Form2 f2 = new Form2();
          f2.Show();
          this.Close();
      }
      private void eklemesf()
      {
          Form4 f4 = new Form4();
          f4.Show();
          this.Close();
      }
        private void Form3_Load(object sender, EventArgs e)
        {
            muslistele();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            muslistele();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            guncelle();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            guncelletex();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            silme();
            muslistele();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            cikisbtn();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            kapatma();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            eklemesf();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            anasayfa();
        }    
        private void button9_Click(object sender, EventArgs e)
        {
            detay();
        }        
        }
    }