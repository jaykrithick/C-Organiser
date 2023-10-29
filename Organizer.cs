using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FileOrganiser
{
    public class Organizer
    {

        private readonly Timer _timer;
        private string[] dirsToMk =
        {
            "installer", "compressed", "pdf", "image", "video", "audio", "text", "office", "other"
        };
        string[] posibleExt = 
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
        public Dictionary<string, string> dict_dir_files = new Dictionary<string, string>();

        public Organizer()
        {
            _timer = new Timer(1000) { AutoReset = true};
            _timer.Elapsed += TimerElapsed;
            dict_dir_files.Add(".exe" , "installers");
            dict_dir_files.Add(".msi", "installers");
            dict_dir_files.Add(".pdf", "pdf");
            dict_dir_files.Add(".jpg", "images");
            dict_dir_files.Add(".png", "images");
            dict_dir_files.Add(".mp4", "videos");
            dict_dir_files.Add(".mp3", "audio");
            dict_dir_files.Add(".txt", "text");
            dict_dir_files.Add(".docx", "office");
            dict_dir_files.Add(".xlsx", "office");
            dict_dir_files.Add(".pptx", "office");
            dict_dir_files.Add(".zip", "compressed");
            dict_dir_files.Add(".rar", "compressed");
            
        }

        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            if(Data.organiserStatus)
            {
                string[] files = Directory.GetDirectories(MainWindow.Path);
                foreach (string Dir in dirsToMk)
                {
                    if(!files.Contains(MainWindow.Path + @"\" + Dir))
                    {
                        Directory.CreateDirectory(MainWindow.Path + @"\" + Dir);
                    }
                }
                foreach (string file in Directory.GetFiles(MainWindow.Path))
                {
                    string ext = Path.GetExtension(file);
                    if (posibleExt.Contains(ext))
                    {
                        string fileName = Path.GetFileName(file);
                        string dest = MainWindow.Path + @"\"+ dict_dir_files[ext] + fileName;
                        if (!File.Exists(dest))
                        {
                            File.Move(file, dest);
                        }
                    }
                }


            }
            
        }
    }
}
