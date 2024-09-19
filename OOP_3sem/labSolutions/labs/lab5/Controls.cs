
namespace lab5
{
    ////////////////////////////////////// Элементы управления //////////////////////////////////////
    public abstract class Controls
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public abstract int Size();
        public abstract void Resize(int width, int height);
        public abstract void Show();
    }

    public class Checktbox : Controls, IControls
    {
        // Конструкторы


        public Checktbox(int width = 10, int height = 10)
        {
            Name = "Чекбокс)";
            Width = width;
            Height = height;
        }

        public Checktbox(string name, int width = 10, int height = 10)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        // переопределение абстрактных методов
        public override void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override int Size()
        {
            return Width * Height;
        }
        public override void Show()
        {
            Console.WriteLine("Это чекбокс ого");
        }
        public void UseControl()
        {
            Console.WriteLine("Вы нажали на чекбокс");
        }
        public override string ToString()
        {
            return ($"Элемент: {this.Name}, ширина: {this.Width}, высота: {this.Height}");
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    public class Radiobutton : Controls, IControls
    {
        // Конструкторы

        public Radiobutton(int width = 10, int height = 10)
        {
            Name = "Радиво кнопка)";
            Width = width;
            Height = height;
        }

        public Radiobutton(string name, int width = 10, int height = 10)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        // переопределение абстрактных методов
        public override void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override int Size()
        {
            return Width * Height;
        }
        public override void Show()
        {
            Console.WriteLine("Это радиокнопка wow");
        }
        public void UseControl()
        {
            Console.WriteLine("Вы нажали на радиокнопку");
        }
        public override string ToString()
        {
            return ($"Элемент: {this.Name}, ширина: {this.Width}, высота: {this.Height}");
        }

    }
    public class Button : Controls, IControls
    {
        // Конструкторы
        public Button(int width = 10, int height = 10)
        {
            Name = "Обычная кнопка:(";
            Width = width;
            Height = height;
        }

        public Button(string name, int width = 10, int height = 10)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        // переопределение абстрактных методов
        public override void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override int Size()
        {
            return Width * Height;
        }
        public override void Show()
        {
            Console.WriteLine("Это обычная кнопка wow");
        }
        public void UseControl()
        {
            Console.WriteLine("Вы нажали на кнопку");
        }
        public override string ToString()
        {
            return ($"Элемент: {this.Name}, ширина: {this.Width}, высота: {this.Height}");
        }

    }
}