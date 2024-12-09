using System;
using static System.Net.Mime.MediaTypeNames; // Подключение пространства имен для работы с типами мультимедиа
using System.IO; // Подключение пространства имен для работы с файлами и директориями
using System.Text;
using System.Reflection;
using System.Collections.Specialized;
using System.IO.Compression; // Подключение пространства имен для работы с архивами
using System.Data.SqlTypes;
using System.Reflection.Metadata;

namespace Lab12
{
    /*.1) Создать класс XXXLog. Он должен отвечать за работу с текстовым файлом
    xxxlogfile.txt. в который записываются все действия пользователя и
    соответственно методами записи в текстовый файл, чтения, поиска нужной
    информации.
    a. Используя данный класс выполните запись всех
    последующих действиях пользователя с указанием действия,
    детальной информации (имя файла, путь) и времени
    (дата/время)
*/
    public static class KVVLog//1)Класс XXXLog для работы с текстовым файлом xxxlogfile.txt
    {
        static string logfile = "BNAlogfile.txt";

        // Метод для записи информации в лог
        public static void Write(string method, string filename = null)
        {
            string textFromLogFile = Read(); // 1)Чтение текущего содержимого файла лога
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
            if (text.IndexOf(str) != -1) // 1)Поиск строки в содержимом лога
            {
                return true; // Возвращает true, если строка найдена
            }
            return false; // Возвращает false, если строка не найдена
        }
        public static void FilterAndSaveLastHourEntries(string filePath)//6)отсавляет послежние записи за час
        {
            // Проверяем существование файла
            if (!File.Exists(filePath))//Exists: Проверяет, существует ли указанная директория
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            // Читаем все строки из файла
            string[] logEntries = File.ReadAllLines(filePath);

            // Получаем текущую дату и время
            DateTime currentDateTime = DateTime.Now;//получветс=т текущее время 

            // Хранилище для записей за последний час
            var lastHourEntries = new System.Collections.Generic.List<string>();

            Console.WriteLine("Записи за последний час:");
            int counters = 0; // <-------------------------------------------------------------- для подсчёта 
            // Перебираем строки и отбираем записи за последний час
            for (int i = 0; i < logEntries.Length; i++)
            {
                if (logEntries[i].StartsWith("Date -"))//сначало считывается такой формат
                {
                    string datePart = logEntries[i].Substring(7).Trim();//начинаем с 7 симвроа потому что дата и пробьелы 
                    /*Substring — это метод строкового класса String в C#, который позволяет извлечь подстроку из строки. Он возвращает часть строки, начиная с указанного индекса, и (опционально) заданной длины.*/

                    // Пытаемся преобразовать дату в объект DateTime
                    if (DateTime.TryParse(datePart, out DateTime logDate))//преобразовываем  в обект чтобы сравнито с текщим
                    {
                        // Проверяем, находится ли дата в последнем часу
                        if (logDate > currentDateTime.AddHours(-1) && logDate <= currentDateTime)//лог(в файле) должно быть больше чем прошлый час и меньше или равно текущему времени
                        {
                            counters++;// <----------------------------------------------------------- тут считаем
                            // Добавляем запись и связанные строки в список
                            lastHourEntries.Add(logEntries[i]);//добавлем дату
                            Console.WriteLine(logEntries[i]); // Вывод в консоль

                            if (i + 1 < logEntries.Length)
                            {
                                lastHourEntries.Add(logEntries[i + 1]);
                                Console.WriteLine(logEntries[i + 1]); // Вывод в консоль
                            }
                            //Проверяется, существуют ли в массиве следующие 1–2 строки (с индексами i + 1 и i + 2), чтобы избежать выхода за пределы массива.
                            if (i + 2 < logEntries.Length)
                            {
                                lastHourEntries.Add(logEntries[i + 2]);
                                Console.WriteLine(logEntries[i + 2]); // Вывод в консоль
                            }
                        }
                    }
                }
            }

            // Перезаписываем файл только записями за последний час
            File.WriteAllLines(filePath, lastHourEntries);

            Console.WriteLine("Количество записей на момент просмотра файла, перед удалением: {0}", counters);
            Console.WriteLine("Файл обновлён. Остались только записи за последний час.");
        }
    }

    // Класс для получения информации о дисках
    /*2)Создать класс XXXDiskInfo c методами для вывода информации о
    a. свободном месте на диске
    b. Файловой системе
    c. Для каждого существующего диска - имя, объем, доступный
    объем, метка тома.
    d. Продемонстрируйте работу класса
    */
    public class KVVDiskInfo
    {
        //2a) Метод для получения информации о свободном месте на диске
        public static void GetFreeDiskSpace(string driveName)
        {
            DriveInfo drive = new DriveInfo(driveName); // Получение информации о диске
            if (drive.IsReady) // Проверка доступности диска есть ли ответ от диска
            {
                Console.WriteLine($"Свободное место на диске {drive.Name}: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ"); // Вывод информации о свободном месте
            }
            else
            {
                Console.WriteLine($"Диск {driveName} недоступен."); // Сообщение, если диск недоступен
            }
        }

        //2b. Метод для получения информации о файловой системе
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

        //2 c. Метод для получения информации о всех существующих дисках
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
    /*3 Создать класс XXXFileInfo c методами для вывода информации о
    конкретном файле
    a. Полный путь
    b. Размер, расширение, имя
    c. Дата создания, изменения
    d. Продемонстрируйте работу класса*/
    public class KVVFileInfo
    {
        // 3a. Метод для получения полного пути к файлу
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

        //2b Метод для вывода информации о размере, расширении и имени файла
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

        //3 c. Метод для вывода информации о дате создания и изменения файла
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
    /*. Создать класс XXXDirInfo c методами для вывода информации о конкретном
директории
    a. Количестве файлов
    b. Время создания
    c. Количестве поддиректориев
    d. Список родительских директориев
    e. Продемонстрируйте работу класса*/
    public class KVVDirInfo
    {
        public static void GetDirInfo(string dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName); // Получение информации о директории
            Console.WriteLine("\nDir name:       " + dirInfo.Name +
                              "\nFiles amount:   " + dirInfo.GetFiles().Length + // Вывод количества файлов
                              "\nCreating time:  " + dirInfo.LastWriteTime + // Вывод времени создания
                              "\nSubDirs amount: " + dirInfo.GetDirectories().Length + // Вывод количества поддиректорий
                              "\nParent dir: " + dirInfo.Parent.Name); // Вывод родительской директории
            KVVLog.Write("GetFileInfo", dirName); // 1)Логирование действия
        }
    }

    // Класс для управления файлами и директориями
    /*Создать класс XXXFileManager. Набор методов определите
самостоятельно. С его помощью выполнить следующие действия:
a. Прочитать список файлов и папок заданного диска. Создать
директорий XXXInspect, создать текстовый файл
xxxdirinfo.txt и сохранить туда информацию. Создать
копию файла и переименовать его. Удалить
первоначальный файл.
b. Создать еще один директорий XXXFiles. Скопировать в
него все файлы с заданным расширением из заданного
пользователем директория. Переместить XXXFiles в
XXXInspect.
c. Сделайте архив из файлов директория XXXFiles.
Разархивируйте его в другой директорий*/
    public class KVVFileManager
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
            string inspectDir = Path.Combine(driveName, "BNAInspect");//комбинирует путь и доболяет 
            Directory.CreateDirectory(inspectDir);

            // Создание и запись в текстовый файл xxxdirinfo.txt
            string filePath = Path.Combine(inspectDir, "BNAdirinfo.txt");//путь к файлу 
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
            if (File.Exists(copyFilePath))//существует ли
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
            string filesDir = Path.Combine(sourceDir, "BNAFiles");//параметр который мы передаем
            Directory.CreateDirectory(filesDir);

            // Копирование файлов с указанным расширением
            foreach (var file in Directory.GetFiles(sourceDir, $"*{extension}"))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(filesDir, fileName);//чтобы в копию записатот путь и файл
                File.Copy(file, destFile, true);//лдля перезаписи
            }

            // Перемещение директории XXXFiles в XXXInspect
            string inspectDir = Path.Combine(sourceDir, "BNAInspect");//еще один директорий
            if (!Directory.Exists(inspectDir))
            {
                Directory.CreateDirectory(inspectDir);
            }

            string newFilesDir = Path.Combine(inspectDir, "BNAFiles");//комбинируем файл
            if (Directory.Exists(newFilesDir))
            {
                Directory.Delete(newFilesDir, true); // Удаление, если директория уже существует
            }
            Directory.Move(filesDir, newFilesDir);//переместить из файлс 
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


            ZipFile.ExtractToDirectory(zipPath, extractPath);//перенести из зип в папку

            Console.WriteLine("Архивирование и разархивирование выполнено успешно.");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            KVVDiskInfo.GetFreeDiskSpace("D"); // Получение информации о свободном месте на диске D
            KVVFileInfo.GetFullPath("lab12.exe"); // Получение полного пути к файлу lab12.exe
            KVVFileInfo.GetFileInfo("lab12.exe"); // Получение информации о файле lab12.exe
            KVVDirInfo.GetDirInfo("test"); // Получение информации о директории Test
            KVVFileManager.GetAllFilesAndDir("..\\net8.0"); // Получение всех файлов и директорий по пути ..\net8.0
            KVVDiskInfo.GetFileSystemInfo("D");
            KVVFileManager.CopyFilesWithExtension("..\\net8.0", ".txt"); // b
            KVVFileManager.ArchiveAndExtractFiles("..\\net8.0");

            string logFilePath = "ExtractedFiles/BNAlogfile.txt";

            // Читаем и выводим записи за последний час
            KVVLog.FilterAndSaveLastHourEntries(logFilePath);
        }
    }
}
