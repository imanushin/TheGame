using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheGame.App
{
    public partial class Form2 : Form
    {
        System.IO.StreamReader sr;
        System.IO.StreamReader sr2;
        System.IO.StreamReader sr3;
        System.IO.StreamReader sr4;
        String auth, quest,curauth;
        String[] questm = new String[125];
        String[] authm = new String[125];
        String[] zamen = new String[6];
        int np, nz, nt, m, s,nca=0/*right answers*/,usezam=0,usepass=0;
        public Form2()
        {
            InitializeComponent();
            sr = new System.IO.StreamReader("D:\\PV\\sost.txt", System.Text.Encoding.GetEncoding(1251));
            sr3 = new System.IO.StreamReader("D:\\PV\\q.txt", System.Text.Encoding.GetEncoding(1251));
            sr4 = new System.IO.StreamReader("D:\\PV\\a.txt", System.Text.Encoding.GetEncoding(1251));
            timer1.Interval = 500;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = new Bitmap("D:\\PV\\empty.jpg");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = new Bitmap("D:\\PV\\empty.jpg");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = new Bitmap("D:\\PV\\empty.jpg");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = new Bitmap("D:\\PV\\empty.jpg");
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.Image = new Bitmap("D:\\PV\\empty.jpg");
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.Image = new Bitmap("D:\\PV\\zam.jpg");
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.Image = new Bitmap("D:\\PV\\zam.jpg");
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.Image = new Bitmap("D:\\PV\\zam.jpg");
            m = (int)Convert.ToDouble(sr.ReadLine());
            s = (int)Convert.ToDouble(sr.ReadLine());
            label2.Text = "0"+m.ToString();
            label3.Visible = true;
            timer1.Enabled = false;
            if (s>=10)
                label4.Text = s.ToString();
            else
                label4.Text = "0" + s.ToString();
            np = (int)Convert.ToDouble(sr.ReadLine());
            curauth = sr.ReadLine();
            nz = (int)Convert.ToDouble(sr.ReadLine());
            nt = (int)Convert.ToDouble(sr.ReadLine());
            if (nz < 3)
                pictureBox8.Visible = false;
            if (nz < 2)
                pictureBox7.Visible = false;
            if (nz < 1)
                pictureBox6.Visible = false;
            sr.Close();
            sr2 = new System.IO.StreamReader("D:\\PV\\"+curauth+".txt", System.Text.Encoding.GetEncoding(1251));
            if (np == 0)
                button2.Enabled = false;
            if (nz == 0)
                button3.Enabled = false;
            if (nt != 1)
            {
                button5.Visible = false;
                timer1.Enabled = true;
                quest=sr3.ReadLine();
                auth=sr4.ReadLine();
                label1.Text = quest;
            }
            else
            {
                label1.Text = "";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            this.Text = "Main";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            np--;
            usepass++;
            switch(usepass)
            {
                case 1:
                    pictureBox5.Visible = false;
                    break;
                case 2:
                    pictureBox3.Visible = false;
                    break;
                case 3:
                    pictureBox4.Visible = false;
                    break;
                case 4:
                    pictureBox2.Visible = false;
                    break;
            }
            /*if (usepass>0)
                pictureBox5.Visible = false;
            if (usepass>1)
                pictureBox3.Visible = false;
            if (usepass > 2)
                pictureBox4.Visible = false;
            if (usepass > 3)
                pictureBox2.Visible = false;*/
            if (np == 0)
                button2.Enabled = false;
            usezam = 1;
            System.IO.FileInfo fi = new System.IO.FileInfo("D:\\PV\\pq.txt");
            System.IO.StreamWriter sw;
            System.IO.FileInfo fi2 = new System.IO.FileInfo("D:\\PV\\pa.txt");
            System.IO.StreamWriter sw2;
            sw = fi.AppendText();
            sw2 = fi2.AppendText();
            sw.WriteLine(quest);
            sw2.WriteLine(auth);
            sw.Close();
            sw2.Close();
            quest = sr3.ReadLine();
            auth = sr4.ReadLine();
            label1.Text = quest;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 0,j;
            if (label3.Visible)
            {
                if (s > 0)
                {
                    s--;
                    if (s < 10)
                        label4.Text = "0" + s.ToString();
                    else
                        label4.Text = s.ToString();
                }
                else
                {
                    if (m > 0)
                    {
                        m--;
                        if (m < 10)
                            label2.Text = "0" + m.ToString();
                        else
                            label2.Text = m.ToString();
                        s = 59;
                        label4.Text = "59";
                    }
                    else
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo("D:\\PV\\rez.txt");
                        System.IO.StreamWriter sw;
                        sw = fi.CreateText();
                        sw.WriteLine("0");
                        sw.WriteLine(curauth);
                        sw.Close();
                        while (!sr3.EndOfStream)
                        {
                            questm[i] = sr3.ReadLine();
                            authm[i] = sr4.ReadLine();
                            i++;
                        }
                        sr3.Close();
                        sr4.Close();
                        System.IO.FileInfo fi2 = new System.IO.FileInfo("D:\\PV\\q.txt");
                        System.IO.FileInfo fi3 = new System.IO.FileInfo("D:\\PV\\a.txt");
                        System.IO.StreamWriter sw2;
                        sw = fi2.CreateText();
                        sw2 = fi3.CreateText();
                        for (j = 0; j < i; j++)
                        {
                            sw.WriteLine(questm[j]);
                            sw2.WriteLine(authm[j]);
                        }
                        sw.Close();
                        sw2.Close();
                        i = 0;
                        if (usezam == 1)
                        {
                            while (!sr2.EndOfStream)
                            {
                                zamen[i] = sr2.ReadLine();
                                i++;
                            }
                            sr2.Close();
                            System.IO.FileInfo fi4 = new System.IO.FileInfo("D:\\PV\\" + curauth + ".txt");
                            sw = fi4.CreateText();
                            for (j = 0; j < i; j++)
                            {
                                sw.WriteLine(zamen[j]);
                            }
                            sw.Close();
                        }
                        else
                            sr2.Close();
                        Hide();
                        Form5 f = new Form5();
                        f.ShowDialog();
                        this.Close();
                    }
                }
                label3.Visible = false;
            }
            else
                label3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0,j;
            nca++;
            switch(nca)
            {
                case 1:
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap("D:\\PV\\correct.jpg");
                    break;
                case 2:
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = new Bitmap("D:\\PV\\correct.jpg");
                    break;
                case 3:
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox4.Image = new Bitmap("D:\\PV\\correct.jpg");
                    break;
                case 4:
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox3.Image = new Bitmap("D:\\PV\\correct.jpg");
                    break;
                case 5:
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox5.Image = new Bitmap("D:\\PV\\correct.jpg");
                    break;
            }
            if (nca==nt)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo("D:\\PV\\rez.txt");
                System.IO.StreamWriter sw;
                sw = fi.CreateText();
                switch(nt)
                {
                    case 1:
                        sw.WriteLine("1000");
                        break;
                    case 2:
                        sw.WriteLine("2500");
                        break;
                    case 3:
                        sw.WriteLine("5000");
                        break;
                    case 4:
                        sw.WriteLine("15000");
                        break;
                    case 5:
                        sw.WriteLine("50000");
                        break;
                }
                sw.WriteLine(curauth);
                sw.Close();
                while(!sr3.EndOfStream)
                {
                    questm[i] = sr3.ReadLine();
                    authm[i] = sr4.ReadLine();
                    i++;
                }
                sr3.Close();
                sr4.Close();
                System.IO.FileInfo fi2 = new System.IO.FileInfo("D:\\PV\\q.txt");
                System.IO.FileInfo fi3 = new System.IO.FileInfo("D:\\PV\\a.txt");
                System.IO.StreamWriter sw2;
                sw = fi2.CreateText();
                sw2 = fi3.CreateText();
                for (j = 0; j < i; j++)
                {
                    sw.WriteLine(questm[j]);
                    sw2.WriteLine(authm[j]);
                }
                sw.Close();
                sw2.Close();
                i = 0;
                if (usezam == 1)
                {
                    while (!sr2.EndOfStream)
                    {
                        zamen[i] = sr2.ReadLine();
                        i++;
                    }
                    sr2.Close();
                    System.IO.FileInfo fi4 = new System.IO.FileInfo("D:\\PV\\" + curauth + ".txt");
                    sw = fi4.CreateText();
                    for (j = 0; j < i; j++)
                    {
                        sw.WriteLine(zamen[j]);
                    }
                    sw.Close();
                }
                else
                    sr2.Close();
                if(nt!=5)
                {
                    nt++;
                    np = 5 - nt;
                    System.IO.FileInfo fi5 = new System.IO.FileInfo("D:\\PV\\sost.txt");
                    sw = fi5.CreateText();
                    sw.WriteLine(m.ToString());
                    sw.WriteLine(s.ToString());
                    sw.WriteLine(np.ToString());
                    sw.WriteLine(curauth);
                    sw.WriteLine(nz.ToString());
                    sw.WriteLine(nt.ToString());
                    sw.Close();
                    Hide();
                    Form3 f = new Form3();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    Hide();
                    Form5 f = new Form5();
                    f.ShowDialog();
                    this.Close();
                }
                
            }
            else
            {
                quest = sr3.ReadLine();
                auth = sr4.ReadLine();
                label1.Text = quest;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            nz--;
            usezam = 1;
            /*if (nz < 3)
                pictureBox8.Visible = false;
            if (nz < 2)
                pictureBox7.Visible = false;
            if (nz < 1)
                pictureBox6.Visible = false;*/
            switch(nz)
            {
                case 2:
                    pictureBox8.Visible = false;
                    break;
                case 1:
                    pictureBox7.Visible = false;
                    break;
                case 0:
                    pictureBox6.Visible = false;
                    break;
            }
            if (nz == 0)
                button3.Enabled = false;
            button2.Enabled = false;
            label1.Text = sr2.ReadLine();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i=0,j;
            while (!sr3.EndOfStream)
            {
                questm[i] = sr3.ReadLine();
                authm[i] = sr4.ReadLine();
                i++;
            }
            sr3.Close();
            sr4.Close();
            System.IO.FileInfo fi2 = new System.IO.FileInfo("D:\\PV\\q.txt");
            System.IO.FileInfo fi3 = new System.IO.FileInfo("D:\\PV\\a.txt");
            System.IO.StreamWriter sw;
            System.IO.StreamWriter sw2;
            sw = fi2.CreateText();
            sw2 = fi3.CreateText();
            for (j = 0; j < i; j++)
            {
                sw.WriteLine(questm[j]);
                sw2.WriteLine(authm[j]);
            }
            sw.Close();
            sw2.Close();
            System.IO.FileInfo fi = new System.IO.FileInfo("D:\\PV\\rez.txt");
            sw = fi.AppendText();
            sw.WriteLine(auth);
            if (nt == 1)
                sw.WriteLine("500");
            sw.Close();
            i = 0;
            if (usezam == 1)
            {
                while (!sr2.EndOfStream)
                {
                    zamen[i] = sr2.ReadLine();
                    i++;
                }
                sr2.Close();
                System.IO.FileInfo fi4 = new System.IO.FileInfo("D:\\PV\\" + curauth + ".txt");
                sw = fi4.CreateText();
                for (j = 0; j < i; j++)
                {
                    sw.WriteLine(zamen[j]);
                }
                sw.Close();
            }
            else
                sr2.Close();
            if (nt!=1)
            {
                Hide();
                Form4 f = new Form4();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                Hide();
                Form5 f = new Form5();
                f.ShowDialog();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            quest = sr3.ReadLine();
            auth = sr4.ReadLine();
            label1.Text = quest;
            button5.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
