using System;
using System.Linq;

namespace lab7
{
    public class OneDimensionalArray<T> : IGeneralized<T> where T : IComparable<T>
    {
        public T[] _array;
        private int _count;
        public OneDimensionalArray(int size = 100) // Инициализания нашего массива (конструктор)
        {
            _array = new T[size];
            _count = 0;
        }

        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }



        public void AddItem(T data)
        {
            if (_count >= _array.Length)
            {
                Console.WriteLine("Массив заполнен, нельзя добавить элемент.");
                return;
            }

            _array[_count] = data;
            _count++;
        }

        public void DeleteItem(T data)
        {
            if (_count == 0)
            {
                Console.WriteLine("Массив пуст, удаление невозможно.");
                return;
            }

            int indexToRemove = -1;

            // Находим индекс элемента, который нужно удалить
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_array[i], data))
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove == -1)
            {
                Console.WriteLine("Элемент не найден.");
                return;
            }

            // Сдвигаем все элементы после удаленного на одну позицию влево
            for (int i = indexToRemove; i < _count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _count--;
            _array[_count] = default; // Устанавливаем последний элемент в значение по умолчанию
        }
        public void Show()
        {
            if (_count == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }

            for (int i = 0; i < _count; i++)
            {
                if (_array[i] != null)  
                Console.WriteLine($"{_array[i]}");
            }

        }

        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(_array[i]))
                {
                    return _array[i];
                }
            }
            return default; // Возвращает значение по умолчанию, если элемент не найден
        }

        // Перегрузка вычитания со скалярным значением
        public static OneDimensionalArray<T> operator -(OneDimensionalArray<T> array, int scalar) 
        {
            var result = new OneDimensionalArray<T>(array._array.Length);
            for (int i = 0; i < array._array.Length; i++)
            {
                result[i] = (dynamic)array._array[i] - scalar;
            }
            return result;
        }

        // Проверка на вхождение элемента
        // Перегрузка оператора ">"
        public static bool operator >(OneDimensionalArray<T> array, T element) 
        {
            foreach (var item in array._array)
            {
                if (item.CompareTo(element) > 0) // Сравниваем элементы массива с заданным значением
                {
                    return true;
                }
            }
            return false;
        }

        // Перегрузка оператора "<"
        public static bool operator <(OneDimensionalArray<T> array, T element)
        {
            foreach (var item in array._array)
            {
                if (item.CompareTo(element) < 0) // Сравниваем элементы массива с заданным значением
                {
                    return true;
                }
            }
            return false;
        }

        // Проверка на неравенство массивов
        public static bool operator ==(OneDimensionalArray<T> array1, OneDimensionalArray<T> array2)
        {
            return array1._array.SequenceEqual(array2._array);
        }
        public static bool operator !=(OneDimensionalArray<T> array1, OneDimensionalArray<T> array2)
        {
            return !array1._array.SequenceEqual(array2._array);
        }

        // Объединение массивов
        public static OneDimensionalArray<T> operator +(OneDimensionalArray<T>  array1, OneDimensionalArray<T> array2)
        {
            var result = new OneDimensionalArray<T>(array1._array.Length + array2._array.Length);
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

        public override bool Equals(object obj)
        {
            // Проверяем, что объект не null и является OneDimensionalArray<T>
            if (obj == null || !(obj is OneDimensionalArray<T>))
                return false;

            // Приводим объект к типу OneDimensionalArray<T>
            var otherArray = (OneDimensionalArray<T>)obj;

            // Сравниваем массивы поэлементно
            return _array.SequenceEqual(otherArray._array);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        
    }
}