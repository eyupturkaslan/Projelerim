using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kimlik
{
    public partial class Form1 : Form
    {
        UInt64 a;
       // UInt64 b1, b2, b3,b4,b5;
        UInt64 carp;
        UInt64[] dizi = new UInt64[12];
        UInt64 x;
        UInt64 kontrol=0;
        UInt64 kontrol2=0;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           // a = Convert.ToUInt64(textBox1.Text);
         //   b1 = a/1 % 10;
           

         //   listBox1.Items.Add(b1);
        //    test = a / 10;
        //    b2 = test % 10;

          //e b2=(a/10)%10;
          //  listBox1.Items.Add(b2);

          //   b3=(a/100)%10;
            //listBox1.Items.Add(b3);

            //b4 = (a / 1000) % 10;
           // listBox1.Items.Add(b4);


           // b5 = (a / 10000) % 10;
           // listBox1.Items.Add(b5);

           // label1.Text = a.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            a = Convert.ToUInt64(textBox1.Text);
            carp = 1;
            for (int i = 11; i >= 1; i--)
            {
               dizi[i] = (a / carp )% 10;
                listBox1.Items.Add(dizi[i]);
                carp = carp * 10;
            }
         kontrol = (dizi[1] + dizi[3] + dizi[5] + dizi[7] + dizi[9]) * 7 - (dizi[2] + dizi[4] + dizi[6] + dizi[8]);
         kontrol = kontrol % 10;
     kontrol2 = (dizi[1] + dizi[2] + dizi[3] + dizi[4] + dizi[5] + dizi[6] + dizi[7] + dizi[8] + dizi[9] + dizi[10]);
     kontrol2 = kontrol2 % 10;
            label2.Text = kontrol.ToString();
            label1.Text = kontrol2.ToString();

            if (kontrol==dizi[10] && kontrol2==dizi[11])
            {
                MessageBox.Show("doğru");
            }
            else
            {
                MessageBox.Show("yannis");
            }

        //    for (int i = 1; i < 10; i += 2)
           // {
            //    x = x + dizi[i];
           //     label1.Text = x.ToString();
          //  }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            for (int i = 1; i < 10; i += 2)
            {
                x = x + dizi[i];
                label1.Text = x.ToString();
            }
        }

    }
}
