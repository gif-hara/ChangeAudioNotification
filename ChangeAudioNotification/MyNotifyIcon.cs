using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeAudioNotification
{
    public sealed class MyNotifyIcon : NAudio.CoreAudioApi.Interfaces.IMMNotificationClient
    {
        private readonly NotifyIcon notifyIcon;

        public MyNotifyIcon()
        {
            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.Icon = Properties.Resources.Icon1;
            this.notifyIcon.Visible = true;
            this.notifyIcon.Text = "ChangeAudioNotification";

            var contextMenuStrip = new ContextMenuStrip();
            var toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Text = "終了";
            toolStripMenuItem.Click += (sender, e) =>
            {
                Application.Exit();
            };
            contextMenuStrip.Items.Add(toolStripMenuItem);

            this.notifyIcon.ContextMenuStrip = contextMenuStrip;

            var enumerator = new MMDeviceEnumerator();
            enumerator.RegisterEndpointNotificationCallback(this);
            foreach (var endpoint in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                Console.WriteLine($"{endpoint.FriendlyName} ID = {endpoint.ID}");
            }
        }

        public void OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId)
        {
            Console.WriteLine($"OnDefaultDeviceChanged: DataFlow = {flow}, Role = {role}, defaultDeviceId = {defaultDeviceId}");
            if (flow == DataFlow.Render && role == Role.Console)
            {
                notifyIcon.ShowBalloonTip(3000, "オーディオ出力が変更されました", GetRenderFriendlyName(defaultDeviceId), ToolTipIcon.None);
            }
        }

        public void OnDeviceAdded(string pwstrDeviceId)
        {
        }

        public void OnDeviceRemoved(string deviceId)
        {
        }

        public void OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
        }
        private string GetRenderFriendlyName(string defaultDeviceId)
        {
            var targetEndPoint = new MMDeviceEnumerator()
                .EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)
                .FirstOrDefault(x => x.ID == defaultDeviceId);

            return targetEndPoint == null ? "不明なデバイス名" : targetEndPoint.FriendlyName;
        }

    }
}
