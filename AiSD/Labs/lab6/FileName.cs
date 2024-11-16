using System;
using System.Collections.Generic;
using System.Linq;

class Node
{
	public char Symbol; // ������, ������� �������� � ���� (��� �������� �����)
	public int Frequency; // ������� ��������� �������
	public Node Left;
	public Node Right;

	// ����������� ��� �������� �����, ������� �������� ������ � �������
	public Node(char symbol, int frequency)
	{
		Symbol = symbol;
		Frequency = frequency;
	}

	// ����������� ��� ���������� �����, ������� ��������� �� ������ ���� ��������
	public Node(Node left, Node right)
	{
		Symbol = '0'; // � ���������� ����� ��� ������������ �������, ���������� '0'
		Frequency = left.Frequency + right.Frequency; // ������� ���������� ����� � ����� ������ ��������
		Left = left;
		Right = right;
	}
}

class HuffmanCoding
{
	public static void Main(string[] args)
	{

		Console.WriteLine("������� ������: ");
		string input = Console.ReadLine();
		var frequencyTable = BuildFrequencyTable(input); // ������� ������� ������ ��������


		Console.WriteLine("������� ������:");
		foreach (var pair in frequencyTable)
		{
			// ����� ������� ������� � ��� �������
			Console.WriteLine($"'{pair.Key}': {pair.Value}");
		}


		var huffmanTree = BuildHuffmanTree(frequencyTable);
		var huffmanCodes = GenerateHuffmanCodes(huffmanTree);


		Console.WriteLine("\n���� ��������:");
		foreach (var pair in huffmanCodes)
		{

			Console.WriteLine($"{pair.Key}: {pair.Value}");
		}


		var encodedString = EncodeString(input, huffmanCodes);
		Console.WriteLine($"\n�������������� ������: {encodedString}");
	}

	// ����� ��� ���������� ������� ������ �������� � ������
	private static Dictionary<char, int> BuildFrequencyTable(string input)
	{
		var frequencyTable = new Dictionary<char, int>(); // ������� ��� �������� ������� ��������

		foreach (char c in input)
		{
			// ���� ������ ��� ���� � �������, ����������� ��� �������
			if (frequencyTable.ContainsKey(c))
				frequencyTable[c]++;
			else
				// ���� ������� ���, ��������� ��� � �������� 1
				frequencyTable[c] = 1;
		}

		return frequencyTable; // ���������� ������� ������
	}


	private static Node BuildHuffmanTree(Dictionary<char, int> frequencyTable)
	{
		var priorityQueue = new List<Node>(); // ������ ��� �������� ����� ������

		// ������� ���� ��� ������� ������� � ��������� �� � �������
		foreach (var pair in frequencyTable)
		{
			priorityQueue.Add(new Node(pair.Key, pair.Value));
		}

		// ��������� ������� �� �������� ������� (��� ���� ������, ��� ���� ��� ���������)
		priorityQueue = priorityQueue.OrderByDescending(n => n.Frequency).ToList();

		// ���� � ������� ������ ������ ����, ���������� ������� ������
		while (priorityQueue.Count > 1)
		{
			// ����� ��� ���� � ���������� �������� (� ����� ������)
			var left = priorityQueue.Last();
			priorityQueue.RemoveAt(priorityQueue.Count - 1); // ������� ��������� ������� (����� ����)
			var right = priorityQueue.Last();
			priorityQueue.RemoveAt(priorityQueue.Count - 1); // ������� ������������� ������� (������ ����)

			// ������� ����� ���������� ���� � ����� ���������
			var newNode = new Node(left, right);
			// ��������� ����� ���� ������� � �������
			priorityQueue.Add(newNode);

			// ����� ��������� ������� �� �������� �������
			priorityQueue = priorityQueue.OrderByDescending(n => n.Frequency).ToList();
		}

		return priorityQueue.First(); // ���������� ������ ������ (������������ ���������� ����)
	}


	private static Dictionary<char, string> GenerateHuffmanCodes(Node root)
	{
		var codes = new Dictionary<char, string>(); // ������� ��� �������� ����� ��������
		GenerateCodes(root, "", codes); // ���������� ���������� ����
		return codes; // ���������� ������� � ������
	}


	private static void GenerateCodes(Node node, string code, Dictionary<char, string> codes)
	{
		if (node == null) return;

		// ���� ���� �������� �������� (��� ��������), ��������� ��� ��� � �������
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
		var encodedString = ""; // ������ ��� �������� �������������� ������
		foreach (char c in input)
		{
			// ��� ������� ������� ��������� ��� ��� � �������������� ������
			encodedString += huffmanCodes[c];
		}
		return encodedString; // ���������� �������������� ������
	}
}








































//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Node
//{
//    public char Symbol;
//    public int Frequency;
//    public Node Left;
//    public Node Right;

//    public Node(char symbol, int frequency)
//    {
//        Symbol = symbol;
//        Frequency = frequency;
//    }

//    public Node(Node left, Node right)
//    {
//        Symbol = '0'; // ������� ������ ��� ���������� �����
//        Frequency = left.Frequency + right.Frequency;
//        Left = left;
//        Right = right;
//    }
//}

//class HuffmanCoding
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("������� ������: ");
//        string input = Console.ReadLine(); // ���� ������
//        var frequencyTable = BuildFrequencyTable(input);

//        // ������� ������� ������
//        Console.WriteLine("������� ������:");
//        foreach (var pair in frequencyTable)
//        {
//            Console.WriteLine($"'{pair.Key}': {pair.Value}");
//        }

//        var huffmanTree = BuildHuffmanTree(frequencyTable);
//        var huffmanCodes = GenerateHuffmanCodes(huffmanTree);

//        Console.WriteLine("\n���� ��������:");
//        foreach (var pair in huffmanCodes)
//        {
//            Console.WriteLine($"{pair.Key}: {pair.Value}");
//        }

//        // ���������� ������
//        var encodedString = EncodeString(input, huffmanCodes);
//        Console.WriteLine($"\n�������������� ������: {encodedString}");
//    }

//    private static Dictionary<char, int> BuildFrequencyTable(string input)
//    {
//        var frequencyTable = new Dictionary<char, int>();

//        foreach (char c in input)
//        {
//            if (frequencyTable.ContainsKey(c))
//                frequencyTable[c]++;
//            else
//                frequencyTable[c] = 1;
//        }

//        return frequencyTable;
//    }

//    private static Node BuildHuffmanTree(Dictionary<char, int> frequencyTable)
//    {
//        var priorityQueue = new List<Node>();

//        foreach (var pair in frequencyTable)
//        {
//            priorityQueue.Add(new Node(pair.Key, pair.Value));
//        }

//        // ��������� �� �������� �������
//        priorityQueue = priorityQueue.OrderByDescending(n => n.Frequency).ToList();

//        while (priorityQueue.Count > 1)
//        {
//            // ����� ��� ���� � ���������� ��������
//            var left = priorityQueue.Last();
//            priorityQueue.RemoveAt(priorityQueue.Count - 1);
//            var right = priorityQueue.Last();
//            priorityQueue.RemoveAt(priorityQueue.Count - 1);

//            // ������� ����� ���� � ��������� ��� ������� � �������
//            var newNode = new Node(left, right);
//            priorityQueue.Add(newNode);

//            // ��������� ����� �� �������� �������
//            priorityQueue = priorityQueue.OrderByDescending(n => n.Frequency).ToList();
//        }

//        return priorityQueue.First();
//    }

//    private static Dictionary<char, string> GenerateHuffmanCodes(Node root)
//    {
//        var codes = new Dictionary<char, string>();
//        GenerateCodes(root, "", codes);
//        return codes;
//    }

//    private static void GenerateCodes(Node node, string code, Dictionary<char, string> codes)
//    {
//        if (node == null) return;

//        if (node.Left == null && node.Right == null) // ��� �������� ����
//        {
//            codes[node.Symbol] = code;
//            return;
//        }

//        GenerateCodes(node.Left, code + "0", codes);
//        GenerateCodes(node.Right, code + "1", codes);
//    }

//    private static string EncodeString(string input, Dictionary<char, string> huffmanCodes)
//    {
//        var encodedString = "";
//        foreach (char c in input)
//        {
//            encodedString += huffmanCodes[c];
//        }
//        return encodedString;
//    }
//}