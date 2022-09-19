using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jwj富记事本
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string s = null;
            if (args.Length > 0)
            {
                s = string.Join(" ", args);//双引号里是一个空格
                string ex = s.Substring(s.LastIndexOf('.') + 1).ToLower();
                if (ex.Equals("rtf") || ex.Equals("txt"))
                    Application.Run(new jwj_Form1(s));
                else
                {
                    MessageBox.Show("无法打开指定的文件" + s);
                    Application.Exit();
                }
            }
            else
                Application.Run(new jwj_Form1());
        }
    }
}
