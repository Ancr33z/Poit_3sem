using System;

namespace MyApp // Пространство имён, в котором будет находиться класс
{
    public class InputValidator
    {
        public static bool ValidateOnlyDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
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
                Console.WriteLine("Введите строку, состоящую только из цифр:");
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
                Console.WriteLine("Введите строку:");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Строка не должна быть пустой. Попробуйте ещё раз.");
                }
            }
            while (string.IsNullOrWhiteSpace(input));

            return input;
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