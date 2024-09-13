using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{

    /////////////////////////////////// Основной класс ///////////////////////////////////
    public class MyArray<T> where T : IComparable<T>
    {
        private T[] _data;
        private int _size;

        public MyArray(int size)
        {
            _size = size;
            _data = new T[size];
        }

        // Метод для установки значения по индексу
        public void SetElement(int index, T value)
        {
            if (index >= 0 && index < _size)
            {
                _data[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс вне допустимого диапазона.");
            }
        }

        // Метод для получения значения по индексу
        public T GetElement(int index)
        {
            if (index >= 0 && index < _size)
            {
                return _data[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс вне допустимого диапазона.");
            }
        }

        // Метод для получения размера массива
        public int Size()
        {
            return _size;
        }

        // Перегрузка оператора true: возвращает true, если все элементы не отрицательные
        public static bool operator true(MyArray<T> array)
        {
            foreach (var item in array._data)
            {
                if (item is IComparable && Convert.ToDouble(item) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Перегрузка оператора false: возвращает true, если есть отрицательные элементы
        public static bool operator false(MyArray<T> array)
        {
            foreach (var item in array._data)
            {
                if (item is IComparable && Convert.ToDouble(item) < 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Перегрузка оператора "-"
        public static MyArray<T> operator -(MyArray<T> array, T scalar)
        {
            MyArray<T> result = new MyArray<T>(array._size);
            for (int i = 0; i < array._size; i++)
            {
                // Для числовых типов, вычитаем scalar (преобразуем к double для выполнения операции)
                result.SetElement(i, (T)Convert.ChangeType(Convert.ToDouble(array.GetElement(i)) - Convert.ToDouble(scalar), typeof(T)));
            }
            return result;
        }

        // Перегрузка оператора ">" для проверки вхождения элемента
        public static bool operator >(MyArray<T> array, T element)
        {
            foreach (var item in array._data)
            {
                if (item.CompareTo(element) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Перегрузка оператора "<" - требуется для пары с оператором ">"
        public static bool operator <(MyArray<T> array, T element)
        {
            return !(array > element);
        }

        // Перегрузка оператора "!="
        public static bool operator !=(MyArray<T> array1, MyArray<T> array2)
        {
            if (array1._size != array2._size)
            {
                return true;
            }

            for (int i = 0; i < array1._size; i++)
            {
                if (!array1.GetElement(i).Equals(array2.GetElement(i)))
                {
                    return true;
                }
            }

            return false;
        }

        // Перегрузка оператора "==" (обязательная пара для !=)

        public static bool operator ==(MyArray<T> array1, MyArray<T> array2)
        {
            if (array1._size != array2._size)
            {
                return false;
            }

            for (int i = 0; i < array1._size; i++)
            {
                if (!array1.GetElement(i).Equals(array2.GetElement(i)))
                {
                    return false;
                }
            }

            return true;
        }

        // Перегрузка оператора "+"
        public static MyArray<T> operator +(MyArray<T> array1, MyArray<T> array2)
        {
            MyArray<T> result = new MyArray<T>(array1._size + array2._size);

            for (int i = 0; i < array1._size; i++)
            {
                result.SetElement(i, array1.GetElement(i));
            }

            for (int i = 0; i < array2._size; i++)
            {
                result.SetElement(i + array1._size, array2.GetElement(i));
            }

            return result;
        }

        /////////////////////////////////// Класс Production ///////////////////////////////////
        public class Production
        {
            private readonly int _organisationID;
            public string OrganisationName { get; set; }

            // Конструктор 
            public Production()
            {
                _organisationID = GetHashCode();
            }

            // Конструктор с параметрами
            public Production(string name)
            {
                _organisationID = GetHashCode();
                this.OrganisationName = name;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        /////////////////////////////////// Класс Developer ///////////////////////////////////
        public class Developer
        {
            private readonly int _developerID;

            public string Name { get; set; }
            public string Department { get; set; }

            // Конструктор 
            public Developer()
            {
                _developerID = GetHashCode();
            }

            // Конструктор с параметрами
            public Developer(string name, string department)/*Это конструктор класса Developer*/
            {
                _developerID = GetHashCode();
                this.Name = name;
                this.Department = department;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}