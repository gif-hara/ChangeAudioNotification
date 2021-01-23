using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeAudioNotification
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var myApplication = new MyApplication();

            Application.ApplicationExit += (sender, e) =>
            {
                myApplication.Dispose();
            };
            Application.Run();
        }
    }
}
