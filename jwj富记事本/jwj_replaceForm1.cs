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
    public partial class jwj_replaceForm : Form
    {
        RichTextBox rtb = null;
        int beginindex = 0;//特定内容的首次查找替换开始位置，默认是替换窗体打开时光标的当前位置或查找内容发生变化时，光标所在的位置。
        bool frombegin = true;

        public jwj_replaceForm(RichTextBox rh)//修改为带参的构造函数
        {
            InitializeComponent();
            rtb = rh;
        }

        private void jwj_replaceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            jwj_global.rp = null;
        }

        private void jwj_replaceForm_Load(object sender, EventArgs e)
        {
            if(rtb.SelectedText!="")//如果编辑区有选中的文本，则将其设置为默认的查找内容
            {
                tb_findtext.Text = rtb.SelectedText;
            }
            beginindex = rtb.SelectionStart;//记住首次查找替换的位置，以便到文末后重新从头开始查找替换，到此处汇合
        }

        private void button1_Click(object sender, EventArgs e)//查找按钮处理
        {
            if (tb_findtext.Text == "")
            {
                MessageBox.Show("请输入待查找的内容。");
                return;
            }
            if (rtb.Text.Length == 0)
            {
                MessageBox.Show("你目前的文档没有文字内容，查找替换结束。");
                return;
            }

            int startindex, endindex, index;
            endindex = rtb.Text.Length;
            if (rtb.SelectedText == "")
            {
                startindex = rtb.SelectionStart;
            }
            else startindex = rtb.SelectionStart + rtb.SelectionLength;
            if (startindex >= endindex || (beginindex != 0 && startindex >= beginindex && frombegin == true))
            {
                index = -1;
            }
            else
            {
                index = rtb.Find(tb_findtext.Text, startindex, endindex, RichTextBoxFinds.None);
            }
            if (index >= 0) rtb.Focus();
            else
            {
                rtb.SelectionStart += rtb.SelectionLength;//将光标移至最后选中项的右侧
                rtb.SelectionLength = 0;//取消上一次的选中
                if (startindex >= beginindex && frombegin == false)
                {
                    if (MessageBox.Show("已达到文档末尾，没有发现匹配内容，是否尝试从文档开始处查找？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frombegin = true;
                        rtb.SelectionStart = 0;
                        button1.PerformClick();
                    }
                }
                else
                {
                    if(MessageBox.Show("没找到内容。已完成对文档的一次遍历搜索，是否从头开始新一轮查找？", "查找完毕！", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frombegin = true;
                        beginindex = 0;
                        rtb.SelectionStart = 0;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//替换按钮处理
        {
            if (tb_findtext.Text == "")
            {
                MessageBox.Show("请输入待替换的内容。");
                return;
            }
            if (rtb.Text.Length == 0)
            {
                MessageBox.Show("你目前的文档没有文字内容，替换结束。");
                return;
            }

            int startindex, endindex, index;
            endindex = rtb.Text.Length;

            //如果选中内容和替换结果相同，则开始查找替换位置从选中内容右侧开始
            if (rtb.SelectedText != "" && rtb.SelectedText.Equals(tb_replacetext.Text))
                startindex = rtb.SelectionStart + tb_replacetext.Text.Length;
            else//否则从选中内容第一个字符开始查找替换
                startindex = rtb.SelectionStart;

            //如果没有选中内容或选中内容与待替换内容不符，则先查找待替换内容
            if (rtb.SelectedText == "" || rtb.SelectedText != tb_replacetext.Text)
            {
                rtb.SelectionLength = 0;
                if (startindex < endindex && !(beginindex != 0 && startindex >= beginindex && frombegin == true))
                {
                    index = rtb.Find(tb_findtext.Text, startindex, endindex, RichTextBoxFinds.None);
                }
            }

            if(rtb.SelectedText!="")//已经找到替换内容
            {
                rtb.SelectedText = tb_replacetext.Text;
                rtb.SelectionStart = rtb.SelectionStart - tb_replacetext.Text.Length;
                rtb.SelectionLength = tb_replacetext.Text.Length;
                rtb.Focus();
            }
            else//没有找到替换内容
            {
                if (startindex >= beginindex && frombegin == false)
                {
                    if (MessageBox.Show("已达到文档末尾，没有发现匹配内容，是否尝试从文档开始处查找替换？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frombegin = true;
                        rtb.SelectionStart = 0;
                        button1.PerformClick();
                    }
                }
                else//已完成从头到尾的完整查找替换
                {
                    if (MessageBox.Show("没找到可替换内容。已完成对文档的一次遍历查找替换，是否从头开始一次查找替换？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frombegin = true;
                        beginindex = 0;
                        rtb.SelectionStart = 0;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//全体替换
        {
            if (tb_findtext.Text == "")
            {
                MessageBox.Show("请输入待替换的内容。");
                return;
            }
            if (rtb.Text.Length == 0)
            {
                MessageBox.Show("你目前的文档没有文字内容，替换结束。");
                return;
            }

            int n = 0;
            int startindex = 0;
            while ((startindex = rtb.Find(tb_findtext.Text, startindex, rtb.Text.Length, RichTextBoxFinds.None)) >= 0)
            {
                n++;
                rtb.SelectedText = rtb.SelectedText.Replace(tb_findtext.Text, tb_replacetext.Text);
                startindex += tb_replacetext.Text.Length;
                if (startindex >= rtb.Text.Length) break;
            }
            rtb.ScrollToCaret();
            MessageBox.Show("替换完成，总共替换了" + n.ToString() + "处。");
        }
    }
}
