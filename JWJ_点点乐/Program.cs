using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JWJ_点点乐
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (new Form3().ShowDialog() == DialogResult.Yes)
            {
                Application.Run(new Form3());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
