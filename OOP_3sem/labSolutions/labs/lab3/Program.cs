using System;
using System.Linq;
using static OneDimensionalArray;

public class Program
{
    public static void Main()
    {
        ////////////////////////////////////// Инициализация массивов и вывод их на экран //////////////////////////////////////

        OneDimensionalArray array1 = new OneDimensionalArray(5);

        Console.WriteLine($"Первый массив: ");
        for (int i = 0; i < 5; i++)
        {
            array1[i] = i + 1; // {1, 2, 3, 4, 5}
            Console.Write($"{array1[i]} ");
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine($"Второй массив: ");
        OneDimensionalArray array2 = new OneDimensionalArray(3);
        for (int i = 0; i < 3; i++)
        {
            array2[i] = i + 6; // {6, 7, 8}
            Console.Write($"{array2[i]} ");
        }

        Console.WriteLine();

        ////////////////////////////////////// Проверка работы перегруженных операций для массивов  //////////////////////////////////////

        Console.WriteLine();
        OneDimensionalArray array3 = array1 + array2; // Объединение массивов
        Console.WriteLine("Объединенный массив: " + string.Join(", ", array3._array));

        var resultArray = array1 - 2; // Разность с 2
        Console.WriteLine("Разность с 2 первого массива: " + string.Join(", ", resultArray._array));

        Console.WriteLine("Содержит ли первый массив 3? " + (array1 > 3));

        Console.WriteLine("Массивы не равны? " + (array1 != array2));

        Console.WriteLine("Сумма элементов первого массива: " + OneDimensionalArray.StatisticOperation.Sum(array1));
        Console.WriteLine("Разница между макс и мин элементов первого массива: " + OneDimensionalArray.StatisticOperation.Difference(array1));
        Console.WriteLine("Количество элементов первого массива: " + OneDimensionalArray.StatisticOperation.Count(array1));

        ////////////////////////////////////// 2 Задание (инициализация класса Production и вывод на экран) //////////////////////////////////////

        Console.WriteLine();
        OneDimensionalArray.Production prod = new OneDimensionalArray.Production(25, "NewCompany");
        Console.WriteLine($"Id компании: {prod.Id}, название компании: {prod.OrganizationName}");

        ////////////////////////////////////// 3 Задание (инициализация класса Developerи вывод на экран) //////////////////////////////////////

        Console.WriteLine();
        OneDimensionalArray.Developer programer = new OneDimensionalArray.Developer("Borisov N. A.", 1, "SoftWare");
        Console.WriteLine($"Имя разработчика : {programer.FullName}, Id программиста: {programer.Id}, отдел работы: {programer.Department}");

        ////////////////////////////////////// Проверка работы расширений для строк (5 задание) //////////////////////////////////////

        Console.WriteLine();
        string testString = "Hello World!";
        Console.WriteLine($"Начальная строка {testString}");
        Console.WriteLine("Строка без гласных: " + StatisticOperation.RemoveVowels(testString));
        Console.WriteLine("Строка без первых пяти элементов: " + StatisticOperation.RemoveFirstFiveElements(testString));

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}