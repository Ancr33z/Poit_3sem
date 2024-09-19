using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    /*К предыдущей лабораторной работе(л.р. 4) добавьте к существующим классам структуру.*/
    internal class Struct
    {
        public struct SimpleUIComponent
        {
            // Поля структуры
            public string Name;
            public int Width;
            public int Height;

            // Конструктор для инициализации полей
            public SimpleUIComponent(string name, int width, int height)
            {
                Name = name;
                Width = width;
                Height = height;
            }

            // Метод для отображения информации о UI-компоненте
            public void DisplayInfo()
            {
                Console.WriteLine($"UI Component: {Name}");
                Console.WriteLine($"Width: {Width}px, Height: {Height}px");
            }
        }
    }
}
