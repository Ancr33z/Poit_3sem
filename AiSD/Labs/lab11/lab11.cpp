#include <iostream>  // Ввод и вывод данных
#include <vector>    // Для работы с векторами
#include <ctime>     // Для генерации случайных чисел
#include <chrono>    // Для замера времени выполнения

using namespace std;
using namespace chrono;

// Функция для генерации случайного числа в диапазоне [min, max]
int randomNumber(int min, int max) {
    return min + rand() % (max - min + 1); // Генерация числа в заданном диапазоне
}

// Функция для генерации и перемешивания номеров в коробках вручную
vector<int> generateBoxes(int n) {
    vector<int> boxes(n); // Создаём вектор для коробок
    for (int i = 0; i < n; ++i) {
        boxes[i] = i + 1; // Заполняем коробки номерами от 1 до n
    }

    // Перемешиваем массив вручную, используя случайные числа
    for (int i = 0; i < n; ++i) {
        int j = randomNumber(0, n - 1); // Генерируем случайный индекс
        swap(boxes[i], boxes[j]);       // Меняем местами элементы
    }

    return boxes; // Возвращаем перемешанный массив
}

// Алгоритм случайного выбора: заключённый открывает случайные 50 коробок
bool randomChoice(const vector<int>& boxes, int prisonerNumber) {
    vector<bool> visited(boxes.size(), false); // Массив для отслеживания уже открытых коробок

    for (int i = 0; i < 50; ++i) { // Максимум 50 попыток
        int boxIndex;
        do {
            boxIndex = randomNumber(0, boxes.size() - 1); // Генерируем случайный индекс коробки
        } while (visited[boxIndex]); // Пропускаем уже открытые коробки

        visited[boxIndex] = true; // Помечаем коробку как открытая
        if (boxes[boxIndex] == prisonerNumber) { // Проверяем номер
            return true; // Найден
        }
    }
    return false; // Не найден
}

// Оптимизированный алгоритм: заключённый следует по цепочке номеров
bool optimalChoice(const vector<int>& boxes, int prisonerNumber) {
    int nextBox = prisonerNumber - 1; // Начинаем с коробки с номером заключённого
    for (int i = 0; i < 50; ++i) { // Максимум 50 шагов
        if (boxes[nextBox] == prisonerNumber) { // Если номер найден
            return true; // Успешно
        }
        nextBox = boxes[nextBox] - 1; // Переходим к следующей коробке
    }
    return false; // Не найден за 50 попыток
}

// Функция для запуска эксперимента
void runExperiment(int n, int rounds) {
    int randomWins = 0;  // Успехи случайного алгоритма
    int optimalWins = 0; // Успехи оптимизированного алгоритма

    auto randomStart = high_resolution_clock::now();
    for (int r = 0; r < rounds; ++r) {
        vector<int> boxes = generateBoxes(n); // Генерируем коробки

        // Проверяем случайный алгоритм
        bool randomSuccess = true;
        for (int prisoner = 1; prisoner <= n; ++prisoner) {
            if (!randomChoice(boxes, prisoner)) {
                randomSuccess = false;
                break;
            }
        }
        if (randomSuccess) randomWins++;
    }
    auto randomEnd = high_resolution_clock::now();
    auto randomDuration = duration_cast<milliseconds>(randomEnd - randomStart);

    auto optimalStart = high_resolution_clock::now();
    for (int r = 0; r < rounds; ++r) {
        vector<int> boxes = generateBoxes(n); // Генерируем коробки

        // Проверяем оптимальный алгоритм
        bool optimalSuccess = true;
        for (int prisoner = 1; prisoner <= n; ++prisoner) {
            if (!optimalChoice(boxes, prisoner)) {
                optimalSuccess = false;
                break;
            }
        }
        if (optimalSuccess) optimalWins++;
    }
    auto optimalEnd = high_resolution_clock::now();
    auto optimalDuration = duration_cast<milliseconds>(optimalEnd - optimalStart);

    // Вывод результатов
    cout << "Результаты после " << rounds << " раундов:" << endl;
    cout << "Случайный алгоритм: " << randomWins << " успешных исходов, время: " << randomDuration.count() << " мс" << endl;
    cout << "Оптимизированный алгоритм: " << optimalWins << " успешных исходов, время: " << optimalDuration.count() << " мс" << endl;
}

int main() {
    srand(time(nullptr)); // Инициализируем генератор случайных чисел

    int n = 100; // Количество заключённых и коробок
    int rounds;  // Количество раундов

    // Ввод количества раундов от пользователя
    cout << "Введите количество раундов для сравнения алгоритмов: ";
    cin >> rounds;

    // Запускаем эксперимент
    runExperiment(n, rounds);

    return 0; // Завершение программы
}
