using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jwj富记事本
{
    public partial class jwj_specialform : Form
    {

        RichTextBox rtb;
        string ch1 = "◆", ch2 = "∵", ch3 = "⑴", ch4 = "¥";

        public jwj_specialform(RichTextBox  rh)
        {
            InitializeComponent();
            rtb = rh;
        }

        private void radioButton80_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                lbl_specchar.Text = rb.Text;
                switch(tabControl1.SelectedIndex)
                {
                    case 0: ch1 = rb.Text; break;
                    case 1: ch2 = rb.Text; break;
                    case 2: ch3 = rb.Text; break;
                    case 3: ch4 = rb.Text; break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtb.SelectedText = lbl_specchar.Text;
        }

        private void jwj_specialform_Load(object sender, EventArgs e)
        {

        }

        private void jwj_specialform_FormClosed(object sender, FormClosedEventArgs e)
        {
            jwj_global.sp = null;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: lbl_specchar.Text = ch1; break;
                case 1: lbl_specchar.Text = ch2; break;
                case 2: lbl_specchar.Text = ch3; break;
                case 3: lbl_specchar.Text = ch4; break;
            }
        }
    }
}
