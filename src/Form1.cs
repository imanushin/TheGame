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
    public partial class Form1 : Form
    {
        System.IO.StreamReader sr;
        System.IO.StreamReader sr2;
        String[] quest = new String[125];
        String[] auth = new String[125];
        String[] curauth = new String[25];
        public Form1()
        {
            InitializeComponent();
            button1.Visible = false;
            this.Text = "Sort";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0, i2 = 0, j = 0, k;
            String newauth, newq, tmp;
            Random rnd;
            rnd = new Random();
            sr = new System.IO.StreamReader("D:\\PV\\q.txt", System.Text.Encoding.GetEncoding(1251));
            sr2 = new System.IO.StreamReader("D:\\PV\\a.txt", System.Text.Encoding.GetEncoding(1251));
            while (!sr2.EndOfStream)
            {
                newauth = sr2.ReadLine();
                newq = sr.ReadLine();
                if (newauth == comboBox1.SelectedItem.ToString())
                {
                    curauth[i2] = newq;
                    i2++;
                }
                else
                {
                    auth[i] = newauth;
                    quest[i] = newq;
                    i++;
                }
            }
            sr.Close();
            sr2.Close();
            for (j = 0; j < i; j++)
            {
                k = rnd.Next(i);
                tmp = auth[k];
                auth[k] = auth[j];
                auth[j] = tmp;
                tmp = quest[k];
                quest[k] = quest[j];
                quest[j] = tmp;
            }
            System.IO.FileInfo fi = new System.IO.FileInfo("D:\\PV\\q.txt");
            System.IO.FileInfo fi2 = new System.IO.FileInfo("D:\\PV\\a.txt");
            System.IO.StreamWriter sw;
            System.IO.StreamWriter sw2;
            sw = fi.CreateText();
            sw2 = fi2.CreateText();
            for (j = 0; j < i; j++)
            {
                sw.WriteLine(quest[j]);
                sw2.WriteLine(auth[j]);
            }
            sw.Close();
            sw2.Close();
            System.IO.FileInfo fi3 = new System.IO.FileInfo("D:\\PV\\q1.txt");
            sw = fi3.CreateText();
            sw.WriteLine(comboBox1.SelectedItem.ToString());
            for (j = 0; j < i2; j++)
                sw.WriteLine(curauth[j]);
            sw.Close();
            System.IO.FileInfo fi4 = new System.IO.FileInfo("D:\\PV\\sost.txt");
            sw = fi4.CreateText();
            sw.WriteLine("4");
            sw.WriteLine("0");
            sw.WriteLine("4");
            sw.WriteLine(comboBox1.SelectedItem.ToString());
            sw.WriteLine("3");
            sw.WriteLine("1");
            sw.Close();
            System.IO.FileInfo fi5 = new System.IO.FileInfo("D:\\PV\\rez.txt");
            sw = fi5.CreateText();
            sw.WriteLine("0");
            sw.WriteLine(comboBox1.SelectedItem.ToString());
            sw.Close();
            Hide();
            Form2 f = new Form2();
            f.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 f = new Form7();
            f.ShowDialog();
            this.Close();
        }

        

    }
}
