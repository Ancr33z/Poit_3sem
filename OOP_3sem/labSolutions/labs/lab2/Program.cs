using System;
using System.Linq;
using MyApp;

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            int numberOfObjects;
            Console.WriteLine("Введите количество рейсов (не менее 2)");
            do
            {
                numberOfObjects = int.Parse(InputValidator.GetValidDigitInput());
                if (numberOfObjects < 2)
                {
                    Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                }
            } while (numberOfObjects < 2);

            // Массив объектов
            Airline[] airlines = new Airline[numberOfObjects];

            // Ввод объектов
            for (int i = 0; i < airlines.Length; i++)
            {
                Console.WriteLine("Введите номер рейса");
                string raceNumber = InputValidator.GetValidStringInput();

                Console.WriteLine("Введите время вылета HH:mm");
                string departureTime = InputValidator.GetValidTime();

                Console.WriteLine("Введите тип самолёта");
                string planeType = InputValidator.GetValidStringInput();

                Console.WriteLine("Введите место назначения");
                string destination = InputValidator.GetValidOnlyLettersInput();

                Console.WriteLine("Введите дату вылета (\"Monday\", \"Tuesday\", \"Wednesday\", \"Thursday\", \"Friday\", \"Saturday\", \"Sunday\")");
                string dayOfWeek = InputValidator.GetValidDayOfWeek();

                airlines[i] = new Airline(destination, raceNumber, planeType, departureTime, dayOfWeek);
            }

            Console.WriteLine();

            // Вызов методов
            Airline.DisplayCount();

            // Сравнение объектов
            Console.WriteLine(airlines[0].Equals(airlines[1]));

            // Ввод для поиска
            Console.WriteLine("Введите день недели для поиска рейсов:");
            string searchDay = InputValidator.GetValidDayOfWeek();

            Console.WriteLine("Введите пункт назначения для поиска рейсов:");
            string searchDestination = InputValidator.GetValidOnlyLettersInput();

            // Список рейсов для заданного дня недели и пункта назначения
            var flightsOnDay = airlines.Where(f => f.DaysOfWeek.Equals(searchDay, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Полеты по {searchDay}:");
            foreach (var flight in flightsOnDay)
            {
                Console.WriteLine(flight);
            }

            Console.WriteLine();

            var flightsToDestination = airlines.Where(f => f.Destination.Equals(searchDestination, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Рейсы в {searchDestination}:");
            foreach (var flight in flightsToDestination)
            {
                Console.WriteLine(flight);
            }
            Console.WriteLine();

            Console.WriteLine(typeof(Airline));
            
            Console.WriteLine();

            foreach (var flight in airlines)
            {
                flight.ToString();
            }

            // Анонимный тип
            var anonymousFlight = new { FlightNumber = "ANttt123", Destination = "Pinsk", DepartureTime = DateTime.Now };
            Console.WriteLine($"Анонимный полет: {anonymousFlight.FlightNumber}, Место назначения: {anonymousFlight.Destination}, Время вылета: {anonymousFlight.DepartureTime}");

            Console.WriteLine();


            for (int i = 0; i < airlines.Length; i++)
            {
                Console.WriteLine(airlines[i].ToString());
            }

            Console.WriteLine();


            string raceInfo = "Информация о рейсе";

            // Переменная для out-параметра не должна быть инициализирована заранее
            string destinationInfo;

            // Вызов метода с использованием ref и out
            airlines[0].ShowInfo(ref raceInfo, out destinationInfo);

            Console.WriteLine(raceInfo); // Номер рейса: 
            Console.WriteLine(destinationInfo); // Место назначения: 


            Console.WriteLine();


            //var airline1 = new
            //{
            //    _destination = "Pinsk",
            //    _raceNumber = "rowe",
            //    _departureTime = "20:12",
            //    _planeType = "airplane",
            //    _dayWeak = "Monday",
            //};

            //Console.WriteLine(airline1);

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}


//using System;
//using System.Text;
//using MyApp;

//namespace MyApp
//{
//    class Program
//    {
//        static void Main()
//        {
//            int numberOfObjects;
//            Console.WriteLine("Введите количество рейсов (не менее 2)");
//            do
//            {
//                numberOfObjects = int.Parse(InputValidator.GetValidDigitInput());
//                if (numberOfObjects < 2)
//                {
//                    Console.WriteLine("Неверный ввод");
//                }
//            } while (numberOfObjects < 2);

//            // Массив объектов
//            Airline[] airlines = new Airline[numberOfObjects];

//            // Ввод объектов
//            for (int i = 0; i < airlines.Length; i++)
//            {

//                Console.WriteLine("Введите номер рейса");
//                string raceNumber = InputValidator.GetValidStringInput();

//                Console.WriteLine("Введите время вылета HH:mm");
//                string departureTime = InputValidator.GetValidTime();

//                Console.WriteLine("Введите тип самолёта");
//                string planeType = InputValidator.GetValidStringInput();

//                Console.WriteLine("Введите место назначения");
//                string ddestination = InputValidator.GetValidOnlyLettersInput();

//                Console.WriteLine("Введите дату вылета (\"Monday\", \"Tuesday\", \"Wednesday\", \"Thursday\", \"Friday\", \"Saturday\", \"Sunday\")");
//                string dayofWeak = InputValidator.GetValidDayOfWeek();

//                airlines[i] = new Airline(ddestination, raceNumber, planeType, departureTime, dayofWeak);
//            }



//            //var flight1 = new Airline("New York", "NY123", "Boeing 737", DateTime.Now, new List<string> { "Monday", "Wednesday", "Friday" });
//            //var flight2 = new Airline("Los Angeles", "LA456", "Airbus A320", DateTime.Now.AddHours(2), new List<string> { "Tuesday", "Thursday" });
//            //var flight3 = new Airline("New York", "NY789", "Boeing 747", DateTime.Now.AddHours(1), new List<string> { "Monday", "Saturday" });

//            Console.WriteLine();


//            // Вызов методов
//            Airline.DisplayCount();

//            // Сравнение объектов
//            Console.WriteLine(airlines[0].Equals(airlines[1]));



//            // Список рейсов для заданного пункта назначения
//            string destination = "New York";
//            var flightsToDestination = airlines.Where(f => f.Destination == destination);
//            Console.WriteLine($"Flights to {destination}:");
//            foreach (var flight in flightsToDestination)
//            {
//                Console.WriteLine(flight);
//            }

//            Console.WriteLine();

//            // Список рейсов для заданного дня недели
//            string day = "Monday";
//            var flightsOnDay = airlines.Where(f => f.DaysOfWeek.Contains(day));
//            Console.WriteLine($"Flights on {day}:");
//            foreach (var flight in flightsOnDay)
//            {
//                Console.WriteLine(flight);
//            }

//            Console.WriteLine();

//            foreach (var flight in airlines)
//            {
//                flight.ShowInfo();
//            }


//            // Анонимный тип
//            var anonymousFlight = new { FlightNumber = "AN123", Destination = "Miami", DepartureTime = DateTime.Now };
//            Console.WriteLine($"Anonymous Flight: {anonymousFlight.FlightNumber}, Destination: {anonymousFlight.Destination}, Departure: {anonymousFlight.DepartureTime}");

//            Console.WriteLine();


//            var airline1 = new
//            {
//                _destination = "minsk",
//                _raceNumber = "rowe",
//                _departureTime = "20:12",
//                _planeType = "airplane",
//                _dayWeak = "Monday",
//            };
//            Console.WriteLine(airline1);

//            Console.WriteLine("Нажмите любую клавишу для выхода...");
//            Console.ReadKey(); // Или Console.ReadLine();
//        }

//    }
//}
