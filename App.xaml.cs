using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Forms = System.Windows.Forms;

namespace FileOrganiser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static readonly Forms.NotifyIcon _notifyIcon;
        // Constructor
        static App()
        {
            _notifyIcon = new Forms.NotifyIcon();
            _notifyIcon.Visible = true;
        }
        // Sytem tray icon code on startup
        protected override void OnStartup(StartupEventArgs e)
        {

            _notifyIcon.Icon = new System.Drawing.Icon("assets/icon.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.Text = "File Organiser";
            _notifyIcon.Click += NotifyIcon_Click;
            

            base.OnStartup(e);

        }

        private void NotifyIcon_Click(object? sender, EventArgs e)
        {
                var MW = new MainWindow();
                App.Current.MainWindow.Show();
        }

        // disposing of the icon on exit
        protected override void OnExit(ExitEventArgs e)
        {

            _notifyIcon.Dispose();
            base.OnExit(e);
        }

    }
}
