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
using System.IO;
namespace Eyup_Turkaslan_60180000107
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public string[] kelime_rnd = new string[14];
        string secilenk = "";
        int can = 0; 
        string resimciz = Path.GetDirectoryName(Application.ExecutablePath);
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=asma.accdb");
        int kazan = 0;
        
        int kaybet = 0;
        public void listele()
        {
            string kazanx= "", kaybetx = "";
            con.Open();
            OleDbCommand kulkontrol = new OleDbCommand("select *from kul where ad=@para",con);
            kulkontrol.Parameters.AddWithValue("@para",giris.kul_ad);
            OleDbDataReader dr = kulkontrol.ExecuteReader();
            while (dr.Read())
            {
                kazanx = dr["kazan"].ToString();
                kaybetx = dr["kaybet"].ToString();
            }
            dr.Close();
            kulkontrol.Dispose();
            con.Close();
            label6.Text = kazanx.ToString();
            label7.Text = kaybetx.ToString();
            
            kazan = Convert.ToInt32(label6.Text);
            kaybet = Convert.ToInt32(label7.Text);
        }
       
        public void gizleme()
        {
            label99.Text = "";
            for (int i = 0; i < secilenk.Length; i++)
            {
                label99.Text += "*";
            }
        }
        public void sıfırla()
        {
            kelime_random();
            Random rastgele = new Random(); 
            label1.Text = giris.kul_ad.ToString(); 
           secilenk = kelime_rnd[rastgele.Next(0, 14)];
            gizleme();
            listBox1.Items.Clear();
            can = 0;
            pictureBox1.ImageLocation = resimciz + "\\asamalar\\" + can + ".png";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label99.Text = "";
            label1.Text = giris.kul_ad.ToString();
            kelime_random();
            Random rnd= new Random();
            secilenk = kelime_rnd[rnd.Next(0,14)];
            gizleme();
            listele();
        }

        private void button99_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                MessageBox.Show("Boş girilemez Ceza aldınız");
                textBox2.Text = ".";
            }

            char harfkontrol = char.Parse(textBox2.Text);
            char[] harfKarakteri =secilenk.ToCharArray();
            bool kontrol = false;

            for (int i = 0; i <= listBox1.Items.Count - 1; i++)
            {
                if (listBox1.Items[i].ToString() == harfkontrol.ToString())
                {
                    MessageBox.Show("Daha önce kullandınız");
                    textBox2.Text = "";
                    return;
                }
            }

            listBox1.Items.Add(harfkontrol.ToString());

            for (int i = 0; i < harfKarakteri.Length; i++)
            {
                if (harfKarakteri[i] == harfkontrol)
                {
                    label99.Text = label99.Text.Remove(i, 1);
                    label99.Text = label99.Text.Insert(i,harfkontrol.ToString());
                   kontrol = true;
                }
            }

            if (label99.Text == secilenk)
            {
                kazan = kazan + 1;
                label6.Text = kazan.ToString();
                label99.Text = secilenk;
                label99.Text = secilenk;
                MessageBox.Show("Doğru");
                con.Open();
                OleDbCommand guncel = new OleDbCommand();
                guncel.Connection = con;
                guncel.CommandText = "update kul set ad='" + label1.Text + "',kazan='" + label6.Text + "',kaybet='" + label7.Text + "' where ad='" + label1.Text + "'";
                guncel.ExecuteNonQuery();
                con.Close();
                return;
            }

            textBox2.Text = "";
            if (kontrol == false)
            {
                can++;
                pictureBox1.ImageLocation = resimciz + "\\asamalar\\" + can + ".png";
            }

            if (can == 10)
            {
                kaybet=kaybet+1;
                label7.Text = kaybet.ToString();
                con.Open();
                OleDbCommand guncel = new OleDbCommand();
                guncel.Connection = con;
                guncel.CommandText = "update kul set ad='" + label1.Text + "',kazan='" + label6.Text + "',kaybet='" + label7.Text + "' where ad='" + label1.Text + "'";
                guncel.ExecuteNonQuery();
                con.Close();
               
                DialogResult kaybetmeMesaji = new DialogResult();// can bıtınce olacaklar
                kaybetmeMesaji = MessageBox.Show("Kaybettiniz Devam veya çıkış ?", "Bilgi ekranı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kaybetmeMesaji == DialogResult.Yes)
                {
                    sıfırla();
                }
                else
                {
                    Application.Exit();
                }
                return;
            }
        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "B";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "A";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "C";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Ç";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "D";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "E";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "F";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "G";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = "H";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = "I";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = "İ";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Ğ";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox2.Text = "J";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text = "K";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = "L";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text = "M";
        }
        public void kelime_random()
        {
            kelime_rnd[0] = "ARNOLD";
            kelime_rnd[1] = "TOP";
            kelime_rnd[2] = "BİSİKLET";
            kelime_rnd[3] = "BİLGİSAYAR";
            kelime_rnd[4] = "FARE";
            kelime_rnd[5] = "MOTOR";
            kelime_rnd[6] = "KOL";
            kelime_rnd[7] = "KLAVYE";
            kelime_rnd[8] = "MÜHENDİS";
            kelime_rnd[9] = "ŞARKICI";
            kelime_rnd[10] = "TİYATRO";
            kelime_rnd[11] = "RESİM";
            kelime_rnd[12] = "YAZICI";
            kelime_rnd[13] = "LAPTOP";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            textBox2.Text = "N";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox2.Text = "O";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Ö";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text = "P";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox2.Text = "R";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox2.Text = "S";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Ş";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox2.Text = "T";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox2.Text = "U";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Ü";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox2.Text = "V";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Y";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Z";
        }
        public void tahmin_tut()
        {
            if (textBox1.Text == secilenk)
            {
                MessageBox.Show("Tahmin doğru.");
                
                label99.Text = secilenk;
                kazan++;
                label6.Text = kazan.ToString();

                con.Open();
                OleDbCommand guncel = new OleDbCommand();
                guncel.Connection = con;
                guncel.CommandText = "update kul set ad='" + label1.Text + "',kazan='" + label6.Text + "',kaybet='" + label7.Text + "' where ad='" + label1.Text + "'";
                guncel.ExecuteNonQuery();
                con.Close();
                listele();
            }
            else
            {
                kaybet++;
                label7.Text = kaybet.ToString();
                con.Open();
                OleDbCommand guncel = new OleDbCommand();
                guncel.Connection = con;
                guncel.CommandText = "update kul set ad='" + label1.Text + "',kazan='" + label6.Text + "',kaybet='" + label7.Text + "' where ad='" + label1.Text + "'";
                guncel.ExecuteNonQuery();
                con.Close();
                listele();
                MessageBox.Show("Tahmin yanlış.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void button30_Click(object sender, EventArgs e)
        {
            tahmin_tut();
        }
       
    }
}
