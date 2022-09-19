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
    public partial class jwj_bulletform : Form
    {
        RichTextBox rtb = null;
        bool rh_wordwrap;
        bool have_bullet = false;
        public jwj_bulletform(RichTextBox rh)
        {
            InitializeComponent();
            rtb = rh;
        }

        string[] bulletlist = new string[] {"●","☆","★","◇","◆","■","○","▲","♣","♠","※","□","→","√","*","卍","△","▽" };
        private void jwj_bulletform_Load(object sender, EventArgs e)
        {
            rh_wordwrap = rtb.WordWrap;
            if (rtb.Lines.Length == 0) return;

            rtb.WordWrap = false;
            if (rtb.Lines[rtb.GetLineFromCharIndex(rtb.SelectionStart)].Length > 0)
            {
                string s = rtb.Text[rtb.GetFirstCharIndexOfCurrentLine()].ToString();
                int index = Array.IndexOf(bulletlist, s);
                if (index > -1)
                {
                    label1.Text = s;
                    ((RadioButton)Controls["radioButton" + (index + 1).ToString()]).Checked = true;
                    rtb.SelectionStart = rtb.GetFirstCharIndexOfCurrentLine();
                    rtb.SelectionLength = 1;
                    nud_bulletsize.Value = Convert.ToDecimal(rtb.SelectionFont.Size);
                    btn_bulletcolor.BackColor = rtb.SelectionColor;
                    label1.ForeColor = rtb.SelectionColor;
                    have_bullet = true;
                }
            }
            rtb.WordWrap = rh_wordwrap;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton ra = sender as RadioButton;
            if (ra.Checked) label1.Text = ra.Text;
        }

        private void btn_bulletcolor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = (sender as Button).BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                (sender as Button).BackColor = cd.Color;
                label1.ForeColor = cd.Color;
            }
        }

        private void nud_bulletsize_ValueChanged(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.Name, float.Parse(nud_bulletsize.Value.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtb.WordWrap = false;
            int index = rtb.GetFirstCharIndexOfCurrentLine();
            rtb.SelectionStart = index;
            if (have_bullet) rtb.SelectionLength = 1;
            else rtb.SelectionLength = 0;
            rtb.SelectedText = label1.Text;
            rtb.SelectionStart = index;
            rtb.SelectionLength = 1;

            rtb.SelectionFont = new Font(label1.Font.Name, float.Parse(nud_bulletsize.Value.ToString()));
            rtb.SelectionColor = btn_bulletcolor.BackColor;

            rtb.WordWrap = rh_wordwrap;
            this.Close();
        }
    }
}
