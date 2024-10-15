#include <iostream>
#include <string>
#include <vector>
#include <unordered_map>
#include <algorithm>
#include <windows.h>

using namespace std;

struct Node {
    string ch;
    int freq;
    Node* left, * right;
    int index;
};

Node* getNode(string ch, int freq, Node* left, Node* right, int index) {
    Node* node = new Node();
    node->ch = ch;
    node->freq = freq;
    node->left = left;
    node->right = right;
    node->index = index;
    return node;
}

void encode(Node* root, string str, unordered_map<string, string>& huffmanCode) {
    if (root == nullptr) return;

    if (!root->left && !root->right) {
        huffmanCode[root->ch] = str;
    }

    encode(root->left, str + "0", huffmanCode);
    encode(root->right, str + "1", huffmanCode);
}

void printTree(Node* root, string indent = "", bool isRight = true) {
    if (root != nullptr) {
        cout << indent;
        if (isRight) {
            cout << "R----";
            indent += "     ";
        }
        else {
            cout << "L----";
            indent += "|    ";
        }
        cout << root->ch << "(" << root->freq << ")" << endl;
        printTree(root->left, indent, false);
        printTree(root->right, indent, true);
    }
}

void buildHuffmanTree(string text) {
    unordered_map<string, int> freq;

    for (char ch : text) {
        string s(1, ch);
        freq[s]++;
    }

    vector<Node*> nodes;
    int index = 0;

    for (auto pair : freq) {
        nodes.push_back(getNode(pair.first, pair.second, nullptr, nullptr, index++));
    }

    // Sort nodes by frequency in descending order
    sort(nodes.begin(), nodes.end(), [](Node* l, Node* r) {
        return l->freq > r->freq;
        });

    while (nodes.size() > 1) {
        Node* right = nodes.back(); nodes.pop_back();
        Node* left = nodes.back(); nodes.pop_back();

        int sum = left->freq + right->freq;
        Node* parent = getNode(left->ch + right->ch, sum, left, right, index++);
        nodes.push_back(parent);

        // Sort nodes again by frequency in descending order
        sort(nodes.begin(), nodes.end(), [](Node* l, Node* r) {
            return l->freq > r->freq;
            });
    }

    Node* root = nodes.front();
    cout << "\nДерево Хаффмана:\n";
    printTree(root);

    unordered_map<string, string> huffmanCode;
    encode(root, "", huffmanCode);

    cout << "\nКоды Хаффмана:\n";
    for (auto pair : huffmanCode) {
        cout << "Символ: '" << pair.first << "' Код: " << pair.second << '\n';
    }
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    string text;
    cout << "Введите текст для кодирования: ";
    getline(cin, text);

    cout << "Построение дерева для текста: \"" << text << "\"\n";
    buildHuffmanTree(text);

    return 0;
}
