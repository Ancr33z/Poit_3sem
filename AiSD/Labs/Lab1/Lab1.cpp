#include <chrono>
#include <iostream>
#include <vector>

using namespace std;

int counter = 0;

// Основной рекурсивный алгоритм для задачи Ханойской башни с произвольным числом стержней
void Hano(int n, int source, int target, vector<int>& sticks) {
    if (n == 0) return;
    if (n == 1) {
        counter++;
        cout << "Переместить диск с " << source << " на " << target << endl;
        return;
    }

    if (sticks.size() == 3) {
        // Если только 3 стержня, используем классический алгоритм
        int temp = 6 - source - target;
        Hano(n - 1, source, temp, sticks);
        Hano(1, source, target, sticks);
        Hano(n - 1, temp, target, sticks);
    }
    else {
        // Найдем промежуточные стержни, исключая source и target
        vector<int> remaining_sticks;
        for (int stick : sticks) {
            if (stick != source && stick != target) {
                remaining_sticks.push_back(stick);
            }
        }

        // Используем первый оставшийся стержень как промежуточный
        int mid_stick = remaining_sticks[0];

        // Разбиваем задачу: часть дисков перемещаем на промежуточный стержень
        int k = n - 1; // Выбираем количество дисков для переноса на промежуточный стержень

        // Перемещаем k дисков на промежуточный стержень
        Hano(k, source, mid_stick, sticks);

        // Перемещаем оставшийся диск на целевой стержень
        Hano(1, source, target, sticks);

        // Перемещаем k дисков с промежуточного стержня на целевой стержень
        Hano(k, mid_stick, target, sticks);
    }
}

int main() {
    setlocale(LC_ALL, "Rus");

    int n, num_sticks, source, target;

    while (true) {
        // Ввод количества стержней
        cout << "\nВведите количество стержней (>= 3): ";
        cin >> num_sticks;
        if (cin.fail() || num_sticks < 3) {
            cout << "\n Данные введены неверно, попробуйте ещё раз." << endl;
            cin.clear();
            cin.ignore(32767, '\n');
            continue;
        }

        // Ввод количества дисков
        cout << "\nВведите число дисков (1 - 1000): ";
        cin >> n;
        if (cin.fail() || n <= 0 || n > 1000) {
            cout << "\n Данные введены неверно, попробуйте ещё раз." << endl;
            cin.clear();
            cin.ignore(32767, '\n');
            continue;
        }

        // Ввод исходного стержня
        cout << "\nВведите номер стержня, с которого нужно переместить диски (1 - " << num_sticks << "): ";
        cin >> source;
        if (cin.fail() || source < 1 || source > num_sticks) {
            cout << "\n Данные введены неверно, попробуйте ещё раз." << endl;
            cin.clear();
            cin.ignore(32767, '\n');
            continue;
        }

        // Ввод целевого стержня
        cout << "\nВведите номер стержня, на который нужно переместить диски (1 - " << num_sticks << ", не равный " << source << "): ";
        cin >> target;
        if (cin.fail() || target < 1 || target > num_sticks || target == source) {
            cout << "\n Данные введены неверно, попробуйте ещё раз." << endl;
            cin.clear();
            cin.ignore(32767, '\n');
            continue;
        }

        // Формируем список всех стержней
        vector<int> sticks(num_sticks);
        for (int i = 0; i < num_sticks; i++) {
            sticks[i] = i + 1;
        }

        // Сброс счетчика перед началом
        counter = 0;

        // Запуск рекурсивного алгоритма
        auto start = chrono::high_resolution_clock::now();
        Hano(n, source, target, sticks);  // Передаем количество стержней и начальные параметры
        auto end = chrono::high_resolution_clock::now();
        chrono::duration<float> duration = end - start;

        cout << "\nВремя выполнения: " << duration.count() << " секунд" << endl;
        cout << "Количество шагов: " << counter << endl;
        break;
    }

    system("pause");
    return 0;
}
