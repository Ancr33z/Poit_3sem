using System;
using System.Collections.Generic;
using System.Linq;

class Node
{
    public char Symbol; // Символ, который хранится в узле (для листовых узлов)
    public int Frequency; // Частота появления символа
    public Node Left;
    public Node Right;

    // Конструктор для листовых узлов, которым задаются символ и частота
    public Node(char symbol, int frequency)
    {
        Symbol = symbol;
        Frequency = frequency;
    }

    // Конструктор для внутренних узлов, которые создаются на основе двух потомков
    public Node(Node left, Node right)
    {
        Symbol = '0'; // У внутренних узлов нет собственного символа, используем '0'
        Frequency = left.Frequency + right.Frequency; // Частота внутренних узлов — сумма частот потомков
        Left = left;
        Right = right;
    }
}

class HuffmanCoding
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Введите строку: ");
        string input = Console.ReadLine();
        var frequencyTable = BuildFrequencyTable(input); // Создаем таблицу частот символов


        Console.WriteLine("Таблица частот:");
        foreach (var pair in frequencyTable)
        {
            // Вывод каждого символа и его частоты
            Console.WriteLine($"'{pair.Key}': {pair.Value}");
        }


        var huffmanTree = BuildHuffmanTree(frequencyTable);
        var huffmanCodes = GenerateHuffmanCodes(huffmanTree);
        Console.WriteLine("\nДерево Хаффмана:");
        PrintHuffmanTree(huffmanTree);

        Console.WriteLine("\nКоды Хаффмана:");
        foreach (var pair in huffmanCodes)
        {

            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }


        var encodedString = EncodeString(input, huffmanCodes);
        Console.WriteLine($"\nЗакодированная строка: {encodedString}");
    }

    // Функция для вывода дерева Хаффмана
    private static void PrintHuffmanTree(Node node, string code = "")
    {
        if (node == null) return; // Если узел пустой, ничего не делаем

        // Если узел является листом, выводим символ и код
        if (node.Left == null && node.Right == null)
        {
            Console.WriteLine($"Символ: '{node.Symbol}', Код: {code}, Частота: {node.Frequency}");
        }
        else
        {
            // Если это внутренний узел, рекурсивно обходим левого и правого потомков
            PrintHuffmanTree(node.Left, code + "0"); // Переход в левый узел добавляет "0" к коду
            PrintHuffmanTree(node.Right, code + "1"); // Переход в правый узел добавляет "1" к коду
        }
    }


    // Метод для построения таблицы частот символов в строке
    private static Dictionary<char, int> BuildFrequencyTable(string input)
    {
        var frequencyTable = new Dictionary<char, int>(); // Словарь для хранения частоты символов

        foreach (char c in input)
        {
            // Если символ уже есть в таблице, увеличиваем его частоту
            if (frequencyTable.ContainsKey(c))
                frequencyTable[c]++;
            else
                // Если символа нет, добавляем его с частотой 1
                frequencyTable[c] = 1;
        }

        return frequencyTable; // Возвращаем таблицу частот
    }


    private static Node BuildHuffmanTree(Dictionary<char, int> frequencyTable)
    {
        var priorityQueue = new List<Node>(); // Список для хранения узлов дерева

        // Создаем узлы для каждого символа и добавляем их в очередь
        foreach (var pair in frequencyTable)
        {
            priorityQueue.Add(new Node(pair.Key, pair.Value));
        }

        // Сортируем очередь по убыванию частоты (чем реже символ, тем выше его приоритет)
        priorityQueue = priorityQueue.OrderByDescending(n => n.Frequency).ToList();

        // Пока в очереди больше одного узла, продолжаем строить дерево
        while (priorityQueue.Count > 1)
        {
            // Берем два узла с наименьшей частотой (в конце списка)
            var left = priorityQueue.Last();
            priorityQueue.RemoveAt(priorityQueue.Count - 1); // Удаляем последний элемент (левый узел)
            var right = priorityQueue.Last();
            priorityQueue.RemoveAt(priorityQueue.Count - 1); // Удаляем предпоследний элемент (правый узел)

            // Создаем новый внутренний узел с двумя потомками
            var newNode = new Node(left, right);
            // Добавляем новый узел обратно в очередь
            priorityQueue.Add(newNode);

            // Снова сортируем очередь по убыванию частоты
            priorityQueue = priorityQueue.OrderByDescending(n => n.Frequency).ToList();
        }

        return priorityQueue.First(); // Возвращаем корень дерева (единственный оставшийся узел)
    }


    private static Dictionary<char, string> GenerateHuffmanCodes(Node root)
    {
        var codes = new Dictionary<char, string>(); // Словарь для хранения кодов символов
        GenerateCodes(root, "", codes); // Рекурсивно генерируем коды
        return codes; // Возвращаем словарь с кодами
    }


    private static void GenerateCodes(Node node, string code, Dictionary<char, string> codes)
    {
        if (node == null) return;

        // Если узел является листовым (нет потомков), добавляем его код в словарь
        if (node.Left == null && node.Right == null)
        {
            codes[node.Symbol] = code;
            return;
        }


        GenerateCodes(node.Left, code + "0", codes);
        GenerateCodes(node.Right, code + "1", codes);
    }


    private static string EncodeString(string input, Dictionary<char, string> huffmanCodes)
    {
        var encodedString = ""; // Строка для хранения закодированной строки
        foreach (char c in input)
        {
            // Для каждого символа добавляем его код в закодированную строку
            encodedString += huffmanCodes[c];
        }
        return encodedString; // Возвращаем закодированную строку
    }

}