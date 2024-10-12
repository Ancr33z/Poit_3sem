#include <iostream>
#include <algorithm>
#define I INT_MAX//(используется для обозначения отсутствия пути)

using namespace std;

struct Edge
{
    int start;
    int end;
    int weight;
};

void Prims(int graphMatrix[8][8], int start)
{
    int x = start - 1;
    int y = 0;
    int visited[8];
    int currentEdge = 0;// Счетчик количества добавленных рёбер в остовное дерево

    for (int i = 0; i < 8; i++)
    {
        visited[i] = false;
    }

    visited[x] = true;

    cout << "^алгоритм Прима^\n";
    int primEdges[7][2];// Массив для хранения рёбер остовного дерева

    while (currentEdge < 7)   // Цикл пока не добавим 7 рёбер
    {
        x = 0;
        y = 0;
        int min = I;
        // Перебираем все вершины
        for (int i = 0; i < 8; i++)
        {
            if (visited[i])
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!visited[j])// Проверяем рёбра к непосещённым вершинам
                    {
                        if (min > graphMatrix[i][j])// Если вес ребра меньше текущего минимума
                        {
                            min = graphMatrix[i][j];// Обновляем минимальный вес
                            x = i;
                            y = j;
                        }
                    }
                }
            }
        }

        visited[y] = true;
        // Записываем найденное ребро в остовное дерево
        primEdges[currentEdge][0] = x + 1;
        primEdges[currentEdge][1] = y + 1;
        currentEdge++;
    }

    for (int i = 0; i < 7; i++)
    {
        cout << "вершина " << primEdges[i][0] << " - " << "вершина " << primEdges[i][1] << "; вес: " << graphMatrix[primEdges[i][0] - 1][primEdges[i][1] - 1] << endl;
    }
}
// Функция для проверки соединенности всех вершин 
bool isConnected(int connectedVert[8])
{
    int root = connectedVert[0];// Сравниваем все вершины с первой
    for (int i = 1; i < 8; i++)
    {
        if (connectedVert[i] != root)// Если вершины принадлежат разным компонентам
        {
            return false;
        }
    }
    return true;
}


void Kruslals(Edge edgeList[], int n)
{
    int connectedVert[8];// Массив для хранения информации о компонентах соединенности

    for (int i = 0; i < 8; i++)
    {
        connectedVert[i] = i;        //  каждая вершина — отдельная компонента
    }

    sort(edgeList, edgeList + n, [](Edge& a, Edge& b) { return a.weight < b.weight; });

    cout << "^алгоритм Краскала^\n";
    int kruskalEdges[7][2];
    int edgeCount = 0;// Счетчик добавленных рёбер
    for (int i = 0; i < n; i++) // Проходим по отсортированным рёбрам
    {
        Edge e = edgeList[i]; // Текущее ребро
        // Если вершины не принадлежат одной компоненте
        if (connectedVert[e.start] != connectedVert[e.end])
        {
            kruskalEdges[edgeCount][0] = e.start + 1; // Добавляем ребро в остовное дере
            kruskalEdges[edgeCount][1] = e.end + 1;
            edgeCount++;
            int oldVert = connectedVert[e.start];
            int newVert = connectedVert[e.end];

            for (int j = 0; j < 8; j++)
            {
                if (connectedVert[j] == oldVert)
                {
                    connectedVert[j] = newVert;
                }
            }
        }
    }
    // Вывод рёбер остовного дерева

    for (int i = 0; i < edgeCount; i++)
    {
        int start = kruskalEdges[i][0];
        int end = kruskalEdges[i][1];
        int weight = 0;
        // Поиск веса ребра между вершинами start и end
        for (int j = 0; j < n; j++)
        {
            if ((edgeList[j].start == start - 1 && edgeList[j].end == end - 1) || (edgeList[j].start == end - 1 && edgeList[j].end == start - 1))
            {
                weight = edgeList[j].weight;
                break;
            }
        }
        cout << "вершина " << start << " - " << "вершина " << end << "; вес: " << weight << endl;
    }
}

int main()
{
    setlocale(LC_ALL, "Rus");

    int graphMatrix[8][8] =
    {
        /*    1  2   3   4   5   6   7  8  */
        /*1*/ {I, 2, I,  8,  2,  I,  I, I},
        /*2*/ {2, I, 3, 10,  5,  I,  I, I},
        /*3*/ {I, 3, I,  I,  12,  I, I, 7},
        /*4*/ {8, 10, I, I,  14, 3,  1, I},
        /*5*/ {2, 5, 12, 14, I,  11, 4, 8},
        /*6*/ {I, I, I, 3,   11,  I, 6, I},
        /*7*/ {I, I, I, 1,   4,   6, I, 9},
        /*8*/ {I, I, 7, I,   8,   I, 9, I}
    };
    // Список рёбер для алгоритма Краскала
    Edge edgeList[] =
    {
        {0, 1, 2}, {0, 3, 8}, {6, 4, 4}, {0, 4, 2},
        {1, 2, 3}, {1, 4, 5}, {1, 3, 10}, {2, 4, 12},
        {2, 7, 7}, {3, 4, 14}, {3, 5, 3}, {3, 6, 1},
        {4, 7, 8}, {5, 6, 6}, {6, 7, 9}, {5, 6, 11}
    };

    int start;
    cout << "Введите начальную вершину для алгоритма Прима (1-8): ";
    cin >> start;

    Prims(graphMatrix, start);
    Kruslals(edgeList, sizeof(edgeList) / sizeof(edgeList[0]));

    return 0;
}
