using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form4 : Form
    {
        int[] num = new int[10];
        int k,s=0,choise=0,stopstep=-1,winpl=0,wina=0,rez,contin=0/*see continue*/,rndN;
        System.IO.StreamReader sr;
        String curauth;


        public Form4()
        {
            InitializeComponent();
            Random rnd;
            int i = 0, j, nextnum, tmp;
            double rndD;
            rnd = new Random();
            timer1.Interval=500;
            sr = new System.IO.StreamReader("D:\\PV\\rez.txt", System.Text.Encoding.GetEncoding(1251));
            rez = (int)Convert.ToDouble(sr.ReadLine());
            curauth = sr.ReadLine();
            label2.Text = sr.ReadLine();
            label3.Text = rez.ToString();
            sr.Close();
            while (i < 10)
            {
                rndD = rnd.NextDouble();
                nextnum = (int)Math.Ceiling(rndD * rez);
                if (nextnum > 10)
                {
                    num[i] = nextnum;
                    i++;
                }
            }
            for (i = 1; i < 10; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    if (num[j] > num[j + 1])
                    {
                        tmp = num[j];
                        num[j] = num[j + 1];
                        num[j + 1] = tmp;
                    }
                }
            }
            timer1.Enabled = false;
            button3.Enabled = false;
            rndN = rnd.Next(3);
            button2.Enabled = false;
            button4.Enabled = false;
            //label3.Text = rndN.ToString();
            this.Text = "GNG";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s < 4)
            {
                s++;
                label1.Text = num[k].ToString();
                if (k==stopstep)
                {
                    label1.Text = "gng!";
                    label1.BackColor = System.Drawing.Color.Red;
                    timer1.Enabled = false;
                    button2.Enabled = false;
                    button4.Enabled = true;
                    if (contin==0)
                        wina = rez;
                }
                else
                {
                    if (k == 9)
                    {
                        timer1.Enabled = false;
                        button2.Enabled = false;
                        button4.Enabled = true;
                        if(contin==0)
                            winpl = rez;
                    }
                }
                
                //label2.Text = s.ToString();
            }
            else
            {
                s = 0;
                k++;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo("D:\\PV\\rez.txt");
            System.IO.StreamWriter sw;
            sw = fi.CreateText();
            sw.WriteLine(winpl.ToString());
            sw.WriteLine(curauth);
            sw.WriteLine(label2.Text);
            sw.WriteLine(wina.ToString());
            sw.Close();
            Hide();
            Form5 f = new Form5();
            f.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd;
            rnd = new Random();
            //button1.Enabled = false;
            if (radioButton1.Checked)
            {
                choise = 0;
                button1.Enabled = true;
            }
            if (radioButton2.Checked)
            {
                choise = 1;
                button1.Enabled = true;
            }
            if (radioButton3.Checked)
            {
                choise = 2;
                button1.Enabled = true;
            }
            if (choise == rndN)
                num[9] = rez;
            else
                stopstep = 3 + rnd.Next(7);
            k = 0;
            label1.Visible = true;
            label1.Text = num[k].ToString();
            timer1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            winpl = (int)Convert.ToDouble(label1.Text);
            wina = rez - winpl;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            contin = 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
