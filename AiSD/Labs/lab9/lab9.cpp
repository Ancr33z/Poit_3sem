#include <iostream> // Подключение библиотеки ввода-вывода
#include<vector> // Подключение библиотеки для работы с векторами
#include<algorithm> // Подключение библиотеки алгоритмов
#include <limits.h> // Подключение библиотеки для работы с константами пределов значений
#include <Windows.h> // Подключение библиотеки Windows
#include <random> // Подключение библиотеки для работы с генерацией случайных чисел
using namespace std; // Использование пространства имен std

//#define V 5 // Определение константы для размера графа
#define V 8 // Альтернативный размер графа

int childsNumber = 0; // Число потомков в популяции
int populationSize = 0; // Размер популяции
int evolutionCirclsNumber = 0; // Количество циклов эволюции
vector<int> nodes = { 1, 2, 3, 4, 5, 6, 7 }; // Вектор узлов графа

//int map[V][V] = { { INT_MAX, 25, 40, 31, 27}, // Определение матрицы смежности для графа
//                { 5, INT_MAX, 17, 30, 25},
//                { 19, 15, INT_MAX, 6, 1},
//                { 9, 50, 24, INT_MAX, 6 },
//                { 22, 8, 7, 10, INT_MAX },
//};

int map[V][V] = {
    {INT_MAX, 25, 40, 31, 27, 16, 7, 9 }, // Расстояния от города 0 до всех остальных
    {5, INT_MAX, 17, 30, 25, 4, 23, 23}, // Расстояния от города 1 до всех остальных
    {19, 15, INT_MAX, 6, 1, 19, 10, 8}, // Расстояния от города 2 до всех остальных
    {9, 50, 24, INT_MAX, 6, 6, 12, 11}, // Расстояния от города 3 до всех остальных
    {22, 8, 7, 10, INT_MAX, 19, 10, 9}, // Расстояния от города 4 до всех остальных
    {9, 50, 24, 6, 11, INT_MAX, 11, 18}, // Расстояния от города 5 до всех остальных
    {9, 50, 24, 6, 6, 14, INT_MAX, 10}, // Расстояния от города 6 до всех остальных
    {9, 50, 24, 6, 6, 12, 15, INT_MAX} // Расстояния от города 7 до всех остальных
};

struct individual { // Структура для представления особи в популяции
    string genome; // Геном особи
    int adaptability; // Приспособленность особи
};

int generateRandomNumber(int start, int end) // Функция для генерации случайного числа в диапазоне
{
    return start + rand() % (end - start); // Генерирует случайное число от start до end
}

bool isCorrect(string s, char ch) // Проверка корректности добавления узла в геном
{
    for (int i = 0; i < s.size(); i++) { // Проходим по каждому элементу строки
        if (s[i] == ch) // Проверяем, не дублируется ли узел
            return false;
    }
    if (map[s[s.size() - 1] - 48][ch - 48] == INT_MAX) { // Проверяем допустимость пути
        return false;
    }
    return true;
}

string mutatedGene(string genome) // Функция для мутации гена
{
    while (true) { // Бесконечный цикл, пока не будет выполнена мутация
        int g1 = generateRandomNumber(1, V); // Генерация первого случайного гена
        int g2 = generateRandomNumber(1, V); // Генерация второго случайного гена

        if (g2 != g1) { // Проверка, чтобы гены были разными
            char temp = genome[g1]; // Замена генов
            genome[g1] = genome[g2];
            genome[g2] = temp;

            break; // Выход из цикла после выполнения замены
        }
    }
    return genome; // Возвращаем мутированный геном
}

string createGenome() // Функция для создания генома
{
    vector<int> n = nodes; // Копирование узлов
    string genome = "0"; // Начальный геном
    while (true) { // Бесконечный цикл
        if (genome.size() == V) { // Проверка длины генома
            genome += genome[0]; // Замыкаем путь
            break;
        }
        int t;
        if (n.size() == 1) { // Если остался один узел
            t = 0;
        }
        else {
            t = generateRandomNumber(0, n.size() - 1); // Случайный выбор узла
        }
        int temp = n[t];
        if (isCorrect(genome, (char)(temp + 48))) { // Проверка корректности добавления узла
            genome += (char)(temp + 48); // Добавление узла в геном
            n.erase(n.begin() + t); // Удаление узла из списка
        }
    }
    return genome; // Возвращаем сгенерированный геном
}

int calculateAdaptability(string genome) // Функция для расчета приспособленности генома
{
    int distance = 0;

    for (int i = 0; i < genome.size() - 1; i++) { // Проходим по каждому гену в геноме
        if (map[genome[i] - 48][genome[i + 1] - 48] == INT_MAX) // Проверка допустимости пути
            return INT_MAX; // Возвращаем максимальное значение, если путь недопустим

        distance += map[genome[i] - 48][genome[i + 1] - 48]; // Добавляем расстояние к общей дистанции
    }

    return distance; // Возвращаем общую приспособленность генома (сумму расстояний)
}

bool compareAdapdability(struct individual t1, struct individual t2) // Функция сравнения по приспособленности
{
    return t1.adaptability < t2.adaptability; // Сравниваем приспособленность двух особей
}

void doGeneticAlgorithm(int map[V][V]) // Основная функция генетического алгоритма
{
    vector<struct individual> population; // Вектор для хранения популяции
    struct individual temp;

    for (int i = 0; i < populationSize; i++) { // Создаем начальную популяцию
        temp.genome = createGenome(); // Генерируем геном
        temp.adaptability = calculateAdaptability(temp.genome); // Рассчитываем приспособленность
        population.push_back(temp); // Добавляем в популяцию
    }

    cout << "\nСтартовая популяция: " << endl;
    cout << "Геном популяци \tвес генома\n";
    for (int i = 0; i < populationSize; i++) // Выводим стартовую популяцию
        cout << population[i].genome << "\t\t"
        << population[i].adaptability << endl;
    cout << "\n";

    sort(population.begin(), population.end(), compareAdapdability); // Сортировка популяции по приспособленности

    int circl = 1;
    while (circl <= evolutionCirclsNumber) { // Основной цикл эволюции
        cout << endl << "Лучший геном: " << population[0].genome;
        cout << " его вес: " << population[0].adaptability << "\n\n";

        vector<struct individual> new_population;

        for (int i = 0; i < childsNumber; i++) { // Генерация потомков

            struct individual parent1 = population[i]; // Выбор родителя 1
            struct individual parent2 = population[i + 1]; // Выбор родителя 2

            while (true)
            {
                string new_genome = mutatedGene(parent1.genome); // Мутация гена
                struct individual new_gene;
                new_gene.genome = new_genome;
                new_gene.adaptability = calculateAdaptability(new_gene.genome); // Расчет приспособленности

                if (new_gene.adaptability <= population[i].adaptability) { // Проверка приспособленности
                    new_population.push_back(new_gene);
                    break;
                }
                else {
                    new_gene.adaptability = INT_MAX;
                    new_population.push_back(new_gene);
                    break;
                }
            }
        }

        for (int i = 0; i < childsNumber; i++) // Добавление потомков в популяцию
        {
            population.push_back(new_population[i]);
        }
        sort(population.begin(), population.end(), compareAdapdability); // Сортировка популяции

        for (int i = 0; i < childsNumber; i++) // Удаление наименее приспособленных
        {
            population.pop_back();
        }

        cout << "Поколение " << circl << " \n";
        cout << "Геном популяци \tвес генома\n";

        for (int i = 0; i < populationSize; i++) // Вывод популяции
            cout << population[i].genome << "\t\t"
            << population[i].adaptability << endl;
        circl++;
    }
    cout << "\n\nнаиболее оптимальный маршрут, найденный генетическим алгоритмом с текущими параметрами: ";
    cout << population[0].genome;
    cout << "\n\n";
}

int main() // Основная функция
{
    srand(time(0));
    setlocale(LC_ALL, "ru"); // Установка локали
    cout << "Введите размер популяций: "; cin >> populationSize;
    cout << "Введите количество потомков в одной популяции: "; cin >> childsNumber;
    cout << "Введите количество эволюционных циклов: "; cin >> evolutionCirclsNumber;
    doGeneticAlgorithm(map); // Запуск генетического алгоритма
}
