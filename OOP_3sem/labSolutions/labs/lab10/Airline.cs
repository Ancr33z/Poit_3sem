using System;
partial class Airline
{
    private static int _objectCount = 0;                //Статическое поле
    public readonly int ID;//поле - только для чтения  // уникальное значение для поля ID создается с помощью метода GenerateUniqueID:

    private const string AirlineType = "Commercial";//поле- константу;
    private string _raceNumber;
    private string _planeType;
    private string _destination;
    private string _departureTime;
    private string _dayWeak;

    //////////////////////////////// Свойства ////////////////////////////////
    public string Destination
    {
        get => _destination;
        set                           //Свойство с ограниченным доступом set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Пункт назначения не может быть пустым.");
            _destination = value;
        }
    }

    public string FlightNumber
    {
        get => _raceNumber;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Номер рейса не может быть пустым.");
            _raceNumber = value;
        }
    }

    public string AircraftType
    {
        get => _planeType;
        set => _planeType = value;
    }

    public string DepartureTime
    {
        get => _departureTime;
        set => _departureTime = value;
    }

    public string DaysOfWeek
    {
        get => _dayWeak;
        set => _dayWeak = value;
    }

    public string Country { get; set; }

    //////////////////////////////// Конструкторы ////////////////////////////////
    /*Не менее трех конструкторов (с параметрами и без, а также с параметрами по умолчанию );*/
    static Airline()//статический конструктор (конструктор типа);
    {
        Console.WriteLine("Вызван статический конструктор.");
    }

    private Airline()//Конструктор без параметров            // закрытый конструктор
    {
        ID = GenerateUniqueID();
    }

    public Airline(string destination, string raceNumber, string planeType, string departureTime, string dayWeak)//Конструктор с параметрами:
    {
        _destination = destination;
        _raceNumber = raceNumber;
        _departureTime = departureTime;
        _planeType = planeType;
        _dayWeak = dayWeak;
        _objectCount++;
    }

    public Airline(string destination, string flightNumber) : this(destination, flightNumber, "Unknown", "00:00", "Unknown") { }//Конструктор с параметрами по умолчанию (с двумя параметрами):

    public Airline(string destination) : this(destination, "Unknown") { }//Конструктор с параметрами по умолчанию (с одним параметром):

    public static int ObjectCount => _objectCount; // Статическое свойство только для чтения

    //////////////////////////////// Методы ////////////////////////////////
    private int GenerateUniqueID()//Закрытый конструктор
    {
        return ++_objectCount;//// Простой пример генерации уникального ID
    }

    public static void DisplayCount()  //Статический метод
    {
        Console.WriteLine($"Общее количество созданных авиакомпаний: {ObjectCount}");
    }

    public override bool Equals(object obj)//для сравнения двух объектов
    {
        if (obj is Airline airline)
        {
            return _raceNumber == airline._raceNumber && _destination == airline._destination;
        }
        return false;
    }

    public override int GetHashCode()//переопределён для генерации хэша
    {
        return HashCode.Combine(_raceNumber, _destination);
    }

    public override string ToString()//Метод ToString переопределён для вывода строки с информацией об объекте. Он возвращает строку с деталями о рейсе.
    {
        return $"Номер рейса: {_raceNumber}, Место назначения: {_destination}, Тип самолета: {_planeType}, Время вылета: {_departureTime}, Дни недели: {_dayWeak}";
    }

 // По скриптум это функция чтобы показать инфу получает инфу из функции а оут тип выдаёт значение в функцию но она тоже по ссылке там в programm написано что там как
    public void ShowInfo(ref string raceInfo, out string destinationInfo)
    {
        // Присваиваем новое значение для параметра ref
        raceInfo = $"Номер рейса: {_raceNumber}";

        // Присваиваем значение параметру out
        destinationInfo = $"Место назначения: {_destination}";

        // Выводим информацию о рейсе
        Console.WriteLine($"Номер рейса: {_raceNumber}, Место назначения: {_destination}, Дни недели: {_dayWeak},  Тип самолета: {_planeType}, Время вылета: {_departureTime}");
    }
}