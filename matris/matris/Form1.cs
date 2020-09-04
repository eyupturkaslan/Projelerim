using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matris
{
    public partial class Form1 : Form
    {
        int[,] matris = new int[3, 3];
        int[,] matris2 = new int[3, 3];
        int[,] matris3= new int[3, 3];
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {   
                for (int a = 0; a < 3; a++)
                {
                    matris[i, a] = rnd.Next(1,100);
                    matris2[i, a] = rnd.Next(1,100);
                    matris3[i, a] = 0;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    matris3[i, j] += matris[i, j] * matris2[i, j];
                   
                }
            }
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView2.Rows.Add();
                dataGridView3.Rows.Add();
                for (int a = 0; a < 3; a++)
                {
                    dataGridView1.Rows[i].Cells[a].Value = matris[i, a];
                    dataGridView2.Rows[i].Cells[a].Value = matris2[i, a];
                    dataGridView3.Rows[i].Cells[a].Value = matris3[i, a];               
                }
            }
        }
    }
}
