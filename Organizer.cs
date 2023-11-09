using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Timers = System.Timers;

namespace FileOrganiser
{
    public class Organizer
    {

        private static Timers.Timer _timer;

        private static readonly string[] DirsToMk =
        {
            "installers", "compressed", "pdf", "images", "videos", "audio", "text", "office", "other"
        };

        private static readonly string[] PosibleExt =
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


        public static void MakeDirs()
        {
            var files = Directory.GetFiles(Data.Path);
            foreach (string dir in DirsToMk)
            {
                if (!files.Contains(Data.Path + @"\" + dir))
                {
                    Directory.CreateDirectory(Data.Path + @"\" + dir);
                }
            }
        }

        public static void Organise(string path)
        {
            MakeDirs();
            Dictionary<string, string> DictDirFiles = new Dictionary<string, string>();
            DictDirFiles.Add(".exe", "installers");
            DictDirFiles.Add(".msi", "installers");
            DictDirFiles.Add(".pdf", "pdf");
            DictDirFiles.Add(".jpg", "images");
            DictDirFiles.Add(".png", "images");
            DictDirFiles.Add(".mp4", "videos");
            DictDirFiles.Add(".mp3", "audio");
            DictDirFiles.Add(".txt", "text");
            DictDirFiles.Add(".docx", "office");
            DictDirFiles.Add(".xlsx", "office");
            DictDirFiles.Add(".pptx", "office");
            DictDirFiles.Add(".zip", "compressed");
            DictDirFiles.Add(".rar", "compressed");
            DictDirFiles.Add(".7z", "compressed");
            DictDirFiles.Add(".iso", "compressed");
            DictDirFiles.Add(".gz", "compressed");
            DictDirFiles.Add(".tar", "compressed");
            DictDirFiles.Add(".bz2", "compressed");
            DictDirFiles.Add(".xz", "compressed");
            DictDirFiles.Add(".tgz", "compressed");
            DictDirFiles.Add(".svg", "images");
            DictDirFiles.Add(".gif", "images");
            DictDirFiles.Add(".bmp", "images");
            DictDirFiles.Add(".ico", "images");
            DictDirFiles.Add(".tif", "images");
            DictDirFiles.Add(".doc", "office");
            DictDirFiles.Add(".ppt", "office");
            DictDirFiles.Add(".xls", "office");
            DictDirFiles.Add(".accda", "office");
            DictDirFiles.Add(".accdb", "office");
            DictDirFiles.Add(".one", "office");
            DictDirFiles.Add(".efc", "office");

            _timer = new Timers.Timer(1000) { AutoReset = true };
            _timer.Start();
            _timer.Elapsed += (_, _) => { };
            while(true){
                if(Data.OrganiserStatus){
                    try
                    {
                        string[] files = Directory.GetFiles(path);
                        
                        foreach (string file in files)
                        {
                            string ext = Path.GetExtension(file);

                            if (DictDirFiles.TryGetValue(ext, out var dir))
                            {
                                string dest = $"{path}\\{dir}";

                                if (!Directory.Exists(dest))
                                    Directory.CreateDirectory(dest);
                                if (!File.Exists($"{dest}\\{Path.GetFileName(file)}"))
                                    try { 
                                        File.Move(file, $"{dest}\\{Path.GetFileName(file)}", false);
                                    }
                                    catch(Exception e) 
                                    {
                                        Debug.WriteLine(e);
                                    }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        App.NotifyIcon.ShowBalloonTip(3000, "Invalid Folder", exception.Message, System.Windows.Forms.ToolTipIcon.Error);
                        throw;
                    }
                }

                
            };
        }
    }
}