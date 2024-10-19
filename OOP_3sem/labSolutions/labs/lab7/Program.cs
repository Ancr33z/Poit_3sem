using System;
using System.Linq;

namespace lab7
{
    public class Program
    {   
        public static void Main()
        {
            ////////////////////////////////////// Инициализация массивов и вывод их на экран //////////////////////////////////////

            //2) Добавьте обработку исключений c finally. 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------Массив типа sbyte---------------\n");
            try
            {
                OneDimensionalArray<sbyte> sbyteArr = new OneDimensionalArray<sbyte>();
                sbyteArr.AddItem(23);
                sbyteArr.AddItem(100);
                sbyteArr.AddItem(127);
                sbyteArr.DeleteItem(23);
                sbyteArr.DeleteItem(100);
                sbyteArr.DeleteItem(127);
                sbyteArr.DeleteItem(23);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            /*3) Проверьте использование обобщения для стандартных типов данных (в 
            качестве стандартных типов использовать целые, вещественные и т.д.). */
            Console.WriteLine("\n---------------Массив типа char---------------\n");
            OneDimensionalArray<char> charArr = new OneDimensionalArray<char>();
            charArr.AddItem('A');
            charArr.AddItem('B');
            charArr.AddItem('C');
            charArr.AddItem('D');
            charArr.AddItem('E');
            charArr.Show();
            Console.WriteLine("\n--------------Массив типа double--------------\n");

            OneDimensionalArray<double> doubleArr = new OneDimensionalArray<double>();
            doubleArr.AddItem(1.276);
            doubleArr.AddItem(93.786);
            doubleArr.AddItem(4.475);
            doubleArr.AddItem(344.475);
            doubleArr.Show();
            Console.WriteLine("\n---------------Массив типа int----------------\n");
            OneDimensionalArray<int> intArr = new OneDimensionalArray<int>();
            intArr.AddItem(10);
            intArr.AddItem(20);
            intArr.AddItem(30);
            intArr.AddItem(40);
            intArr.Show();

            Predicate<int> isEven = n => n % 2 == 0;

            int result = intArr.Find(isEven);
            Console.WriteLine($"Первое четное число: {result}");

            Console.WriteLine("\n---------------Массив типа Bars---------------\n");

            OneDimensionalArray<Circle> circleArr = new OneDimensionalArray<Circle>();
            circleArr.AddItem(new Circle("Круг №12", 12));
            circleArr.AddItem(new Circle("Круг №13", 14));
            circleArr.AddItem(new Circle("Круг №14", 20));
            circleArr.AddItem(new Circle("Круг №15", 13));
            circleArr.Show();
            Console.WriteLine("\n---------------Массив типа Bars из JSON---------------\n");

            OneDimensionalArray<Circle> circleArrJson = new OneDimensionalArray<Circle>();
            circleArrJson.AddItem(new Circle("Круг №200", 21));
            circleArrJson.AddItem(new Circle("Круг №300", 22));
            circleArrJson.AddItem(new Circle("Круг №400 ", 21));
            circleArrJson.AddItem(new Circle("Круг №500", 30));

            GenericAndFiles.WriteArray(circleArrJson);
            OneDimensionalArray<Circle> testJson = new OneDimensionalArray<Circle>();
            GenericAndFiles.ReadArray(testJson);
            testJson.Show();

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}