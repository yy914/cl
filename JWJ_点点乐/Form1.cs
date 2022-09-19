using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JWJ_点点乐
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        happy_click hc;
        Timer t = new Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            Point[] p = new Point[9];
            p[0].X = 115; p[0].Y = 100;
            p[1].X = 300; p[1].Y = 100;
            p[2].X = 485; p[2].Y = 100;
            p[3].X = 115; p[3].Y = 210;
            p[4].X = 300; p[4].Y = 210;
            p[5].X = 485; p[5].Y = 210;
            p[6].X = 115; p[6].Y = 330;
            p[7].X = 300; p[7].Y = 330;
            p[8].X = 485; p[8].Y = 330;
            hc = new happy_click(pb_pet.Image, 5, p, 4, pb_pet.Size);
            t.Interval = 1000;
            t.Tick += Timer1_Tick;

        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("开始"))
            {
                hc.SCORE = 0;
                label2.Text = hc.SCORE.ToString();
                progressBar1.Value = 0;
                progressBar1.Maximum = hc.PLAYTIME * 60;
                progressBar1.Visible = true;
                button1.Text = "暂停";
                this.MouseMove += Form1_MouseMove;
                pb_pet.Click += Pb_pet_Click;
                t.Start();
            }
            else
            {
                if (button1.Text.Equals("暂停"))
                {
                    this.MouseMove -= Form1_MouseMove;
                    pb_pet.Click -= Pb_pet_Click;
                    t.Stop();
                    button1.Text = "继续";
                }
                else
                {
                    this.MouseMove += Form1_MouseMove;
                    pb_pet.Click += Pb_pet_Click;
                    t.Start();
                    button1.Text = "暂停";
                }
            }

        }

        private void Pb_pet_Click(object sender, EventArgs e)
        {
            hc.catched();
            label2.Text = hc.SCORE.ToString();
            pb_pet.Location = hc.CUR_HOUSE;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (hc.FLAG == true) return;
            if (hc.do_run(e.X, e.Y))
                pb_pet.Location = hc.CUR_HOUSE;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            label3.Text = (progressBar1.Value * 100 / progressBar1.Maximum).ToString() + "%";
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                t.Stop();
                MessageBox.Show("时间到！您的得分是：" + label2.Text);
                this.MouseMove -= Form1_MouseMove;
                pb_pet.Click -= Pb_pet_Click;
                button1.Text = " 开始";
                progressBar1.Visible = false;
                label3.Text = "";
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("暂停")) button1.PerformClick();
            Form2 f = new Form2(hc);
            if (f.ShowDialog() == DialogResult.Yes) pb_pet.Image = hc.PET;
            if (button1.Text.Equals("继续")) button1.PerformClick();
        }
    }
}
