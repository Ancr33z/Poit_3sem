using Lab8;
using System;
using System.Linq;

namespace lab8
{
    public class Program
    {
        public static void Main()
        {
            ////////////////////////////////////// Инициализация массивов и вывод их на экран //////////////////////////////////////














            /*Используя стандартные типы делегатов 
            (Action, Func, Predicate) организуйте алгоритм последовательной обработки 
            строки написанными вами методами. Везде где возможно использовать лямбда-выражения.*/
            Console.WriteLine("-----------------------------------------------------------------------");
            EditString.str = "Стр:Ока!      , пРо;с?ТО ..    .., стр;ока,?";
            Action stringEdit = () => EditString.RemovePunctuation();
            stringEdit += () => EditString.ToUpperCase();
            stringEdit += () => EditString.ToLowerCase();
            stringEdit += () => EditString.RemoveSpaces();
            stringEdit += () => EditString.AddQuestion();
            stringEdit?.Invoke();

            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}