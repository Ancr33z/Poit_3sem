using System;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections.Specialized;
using System.IO.Compression;
using System.Data.SqlTypes;

namespace Lab12
{
    public static class KVVLog
    {
        static string logfile = "BNAlogfile.txt";

        public static void Write(string method, string filename = null)
        {
            string textFromLogFile = Read();
            textFromLogFile += $"Date - {DateTime.Now}" + (filename != null ? $"\nFile - {filename} \n" : "\n")
                + $"Method - {method}\n";

            using (StreamWriter writer = new StreamWriter(logfile, false))
            {
                writer.WriteLine(textFromLogFile);
            }
        }

        public static string Read()
        {
            using (StreamReader reader = new StreamReader(logfile))
            {
                string text = reader.ReadToEnd();
                return text;
            }
        }

        public static bool Find(string str)
        {
            string text = Read();
            if (text.IndexOf(text) != -1)
            {
                return true;
            }
            return false;
        }
    }

    public class KVVDiskInfo
    {
        public static void GetFreeDiskSpace()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string info = "Free spase: \n";
            foreach (DriveInfo drive in allDrives)
            {
                info += $"{drive.Name} - {drive.AvailableFreeSpace / 1_000_000_000} \n";
            }
            Console.WriteLine(info);
            KVVLog.Write("FreeDeskSpace");
        }
    }

    public static class KVVFileInfo
    {
        public static string GetFullPath(string filename)
        {
            string path = Path.GetFullPath(filename);
            Console.WriteLine(path);
            KVVLog.Write("FullPath", filename);
            return path;
        }

        public static void GetFileInfo(string filename)
        {
            FileInfo fileinfo = new FileInfo(filename);
            Console.WriteLine("\nFull path:     " + KVVFileInfo.GetFullPath(filename) +
                              "\nFile name:     " + fileinfo.Name +
                              "\nFile size:     " + fileinfo.Length +
                              "\nExtension:     " + fileinfo.Extension +
                              "\nData and time: " + fileinfo.LastWriteTime);
            KVVLog.Write("GetFileInfo");
        }
    }

    public class KVVDirInfo
    {
        public static void GetDirInfo(string dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            Console.WriteLine("\nDir name:       " + dirInfo.Name +
                              "\nFiles amount:   " + dirInfo.GetFiles().Length +
                              "\nCreating time:  " + dirInfo.LastWriteTime +
                              "\nSubDirs amount: " + dirInfo.GetDirectories().Length +
                              "\nParent dir: " + dirInfo.Parent.Name);
            KVVLog.Write("GetFileInfo", dirName);
        }
    }

    public class KVVFileManager
    {
        public static void GetAllFilesAndDir(string path)
        {
            string filesAndDir = "";
            DriveInfo[] drives = DriveInfo.GetDrives();
            string[] dirs = System.IO.Directory.GetDirectories(path);
            string[] files = System.IO.Directory.GetFiles(path);

            filesAndDir = "\nFolders:\n";
            foreach (string dir in dirs)
            {
                filesAndDir += dir + "\n";
            }

            filesAndDir += "Files:\n";
            foreach (string file in files)
            {
                filesAndDir += file + "\n";
            }
            Console.WriteLine(filesAndDir);
            KVVLog.Write("GetAllFilesAndDir");
        }

        public static void CreateDir(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch
            {
                Console.WriteLine("Error creating directory");
            }
            KVVLog.Write("CreateDir");
        }

        public static void CreateFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            using (StreamWriter writer = fileInfo.CreateText())
            {
                writer.WriteLine("");
                writer.Close();
            }
            KVVLog.Write("CreateFile");
        }

        public static void CopyFile(string path, string path2)
        {
            try
            {
                File.Copy(path, path2);
            }
            catch
            {
                Console.WriteLine("Error copying the file");
            }

            FileInfo delete = new FileInfo(path);
            try
            {
                delete.Delete();
            }
            catch
            {
                Console.WriteLine("Access denied");
            }
            KVVLog.Write("CopyFile");
        }

        public static void CopyFiles(string extension, string path, string path2, string path3)
        {
            try
            {
                Directory.CreateDirectory(path2);

                string[] files = Directory.GetFiles(path, extension);
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(path2, fileName);
                    File.Copy(file, destFile, true);
                }
            }
            catch
            {
                Console.WriteLine("Error creating files:");
            }

            try
            {
                string path4 = path3 + @"\BNAFiles";

                DirectoryInfo destDir = new DirectoryInfo(path4);
                if (destDir.Exists)
                    destDir.Delete(true);
                Directory.Move(path2, path4);
            }
            catch
            {
                Console.WriteLine("Error moving files: ");
            }

            KVVLog.Write("CopyFiles");
        }

        public static void ZipFiles(string path, string path2, string path3)
        {
            try
            {
                ZipFile.CreateFromDirectory(path, path2);
            }
            catch
            {
                Console.WriteLine("Error creating archive:");
            }
            try
            {
                ZipFile.ExtractToDirectory(path2, path3);
                Console.WriteLine("Archive has been dearchivized");
            }
            catch
            {
                Console.WriteLine("Error dearchiving the archive:");
            }
            KVVLog.Write("ZipFiles");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            KVVDiskInfo.GetFreeDiskSpace();
            KVVFileInfo.GetFullPath("lab12.exe");
            KVVFileInfo.GetFileInfo("lab12.exe");
            KVVDirInfo.GetDirInfo("Test");
            KVVFileManager.GetAllFilesAndDir("D:\\education\\2025\\Poit_3sem\\OOP_3sem\\labSolutions\\labs\\lab12\\bin\\Debug\\net8.0");
            KVVFileManager.CreateDir("BNAInspect");
            KVVFileManager.CreateDir("BNAFiles");
            KVVFileManager.CreateFile("test.txt");
            KVVFileManager.CopyFile("D:\\education\\2025\\Poit_3sem\\OOP_3sem\\labSolutions\\labs\\lab12\\bin\\Debug\\net8.0\\test.txt",
                "D:\\education\\2025\\Poit_3sem\\OOP_3sem\\labSolutions\\labs\\lab12\\bin\\Debug\\net8.0\\Test\\text.txt");
            KVVFileManager.ZipFiles("D:\\education\\2025\\Poit_3sem\\OOP_3sem\\labSolutions\\labs\\lab12\\bin\\Debug\\net8.0\\Test",
                "D:\\education\\2025\\Poit_3sem\\OOP_3sem\\labSolutions\\labs\\lab12\\bin\\Debug\\net8.0\\zip.zip",
                "D:\\education\\2025\\Poit_3sem\\OOP_3sem\\labSolutions\\labs\\lab12\\bin\\Debug\\net8.0\\Norm");

        }
    }
}
