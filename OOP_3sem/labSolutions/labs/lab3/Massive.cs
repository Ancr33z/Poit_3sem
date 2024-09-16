using System;
using System.Linq;

public class OneDimensionalArray 
{
    public int[] _array;

    public OneDimensionalArray(int size) // Инициализания нашего массива (конструктор)
    {
        _array = new int[size];
    }

    public int this[int index]
    {
        get => _array[index];
        set => _array[index] = value;
    }

    // Перегрузка вычитания со скалярным значением
    public static OneDimensionalArray operator -(OneDimensionalArray array, int scalar)
    {
        var result = new OneDimensionalArray(array._array.Length);
        for (int i = 0; i < array._array.Length; i++)
        {
            result[i] = array._array[i] - scalar;
        }
        return result;
    }

    // Проверка на вхождение элемента
    public static bool operator >(OneDimensionalArray array, int element)
    {
        return array._array.Contains(element);
    }

    public static bool operator <(OneDimensionalArray array, int element)
    {
        return array._array.Contains(element);
    }

    // Проверка на неравенство массивов
    public static bool operator ==(OneDimensionalArray array1, OneDimensionalArray array2)
    {
        return array1._array.SequenceEqual(array2._array);
    }
    public static bool operator !=(OneDimensionalArray array1, OneDimensionalArray array2)
    {
        return !array1._array.SequenceEqual(array2._array);
    }

    // Объединение массивов
    public static OneDimensionalArray operator +(OneDimensionalArray array1, OneDimensionalArray array2)
    {
        var result = new OneDimensionalArray(array1._array.Length + array2._array.Length);
        for (int i = 0; i < array1._array.Length; i++)
        {
            result[i] = array1._array[i];
        }
        for (int i = 0; i < array2._array.Length; i++)
        {
            result[i + array1._array.Length] = array2._array[i];
        }
        return result;
    }

    ////////////////////////////////////// Задание 2 (класс Production) //////////////////////////////////////
    public class Production // Класс по заданию 
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }

        public Production(int id, string organizationName)// Конструктор 
        {
            Id = id;
            OrganizationName = organizationName;
        }
    }

    ////////////////////////////////////// Задание 3 (класс Developer) //////////////////////////////////////
    public class Developer // Класс по заданию 
    {
        public string FullName { get; set; }
        public int Id { get; set; }
        public string Department { get; set; }

        public Developer(string fullName, int id, string department) // Конструктор 
        {
            FullName = fullName;
            Id = id;
            Department = department;
        }
    }

    ////////////////////////////////////// Задание 4 //////////////////////////////////////
    public static class StatisticOperation
    {
        public static int Sum(OneDimensionalArray array) // функция для суммы элементов массива(вызывается функция массивов а не локальная)
        {
            return array._array.Sum();
        }

        public static int Difference(OneDimensionalArray array) // Сравнение максимально и минимального элемента
        {
            return array._array.Max() - array._array.Min();
        }

        public static int Count(OneDimensionalArray array) // Вычисление длинны массива
        {
            return array._array.Length;
        }
    }
}
