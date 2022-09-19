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
    public partial class Form2 : Form
    {
        happy_click hc;
        int temp_index;
        Image temp_img;
        public Form2(happy_click h)
        {
            InitializeComponent();
            hc = h;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            settime.Value = hc.PLAYTIME;
            setdifficult.SelectedIndex = hc.DIFFICULT - 1;
            temp_img = hc.PET;
            temp_index = hc.PET_INDEX;
            switch (hc.PET_INDEX)
            {
                case 1: p1.BackColor = Color.FromArgb(255, 192, 192); break;
                case 2: p2.BackColor = Color.FromArgb(255, 192, 192); break;
                case 3: p3.BackColor = Color.FromArgb(255, 192, 192); break;
                case 4: p4.BackColor = Color.FromArgb(255, 192, 192); break;
                case 5: p5.BackColor = Color.FromArgb(255, 192, 192); break;
                case 6: p6.BackColor = Color.FromArgb(255, 192, 192); break;
                case 7: p7.BackColor = Color.FromArgb(255, 192, 192); break;
                case 8: p8.BackColor = Color.FromArgb(255, 192, 192); break;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hc.PET = temp_img;
            if (hc.PLAYTIME != (int)settime.Value)
            {
                hc.PLAYTIME = (int)settime.Value;
                MessageBox.Show("游戏时长的设置将在新一轮游戏生效！");
            }
            hc.DIFFICULT = setdifficult.SelectedIndex + 1;
            hc.PET_INDEX = temp_index;
            this.DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;//返回no给form2
        }

        private void p1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            temp_img = p.Image;

            p1.BackColor = Color.FromArgb(224, 224, 224);
            p2.BackColor = Color.FromArgb(224, 224, 224);
            p3.BackColor = Color.FromArgb(224, 224, 224);
            p4.BackColor = Color.FromArgb(224, 224, 224);
            p5.BackColor = Color.FromArgb(224, 224, 224);
            p6.BackColor = Color.FromArgb(224, 224, 224);
            p7.BackColor = Color.FromArgb(224, 224, 224);
            p8.BackColor = Color.FromArgb(224, 224, 224);

            temp_index = int.Parse(p.Name.Substring(1));
            p.BackColor = Color.FromArgb(255, 192, 192);
        }

        

       
    }
}
