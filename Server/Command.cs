using System;
using System.IO;
using System.Diagnostics;

namespace Server
{
    public class Command
    {
        public static string Execute(string command)
        {
            if (command == "hostname")
            {
                return Environment.MachineName;
            }
            else if (command == "dir")
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string[] files = Directory.GetFileSystemEntries(path);

                string result = "";

                foreach (string file in files)
                {
                    result += Path.GetFileName(file) + "\n";
                }

                return result;
            }
            else if (command == "ipconfig")
            {
                ProcessStartInfo info = new ProcessStartInfo();

                info.FileName = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.System),
                    "ipconfig.exe");

                info.UseShellExecute = false;
                info.RedirectStandardOutput = true;
                info.CreateNoWindow = true;

                Process process = new Process();
                process.StartInfo = info;

                process.Start();

                string result = process.StandardOutput.ReadToEnd();

                process.WaitForExit(5000);

                process.Close();

                return result;
            }
            else
            {
                return "Lệnh không được hỗ trợ!";
            }
        }
    }
}
