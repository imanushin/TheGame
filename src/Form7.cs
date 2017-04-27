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
    
    public partial class Form7 : Form
    {
        System.IO.StreamReader sr;
        System.IO.StreamReader sr2;
        String[] ques = new String[125];
        int i = 0,s=0,j;
        int[] rez = new int[5];
        public Form7()
        {
            InitializeComponent();
            sr = new System.IO.StreamReader("D:\\PV\\pq.txt", System.Text.Encoding.GetEncoding(1251));
            sr2 = new System.IO.StreamReader("D:\\PV\\pa.txt", System.Text.Encoding.GetEncoding(1251));
            while(!sr.EndOfStream)
            {
                ques[i] = sr.ReadLine();
                i++;
            }
            sr.Close();
            sr = new System.IO.StreamReader("D:\\PV\\pq.txt", System.Text.Encoding.GetEncoding(1251));
            label1.Text = "";
            this.Text = "Vspec";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (s==0)
            {
                label1.Text = "Auth:"+sr2.ReadLine();
                s = 1;
            }
            else
            {
                label1.Text = sr.ReadLine();
                j++;
                if (j > i)
                    button1.Enabled = false;
                s = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int npl;
            sr.Close();
            sr2.Close();
            sr = new System.IO.StreamReader("D:\\PV\\table.txt", System.Text.Encoding.GetEncoding(1251));
            for (i = 0; i < 5;i++)
            {
                npl = (int)Convert.ToDouble(sr.ReadLine());
                npl--;
                rez[npl] += (int)Convert.ToDouble(sr.ReadLine());
            }
            sr.Close();
            System.IO.FileInfo fi = new System.IO.FileInfo("D:\\PV\\table.txt");
            System.IO.StreamWriter sw;
            sw = fi.CreateText();
            for (i=0;i<5;i++)
            {
                npl = i+1;
                sw.WriteLine(npl.ToString());
                sw.WriteLine(rez[i].ToString());
            }
            sw.Close();
            System.IO.FileInfo fi2 = new System.IO.FileInfo("D:\\PV\\pa.txt");
            sw = fi2.CreateText();
            sw.Close();
            System.IO.FileInfo fi3 = new System.IO.FileInfo("D:\\PV\\pq.txt");
            sw = fi3.CreateText();
            sw.Close();
            Hide();
            Form6 f = new Form6();
            f.ShowDialog();
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            rez[0] += 100;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            rez[3] += 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rez[0] += 200;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rez[1] += 200;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            rez[1] += 100;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            rez[2] += 200;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            rez[2] += 100;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            rez[3] += 200;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            rez[4] += 200;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            rez[4] += 100;
        }
    }
}
