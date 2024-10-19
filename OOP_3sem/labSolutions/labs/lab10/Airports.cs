using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Airport
    {
        public string City { get; set; }    // Город, в котором расположен аэропорт
        public string Name { get; set; }    // Название аэропорта

        // Конструктор с параметрами для инициализации
        public Airport(string city, string name)
        {
            City = city;
            Name = name;
        }

        // Переопределение метода ToString для удобного отображения информации об аэропорте
        public override string ToString()
        {
            return $"{Name} ({City})";
        }
    }
}
