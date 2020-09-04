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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        private void ekle()
        {
            con = new SqlConnection("Data Source=DESKTOP-DEG2CAM\\SQLEXPRESS01;Initial Catalog=techno;Integrated Security=True");
            con.Open();
            string sql = "insert into ariza_tablo (a_id,a_adi,urun_adi,seri_no,mus_no,aciklama,parca,gelis,cikis,fiyat) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10) ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", Convert.ToInt32(textBox5.Text));
            cmd.Parameters.AddWithValue("@p6", textBox6.Text);
            cmd.Parameters.AddWithValue("@p7", textBox7.Text);
            cmd.Parameters.AddWithValue("@p8",dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@p9", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@p10", Convert.ToInt32(textBox8.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("işlem başarılı");
            con.Close();
            form5edon();
        }
        private void eklesorgu()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("İd boş bırakılamaz");
                Form5 f5 = new Form5();
                f5.Show();
                this.Close();
            }
            else
            {
                ekle();
            }
        }
        private void form5edon()
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            eklesorgu();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            form5edon();
        }
    }
}
