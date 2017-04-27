using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheGame.App
{
    public partial class Form6 : Form
    {
        System.IO.StreamReader sr;
        int s = 0;
        String[] name = new String[5];
        int[] rez = new int[5];
        String hmn,hmn2,r,r2;
        public Form6()
        {
            InitializeComponent();
            timer1.Interval = 3500;
            sr = new System.IO.StreamReader("D:\\PV\\table.txt", System.Text.Encoding.GetEncoding(1251));
            label1.Text = sr.ReadLine();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = new Bitmap("D:\\PV\\"+label1.Text+".jpg");
            label6.Text = sr.ReadLine();
            name[0] = label1.Text;
            rez[0] = (int)Convert.ToDouble(label6.Text);
            label2.Text = sr.ReadLine();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = new Bitmap("D:\\PV\\" + label2.Text + ".jpg");
            label7.Text = sr.ReadLine();
            name[1] = label2.Text;
            rez[1] = (int)Convert.ToDouble(label7.Text);
            label3.Text = sr.ReadLine();
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = new Bitmap("D:\\PV\\" + label3.Text + ".jpg");
            label8.Text = sr.ReadLine();
            name[2] = label3.Text;
            rez[2] = (int)Convert.ToDouble(label8.Text);
            label4.Text = sr.ReadLine();
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = new Bitmap("D:\\PV\\" + label4.Text + ".jpg");
            label9.Text = sr.ReadLine();
            name[3] = label4.Text;
            rez[3] = (int)Convert.ToDouble(label9.Text);
            label5.Text = sr.ReadLine();
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.Image = new Bitmap("D:\\PV\\" + label5.Text + ".jpg");
            label10.Text = sr.ReadLine();
            name[4] = label5.Text;
            rez[4] = (int)Convert.ToDouble(label10.Text);
            sr.Close();
            button2.Enabled = false;
            button3.Enabled = false;
            timer1.Enabled = false;
            label11.Visible = false;
            label12.Visible = false;
            this.Text = "Table";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 f = new Form7();
            f.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i, j, hold;
            String hold2;
            s++;
            if (s == 2)
            {
                label12.Visible = true;
                //label12.Text = sr2.ReadLine();
                label12.Text = r;
                label11.Visible = true;
                //hmn = sr2.ReadLine();
                label11.Text = "Pl: " + hmn;
            }
            if (s == 4)
            {
                for (i = 0; i < 5; i++)
                {
                    if (name[i] == hmn)
                    {
                        rez[i] += (int)Convert.ToDouble(label12.Text);
                        break;
                    }
                }
                label11.Visible = false;
                label12.Visible = false;
                label6.Text = rez[0].ToString();
                label7.Text = rez[1].ToString();
                label8.Text = rez[2].ToString();
                label9.Text = rez[3].ToString();
                label10.Text = rez[4].ToString();
                //hmn = sr2.ReadLine();

            }
            if (s == 6)
            {
                if (hmn2 != "")
                {
                    label11.Visible = true;
                    label11.Text = "Auth: " + hmn2;
                    label12.Visible = true;
                    //label12.Text = sr2.ReadLine();
                    label12.Text = r2;
                }
                else
                {
                    for (i = 1; i < 5; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            if (rez[j] < rez[j + 1])
                            {
                                hold = rez[j];
                                rez[j] = rez[j + 1];
                                rez[j + 1] = hold;
                                hold2 = name[j];
                                name[j] = name[j + 1];
                                name[j + 1] = hold2;
                            }

                        }
                    }
                    label1.Text = name[0];
                    label2.Text = name[1];
                    label3.Text = name[2];
                    label4.Text = name[3];
                    label5.Text = name[4];
                    label6.Text = rez[0].ToString();
                    label7.Text = rez[1].ToString();
                    label8.Text = rez[2].ToString();
                    label9.Text = rez[3].ToString();
                    label10.Text = rez[4].ToString();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap("D:\\PV\\" + name[0] + ".jpg");
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = new Bitmap("D:\\PV\\" + name[1] + ".jpg");
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox3.Image = new Bitmap("D:\\PV\\" + name[2] + ".jpg");
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox4.Image = new Bitmap("D:\\PV\\" + name[3] + ".jpg");
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox5.Image = new Bitmap("D:\\PV\\" + name[4] + ".jpg");
                }
            }
            if (s == 8)
            {
                if (hmn2 != "")
                {
                    for (i = 0; i < 5; i++)
                    {
                        if (name[i] == hmn2)
                        {
                            rez[i] += (int)Convert.ToDouble(label12.Text);
                            break;
                        }
                    }
                    label11.Visible = false;
                    label12.Visible = false;
                    label6.Text = rez[0].ToString();
                    label7.Text = rez[1].ToString();
                    label8.Text = rez[2].ToString();
                    label9.Text = rez[3].ToString();
                    label10.Text = rez[4].ToString();
                }
            }
            if (s == 10)
            {
                if (hmn2 != "")
                {
                    for (i = 1; i < 5; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            if (rez[j] < rez[j + 1])
                            {
                                hold = rez[j];
                                rez[j] = rez[j + 1];
                                rez[j + 1] = hold;
                                hold2 = name[j];
                                name[j] = name[j + 1];
                                name[j + 1] = hold2;
                            }

                        }
                    }
                    label1.Text = name[0];
                    label2.Text = name[1];
                    label3.Text = name[2];
                    label4.Text = name[3];
                    label5.Text = name[4];
                    label6.Text = rez[0].ToString();
                    label7.Text = rez[1].ToString();
                    label8.Text = rez[2].ToString();
                    label9.Text = rez[3].ToString();
                    label10.Text = rez[4].ToString();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap("D:\\PV\\" + name[0] + ".jpg");
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = new Bitmap("D:\\PV\\" + name[1] + ".jpg");
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox3.Image = new Bitmap("D:\\PV\\" + name[2] + ".jpg");
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox4.Image = new Bitmap("D:\\PV\\" + name[3] + ".jpg");
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox5.Image = new Bitmap("D:\\PV\\" + name[4] + ".jpg");
                }
            }
            if (s == 12)
            {
                //sr.Close();
                System.IO.FileInfo fi = new System.IO.FileInfo("D:\\PV\\table.txt");
                System.IO.StreamWriter sw;
                sw = fi.CreateText();
                sw.WriteLine(label1.Text);
                sw.WriteLine(label6.Text);
                sw.WriteLine(label2.Text);
                sw.WriteLine(label7.Text);
                sw.WriteLine(label3.Text);
                sw.WriteLine(label8.Text);
                sw.WriteLine(label4.Text);
                sw.WriteLine(label9.Text);
                sw.WriteLine(label5.Text);
                sw.WriteLine(label10.Text);
                sw.Close();
                button2.Enabled = true;
                button3.Enabled = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            timer1.Enabled = true;
            sr = new System.IO.StreamReader("D:\\PV\\rez.txt", System.Text.Encoding.GetEncoding(1251));
            r = sr.ReadLine();
            hmn = sr.ReadLine();
            hmn2 = sr.ReadLine();
            r2 = sr.ReadLine();
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sr2.Close();
            Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int i, j, hold;
            String hold2;
            name[0] = label1.Text;
            name[1] = label2.Text;
            name[2] = label3.Text;
            name[3] = label4.Text;
            name[4] = label5.Text;
            rez[0] = (int)Convert.ToDouble(label6.Text);
            rez[1] = (int)Convert.ToDouble(label7.Text);
            rez[2] = (int)Convert.ToDouble(label8.Text);
            rez[3] = (int)Convert.ToDouble(label9.Text);
            rez[4] = (int)Convert.ToDouble(label10.Text);
            for (i = 1; i < 5; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (rez[j] < rez[j + 1])
                    {
                        hold = rez[j];
                        rez[j] = rez[j + 1];
                        rez[j + 1] = hold;
                        hold2 = name[j];
                        name[j] = name[j + 1];
                        name[j + 1] = hold2;
                    }

                }
            }
            label1.Text = name[0];
            label2.Text = name[1];
            label3.Text = name[2];
            label4.Text = name[3];
            label5.Text = name[4];
            label6.Text = rez[0].ToString();
            label7.Text = rez[1].ToString();
            label8.Text = rez[2].ToString();
            label9.Text = rez[3].ToString();
            label10.Text = rez[4].ToString();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = new Bitmap("D:\\PV\\" + name[0] + ".jpg");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = new Bitmap("D:\\PV\\" + name[1] + ".jpg");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = new Bitmap("D:\\PV\\" + name[2] + ".jpg");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = new Bitmap("D:\\PV\\" + name[3] + ".jpg");
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.Image = new Bitmap("D:\\PV\\" + name[4] + ".jpg");
            button3.Enabled = false;
        }
    }
}
