using System;
using System.Linq;
using System.Collections.Generic;
using lab10;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1) Задайте массив типа string, содержащий 12 месяцев (June, July, May, 
            December, January ….). Используя LINQ to Object напишите запрос выбирающий 
            последовательность месяцев с длиной строки равной n, запрос возвращающий 
            только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке,
            запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х.*/

            string[] months = {"January", "February", "March", "April", "May", "June",
                   "July", "August", "September", "October", "November", "December", };

            int n = 8;
            var selectedMonths = from m in months where m.Length == n select m;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (string i in selectedMonths)
                Console.WriteLine(i);

            selectedMonths = from m in months
                             where Array.IndexOf(months, m) < 2 ||
            Array.IndexOf(months, m) > 4 && Array.IndexOf(months, m) < 8 ||
            Array.IndexOf(months, m) == 11
                             select m;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (string i in selectedMonths)
                Console.WriteLine(i);

            selectedMonths = from m in months orderby m select m;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (string i in selectedMonths)
                Console.WriteLine(i);

            selectedMonths = from m in months where m.Contains('u') && m.Length >= 4 select m;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (string i in selectedMonths)
                Console.WriteLine(i);

            /*. Создайте коллекцию List<T> и параметризируйте ее типом (классом) 
                из лабораторной №2 (при необходимости реализуйте нужные интерфейсы). 
                Заполните ее минимум 10 элементами. */
            List<Airline> airlines = new List<Airline>
            {
                new Airline("New York", "NY101", "Boeing 747", "10:00", "Monday"),
                new Airline("Los Angeles", "LA202", "Airbus A320", "12:00", "Tuesday"),
                new Airline("Chicago", "CH303", "Boeing 737", "08:30", "Wednesday"),
                new Airline("Miami", "MI404", "Airbus A330", "07:00", "Thursday"),
                new Airline("Houston", "HO505", "Boeing 777", "11:00", "Friday"),
                new Airline("San Francisco", "SF606", "Airbus A380", "09:00", "Saturday"),
                new Airline("Seattle", "SE707", "Boeing 787", "06:30", "Monday"),
                new Airline("Orlando", "OR808", "Boeing 757", "10:15", "Wednesday"),
                new Airline("Boston", "BO909", "Airbus A350", "14:45", "Friday"),
                new Airline("Dallas", "DA1010", "Boeing 767", "12:45", "Wednesday")
            };

            string targetDestination = "New York";
            string targetDay = "Wednesday";

            // Список рейсов для заданного пункта назначения
            var destinationFlights = airlines.Where(a => a.Destination == targetDestination).ToList();
            Console.WriteLine($"Рейсы в {targetDestination}:");
            destinationFlights.ForEach(Console.WriteLine);

            Console.WriteLine("\n--------------------------------------------------");

            // Количество рейсов для заданного дня недели
            var flightsOnDay = airlines.Count(a => a.DaysOfWeek == targetDay);
            Console.WriteLine($"Количество рейсов на {targetDay}: {flightsOnDay}");

            Console.WriteLine("\n--------------------------------------------------");

            // Рейс, который вылетает в понедельник раньше всех
            var earliestMondayFlight = airlines
                .Where(a => a.DaysOfWeek == "Monday")
                .OrderBy(a => TimeSpan.Parse(a.DepartureTime))
                .FirstOrDefault();
            Console.WriteLine("Рейс, который вылетает в понедельник раньше всех:");
            Console.WriteLine(earliestMondayFlight);

            Console.WriteLine("\n--------------------------------------------------");

            // Рейс, который вылетает в среду или пятницу позже всех
            var latestWedOrFriFlight = airlines
                .Where(a => a.DaysOfWeek == "Wednesday" || a.DaysOfWeek == "Friday")
                .OrderByDescending(a => TimeSpan.Parse(a.DepartureTime))
                .FirstOrDefault();
            Console.WriteLine("Рейс, который вылетает в среду или пятницу позже всех:");
            Console.WriteLine(latestWedOrFriFlight);

            Console.WriteLine("\n--------------------------------------------------");

            // Список рейсов, упорядоченных по времени вылета
            var sortedFlights = airlines.OrderBy(a => TimeSpan.Parse(a.DepartureTime)).ToList();
            Console.WriteLine("Список рейсов, упорядоченных по времени вылета:");
            sortedFlights.ForEach(Console.WriteLine);

            /*4) Придумайте и напишите свой собственный запрос, в котором было 
            бы не менее 5 операторов из разных категорий: условия, проекций, 
            упорядочивания, группировки, агрегирования, кванторов и разбиения.*/
            Console.WriteLine("------------------------------------------------------------------");
            var query = airlines
                .Where(a => a.DaysOfWeek == "Monday" || a.DaysOfWeek == "Wednesday" || a.DaysOfWeek == "Friday") // Условие по дням недели
                .OrderBy(a => TimeSpan.Parse(a.DepartureTime))                                                  // Упорядочивание по времени вылета
                .GroupBy(a => a.Destination)                                                                     // Группировка по пункту назначения
                .Where(g => g.Count() >= 1)                                                                      // Фильтрация пунктов назначения с хотя бы одним рейсом
                .Select(g => new
                {
                    Destination = g.Key,
                    Flights = g,
                    AverageDepartureTime = g.Average(a => TimeSpan.Parse(a.DepartureTime).TotalMinutes),         // Среднее время вылета
                    Count = g.Count()
                })
                .Where(group => group.Flights.Any(a => TimeSpan.Parse(a.DepartureTime) >= TimeSpan.Parse("06:00"))) // Оставляем рейсы, вылетающие не раньше 06:00
                .Take(10);                                                                                        // Ограничение на 10 элементов

            foreach (var group in query)
                {
                    Console.WriteLine($"Город назначения: {group.Destination}, Количество рейсов: {group.Count}, Среднее время вылета: {TimeSpan.FromMinutes(group.AverageDepartureTime):hh\\:mm}");
                    foreach (var flight in group.Flights)
                    {
                        Console.WriteLine($"\tРейс: {flight.FlightNumber}, Время вылета: {flight.DepartureTime}, Дни недели: {flight.DaysOfWeek}");
                    }
                }
            
            Console.WriteLine("------------------------------------------------------------------");


            //5) Придумайте запрос с оператором Join
            List<Airline> airlines2 = new List<Airline>
            {
                new Airline("New York", "NY101", "Boeing 747", "10:00", "Monday"),
                new Airline("Los Angeles", "LA202", "Airbus A320", "12:00", "Tuesday"),
                new Airline("Chicago", "CH303", "Boeing 737", "08:30", "Wednesday")
            };

            // Создаем коллекцию аэропортов
            List<Airport> airports = new List<Airport>
            {
            new Airport("New York", "John F. Kennedy International Airport"),
            new Airport("Los Angeles", "Los Angeles International Airport"),
            new Airport("Chicago", "O'Hare International Airport")
};

            // Запрос с оператором Join
            var query2 = from airline in airlines
                        join airport in airports on airline.Destination equals airport.City
                        select new
                        {
                            FlightNumber = airline.FlightNumber,
                            Destination = airline.Destination,
                            AirportName = airport.Name,
                            DepartureTime = airline.DepartureTime
                        };

            // Вывод результатов
            Console.WriteLine("Список рейсов с аэропортами назначения:");
            foreach (var item in query2)
            {
                Console.WriteLine($"Рейс {item.FlightNumber} направляется в {item.Destination} - {item.AirportName}, Время вылета: {item.DepartureTime}");
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
