using Newtonsoft.Json;
using System.IO;

namespace lab7
{
    internal class GenericAndFiles
    {
        // Метод для записи массива в JSON-файл
        public static void WriteArray<T>(OneDimensionalArray<T> array) where T : IComparable<T>
        {
            JsonSerializer serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            using (StreamWriter sw = new StreamWriter(@"D:\education\2025\Poit_3sem\OOP_3sem\labSolutions\labs\lab7\Data.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, array._array);
            }
        }

        public static void ReadArray<T>(OneDimensionalArray<T> array) where T : class, IComparable<T>
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            // Чтение JSON-файла
            using var stream = new StreamReader(@"D:\education\2025\Poit_3sem\OOP_3sem\labSolutions\labs\lab7\Data.json");
            string jsonData = stream.ReadToEnd();

            // Десериализация массива данных
            T[] deserializedArray = JsonConvert.DeserializeObject<T[]>(jsonData, settings);

            // Проверка на размер массива и переинициализация при необходимости
            if (deserializedArray.Length > array._array.Length)
            {
                array = new OneDimensionalArray<T>(deserializedArray.Length);
            }

            // Заполнение нашего массива десериализованными данными
            for (int i = 0; i < deserializedArray.Length; i++)
            {
                array.AddItem(deserializedArray[i]);
            }
        }



    }
}
