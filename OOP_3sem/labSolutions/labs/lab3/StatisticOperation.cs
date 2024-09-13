using System;


namespace lab3
{
    public static class StatisticOperation
    {
        // Метод для вычисления суммы элементов массива
        // Метод для вычисления суммы элементов массива
        public static T Sum<T>(MyArray<T> array) where T : IComparable<T>, IConvertible
        {
            dynamic sum = 0;  // Используем dynamic для поддержки числовых типов
            for (int i = 0; i < array.Size(); i++)
            {
                sum += array.GetElement(i);
            }
            return sum;
        }

        // Метод для вычисления разницы между максимальным и минимальным элементом
        public static T DifferenceMaxMin<T>(MyArray<T> array) where T : IComparable<T>
        {
            T max = array.GetElement(0);
            T min = array.GetElement(0);

            for (int i = 1; i < array.Size(); i++)
            {
                T current = array.GetElement(i);
                if (current.CompareTo(max) > 0)
                {
                    max = current;
                }
                if (current.CompareTo(min) < 0)
                {
                    min = current;
                }
            }

            return (dynamic)max - (dynamic)min;
        }

        // Метод для подсчета количества элементов массива
        public static int Count<T>(MyArray<T> array) where T : IComparable<T>
        {
            return array.Size();
        }


        public static string RemoveVowels(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            // Список гласных
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U', 'а', 'е', 'и', 'о', 'у', 'э', 'ы', 'я', 'ю', 'А', 'Е', 'И', 'О', 'У', 'Э', 'Ы', 'Я', 'Ю' };

            foreach (var vowel in vowels)
            {
                str = str.Replace(vowel.ToString(), "");
            }

            return str;
        }

        public static MyArray<T> RemoveFirstFive<T>(this MyArray<T> array) where T : IComparable<T>
        {
            int newSize = array.Size() > 5 ? array.Size() - 5 : 0;
            MyArray<T> result = new MyArray<T>(newSize);

            for (int i = 0; i < newSize; i++)
            {
                result.SetElement(i, array.GetElement(i + 5));
            }

            return result;
        }
    }

}