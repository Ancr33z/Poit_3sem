using System;
using System.Linq;


public static class StatisticOperation // Создаём класс ещё раз чтобы дописать нужный функционал в отдельном файле
{
    public static string RemoveVowels(this string str) // Функция удаления гласных из строки 
    {
        return new string(str.Where(c => !"aeiouAEIOU".Contains(c)).ToArray());
    }

    public static string RemoveFirstFiveElements(this string str) // Функция удаления 5 элементов из строки
    {
        return str.Length > 5 ? str.Substring(5) : string.Empty;
    }
}
