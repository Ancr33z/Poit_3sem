namespace lab4
{

    ////////////////////////////////////// Фигуры //////////////////////////////////////
    public abstract class Figure
    {
        public const double PI = Math.PI;
        public int Side { get; set; }
        public string Name { get; set; }

        public abstract void GetFigureType() ;

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



}
