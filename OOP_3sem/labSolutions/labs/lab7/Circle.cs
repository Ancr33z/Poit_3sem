using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab7
{
    internal class Circle : IComparable<Circle>
    {
        public readonly double PI = 3.1415;
        public string Name { get; set; }
        public int Radius { get; set; }
        public Circle()
        {
            Name = "Круг";
        }

        public Circle(string name, int radius = 5)
        {
            Name = name;
            Radius = radius;
        }


        public void Area()
        {
            double temp = Radius;
            temp = temp * PI * PI;
            Console.WriteLine(temp);

        }
        public void Perimeter()
        {
            Console.WriteLine(Radius * 2 * PI);
        }
        public void GetFigureType()
        {
            Console.WriteLine("Это круг");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}, радиус круга: {this.Radius}";
        }

        public int CompareTo(Circle other)
        {
            if (other == null)
                return 1;

            return this.Radius.CompareTo(other.Radius);
        }
    }

}
