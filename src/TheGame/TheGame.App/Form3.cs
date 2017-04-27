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
    public partial class Form3 : Form
    {
        System.IO.StreamReader sr;
        public Form3()
        {
            int m,s,nz;
            InitializeComponent();
            sr = new System.IO.StreamReader("D:\\PV\\sost.txt", System.Text.Encoding.GetEncoding(1251));
            m=(int)Convert.ToDouble(sr.ReadLine());
            s=(int)Convert.ToDouble(sr.ReadLine());
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = new Bitmap("D:\\PV\\zam.jpg");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = new Bitmap("D:\\PV\\zam.jpg");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = new Bitmap("D:\\PV\\zam.jpg");
            if (s>=10)
                label1.Text = "0" + m.ToString() + ":" + s.ToString();
            else
                label1.Text = "0" + m.ToString() + ":" + "0"+s.ToString();
            sr.ReadLine();
            sr.ReadLine();
            nz = (int)Convert.ToDouble(sr.ReadLine());
            if (nz < 3)
                pictureBox3.Visible = false;
            if (nz < 2)
                pictureBox2.Visible = false;
            if (nz < 1)
                pictureBox1.Visible = false;
            sr.Close();
            sr = new System.IO.StreamReader("D:\\PV\\rez.txt", System.Text.Encoding.GetEncoding(1251));
            label2.Text = sr.ReadLine();
            sr.Close();
            this.Text = "Prom";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 f = new Form2();
            f.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 f = new Form5();
            f.ShowDialog();
            this.Close();
        }
    }
}
