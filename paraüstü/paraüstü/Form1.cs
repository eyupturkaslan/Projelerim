using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paraüstü
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int a;
        int sayac;
        int sayac2=0;
        int[] dizi=new int[]{1,5,10,20,50,100,200};

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            a = Convert.ToInt32(textBox1.Text);
            for (int i = 6; i >= 0; i--)
            {
                sayac = 0;
                while (a >= dizi[i])
                {
                    a = a - dizi[i];
                    sayac++;
                    dataGridView1.Rows[sayac2].Cells[i].Value = sayac;
                }
            }
            sayac2++;
            }
        }
    }

