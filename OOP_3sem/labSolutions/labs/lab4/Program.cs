using lab4;
using System;
using System.Linq;

namespace lab4
{
    public class Program
    {
        public static void Main()
        {
            /*Написать демонстрационную программу, в которой создаются объекты 
            различных классов. Поработать с объектами через ссылки на абстрактные
            классы и интерфейсы. В этом случае для идентификации типов объектов
            использовать операторы is или as.*/


            //////////////////////////////////////  //////////////////////////////////////
            Rectangle square1 = new Rectangle("Квадрат №1");
            Figure square2 = new Rectangle("Квадрат №2");
            IFigure square3 = new Rectangle("Квадрат №3");

            if (square1 is Rectangle)
            {
                Console.WriteLine("square1 это квадпрямоугольникрат");
            }
            if (square2 is Rectangle)
            {
                Console.WriteLine("square2 это прямоугольник");
            }
            if (square3 is Rectangle)
            {
                Console.WriteLine("square3 это прямоугольник");
            }
            if ((square1 as Figure) != null)
            {
                Console.WriteLine("square1 преобразован в фигуру");
            }

            Console.WriteLine();

            square1.GetFigureType();
            square2.GetFigureType();
            square1.Perimeter();
            square1.Area();


            /*В демонстрационной программе создайте массив, содержащий ссылки на разнотипные объекты
            ваших классов по иерархии, а также объект класса Printer и последовательно 
            вызовите его метод IAmPrinting со всеми ссылками в качестве аргументов.*/
            Console.WriteLine("----------------------------------------------");

            var square = new Rectangle("Прямоугольник 1");
            var circle = new Circle("Круг 1");
            var figureItems = new Figure[2];

            var printer = new Printer();

            figureItems[0] = square;
            figureItems[1] = circle;

            foreach (var item in figureItems)
            {
                printer.IAmPrinting(item);
            }

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("----------------------------------------------");

            var checktbox = new Checktbox();
            var radiobutton = new Radiobutton("Радиокнопка 1");
            var Button = new Button("Кнопка 1");
            var controlers = new Controls[3];

            controlers[0] = checktbox;
            controlers[1] = radiobutton;
            controlers[2] = Button;

            foreach (var item in controlers)
            {
                printer.IAmPrinting(item);
            }

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}