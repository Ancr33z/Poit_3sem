using lab9;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace lab9
{
    public class Program
    {
        public static void Main()
        {
            ////////////////////////////////////// Инициализация массивов и вывод их на экран //////////////////////////////////////
            Console.WriteLine("--------------------------------------------------");
            BooksCollection collection = new BooksCollection();
            collection.Add(new Boooks("Хоббит", "Джон Рональд Руэл Толкин"));
            collection.Add(new Boooks("И никого не стало", "Агата Кристи"));
            collection.Add(new Boooks("Параллелепипед", "Геометрия Автор"));
            collection.Add(new Boooks("Треугольник", "Геометрия Автор"));
            collection.Add(new Boooks("Октаэдр", "Геометрия Автор"));
            collection.Add(new Boooks("Дельтоид", "Геометрия Автор"));
            collection.Show();

            Console.WriteLine("--------------------------------------------------");
            collection.RemoveAt(3); // Удаляем книгу по индексу
            collection.Show();

            Console.WriteLine("--------------------------------------------------");
            collection.Insert(3, new Boooks("Тор", "Мифология Автор")); // Вставляем книгу по индексу
            collection.Show();

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{collection[5]}"); // Выводим информацию о книге по индексу



            /*Используя стандартные типы делегатов 
            (Action, Func, Predicate) организуйте алгоритм последовательной обработки 
            строки написанными вами методами. Везде где возможно использовать лямбда-выражения.*/
            Console.WriteLine("--------------------------------------------------");
            // Создаем коллекцию List<int> и заполняем ее данными типа int
            List<int> numbers = new List<int>();

            for (int i = 1; i < 8; i++)
                numbers.Add(i);

            // a) Выводим коллекцию на консоль
            foreach (var number in numbers)
                Console.WriteLine(number.ToString());
            Console.WriteLine("--------------------------------------------------");

            // b) Удаляем из коллекции 4 последовательных элемента
            numbers.RemoveRange(0, 4); // Удаляем первые 4 элемента
            foreach (var number in numbers)
                Console.WriteLine(number.ToString());
            Console.WriteLine("--------------------------------------------------");

            // c) Добавляем другие элементы, используя различные методы добавления
            numbers.Add(10);             // Добавляем элемент в конец списка
            numbers.Insert(0, 11);       // Вставляем элемент в начало списка
            numbers.Insert(2, 12);       // Вставляем элемент по индексу 2
            numbers.AddRange(new[] { 13, 14 }); // Добавляем коллекцию элементов в конец списка
            foreach (var number in numbers)
                Console.WriteLine(number.ToString());
            Console.WriteLine("--------------------------------------------------");

            // d) Создаем вторую коллекцию HashSet<int> и заполняем ее данными из первой коллекции
            HashSet<int> uniqueNumbers = new HashSet<int>(numbers);

            // e) Выводим вторую коллекцию на консоль
            foreach (var number in uniqueNumbers)
                Console.WriteLine(number.ToString());


            Console.WriteLine("-----------------------------------------------------------------------");
            /*3. Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте 
            произвольный метод и зарегистрируйте его на событие CollectionChange. 
            Напишите демонстрацию с добавлением и удалением элементов. В качестве 
            типа T используйте свой класс из таблицы.*/
            // Создаем ObservableCollection с объектами Book
            ObservableCollection<Boooks> books = new ObservableCollection<Boooks>()
            {
                new Boooks("Хоббит", "Джон Рональд Руэл Толкин"),
                new Boooks("1984", "Джордж Оруэлл"),
                new Boooks("Мастер и Маргарита", "Михаил Булгаков"),
                new Boooks("Война и мир", "Лев Толстой")
            };

            // Подписываемся на событие CollectionChanged
            books.CollectionChanged += BooksCollectionChanged;

            // Выводим начальное состояние коллекции
            foreach (var book in books)
                Console.WriteLine(book.ToString());
            Console.WriteLine("--------------------------------------------------");

            // Добавляем, изменяем и удаляем элементы в коллекции
            books.Add(new Boooks("Преступление и наказание", "Федор Достоевский")); // Добавление
            books[0] = new Boooks("Братья Карамазовы", "Федор Достоевский");         // Замена элемента
            books.RemoveAt(2);                                                     // Удаление

            Console.WriteLine("--------------------------------------------------");
            // Выводим финальное состояние коллекции
            foreach (var book in books)
                Console.WriteLine(book.ToString());

            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        private static void BooksCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Добавлены новые элементы:");
                    foreach (Boooks book in e.NewItems)
                        Console.WriteLine(book.ToString());
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Удалены элементы:");
                    foreach (Boooks book in e.OldItems)
                        Console.WriteLine(book.ToString());
                    break;

                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Элементы заменены:");
                    Console.WriteLine("Старый элемент:");
                    foreach (Boooks book in e.OldItems)
                        Console.WriteLine(book.ToString());
                    Console.WriteLine("Новый элемент:");
                    foreach (Boooks book in e.NewItems)
                        Console.WriteLine(book.ToString());
                    break;
            }
        }
    }
}