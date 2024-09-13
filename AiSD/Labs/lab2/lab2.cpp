#include <iostream>
#include <queue>

using namespace std;

const int n = 10;
bool* visited = new bool[n];

//матрица смежности графа
int graph[n][n] =
{
{0, 1, 0, 0, 1, 0, 0, 0, 0, 0},
{1, 0, 0, 0, 0, 0, 1, 1, 0, 0},
{0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
{0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
{1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
{0, 0, 0, 1, 1, 0, 0, 0, 1, 0},
{0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
{0, 1, 1, 0, 0, 0, 1, 0, 0, 0},
{0, 0, 0, 1, 0, 1, 0, 0, 0, 1},
{0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
};

//поиск в глубину
void DFS(int st)
{
	cout << st + 1 << " ";
	visited[st] = true;

	for (int r = 0; r < n; r++) {
		if ((graph[st][r] != 0) && (!visited[r]))
			DFS(r);
	}
}

//поиск в ширину
void BFS(int start)
{
	queue <int> q; // очередь для хранения номеров вершин
	bool visited[n]; //false - вершина не рассмотрена, true - рассмотрена
	bool inqueue[n]; //false - вершина не в очереди, true - в очереди
	int view_cell; // номер посещаемой вершины

	for (int i = 0; i < n; i++)
	{
		visited[i] = inqueue[i] = false;
	}

	q.push(start); // записываем начальную вершину в очередь
	visited[start] = inqueue[start] = true; //рассмотрели первую вершину

	while (!q.empty())
	{
		view_cell = q.front(); //обращение к первому элементу очереди
		cout << view_cell + 1 << " ";

		visited[view_cell] = true;
		q.pop();

		for (int i = 0; i < n; i++)
		{
			if (!inqueue[i] && graph[view_cell][i])
			{
				q.push(i);
				inqueue[i] = true;
			}
		}
	}
}

// функция для подсчета количества рёбер
int countEdges()
{
	int edgeCount = 0;
	for (int i = 0; i < n; i++)
	{
		for (int j = i + 1; j < n; j++) // просматриваем только верхнюю половину матрицы
		{
			if (graph[i][j] == 1)
			{
				edgeCount++;
			}
		}
	}
	return edgeCount;
}

//главная функция
int main()
{
	setlocale(LC_ALL, "Rus");
	int start;
	cout << "Матрица смежности графа: " << endl;
	for (int i = 0; i < n; i++)
	{
		visited[i] = false;

		for (int j = 0; j < n; j++)
			cout << " " << graph[i][j];
		cout << endl;
	}

	// Подсчет количества рёбер
	int edges = countEdges();
	cout << "\nЧисло рёбер в графе: " << edges << endl;

	//поиск в глубину
	cout << "\n" << endl;
	cout << "Поиск в глубину" << endl;
	cout << "Стартовая вершина >> "; cin >> start;
	cout << "Порядок обхода: ";
	DFS(start - 1);

	//поиск в ширину
	cout << "\n" << endl;
	int start_2;
	cout << "\nПоиск в ширину" << endl;
	cout << "Стартовая вершина >> "; cin >> start_2;
	cout << "Порядок обхода: ";
	BFS(start_2 - 1);

	//Числовое O большое
	cout << "\nЧисловая оценка сложности (O):" << endl;
	cout << "Время работы DFS: O(" << n * n << ") = " << n * n << endl;
	cout << "Время работы BFS: O(" << n * n << ") = " << n * n << endl;

	delete[] visited;
	cout << endl;

	return 0;
}
