using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    /*Создать UI из имеющихся фигур и элементов управления. Вывести список всех кнопок, подсчитать общее количество 
      элементов на UI, найти площадь занимаемую всеми элментами*/
    public class UIContainer
    {
        public List<Controls> ControlsList { get; private set; }
        public int NumberOfButton { get; private set; }
        public int CurrentArea { get; private set; }
        public UIContainer()
        {
            CurrentArea = 0;
            NumberOfButton = 0;
            ControlsList = new List<Controls>();
        }
        public UIContainer(List<Controls> list)
        {
            CurrentArea = CurrentArea + list.Sum(item => item.Size());
            NumberOfButton = list.Count;
            ControlsList = list;
        }

        public void AddItem(Controls item)
        {
            ControlsList.Add(item);
            CurrentArea += item.Size();
            NumberOfButton++;
        }

        public void DeleteItem(Controls item)
        {
            if (!ControlsList.Contains(item))
                throw new ArgumentException();

            ControlsList.Remove(item);
            CurrentArea -= item.Size();
            NumberOfButton--;
        }

        public void PrintList()
        {
            Console.WriteLine(
               $"----------------------\n" +
               $"Количество кнопок: {NumberOfButton}\n" +
               $"Текущая площадь: {CurrentArea}\n");

            foreach (var item in ControlsList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("----------------------");
        }
    }
}
