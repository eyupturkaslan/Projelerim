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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        SqlConnection con;
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty)
            {
                MessageBox.Show("İd boş bırakılamaz");
                Form3 f3 = new Form3();
                f3.Show();
                this.Close();
            }
            else
            {
                ekle();
            }
        }
        private void ekle()
        {
            con = new SqlConnection("Data Source=DESKTOP-DEG2CAM\\SQLEXPRESS01;Initial Catalog=techno;Integrated Security=True");
            con.Open();
            string sql = "insert into mus_tablo (mus_id,mus_adi,mus_soyadi,email,mus_ano,mus_aciklama,mus_tel)values (@p1,@p2,@p3,@p4,@p5,@p6,@p7) ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", Convert.ToInt32(textBox5.Text));
            cmd.Parameters.AddWithValue("@p6", textBox6.Text);
            cmd.Parameters.AddWithValue("@p7", textBox7.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("işlem başarılı");
            con.Close();
            form3edon();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            form3edon();
        }
        private void form3edon()
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }
    }
}