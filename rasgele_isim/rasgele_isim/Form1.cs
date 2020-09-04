using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rasgele_isim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int art = 0;
        string[] soyad = new string[] { "ay", "kütük", "polat", "güngör", "özer", "çakır", "kaya", "ışık" };
        string[] yarismaci = new string [] {"talha","samet","polat","muhammed","selma","sema","ugur","halit","aykut"};
        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < yarismaci.Length; i++)
            {
                listBox1.Items.Add(yarismaci[i]);
            }
            int kazanan;
            kazanan = rnd.Next(0,yarismaci.Length);
            MessageBox.Show("Kazanan isim "+yarismaci[kazanan]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                dataGridView1.Rows.Add();

                int kazanan, soy;


                kazanan = rnd.Next(0, yarismaci.Length);
                soy = rnd.Next(0, soyad.Length);
                dataGridView1.Rows[i].Cells[0].Value = yarismaci[kazanan];
                dataGridView1.Rows[i].Cells[1].Value = soyad[soy];
                dataGridView1.Rows[i].Cells[2].Value = rnd.Next(1, 100);
                art = art + 1;
            }
           

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
