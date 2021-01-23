using System.Windows.Forms;
using System.Management;
using System;
using NAudio.CoreAudioApi;
using System.Linq;

namespace ChangeAudioNotification
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
        }
    }
}
