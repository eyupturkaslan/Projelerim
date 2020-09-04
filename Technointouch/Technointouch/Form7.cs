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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private void cart()
        {
            con = new SqlConnection("Data Source=DESKTOP-DEG2CAM\\SQLEXPRESS01;Initial Catalog=techno;Integrated Security=True");
            con.Open();
            string sql = "select count(*) from ariza_tablo where urun_adi='samsung'";
            cmd = new SqlCommand(sql, con);

            int samsung = 0, apple = 0,lg=0,xiaomi=0;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                samsung = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            string sql1 = "select count(*) from ariza_tablo where urun_adi='apple'";
            cmd = new SqlCommand(sql1, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                apple = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            string sql2 = "select count(*) from ariza_tablo where urun_adi='lg'";
            cmd = new SqlCommand(sql2, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               lg = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            string sql3 = "select count(*) from ariza_tablo where urun_adi='xiaomi'";
            cmd = new SqlCommand(sql3, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               xiaomi = Convert.ToInt32(dr[0]);
            }
            chart1.Series["marka"].Points.Clear();
            if (samsung > 0)chart1.Series["marka"].Points.AddXY("Samsung", samsung);
            if (apple > 0)chart1.Series["marka"].Points.AddXY("Apple", apple);
            if (lg > 0)chart1.Series["marka"].Points.AddXY("LG", lg);
            if (xiaomi> 0)chart1.Series["marka"].Points.AddXY("XIAOMI",xiaomi);
            con.Close();
        }
        private void cikisbtn()
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cart();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cikisbtn();
        }
    }
}
