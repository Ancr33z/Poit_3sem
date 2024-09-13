using System;
using lab3;

namespace lab3
{
    public class Program
    {
        public static void Main()
        {
            // Инициализация объектов классов Production и Developer
            MyArray<int>.Production production1 = new MyArray<int>.Production("Tech Corp");
            MyArray<int>.Developer developer1 = new MyArray<int>.Developer("Антон", "Software Development");

            // Вывод информации о производстве
            Console.WriteLine("Информация о производстве:");
            Console.WriteLine($"Название организации: {production1.OrganisationName}");

            // Вывод информации о разработчике
            Console.WriteLine("\nИнформация о разработчике:");
            Console.WriteLine($"Имя: {developer1.Name}");
            Console.WriteLine($"Отдел: {developer1.Department}");

            // Тестирование перегруженных операций с MyArray<int>
            MyArray<int> array1 = new MyArray<int>(5);
            MyArray<int> array2 = new MyArray<int>(5);

            // Заполняем массивы значениями
            for (int i = 0; i < 5; i++)
            {
                array1.SetElement(i, i + 1);  // Массив [1, 2, 3, 4, 5]
                array2.SetElement(i, i + 6);  // Массив [6, 7, 8, 9, 10]
            }

            // Перегруженная операция "+"
            MyArray<int> combinedArray = array1 + array2;
            Console.WriteLine("\nРезультат сложения двух массивов:");
            for (int i = 0; i < combinedArray.Size(); i++)
            {
                Console.Write($"{combinedArray.GetElement(i)} ");
            }

            // Перегруженная операция "!="
            bool areNotEqual = array1 != array2;
            Console.WriteLine($"\n\nМассивы array1 и array2 не равны: {areNotEqual}");

            // Перегруженная операция ">" (проверка вхождения элемента)
            bool containsValue = array1 > 3;  // Проверяем, содержится ли число 3 в array1
            Console.WriteLine($"Массив array1 содержит элемент 3: {containsValue}");

            // Перегруженная операция "-"
            MyArray<int> subtractedArray = array1 - 2;  // Вычитаем 2 из каждого элемента массива
            Console.WriteLine("\nРезультат вычитания 2 из каждого элемента массива array1:");
            for (int i = 0; i < subtractedArray.Size(); i++)
            {
                Console.Write($"{subtractedArray.GetElement(i)} ");
            }
        }
    }
}
