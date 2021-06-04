using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tsanie.FlvBugger {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            //byte[] bs = BitConverter.GetBytes(15.0);
            //return;
            // 1904/01/01 08:00:00.000
            //DateTime dt = new DateTime(600527808000000000L + 3375573706 * 10000000L);
            //MessageBox.Show(dt.ToString());
            //return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FlvMain());
        }
    }
}
