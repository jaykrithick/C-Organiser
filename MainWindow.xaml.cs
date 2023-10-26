using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileOrganiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string Path = @"";
        public bool organiserStatus = false;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MinimiseBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (organiserStatus) { 
            App.Current.MainWindow.Hide();
            }
            else
            {
                App.Current.Shutdown();
            }
        }

        private void SetDownloadsDirBtn_Click(object sender, RoutedEventArgs e)
        {
            Path = PathInput.Text;
            PathInput.Text = Path;
        }
        private void enableDisableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Path == null || Path == @"")
            {
                App._notifyIcon.ShowBalloonTip(3000, "Error", "Please set a path", System.Windows.Forms.ToolTipIcon.Error);
            }else
            {
                organiserStatus = !organiserStatus;
                if (organiserStatus == true)
                {
                    organiserStatusTxt.Text = "Organiser Enabled";
                }
                else
                {
                    organiserStatusTxt.Text = "Organiser Disabled";
                }
            }
        }
        
    }
}
