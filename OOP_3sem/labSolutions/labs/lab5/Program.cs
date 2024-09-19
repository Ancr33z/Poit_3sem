using lab5;
using System;
using System.Linq;

namespace lab5
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
            Controls checktbox = new Checktbox("Чекбокс №1", 15, 20);
            Controls radiobutton = new Radiobutton("Радиокнопка №1", 150, 50);
            Controls button = new Button("Кнопка №1", 120, 100);
            Controls button1 = new Button("Кнопка №2", 130, 320);
            UIContainer UI = new UIContainer();
            UI.AddItem(checktbox);
            UI.AddItem(radiobutton);
            UI.AddItem(button);
            UI.AddItem(button1);
            UI.PrintList();
            UI.DeleteItem(button1);
            UI.PrintList();




            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}