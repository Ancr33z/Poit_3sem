#include <iostream>
#include <string>
#include <queue>
#include <windows.h>
#include <unordered_map>
using namespace std;

struct Node
{
    char ch;
    int freq;
    Node* left, * right;
    int index; // Поле индекса для сохранения порядка добавления
};

// Функция для создания нового узла
Node* getNode(char ch, int freq, Node* left, Node* right, int index)
{
    Node* node = new Node();
    node->ch = ch;
    node->freq = freq;
    node->left = left;
    node->right = right;
    node->index = index; // Инициализируем индекс
    return node;
}

// Структура для сравнения узлов в приоритетной очереди
struct comp
{
    // Функция сравнения узлов по частоте, если частоты равны — сравниваем по ASCII
    bool operator()(Node* l, Node* r)
    {
        if (l->freq == r->freq)
            return l->ch > r->ch;  // При одинаковых частотах приоритет символа с меньшим ASCII
        return l->freq > r->freq;  // Узлы с меньшей частотой имеют более высокий приоритет
    }
};

void encode(Node* root, string str, unordered_map<char, string>& huffmanCode)
{
    if (root == nullptr)
        return;

    if (!root->left && !root->right)
        huffmanCode[root->ch] = str;

    encode(root->left, str + "0", huffmanCode);
    encode(root->right, str + "1", huffmanCode);
}

void decode(Node* root, int& index, string str)
{
    if (root == nullptr)
    {
        return;
    }

    if (!root->left && !root->right)
    {
        cout << root->ch;
        return;
    }
    index++;

    // Рекурсивно декодируем в зависимости от текущего бита (0 или 1)
    if (str[index] == '0')
        decode(root->left, index, str);
    else
        decode(root->right, index, str);
}

// Функция для визуализации дерева
void printTree(Node* root, string indent = "", bool isRight = true)
{
    if (root != nullptr)
    {
        cout << indent;
        if (isRight)
        {
            cout << "R----";
            indent += "     ";
        }
        else
        {
            cout << "L----";
            indent += "|    ";
        }
        cout << root->ch << "(" << root->freq << ")" << endl;
        printTree(root->left, indent, false);
        printTree(root->right, indent, true);
    }
}

void buildHuffmanTree(string text)
{
    // Хэш-таблица для хранения частот каждого символа
    unordered_map<char, int> freq;

    // Заполнение хэш-таблицы частот символов
    for (char ch : text)
    {
        freq[ch]++;
    }

    // Приоритетная очередь для хранения узлов дерева Хаффмана
    priority_queue<Node*, vector<Node*>, comp> pq;

    // Переменная для отслеживания индекса узла
    int index = 0;

    // Добавляем узлы в приоритетную очередь
    for (auto pair : freq) {
        pq.push(getNode(pair.first, pair.second, nullptr, nullptr, index++));
    }

    cout << "Частота символов" << endl;
    for (auto pair : freq)
    {
        cout << pair.first << " " << pair.second << endl;
    }

    // Строим дерево Хаффмана, объединяя узлы с наименьшей частотой
    while (pq.size() != 1)
    {
        Node* left = pq.top(); pq.pop();
        Node* right = pq.top(); pq.pop();

        int sum = left->freq + right->freq;
        pq.push(getNode('\0', sum, left, right, index++));
    }

    // Корень дерева Хаффмана
    Node* root = pq.top();

    // Визуализируем дерево
    cout << "\nДерево Хаффмана:\n";
    printTree(root);

    // Хэш-таблица для хранения кодов Хаффмана для каждого символа
    unordered_map<char, string> huffmanCode;

    encode(root, "", huffmanCode);

    cout << "Коды Хаффмана :\n" << '\n';
    for (auto pair : huffmanCode)
    {
        cout << "Символ: '" << pair.first << "' Код: " << pair.second << '\n';
    }

    cout << "\nИсходная строка :\n" << text << '\n';

    string str = "";
    for (char ch : text)
    {
        str += huffmanCode[ch];
    }

    cout << "\nЗакодированная строка :\n" << str << '\n';

    int indexDecode = -1;

    cout << "\nДекодированная строка: \n";
    while (indexDecode < (int)str.size() - 2)
    {
        decode(root, indexDecode, str);
    }
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    string text;
    cout << "Введите текст для кодирования: ";
    getline(cin, text);  // Ввод текста пользователем

    buildHuffmanTree(text);

    return 0;
}
