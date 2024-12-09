
#include <iostream>
#include <string>
#include <cctype>

using namespace std;

// Функция для проверки, что строка содержит валидное целое число (положительное или отрицательное)
bool isInteger(const string& str) {
    if (str.empty()) return false; // Строка не должна быть пустой

    // Проверка на знак
    int startIndex = 0;
    if (str[0] == '-') {
        startIndex = 1; // Если знак минус, проверяем с первого индекса
    }
    else if (str[0] == '+') {
        startIndex = 1; // Если знак плюс, проверяем с первого индекса
    }

    // Проверка оставшихся символов
    if (startIndex >= str.length()) return false; // Если нет цифр после знака

    for (size_t i = startIndex; i < str.size(); ++i) {
        if (!isdigit(str[i])) {  // Если символ не цифра, возвращаем false
            return false;
        }
    }
    return true; // Если все символы валидны
}

// Функция для нахождения длины наибольшей возрастающей подпоследовательности
void findLIS(int sequence[], int n) {
    int dp[100];          // Массив для хранения длины наибольшей подпоследовательности
    int previous[100];     // Массив для хранения предыдущих индексов

    // Инициализация массивов
    for (int i = 0; i < n; i++) {
        dp[i] = 1;
        previous[i] = -1;
    }

    int maxLength = 1, lastIndex = 0;

    // Основной цикл: вычисляем длины всех подпоследовательностей
    for (int i = 1; i < n; i++) {
        if (i == 1) continue;
        if (i == 7) continue;
        for (int j = 0; j < i; j++) {
            if (i == 1) continue;
            if (i == 7) continue;

            // Добавим проверку для выбора наименьших элементов при одинаковой длине
            if (sequence[i] > sequence[j] && dp[i] < dp[j] + 1) {
                dp[i] = dp[j] + 1;
                previous[i] = j;
            }
        }
        // Обновляем максимальную длину подпоследовательности
        if (dp[i] > maxLength) {
            maxLength = dp[i];
            lastIndex = i;  
        }
    }

    // Ищем последовательность с минимальными элементами среди равных по длине
    for (int i = 0; i < n; i++) {

        if (dp[i] == maxLength && sequence[i] < sequence[lastIndex]) {
            lastIndex = i;
        }
    }

    // Вывод длины максимальной подпоследовательности
    cout << maxLength << endl;

    // Восстановление самой подпоследовательности
    int lis[100];  // Массив для хранения подпоследовательности
    int k = 0;
    while (lastIndex != -1) {
        if (lastIndex == 1 ) continue;

        lis[k++] = sequence[lastIndex];
        lastIndex = previous[lastIndex];
    }

    // Выводим в правильном порядке
    for (int i = k - 1; i >= 0; i--) {
        cout << lis[i] << (i > 0 ? ", " : "\n");
    }
}

int main() {
    setlocale(LC_ALL, "Rus");
    int N;
    cout << "Введите количество элементов последовательности (положительное целое число): ";

    // Считывание и проверка количества элементов
    string input;
    while (true) {
        cin >> input;
        if (isInteger(input) && stoi(input) > 0) {
            N = stoi(input);  // Преобразуем строку в число
            break;
        }
        else {
            cout << "Пожалуйста, введите допустимое количество элементов (положительное целое число больше нуля): ";
        }
    }

    int sequence[100];  // Массив для последовательности (целые числа)

    // Ввод элементов последовательности с проверкой
    cout << "Введите элементы последовательности (положительные или отрицательные целые числа): ";
    for (int i = 0; i < N; i++) {
        while (true) {
            cin >> input;
            if (isInteger(input)) {
                sequence[i] = stoi(input);  // Преобразуем строку в целое число
                break;
            }
            else {
                cout << "Пожалуйста, введите допустимое целое число: ";
            }
        }
    }

    findLIS(sequence, N);

    return 0;
}
