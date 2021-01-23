using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeAudioNotification
{
    public class MyApplication : IDisposable
    {
        public MyApplication()
        {
            Console.WriteLine("Hello MyApplication");

            //var form = new Form1();
            new MyNotifyIcon();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose MyApplication");
        }
    }
}
