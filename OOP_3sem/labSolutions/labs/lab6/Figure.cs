namespace lab6
{
    public abstract class Figure
    {
        public const double PI = Math.PI;
        public int Side { get; set; }
        public string Name { get; set; }

        public abstract void GetFigureType() ;

    }

    public class Square : Figure, IFigure
    {
        public Square()
        {
            Name = "Квадрат";
        }

        public Square(string name, int side = 2)
        {
            Name = name;
            Side = side; 
        }


        public void Area()
        {
            Console.WriteLine(Side * Side);
        }
        public void Perimeter()
        {
            Console.WriteLine((Side * 4));
        }
        public override void GetFigureType()
        {
            Console.WriteLine("Это квадрат");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}, сторона: {this.Side}";
        }
    }

    public class Rectangle : Figure, IFigure
    {
        public int SecondSize { get; set; }
        public  Rectangle()
        {
            Name = "Прямоугольник";
        }

        public Rectangle(string name, int side = 5, int secondSize = 10)
        {
            Name = name;
            Side = side;
            SecondSize = secondSize;
        }


        public void Area()
        {
            Console.WriteLine(Side * SecondSize);
        }
        public void Perimeter()
        {
            Console.WriteLine((Side + SecondSize) * 2);
        }
        public override void GetFigureType()
        {
            Console.WriteLine("Это прямоугольник");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}, первоя сторона: {this.Side}, вторая сторона: {this.SecondSize}";
        }
    }

    public class Circle : Figure, IFigure
    {

        public int secondSize { get; set; }
        public Circle()
        {
            Name = "Круг";
        }

        public Circle(string name, int radius = 5)
        {
            Name = name;
            Side = radius;
        }


        public void Area()
        {
            double temp = Side;
            temp = temp * PI * PI;
            Console.WriteLine(temp);

        }
        public void Perimeter()
        {
            Console.WriteLine(Side * 2 * PI);
        }
        public override void GetFigureType()
        {
            Console.WriteLine("Это круг");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}, радиус круга: {this.Side}";
        }
    }

    public sealed class RectangularTriangle : Figure, IFigure
    {
        public int Hypotenuse { get; set; }
        public int SecondSize { get; set; }
        public RectangularTriangle()
        {
            Name = "Прямоугольный треугольник";
        }

        public RectangularTriangle(string name, int side = 3, int secondSize = 4)
        {
            Name = name;
            Side = side;
            SecondSize = secondSize;
            Hypotenuse = (int)Math.Sqrt(Math.Pow(side, 2) + Math.Pow(secondSize, 2));
        }


        public void Area()
        {
            Console.WriteLine(Side * SecondSize / 2);
        }
        public void Perimeter()
        {
            Console.WriteLine(Side + SecondSize + Hypotenuse);
        }

        public override void GetFigureType()
        {
            Console.WriteLine("Это прямоугольный треугольник");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}, первый катет: {this.Side}, второй катет: {this.SecondSize}, гипотенуза: {this.Hypotenuse}";
        }
    }

    public class Cube : Figure, IFigure
    {
        public int Volume { get; set; }
        public Cube()
        {
            Name = "Куб";
        }

        public Cube(string name, int side = 3)
        {
            Name = name;
            Side = side;
        }


        public void Area()
        {
            Console.WriteLine(6 * Side * Side);
        }
        public void Perimeter()
        {
            Console.WriteLine(Side * 12);
        }

        public override void GetFigureType()
        {
            Console.WriteLine("Это куб");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}, сторона: {this.Side}";
        }
    }
}
