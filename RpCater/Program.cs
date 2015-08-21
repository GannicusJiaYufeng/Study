using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpCater
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
            ////FrmLogin f1 = new FrmLogin();
            ////if (f1.ShowDialog() == DialogResult.OK)
            ////{
            // //   Application.Run(FrmMember.Instance);
            //   Application.Run(new  FrmLogin());
            ////}
            FrmLogin  f2 = new FrmLogin();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
            
        }
    }
}
