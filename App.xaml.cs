using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace FileOrganiser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        
        private static readonly string[] DirsToMk =
        {
            "installer", "compressed", "pdf", "image", "video", "audio", "text", "office", "other"
        };

        static readonly string[] PosibleExt = 
        { 
            ".exe", 
            ".msi", 
            ".pdf", 
            ".jpg", 
            ".png", 
            ".mp4", 
            ".mp3", 
            ".txt", 
            ".docx", 
            ".xlsx", 
            ".pptx", 
            ".zip", 
            ".rar",
        };

        private static Dictionary<string, string> _dictDirFiles = new Dictionary<string, string>();
        public static Thread _organiserThread;

        public static readonly NotifyIcon NotifyIcon;
        // Constructor
        static App()
        {
            NotifyIcon = new NotifyIcon();
            NotifyIcon.Visible = true;
        }
        // System tray icon code on startup
        protected override void OnStartup(StartupEventArgs e)
        {

            NotifyIcon.Icon = new Icon("assets/icon.ico");
            NotifyIcon.Visible = true;
            NotifyIcon.Text = "File Organiser";
            NotifyIcon.Click += NotifyIcon_Click;
            _organiserThread = new Thread(() => Organizer.Organise(Data.Path));
            
            base.OnStartup(e);

        }

        private static void NotifyIcon_Click(object? sender, EventArgs e)
        {
            Current.MainWindow!.Show();
        }
        
        

        // disposing of the icon on exit
        protected override void OnExit(ExitEventArgs e)
        {

            NotifyIcon.Dispose();
            base.OnExit(e);
        }

    }
}
