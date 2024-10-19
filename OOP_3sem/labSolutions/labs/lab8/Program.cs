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


            User user1 = new User("User1");
            User user2 = new User("User2");

            user1.SubscribeToMove(offset => Console.WriteLine($"{user1.Name} сдвинут на {offset}."));
            user1.SubscribeToResize(factor => Console.WriteLine($"{user1.Name} {factor}."));

            user2.SubscribeToMove(offset => Console.WriteLine($"{user2.Name} сдвинут на {offset}."));

            user1.OnMove(10);
            user1.OnResize(0.5);
            user2.OnMove(20);

            // Проверить состояния объектов после событий
            Console.WriteLine($"{user1.Name} - Позиция: {user1.Position}, Размер: {user1.Size}");
            Console.WriteLine($"{user2.Name} - Позиция: {user2.Position}, Размер: {user2.Size}");



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