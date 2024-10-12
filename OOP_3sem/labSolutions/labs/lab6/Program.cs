using System;
using System.IO;
using System.Diagnostics;

namespace lab6
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Controls bench = new Checktbox("Чекбокс №1", -1203);
            }
            catch (WidthException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine($"Ошибка при создании экземляра класса {e.ErrorInClass}");
                Console.WriteLine($"Неверное значение: {e.Width}");
            }
            
            Console.WriteLine("\n--------------------------------------\n");

            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Button radiobutton = new Button("Радиокнопка", 400, 2220);
            }
            catch (AreaException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine($"Ошибка при создании экземляра класса {e.ErrorInClass}");
                Console.WriteLine($"Неверное значение: {e.Area}");
            }
            Console.WriteLine("\n--------------------------------------\n");
            //3) В конце поставьте универсальный обработчик catch.
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Button иutton = new Button("Обычная кнопка", 10000, 50);
            }
            catch
            {
                Console.WriteLine("Неверные данные!");
            }
            Console.WriteLine("\n--------------------------------------\n");
            //4) Используйте классический вид try-catch-finally.
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                UIContainer gym = new UIContainer();
                Radiobutton radiobutton = new Radiobutton("Радиокнопка", 100,200);
                gym.AddItem(radiobutton);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Finally");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();


            Console.WriteLine("----------------------------------------------");


            /*7)Добавьте в код макрос Assert. Объясните что он 
                проверяет, как будет выполняться программа в случае не выполнения 
                условия. Объясните назначение Assert. */
                Controls mat = new Button("Кнопка", 120,10);
                Debug.Assert(mat.Width > 200, "Ширина не может быть меньше 200");

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}