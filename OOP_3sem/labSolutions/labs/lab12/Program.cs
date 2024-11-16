using System; // Подключение пространства имен для базовых функций C#
using static System.Net.Mime.MediaTypeNames; // Подключение пространства имен для работы с типами мультимедиа
using System.IO; // Подключение пространства имен для работы с файлами и директориями
using System.Text; // Подключение пространства имен для работы с текстом и кодировками
using System.Reflection; // Подключение пространства имен для работы с отражением
using System.Collections.Specialized; // Подключение пространства имен для работы с коллекциями
using System.IO.Compression; // Подключение пространства имен для работы с архивами
using System.Data.SqlTypes; // Подключение пространства имен для работы с SQL типами данных

namespace Lab12 // Объявление пространства имен Lab12
{
    // Статический класс для ведения логов
    public static class BNALog
    {
        static string logfile = "BNAlogfile.txt"; // Имя файла лога

        // Метод для записи информации в лог
        public static void Write(string method, string filename = null)
        {
            string textFromLogFile = Read(); // Чтение текущего содержимого файла лога
            textFromLogFile += $"Date - {DateTime.Now}" + (filename != null ? $"\nFile - {filename} \n" : "\n")
                + $"Method - {method}\n"; // Форматирование записи с датой, именем метода и файла, если задан

            using (StreamWriter writer = new StreamWriter(logfile, false)) // Открытие файла для записи
            {
                writer.WriteLine(textFromLogFile); // Запись информации в файл лога
            }
        }

        // Метод для чтения информации из лога
        public static string Read()
        {
            using (StreamReader reader = new StreamReader(logfile)) // Открытие файла для чтения
            {
                string text = reader.ReadToEnd(); // Чтение всего содержимого файла
                return text; // Возвращение содержимого файла
            }
        }

        // Метод для поиска строки в лог-файле
        public static bool Find(string str)
        {
            string text = Read(); // Чтение содержимого лога
            if (text.IndexOf(str) != -1) // Поиск строки в содержимом лога
            {
                return true; // Возвращает true, если строка найдена
            }
            return false; // Возвращает false, если строка не найдена
        }
    }

    // Класс для получения информации о дисках
    public class BNADiskInfo
    {
        // Метод для получения информации о свободном месте на диске
        public static void GetFreeDiskSpace(string driveName)
        {
            DriveInfo drive = new DriveInfo(driveName); // Получение информации о диске
            if (drive.IsReady) // Проверка доступности диска
            {
                Console.WriteLine($"Свободное место на диске {drive.Name}: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ"); // Вывод информации о свободном месте
            }
            else
            {
                Console.WriteLine($"Диск {driveName} недоступен."); // Сообщение, если диск недоступен
            }
        }

        // Метод для получения информации о файловой системе
        public static void GetFileSystemInfo(string driveName)
        {
            DriveInfo drive = new DriveInfo(driveName); // Получение информации о диске
            if (drive.IsReady) // Проверка доступности диска
            {
                Console.WriteLine($"Файловая система на диске {drive.Name}: {drive.DriveFormat}"); // Вывод информации о файловой системе
            }
            else
            {
                Console.WriteLine($"Диск {driveName} недоступен."); // Сообщение, если диск недоступен
            }
        }

        // Метод для вывода информации по всем существующим дискам
        public static void GetAllDrivesInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives(); // Получение массива дисков

            foreach (DriveInfo drive in drives) // Перебор каждого диска
            {
                if (drive.IsReady) // Проверка доступности диска
                {
                    Console.WriteLine($"Диск: {drive.Name}"); // Вывод имени диска
                    Console.WriteLine($"Файловая система: {drive.DriveFormat}"); // Вывод файловой системы
                    Console.WriteLine($"Полный объем: {drive.TotalSize / (1024 * 1024 * 1024)} ГБ"); // Вывод полного объема
                    Console.WriteLine($"Доступный объем: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ"); // Вывод доступного объема
                    Console.WriteLine($"Метка тома: {drive.VolumeLabel}"); // Вывод метки тома
                    Console.WriteLine(); // Пустая строка для разделения выводов
                }
                else
                {
                    Console.WriteLine($"Диск {drive.Name} недоступен."); // Сообщение, если диск недоступен
                }
            }
        }
    }

    // Класс для работы с файлами
    public class BNAFileInfo
    {
        // Метод для вывода полного пути файла
        public static void GetFullPath(string filePath)
        {
            if (File.Exists(filePath)) // Проверка существования файла
            {
                FileInfo fileInfo = new FileInfo(filePath); // Получение информации о файле
                Console.WriteLine($"Полный путь: {fileInfo.FullName}"); // Вывод полного пути
            }
            else
            {
                Console.WriteLine("Файл не существует."); // Сообщение, если файл не существует
            }
        }

        // Метод для вывода информации о размере, расширении и имени файла
        public static void GetBasicInfo(string filePath)
        {
            if (File.Exists(filePath)) // Проверка существования файла
            {
                FileInfo fileInfo = new FileInfo(filePath); // Получение информации о файле
                Console.WriteLine($"Имя файла: {fileInfo.Name}"); // Вывод имени файла
                Console.WriteLine($"Размер файла: {fileInfo.Length} байт"); // Вывод размера файла
                Console.WriteLine($"Расширение файла: {fileInfo.Extension}"); // Вывод расширения файла
            }
            else
            {
                Console.WriteLine("Файл не существует."); // Сообщение, если файл не существует
            }
        }

        // Метод для вывода информации о дате создания и изменения файла
        public static void GetFileInfo(string filePath)
        {
            if (File.Exists(filePath)) // Проверка существования файла
            {
                FileInfo fileInfo = new FileInfo(filePath); // Получение информации о файле
                Console.WriteLine($"Дата создания: {fileInfo.CreationTime}"); // Вывод даты создания
                Console.WriteLine($"Дата последнего изменения: {fileInfo.LastWriteTime}"); // Вывод даты последнего изменения
            }
            else
            {
                Console.WriteLine("Файл не существует."); // Сообщение, если файл не существует
            }
        }
    }

    // Класс для получения информации о директориях
    public class BNADirInfo
    {
        public static void GetDirInfo(string dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName); // Получение информации о директории
            Console.WriteLine("\nDir name:       " + dirInfo.Name +
                              "\nFiles amount:   " + dirInfo.GetFiles().Length + // Вывод количества файлов
                              "\nCreating time:  " + dirInfo.LastWriteTime + // Вывод времени создания
                              "\nSubDirs amount: " + dirInfo.GetDirectories().Length + // Вывод количества поддиректорий
                              "\nParent dir: " +     dirInfo.Parent.Name); // Вывод родительской директории
            BNALog.Write("GetFileInfo", dirName); // Логирование действия
        }
    }

    // Класс для управления файлами и директориями
    public class BNAFileManager
    {
        // a. Чтение списка файлов и папок, создание директории и текстового файла, запись информации и удаление исходного файла
        public static void GetAllFilesAndDir(string driveName)
        {
            // Проверяем, существует ли диск
            if (!Directory.Exists(driveName))
            {
                Console.WriteLine("Диск не существует.");
                return;
            }

            // Создание директории XXXInspect
            string inspectDir = Path.Combine(driveName, "BNAInspect");
            Directory.CreateDirectory(inspectDir);

            // Создание и запись в текстовый файл xxxdirinfo.txt
            string filePath = Path.Combine(inspectDir, "BNAdirinfo.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Записываем список файлов и папок
                writer.WriteLine("Список файлов и папок:");
                foreach (var directory in Directory.GetDirectories(driveName))
                {
                    writer.WriteLine("Директория: " + directory);
                }
                foreach (var file in Directory.GetFiles(driveName))
                {
                    writer.WriteLine("Файл: " + file);
                }
            }

            // Копирование и переименование файла
            string copyFilePath = Path.Combine(inspectDir, "BNAdirinfo_copy.txt");
            if (File.Exists(copyFilePath))
            {
                File.Delete(copyFilePath); // Удаление, если директория уже существует
            }
            File.Copy(filePath, copyFilePath);
            File.Delete(filePath); // Удаление оригинального файла
        }

        // b. Создание XXXFiles, копирование файлов с заданным расширением, перемещение XXXFiles в XXXInspect
        public static void CopyFilesWithExtension(string sourceDir, string extension)
        {
            // Проверка существования исходного каталога
            if (!Directory.Exists(sourceDir))
            {
                Console.WriteLine("Исходный каталог не существует.");
                return;
            }

            // Создание директории XXXFiles
            string filesDir = Path.Combine(sourceDir, "BNAFiles");
            Directory.CreateDirectory(filesDir);

            // Копирование файлов с указанным расширением
            foreach (var file in Directory.GetFiles(sourceDir, $"*{extension}"))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(filesDir, fileName);
                File.Copy(file, destFile, true);
            }

            // Перемещение директории XXXFiles в XXXInspect
            string inspectDir = Path.Combine(sourceDir, "BNAInspect");
            if (!Directory.Exists(inspectDir))
            {
                Directory.CreateDirectory(inspectDir);
            }

            string newFilesDir = Path.Combine(inspectDir, "BNAFiles");
            if (Directory.Exists(newFilesDir))
            {
                Directory.Delete(newFilesDir, true); // Удаление, если директория уже существует
            }
            Directory.Move(filesDir, newFilesDir);
        }

        // c. Создание архива из директории XXXFiles и разархивация его в другую директорию
        public static void ArchiveAndExtractFiles(string sourceDir)
        {
            string filesDir = Path.Combine(sourceDir, "BNAInspect", "BNAFiles");

            // Проверка существования XXXFiles
            if (!Directory.Exists(filesDir))
            {
                Console.WriteLine("Каталог BNAFiles не найден.");
                return;
            }

            // Создание архива
            string zipPath = Path.Combine(sourceDir, "BNAFiles.zip");
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath); // Удаление, если файл уже существует
            }
            ZipFile.CreateFromDirectory(filesDir, zipPath);

            // Разархивация архива в другую директорию
            string extractPath = Path.Combine(sourceDir + "", "ExtractedFiles");
            if (Directory.Exists(extractPath))
            {
                Directory.Delete(extractPath, true); // Удаление, если файл уже существует
            }
            Directory.CreateDirectory(extractPath);


            ZipFile.ExtractToDirectory(zipPath, extractPath);

            Console.WriteLine("Архивирование и разархивирование выполнено успешно.");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            BNADiskInfo.GetFreeDiskSpace("D"); // Получение информации о свободном месте на диске D
            BNAFileInfo.GetFullPath("lab12.exe"); // Получение полного пути к файлу lab12.exe
            BNAFileInfo.GetFileInfo("lab12.exe"); // Получение информации о файле lab12.exe
            BNADirInfo.GetDirInfo("test"); // Получение информации о директории Test
            BNAFileManager.GetAllFilesAndDir("..\\net8.0"); // Получение всех файлов и директорий по пути ..\net8.0
            BNAFileManager.CopyFilesWithExtension("..\\net8.0", ".txt"); // b
            BNAFileManager.ArchiveAndExtractFiles("..\\net8.0");


        }
     }
}
