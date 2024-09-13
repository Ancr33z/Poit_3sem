using System;

namespace MyApp // Пространство имён, в котором будет находиться класс
{
    public class InputValidator
    {
        public static bool ValidateOnlyDigits(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            foreach (char c in input)
            {

                if (c == '\n' || !char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetValidDigitInput()
        {
            string input;
            do
            {
                input = Console.ReadLine();

                if (!ValidateOnlyDigits(input))
                {
                    Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                }
            }
            while (!ValidateOnlyDigits(input));

            return input;
        }

        public static string GetValidStringInput()
        {
            string input;
            do
            {
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Строка не должна быть пустой. Попробуйте ещё раз.");
                }
            }
            while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public static string GetValidOnlyLettersInput()
        {
            string input;
            do
            {
                Console.WriteLine("Введите строку, содержащую только буквы:");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Строка не должна быть пустой. Попробуйте ещё раз.");
                }
                else if (!IsAllLetters(input))
                {
                    Console.WriteLine("Строка должна содержать только буквы. Попробуйте ещё раз.");
                    input = null; // Обнуляем строку, чтобы цикл повторился
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private static bool IsAllLetters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetValidDayOfWeek()
        {
            // Массив с допустимыми днями недели
            string[] validDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            while (true)  // Бесконечный цикл, пока не будет введено корректное значение
            {
                string day = Console.ReadLine();

                // Проверяем, что введённый день недели существует в массиве
                if (Array.Exists(validDays, d => d.Equals(day, StringComparison.OrdinalIgnoreCase)))
                {
                    return day;  // Если день недели корректен, возвращаем его
                }
                else
                {
                    Console.WriteLine("Некорректный день недели. Попробуйте ещё раз.");
                }
            }
        }

        public static string GetValidTime() // Проверка валидного времени и возврат значения 
        {
            while (true)  // Бесконечный цикл, пока не будет введено корректное время
            {
                string timeInput = Console.ReadLine();

                // Проверяем введённое время
                if (ValidateTime(timeInput))
                {
                    return timeInput;  // Возвращаем строку с корректным временем
                }
                else
                {
                    Console.WriteLine("Некорректное время. Попробуйте ещё раз.");
                }
            }
        }
        private static bool ValidateTime(string time)
        {
            // Проверяем, что строка не пуста
            if (string.IsNullOrEmpty(time))
            {
                return false;
            }

            // Разделяем строку по символу ':'
            string[] timeParts = time.Split(':');

            // Проверяем, что время состоит из двух частей (часы и минуты)
            if (timeParts.Length != 2)
            {
                return false;
            }

            // Проверяем, что часы и минуты являются числами
            if (int.TryParse(timeParts[0], out int hours) && int.TryParse(timeParts[1], out int minutes))
            {
                // Часы должны быть в диапазоне 0-23, а минуты в диапазоне 0-59
                if (hours >= 0 && hours < 24 && minutes >= 0 && minutes < 60)
                {
                    return true;
                }
            }

            // Если какое-либо условие не выполнено, возвращаем false
            return false;
        }
    }
}
//class Program
//{
//    static void Main(string[] args)
//    {
//        // Пример ввода только цифр
//        string validDigitInput = InputValidator.GetValidDigitInput();
//        Console.WriteLine($"Корректный ввод цифр: {validDigitInput}");

//        // Пример ввода произвольной строки
//        string validStringInput = InputValidator.GetValidStringInput();
//        Console.WriteLine($"Корректный ввод строки: {validStringInput}");
//    }
//}