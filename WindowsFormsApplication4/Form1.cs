using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] soru;
        int tahmin;
        int[] ttahmin = new int[4];
        int i, j, index = 1;
        int yerinde = 0, ydat = 0;
        int tahmintut;
        int arti = 0, eksi = 0;
        private void sayitut()
        {
            i=0;
            soru = new int[4];
            Random rnd = new Random();

            //tahmin edilicek sayı 
            while ( i < 4)
            {
                soru[i] = rnd.Next(0, 10);

                if (i == 0 && soru[0] == 0)
                    continue;
                if (i == 1 && soru[1] == soru[0])
                    continue;
                if(i == 2 && (soru[2] == soru[1] || soru[2] == soru[0]))
                    continue;
                if (i == 3 && (soru[3] == soru[2] || soru[3] == soru[1] || soru[3] == soru[0])) 
                    continue;
                i++;
            }
     
        }
    
        private void oyun()
        {
            do
            {
                tahmin = (int)numericUpDown1.Value;
                if (10000 < tahmin || tahmin < 1000)
                {
                    MessageBox.Show("Bu Deger Limitlerin Disinda ..");
                    return;
                }
            }
            while (tahmin > 10000 || tahmin < 1000);

            tahmintut = tahmin;
            //tahmin sayısını diziye atadık
            ttahmin[0] = tahmin / 1000;
            tahmin = tahmin % 1000;
            // MessageBox.Show(" "+ ttahmin[0]+"    "+ tahmin);
            ttahmin[1] = tahmin / 100;
            tahmin = tahmin % 100;
            // MessageBox.Show(" "+ ttahmin[1]+"    "+ tahmin);
            ttahmin[2] = tahmin / 10;
            tahmin = tahmin % 10;
            //  MessageBox.Show(" " + ttahmin[2] + "    " + tahmin);
            ttahmin[3] = tahmin;
            // MessageBox.Show(" " + ttahmin[3] + "    " + tahmin);

            textBox1.Text = Convert.ToString(ttahmin[0]);
            textBox2.Text = Convert.ToString(ttahmin[1]);
            textBox3.Text = Convert.ToString(ttahmin[2]);
            textBox4.Text = Convert.ToString(ttahmin[3]);



            if (ttahmin[1] == ttahmin[0])
            {
                MessageBox.Show("Girdiginiz sayida hata var. yeniden deneyin..");
                return;
            }
            if (ttahmin[2] == ttahmin[1] || ttahmin[2] == ttahmin[0])
            {
                MessageBox.Show("Girdiginiz sayida hata var. yeniden deneyin..");
                return;
            }
            if (ttahmin[3] == ttahmin[2] || ttahmin[3] == ttahmin[1] || ttahmin[3] == ttahmin[0])
            {
                MessageBox.Show("Girdiginiz sayida hata var. yeniden deneyin..");
                return;
            }

            if (ttahmin[0] == soru[0])
                label3.BackColor = Color.Green;
            if (ttahmin[1] == soru[1])
                label4.BackColor = Color.Green;
            if (ttahmin[2] == soru[2])
                label5.BackColor = Color.Green;
            if (ttahmin[3] == soru[3])
                label6.BackColor = Color.Green;

            if (ttahmin[0] == soru[1] || ttahmin[0] == soru[2] || ttahmin[0] == soru[3])
                label3.BackColor = Color.Blue;
            if (ttahmin[1] == soru[0] || ttahmin[1] == soru[2] || ttahmin[1] == soru[3])
                label4.BackColor = Color.Blue;
            if (ttahmin[2] == soru[1] || ttahmin[2] == soru[0] || ttahmin[2] == soru[3])
                label5.BackColor = Color.Blue;
            if (ttahmin[3] == soru[1] || ttahmin[3] == soru[2] || ttahmin[3] == soru[0])
                label6.BackColor = Color.Blue;

            if (ttahmin[0] != soru[1] && ttahmin[0] != soru[2] && ttahmin[0] != soru[3] && ttahmin[0] != soru[0])
                label3.BackColor = Color.Yellow;
            if (ttahmin[1] != soru[0] && ttahmin[1] != soru[2] && ttahmin[1] != soru[3] && ttahmin[1] != soru[1])
                label4.BackColor = Color.Yellow;
            if (ttahmin[2] != soru[1] && ttahmin[2] != soru[0] && ttahmin[2] != soru[3] && ttahmin[2] != soru[2])
                label5.BackColor = Color.Yellow;
            if (ttahmin[3] != soru[1] && ttahmin[3] != soru[2] && ttahmin[3] != soru[0] && ttahmin[3] != soru[3])
                label6.BackColor = Color.Yellow;


            for (j = 0; j < 4; j++)
            {

                if (ttahmin[j] == soru[0] || ttahmin[j] == soru[1] || ttahmin[j] == soru[2] || ttahmin[j] == soru[3])
                {

                    if (soru[j] != ttahmin[j])
                    {
                        ydat += 1;
                        //	printf("\n%d",i); which one
                    }
                    if (ttahmin[j] == soru[j])
                    {
                        yerinde += 1;
                        //	printf("\t%d\n",i); which one
                    }
                    eksi += ydat;
                    arti += yerinde;
                }
            }
            listBox1.Items.Add(index++ + ") " + tahmintut + "\t       " + " - " + ydat + "  " + " + " + yerinde);
            if (yerinde == 4)
            {
                MessageBox.Show("tebrikler kazandın");
                index = 0;
                listBox1.Items.Clear();
                numericUpDown1.Value = 0;
                textBox1.Clear();   textBox2.Clear();   textBox3.Clear();   textBox4.Clear();
                label3.BackColor = Color.Yellow;    label4.BackColor = Color.Yellow;
                label5.BackColor = Color.Yellow;    label6.BackColor = Color.Yellow;
                button2.Enabled = false;    numericUpDown1.Enabled = false;
            }
            ydat = 0;
            yerinde = 0;
            //hakları saydır
            if (index > 11)
            {
                index = 0;
                listBox1.Items.Clear();
                numericUpDown1.Value = 0;
                MessageBox.Show("hakların bitti...");
                textBox1.Clear();   textBox2.Clear();   textBox3.Clear();   textBox4.Clear();
                label3.BackColor = Color.Yellow;    label4.BackColor = Color.Yellow;
                label5.BackColor = Color.Yellow;    label6.BackColor = Color.Yellow;
                button2.Enabled = false;    numericUpDown1.Enabled = false;
            }
        }
private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            numericUpDown1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            oyun();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayitut();
            button2.Enabled = true;
            numericUpDown1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oyun();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
