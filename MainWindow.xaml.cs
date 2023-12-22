using System;
using System.IO;
using System.Threading;
using Timers = System.Timers;
using System.Windows;
using System.Windows.Forms;

namespace FileOrganiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Thread backgroundthread;




        public MainWindow()
        {
            InitializeComponent();
        }

        private void MinimiseBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (Data.OrganiserStatus)
            {
                App.Current.MainWindow.Hide();
                App.NotifyIcon.ShowBalloonTip(3000, "Running in Background", "Organizer minimised to system tray", ToolTipIcon.Info);
            }
            else
            {
                WindowState = WindowState.Minimized;
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Data.OrganiserStatus) { 
                App.Current.MainWindow.Hide();
                App.NotifyIcon.ShowBalloonTip(3000, "Running in Background", "Organizer minimised to system tray", ToolTipIcon.Info);
            }
            else
            {
                App.Current.Shutdown();
            }
        }

        private void SetDownloadsDirBtn_Click(object sender, RoutedEventArgs e)
        {
            Data.Path = PathInput.Text;
            PathInput.Text = Data.Path;
        }
        private void enableDisableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PathInput.Text.Length == 0)
            {
                App.NotifyIcon.ShowBalloonTip(3000, "Invalid Folder", "Please set a path", ToolTipIcon.Error);
            }else
            {
                Data.OrganiserStatus = !Data.OrganiserStatus;
                organiserStatusTxt.Text = Data.OrganiserStatus == true ? "Organiser Enabled" : "Organiser Disabled";
                backgroundthread = new Thread( () => Organizer.Organise(Data.Path));
                if (Data.OrganiserStatus)
                    backgroundthread.Start();
                else
                    backgroundthread.Interrupt();
            }

            
        }

        private void openDialog_OnClick(object sender, RoutedEventArgs e)
        {
            // Create a new FolderBrowserDialog object.
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set the initial directory for the dialog.
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            // Show the dialog and get the selected folder path.
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Data.Path = folderBrowserDialog.SelectedPath;
                PathInput.Text = Data.Path;
            }
        }


    }
}
