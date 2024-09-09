using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp;


namespace MyApp

{
    internal class Airline
    {
        public const ;
        readonly int id;
        private int _raceNumber;
        private int _departureTime;

        private string _dayWeak;
        private string _planeType;
        private string _destination;

        public int RaceNumber
        {
            get { return _raceNumber; }
            set { _raceNumber = value; }
        }

        // Свойство для _departureTime
        public int DepartureTime
        {
            get { return _departureTime; }
            set { _departureTime = value; }
        }

        // Свойство для _dayWeak
        public string DayWeak
        {
            get { return _dayWeak; }
            set {_dayWeak = value; }
        }

        // Свойство для _planeType
        public string PlaneType
        {
            get { return _planeType; }
            set {_planeType = value; }
        }

        // Свойство для _destination
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        public Airline()
        {

        }

        public Airline(int raceNumber, int departureTime, string destination, string planeType, string dayWeak)
        {
            this.raceNumber = raceNumber;
            this.departureTime = departureTime;
            this.destination = destination;
            this.planeType = planeType;
            this.dayWeak = dayWeak;
        }

        public static string GetValidInput()
        {
            string input;
            do
            {
                Console.WriteLine("Введите строку, состоящую только из цифр:");
                input = Console.ReadLine();

                if (!ValidateOnlyDigits(input))
                {
                    Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                }
            }
            while (!ValidateOnlyDigits(input)); // Повторяем, пока не будет введено корректное значение

            return input; // Возвращаем корректное значение
        }

        public static bool ValidateOnlyDigits(string input)
        {
            // Перебираем каждый символ и проверяем, является ли он цифрой
            foreach (char c in input)
            {
                if (!char.IsDigit(c)) // Проверяем, является ли символ цифрой
                {
                    return false;
                }
            }
            return true;
        }

    }
}
