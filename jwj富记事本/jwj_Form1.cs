using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jwj富记事本
{
    public partial class jwj_Form1 : Form
    {
        bool toolflag = true;
        public jwj_Form1()
        {
            InitializeComponent();
        }

        public jwj_Form1(string s)
        {
            InitializeComponent();
            filename = s;
        }

        private void jwj_Form1_Load(object sender, EventArgs e)
        {
            //收起左侧
            splitContainer1.Panel1Collapsed = true;

            //读取系统字体
            ts_cbfont.Items.Clear();
            InstalledFontCollection f = new InstalledFontCollection();
            foreach(FontFamily ff in f.Families)
            {
                ts_cbfont.Items.Add(ff.Name);
            }

            //设置默认值
            ts_cbfont.Text = "宋体";
            ts_cbfont.SelectedIndex = 9;

            ts_fontsize.KeyUp += Ts_fontsize_KeyUp;
            ts_cbfont.SelectedIndexChanged += Ts_cbfont_SelectedIndexChanged;
            ts_fontsize.SelectedIndexChanged += Ts_fontsize_SelectedIndexChanged;

            if (filename == null) return;
            string ex = filename.Substring(filename.LastIndexOf('.') + 1);
            try
            {
                if (ex.ToLower().Equals("txt"))
                    rh.LoadFile(filename, RichTextBoxStreamType.PlainText);
                else
                    rh.LoadFile(filename);
                rh.Modified = false;
                string t = filename.Substring(filename.LastIndexOf(@"\") + 1);
                this.Text = "jwj_富记事本    " + t;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
                filename = null;
            }
        }

        
        //private void Rh_DragDrop(object sender, DragEventArgs e)
        //{
        //    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        //    foreach (string file in files)
        //    {
        //        if (Path.GetExtension(file) == ".txt") 
        //        {
        //            StreamReader sr = new StreamReader(file, System.Text.Encoding.Default);
        //            rh.Text=sr.ReadToEnd();
        //            sr.Close();
        //            this.rh.Focus();
                    
        //            this.rh.Select(this.rh.TextLength, 0);
                    
        //            this.rh.ScrollToCaret();

        //        }
        //        if (Path.GetExtension(file) == ".rtf") 
        //        {
        //            StreamReader sr = new StreamReader(file, System.Text.Encoding.Default);
        //            rh.Rtf = sr.ReadToEnd();
        //            sr.Close();
        //            this.rh.Focus();

        //            this.rh.Select(this.rh.TextLength, 0);

        //            this.rh.ScrollToCaret();
        //        }
        //    }

        //}

        //private void Rh_DragEnter(object sender, DragEventArgs e)
        //{

        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        e.Effect = DragDropEffects.Link;
        //    }
        //    else
        //    {
        //        e.Effect = DragDropEffects.None;
        //    }
        //}

        //缩进
        //public void appendContent(string content)
        //{
        //    this.rh.SelectionStart = this.rh.TextLength;
        //    this.rh.SelectedText = "\r\n";
        //    this.rh.SelectionIndent = 60;
        //    this.rh.SelectionHangingIndent = -20;
        //    this.rh.SelectionRightIndent = 40;
        //    this.rh.SelectionAlignment = HorizontalAlignment.Left;
        //    this.rh.SelectedText = content;
        //    this.rh.SelectionStart = this.rh.TextLength;
        //    this.rh.SelectedText = "\r\n";
        //    this.rh.SelectionIndent = 0;
        //    this.rh.SelectionHangingIndent = 0;
        //    this.rh.SelectionRightIndent = 0;
        //}

        private void Ts_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (size_flag == false) return;
            float fontsize = 0;
            if (ts_fontsize.SelectedIndex == -1) return;
            else
            {
                int k = Array.IndexOf(d, ts_fontsize.Text.Trim());
                fontsize = v[k];
            }

            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;
            for (int i = 0; i < len; i++)
            {
                rh.Select(selectstart + i, 1);
                rh.SelectionFont = new Font(rh.SelectionFont.FontFamily, fontsize, rh.SelectionFont.Style);
            }
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void Ts_cbfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (size_flag == false || ts_cbfont.SelectedIndex == -1) return;

            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;
            for (int i = 0; i < len; i++)
            {
                rh.Select(selectstart + i, 1);
                rh.SelectionFont = new Font(ts_cbfont.Text,rh.SelectionFont.Size, rh.SelectionFont.Style);
            }
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void Ts_fontsize_KeyUp(object sender, KeyEventArgs e)
        {
            if (ts_fontsize.SelectedIndex != -1) return;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    float fontsize = float.Parse(ts_fontsize.Text.Trim());

                    int len = rh.SelectionLength;
                    int selectstart = rh.SelectionStart;
                    toolflag = false;
                    for(int i = 0; i < len; i++)
                    {
                        rh.Select(selectstart + i, 1);
                        rh.SelectionFont = new Font(rh.SelectionFont.FontFamily, fontsize, rh.SelectionFont.Style);
                    }
                    rh.SelectionStart = selectstart;
                    rh.SelectionLength = len;
                    toolflag = true;
                    rh.Focus();
                }
                catch
                {
                    MessageBox.Show("属性值不正确");
                    ts_fontsize.Focus();
                }
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rh.SelectedRtf!="")rh.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Rtf) == true)
                rh.Paste();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rh.SelectedRtf != "") rh.Cut();
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts = sender as ToolStripMenuItem;
            ts.Checked = !ts.Checked;
            rh.WordWrap = !rh.WordWrap;
        }

        private void 背景设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = rh.BackColor;
            if(cd.ShowDialog()==DialogResult.OK)
            {
                rh.BackColor = cd.Color;
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.SelectAll();
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.Undo();
        }

        private void 恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.Redo();
        }

        private void 左对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void 居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void 右对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void 时间日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.SelectedText = DateTime.Now.ToString();
        }

        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rh.SelectedText != null) tb_findtext.Text = rh.SelectedText;//如果有选中内容，默认为查找内容
            lbl_findnum.Text = "";//清空结果
            splitContainer1.Panel1Collapsed = false;//展开左侧
        }

        string lastfindtext = "";//记录已经完成查找的上一次待查找内容
        private void clear_findbackcolor()//清除查找到内容的高亮显示
        {
            if(rh.Text.Length!=0)
            {
                int startindex = 0, endindex = rh.Text.Length;//查找范围
                while((startindex=rh.Find(lastfindtext,startindex,endindex,RichTextBoxFinds.None))>=0)
                {
                    rh.SelectionStart = startindex;
                    rh.SelectionLength = lastfindtext.Length;
                    rh.SelectionBackColor = rh.BackColor;//bug：会使局部文字底纹消失
                    startindex += lastfindtext.Length;
                    if (startindex >= endindex) break;
                }
            }
            rh.SelectionLength = 0;
            lastfindtext = "";
        }

        private void btn_dofind_Click(object sender, EventArgs e)
        {
            if(tb_findtext.Text=="")
            {
                MessageBox.Show("请输入待查找内容");
                tb_findtext.Focus();
                return;
            }

            if (lastfindtext != "") clear_findbackcolor();

            if (rh.Text.Length == 0)
            {
                lbl_findnum.Text = "不存在查找的内容";
                return;
            }

            toolflag = false;
            int i = 0;//结果个数
            int startindex = 0, endindex = rh.Text.Length;//查找范围
            while((startindex = rh.Find(tb_findtext.Text, startindex, endindex, RichTextBoxFinds.None)) >= 0)
            {
                rh.SelectionStart = startindex;
                rh.SelectionLength = tb_findtext.Text.Length;
                rh.SelectionBackColor = Color.YellowGreen;
                i++;
                startindex += tb_findtext.Text.Length;
                if (startindex >= endindex) break;
            }
            if (i > 0) lastfindtext = tb_findtext.Text;
            lbl_findnum.Text = "查找到" + i.ToString()+"个结果。";
            rh.ScrollToCaret();//将滚动条的位置设置到最后一个查找到的内容的位置
            toolflag = true;
        }

        //splitcontainer.panel1关闭按钮，关闭左侧界面panel1
        private void pb_leftclose_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            //如有查找结果，清空并消除高亮显示
            if (lastfindtext != "") clear_findbackcolor();
        }

        private void splitContainer1_Panel1_ClientSizeChanged(object sender, EventArgs e)
        {
            Panel p1 = sender as Panel;
            tb_findtext.Width = p1.Width - 10;
        }

        private void 替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(jwj_global.rp==null)
            {
                jwj_global.rp = new jwj_replaceForm(rh);
                jwj_global.rp.Show();
            }
            else
            {
                jwj_global.rp.Activate();
                jwj_global.rp.Left = Screen.PrimaryScreen.WorkingArea.Width / 3;
                jwj_global.rp.Top = Screen.PrimaryScreen.WorkingArea.Width / 3;
            }
        }

        string filename = null;//用于存放文件（包含路径）
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dosave();
        }

        //对原文档保存的统一处理 保存返回1，失败-1，没有执行保存返回0
        private int dosave()
        {
            try
            {
                if (filename == null)//如果是第一次保存，则选择保存路径和文件名
                {
                    SaveFileDialog sd = new SaveFileDialog();
                    sd.Filter = "RTF文件|*.rtf|TXT文本|*.txt";
                    sd.Title = "保存文件";
                    sd.OverwritePrompt = true;//覆盖提示
                    if (sd.ShowDialog() == DialogResult.OK)//单击保存对话框的确定或保存按钮
                    {
                        string s = sd.FileName;
                        if (sd.FilterIndex == 1) rh.SaveFile(s);
                        else rh.SaveFile(s, RichTextBoxStreamType.PlainText);
                        rh.Modified = false;//设置控件为未修改状态
                        filename = s;
                        string t = filename.Substring(filename.LastIndexOf(@"\") + 1);//去除路径
                        this.Text = "jwj_富记事本  " + t;
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else//非第一次保存
                {
                    string a = filename.Substring(filename.LastIndexOf('.') + 1).ToLower();//扩展名
                    if (a.Equals("rtf")) rh.SaveFile(filename);
                    else rh.SaveFile(filename, RichTextBoxStreamType.PlainText);
                    rh.Modified = false;
                    return 1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rh.Modified == true)
            {
                DialogResult result = MessageBox.Show("文件内容发生改变，是否保存？", "提示", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.Yes)
                {
                    int i = dosave();
                    if (i < 1) return;
                }
            }

            filename = null;
            rh.Clear();
            rh.Modified = false;
            this.Text = "jwj富记事本  " + filename;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rh.Modified == true)
            {
                DialogResult result = MessageBox.Show("文件内容发生改变，是否保存？", "提示", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.Yes)
                {
                    int i = dosave();
                    if (i < 1) return;
                }
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RTF文件|*.rtf|TXT文本|*.txt";
            ofd.Title = "打开文件";
            if (filename != null) ofd.InitialDirectory = filename.Substring(0, filename.LastIndexOf(@"\"));
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                rh.Clear();
                string a = filename.Substring(filename.LastIndexOf('.') + 1).ToLower();
                try
                {
                    if (a.Equals("rtf"))
                        rh.LoadFile(filename);
                    else
                        rh.LoadFile(filename, RichTextBoxStreamType.PlainText);
                    this.Text = "jwj_富记事本  " + ofd.SafeFileName;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    filename = null;
                    this.Text = "jwj_富记事本";
                }
                rh.Modified = false;
            }

        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sd = new SaveFileDialog();

                sd.Filter = "RTF文件|*.rtf|TXT文本|*.txt";
                sd.Title = "保存文件";
                sd.OverwritePrompt = true;//覆盖提示

                if (sd.ShowDialog() == DialogResult.OK)
                {

                    string s = sd.FileName;
                    if (sd.FilterIndex == 1) rh.SaveFile(s);
                    else rh.SaveFile(s, RichTextBoxStreamType.PlainText);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jwj_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rh.Modified == true)
            {
                DialogResult result = MessageBox.Show("文件内容已经发生改变，是否保存？", "提示"
                    , MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;

                }
                if (result == DialogResult.Yes)
                {
                    int i = dosave();
                    if (i <= 0)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void 项目符号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jwj_bulletform nform = new jwj_bulletform(rh);
            nform.ShowDialog();
        }

        float[] v = new float[] {42,36,25.8f,24,22.2f,18,16.2f,15,13.8f,12,10.8f,9,7.8f,6.75f,5.25f };
        string[] d = new string[] {"初号","小初","一号","小一","二号","小二","三号","小三","四号","小四","五号","小五","六号","小六","七号" };

        bool font_flag = true;
        bool size_flag = true;
        private StringReader myReader;

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = rh.SelectionFont;
            fd.Color = rh.SelectionColor;
            fd.ShowColor = true;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                rh.SelectionColor = fd.Color;
                rh.SelectionFont = fd.Font;

                font_flag = size_flag = false;
                ts_color.BackColor = fd.Color;
                ts_cbfont.Text = fd.Font.FontFamily.Name;
                int k = Array.IndexOf(v, fd.Font.Size);
                if (k > -1) ts_fontsize.Text = d[k];
                else ts_fontsize.Text = fd.Font.Size.ToString();
                加粗toolStripButton.Checked = fd.Font.Bold;
                斜体toolStripButton.Checked = fd.Font.Italic;
                下划线toolStripButton.Checked = fd.Font.Underline;
                删除线toolStripButton.Checked = fd.Font.Strikeout;
                size_flag = font_flag = true;
            }
        }

        private void 加粗toolStripButton_Click(object sender, EventArgs e)
        {
            toolflag = false;

            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;
            bool isbold = true;
            for (int i = 0; i < len; i++)
            {
                rh.Select(selectstart + i, 1);
                if (i == 0) isbold = rh.SelectionFont.Bold;
                if (isbold)
                    rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style & ~FontStyle.Bold);
                else
                    rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style | FontStyle.Bold);

            }
            加粗toolStripButton.Checked = !isbold;
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void 斜体toolStripButton_Click(object sender, EventArgs e)
        {
            toolflag = false;

            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;
            bool isbold = true;
            for (int i = 0; i < len; i++)
            {
                rh.Select(selectstart + i, 1);
                if (i == 0) isbold = rh.SelectionFont.Italic;
                if (isbold)
                    rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style & ~FontStyle.Italic);
                else
                    rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style | FontStyle.Italic);
            }
            斜体toolStripButton.Checked = !isbold;
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void 下划线toolStripButton_Click(object sender, EventArgs e)
        {
            toolflag = false;

            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;
            bool isbold = true;
            for (int i = 0; i < len; i++)
            {
                rh.Select(selectstart + i, 1);
                if (i == 0) isbold = rh.SelectionFont.Underline;
                if (isbold)
                    rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style & ~FontStyle.Underline);
                else
                    rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style | FontStyle.Underline);

            }
            下划线toolStripButton.Checked = !isbold;
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void 删除线toolStripButton_Click(object sender, EventArgs e)
        {
            toolflag = false;

            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;
            bool isso = true;
            for (int i = 0; i < len; i++)
            {
                rh.Select(selectstart + i, 1);
                if (i == 0)
                    isso = rh.SelectionFont.Strikeout;
                if (isso)
                    rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style & ~FontStyle.Strikeout);
                else
                    rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style | FontStyle.Strikeout);

            }
            删除线toolStripButton.Checked = !isso;
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void 图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.FileName = "BMP.JPEG,GIF,icon,png|*.bmp;*.jpg;*.gif;*.icon;*.png";
            if (of.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(of.FileName);
                Clipboard.SetDataObject(img);
                rh.Paste(DataFormats.GetFormat(DataFormats.Bitmap));
            }
        }

        private void 字体颜色toolStripButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = rh.SelectionColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                rh.SelectionColor = cd.Color;
                ts_color.BackColor = cd.Color;
            }
        }

        private void 底纹toolStripButton_Click(object sender, EventArgs e)
        {
            if(rh.SelectionBackColor == null)
            {
                rh.SelectionBackColor = Color.Gray;

            }
            else
            {
                if (rh.SelectionBackColor.Equals(Color.Gray))
                {
                    rh.SelectionBackColor = rh.BackColor;
                }
                else
                {
                    rh.SelectionBackColor = Color.LightGray;
                }
            }
        }

        private void jwj_Form1_DragEnter(object sender, DragEventArgs e)
        {
            //鼠标拖动放入文件，拖入
            if (e.Data.GetDataPresent(DataFormats.FileDrop))//预览文件有无拖入
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void jwj_Form1_DragDrop(object sender, DragEventArgs e)
        {
            //鼠标松开
            string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (ss.Length == 0) return;
            foreach (string s in ss)
            {
                Process p = new Process();
                p.StartInfo.FileName = Process.GetCurrentProcess().ProcessName;
                p.StartInfo.Arguments = s;
                p.Start();
            }
        }

        private void 字数统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s;
            if (rh.SelectedText == "") s = rh.Text;
            else s = rh.SelectedText;
            int c_all = 0;//计空格字符数
            int c = 0;//不计空格字符数
            int c_ch = 0;//中文字数

            c_all = s.Replace("\n", "").Length;//总字数中去除回车
            s = s.Replace(" ", "").Replace("\n", "");//去除空格和回车
            c = s.Length;
            CharEnumerator chenumeator = s.GetEnumerator();
            Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
            while (chenumeator.MoveNext())
            {
                if (regex.IsMatch(chenumeator.Current.ToString(), 0)) c_ch++;
            }
            MessageBox.Show("字符总数：" + c_all + "\n不计空格字符数：" + c + "\n中文字符数：" + c_ch,"字数统计");
        }

        private void rh_TextChanged(object sender,EventArgs e)
        {
            tlb_num.Text = rh.Text.Replace("\n", "").Length.ToString();
        }

        private void 特殊字符ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (jwj_global.sp == null)
            {
                jwj_global.sp = new jwj_specialform(rh);
                jwj_global.sp.Show();
            }
            else
            {
                jwj_global.sp.Activate();
                jwj_global.sp.Left = Screen.PrimaryScreen.WorkingArea.Width / 3;
                jwj_global.sp.Top = Screen.PrimaryScreen.WorkingArea.Height / 3;
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog ptDialog = new PrintDialog();
            ptDialog.Document = this.MyPrintDC;
            if (ptDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.MyPrintDC.Print();
                }
                catch
                {
                    this.MyPrintDC.PrintController.OnEndPrint(this.MyPrintDC, new System.Drawing.Printing.PrintEventArgs());
                }
            }
        }

        private void rh_SelectionChanged(object sender, EventArgs e)
        {
            if (toolflag == false) return;
            tlb_rows.Text = (rh.GetLineFromCharIndex(rh.SelectionStart) + 1).ToString();
            tlb_cols.Text = (rh.SelectionStart - rh.GetFirstCharIndexOfCurrentLine() + 1).ToString();

            font_flag = false;
            size_flag = false;
            if (rh.SelectionLength == 0)
            {
                ts_cbfont.Text = rh.SelectionFont.FontFamily.Name;
                ts_fontsize.Text = rh.SelectionFont.Size.ToString();
                加粗toolStripButton.Checked = rh.SelectionFont.Bold;
                斜体toolStripButton.Checked = rh.SelectionFont.Italic;
                下划线toolStripButton.Checked = rh.SelectionFont.Underline;
                ts_color.BackColor = rh.SelectionColor;
            }
            else
            {
                string u_fontfamily = "";
                string u_fontsize = "";
                bool u_bold = false;
                bool u_italic = false;
                bool u_underline = false;
                char[] flags = new char[] { '1', '1', '1', '1', '1' };//分别表字体种类，大小，加粗，斜体，下划线是否一致，1为一致
                RichTextBox rhtemp = new RichTextBox();
                rhtemp.Rtf = rh.SelectedRtf;
                toolflag = false;
                int oldselectstart = rh.SelectionStart;
                int oldlen = rh.SelectionLength;

                for(int i = 0; i < rh.SelectionLength; i++)
                {
                    rhtemp.Select(i, 1);
                    if (i == 0)
                    {
                        u_fontfamily = rhtemp.SelectionFont.FontFamily.Name;
                        u_fontsize = rhtemp.SelectionFont.Size.ToString();
                        u_bold = rhtemp.SelectionFont.Bold;
                        u_italic = rhtemp.SelectionFont.Italic;
                        u_underline = rhtemp.SelectionFont.Underline;
                        ts_color.BackColor = rhtemp.SelectionColor;
                    }
                    else
                    {
                        if (!u_fontfamily.Equals(rhtemp.SelectionFont.FontFamily.Name)) flags[0] = '0';
                        if (!u_fontsize.Equals(rhtemp.SelectionFont.Size.ToString())) flags[1] = '0';
                        if (!u_bold.Equals(rhtemp.SelectionFont.Bold)) flags[2] = '0';
                        if (!u_italic.Equals(rhtemp.SelectionFont.Italic)) flags[3] = '0';
                        if (!u_underline.Equals(rhtemp.SelectionFont.Underline)) flags[4] = '0';
                    }
                    if ((new string(flags)).Equals("00000")) break;
                }
                rh.SelectionStart = oldselectstart;
                rh.SelectionLength = oldlen;
                toolflag = true;

                if (flags[0].Equals('1')) ts_cbfont.Text = u_fontfamily;
                else ts_cbfont.SelectedIndex = -1;
                if (flags[1].Equals('1')) ts_fontsize.Text = u_fontsize;
                else ts_fontsize.Text = "";
                if (flags[2].Equals('1') && u_bold == true) 加粗toolStripButton.Checked = true;
                else 加粗toolStripButton.Checked = false;
                if (flags[3].Equals('1') && u_italic == true) 斜体toolStripButton.Checked = true;
                else 斜体toolStripButton.Checked = false;
                if (flags[4].Equals('1') && u_underline == true) 下划线toolStripButton.Checked = true;
                else 下划线toolStripButton.Checked = false;
            }
            if (ts_fontsize.Text != "")
            {
                int k = Array.IndexOf(v, float.Parse(ts_fontsize.Text));
                if (k > -1) ts_fontsize.Text = d[k];
            }
            font_flag = true;
            size_flag = true;
        }

        private void MyPrintDC_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.myReader = new StringReader(this.rh.Text);//定义字符读流
            Graphics myGraphics = e.Graphics;
            Font myPrintFont = this.rh.Font;
            //计算一页行数
            float iLinePage = e.MarginBounds.Height / myPrintFont.GetHeight(myGraphics);
            int iLineNumber = 0;//打印行数
            float fyPosition = 0;//打印时的纵坐标
            float fMarginLeft = e.MarginBounds.Left;//纸页面左边界
            float fMarginTop = e.MarginBounds.Top;
            string strLine = "";
            while ((iLineNumber < iLinePage) && (strLine = myReader.ReadLine()) != null)
            {
                fyPosition = fMarginTop + iLineNumber * myPrintFont.GetHeight(myGraphics);
                myGraphics.DrawString(strLine, myPrintFont, new SolidBrush(Color.Black), fMarginLeft, fyPosition, new StringFormat());
                iLineNumber++;
            }
            if (strLine != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        private void 打印预览toolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog myptViewDialog = new PrintPreviewDialog();
            myptViewDialog.Document = this.MyPrintDC;
            try
            {
                myptViewDialog.ShowDialog();
            }
            catch
            {
                this.MyPrintDC.PrintController.OnEndPrint(this.MyPrintDC, new System.Drawing.Printing.PrintEventArgs());
            }
        }

        private void 显示隐藏任务栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = menuStrip1.Visible;
            menuStrip1.Visible = !flag;
        }

        private void 显示隐藏快捷工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = toolStrip1.Visible;
            toolStrip1.Visible = !flag;
        }

        private void 显示隐藏状态栏toolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = statusStrip1.Visible;
            statusStrip1.Visible = !flag;
        }

        private void 编辑ToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            if (rh.SelectedRtf == "")
            { 
                复制ToolStripMenuItem.Enabled = false; 
                剪切ToolStripMenuItem.Enabled = false; 
            }
            else
            {
                复制ToolStripMenuItem.Enabled = true;
                剪切ToolStripMenuItem.Enabled = true;
            }
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Rtf) == false)
            {
                粘贴ToolStripMenuItem.Enabled = false;
            }
            else 粘贴ToolStripMenuItem.Enabled = true;
            if (rh.CanUndo==false) 撤销ToolStripMenuItem.Enabled = false;
            else 撤销ToolStripMenuItem.Enabled = true;
            if (rh.CanRedo==false) 恢复ToolStripMenuItem.Enabled = false;
            else 恢复ToolStripMenuItem.Enabled = true;
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (rh.SelectedRtf == "")
            {
                复制ToolStripMenuItem1.Enabled = false;
                剪切ToolStripMenuItem1.Enabled = false;
            }
            else
            {
                复制ToolStripMenuItem1.Enabled = true;
                剪切ToolStripMenuItem1.Enabled = true;
            }
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Rtf) == false)
            {
                粘贴ToolStripMenuItem1.Enabled = false;
            }
            else
            {
                粘贴ToolStripMenuItem1.Enabled = true;
            }
            if (rh.CanUndo == false) 撤销toolStripMenuItem1.Enabled = false;
            else 撤销toolStripMenuItem1.Enabled = true;
            if (rh.Text == "") 全选toolStripMenuItem1.Enabled = false;
            else 全选toolStripMenuItem1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (rh.SelectedRtf == "")
            {
                复制CToolStripButton.Enabled = false;
                剪切UToolStripButton.Enabled = false;
            }
            else
            {
                复制CToolStripButton.Enabled = true;
                剪切UToolStripButton.Enabled = true;
            }
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Rtf) == false)
            {
                粘贴PToolStripButton.Enabled = false;
            }
            else 粘贴PToolStripButton.Enabled = true;
            if (rh.CanUndo == false) 撤销toolStripButton.Enabled = false;
            else 撤销toolStripButton.Enabled = true;
            if (rh.CanRedo == false) 恢复toolStripButton.Enabled = false;
            else 恢复toolStripButton.Enabled = true;
        }

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jwj_about a = new jwj_about();
            a.ShowDialog();
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jwj_help a = new jwj_help();
            a.ShowDialog();
        }

        private void jwj_Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                新建ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                打开ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                保存ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                打印ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.X)
            {
                退出ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                查找ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.H)
            {
                替换ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                字数统计ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void rh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                新建ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                打开ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                保存ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                打印ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.X)
            {
                退出ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                查找ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.H)
            {
                替换ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                字数统计ToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }
    }
}
