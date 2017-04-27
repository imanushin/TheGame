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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            System.IO.StreamReader sr;
            System.IO.StreamReader sr2;
            String auth;
            int numg;
            sr = new System.IO.StreamReader("D:\\PV\\q1.txt", System.Text.Encoding.GetEncoding(1251));
            System.IO.FileInfo fi = new System.IO.FileInfo("D:\\PV\\q.txt");
            System.IO.FileInfo fi2 = new System.IO.FileInfo("D:\\PV\\a.txt");
            System.IO.StreamWriter sw;
            System.IO.StreamWriter sw2;
            sw = fi.AppendText();
            sw2 = fi2.AppendText();
            auth = sr.ReadLine();
            while(!sr.EndOfStream)
            {
                sw.WriteLine(sr.ReadLine());
                sw2.WriteLine(auth);
            }
            sr.Close();
            sw.Close();
            sw2.Close();
            sr = new System.IO.StreamReader("D:\\PV\\basesost.txt", System.Text.Encoding.GetEncoding(1251));
            numg = (int)Convert.ToDouble(sr.ReadLine());
            sr.Close();
            numg++;
            System.IO.FileInfo fi3 = new System.IO.FileInfo("D:\\PV\\base"+numg.ToString()+".txt");
            System.IO.FileInfo fi4 = new System.IO.FileInfo("D:\\PV\\abase" + numg.ToString() + ".txt");
            sw = fi3.CreateText();
            sw2 = fi4.CreateText();
            sr = new System.IO.StreamReader("D:\\PV\\q.txt", System.Text.Encoding.GetEncoding(1251));
            sr2 = new System.IO.StreamReader("D:\\PV\\a.txt", System.Text.Encoding.GetEncoding(1251));
            while(!sr.EndOfStream)
            {
                sw.WriteLine(sr.ReadLine());
                sw2.WriteLine(sr2.ReadLine());
            }
            sr.Close();
            sr2.Close();
            sw.Close();
            sw2.Close();
            System.IO.FileInfo fi5 = new System.IO.FileInfo("D:\\PV\\gamerec.txt");
            sw = fi5.AppendText();
            sr = new System.IO.StreamReader("D:\\PV\\rez.txt", System.Text.Encoding.GetEncoding(1251));
            sw.WriteLine(numg.ToString());
            label2.Text = sr.ReadLine();
            sw.WriteLine(label2.Text);
            label1.Text = sr.ReadLine();
            sw.WriteLine(label1.Text);
            auth = sr.ReadLine();
            if(auth!="")
            {
                sw.WriteLine(sr.ReadLine());
                sw.WriteLine(sr.ReadLine());
            }
            sw.WriteLine("");
            sr.Close();
            sw.Close();
            System.IO.FileInfo fi6 = new System.IO.FileInfo("D:\\PV\\basesost.txt");
            sw = fi6.CreateText();
            sw.WriteLine(numg.ToString());
            sw.Close();
            this.Text = "Rez";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 f = new Form6();
            f.ShowDialog();
            this.Close();
        }
    }
}
