﻿#include <iostream>
#include <algorithm>
#include <string>
#include <vector>

using namespace std;

// Определение структуры Item (товар)
struct Item
{
    string name;   // Название товара
    int weight;    // Вес товара
    int value;     // Стоимость товара
};

void printMatrix(const std::vector<std::vector<int>>& matrix) {

}

// Функция для решения задачи о рюкзаке методом динамического программирования
void knapsack(int capacity, Item* items, int numItems)
{
    // Выделение динамической памяти для двумерного массива dp (динамической таблицы результатов подзадач)

 // dp - это массив, который будет использоваться для хранения результатов подзадач задачи о рюкзаке.
 // dp[i][w] будет содержать максимальную стоимость предметов, которую можно уложить в рюкзак вместимости w,
 // если у нас есть i товаров для выбора.

 // Выделяем память для строк массива dp.
    int** dp = new int* [numItems + 1];

    // Заполняем каждую строку массива dp.
    for (int i = 0; i <= numItems; ++i)
    {
        // Выделяем память для столбцов массива dp (для каждой возможной вместимости рюкзака).
        dp[i] = new int[capacity + 1];
    }


    // Заполнение массива dp пошагово для решения задачи о рюкзаке методом динамического программирования

// Внешний цикл итерирует по товарам, а внутренний цикл итерирует по возможным вместимостям рюкзака.

    for (int i = 0; i <= numItems; ++i)
    {
        for (int w = 0; w <= capacity; ++w)
        {
            if (i == 0 || w == 0)
            {
                // Базовый случай: рюкзак пуст или товаров нет
                // Если у нас нет товаров (i == 0) или рюкзак пуст (w == 0), 
                // то максимальная стоимость в этом случае равна 0.
                dp[i][w] = 0;
            }
            else
                if (items[i - 1].weight <= w)
                {
                    // Если текущий товар можно положить в рюкзак, выбираем максимальное значение
                    // Сравниваем два варианта: 1) не включать текущий товар (dp[i-1][w]) 
                    // и 2) включить текущий товар (dp[i-1][w - items[i-1].weight] + items[i-1].value)
                    dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - items[i - 1].weight] + items[i - 1].value);
                }
                else
                {
                    // Если текущий товар слишком тяжелый, не кладем его в рюкзак
                    // В этом случае максимальная стоимость равна максимальной стоимости,
                    // которую можно получить без учета текущего товара.
                    dp[i][w] = dp[i - 1][w];
                }
        }
    }


    // Определение, какие товары были положены в рюкзак и вывод результатов

    int w = capacity; // Инициализация вместимости текущего рюкзака

    cout << "Максимальная стоимость: " << dp[numItems][capacity] << endl; // Вывод максимальной стоимости, достигнутой в рюкзаке

    cout << "Предметы в рюкзаке:" << endl; // Вывод заголовка

    // Цикл для определения, какие товары были положены в рюкзак
    for (int i = numItems; i > 0 && w > 0; --i)
    {
        if (dp[i][w] != dp[i - 1][w]) {
            // Если текущий товар был добавлен в рюкзак, выводим его информацию
            cout << "  - " << items[i - 1].name << " (вес: " << items[i - 1].weight << ", стоимость: " << items[i - 1].value << ")" << endl;
            w -= items[i - 1].weight; // Уменьшаем вместимость рюкзака на вес добавленного товара
        }
    }

    for (int i = 0; i < numItems; ++i) {
        for (int j = 0; j < capacity; ++j) {
            std::cout << dp[i][j] << " ";
        }
        std::cout << std::endl;
    }
    // Освобождаем выделенную память
    for (int i = 0; i <= numItems; ++i)
    {
        delete[] dp[i];
    }
    delete[] dp;
}



int main() {
    setlocale(LC_ALL, "RUSSIAN"); // Устанавливаем локаль для отображения русского текста
    int capacity;
    cout << "Введите вместимость рюкзака: ";
    cin >> capacity;

    int numItems;
    cout << "Введите количество товаров: ";
    cin >> numItems;

    // Выделяем память для массива товаров
    Item* items = new Item[numItems];
    // Ввод информации о товарах
    for (int i = 0; i < numItems; ++i) {
        cout << "Товар #" << i + 1 << ":" << endl;
        cout << "  Название: ";
        cin >> items[i].name;
        cout << "  Вес: ";
        cin >> items[i].weight;
        cout << "  Стоимость: ";
        cin >> items[i].value;
    }

    // Вызываем функцию для решения задачи о рюкзаке
    knapsack(capacity, items, numItems);

    // Освобождаем выделенную память
    delete[] items;

    return 0;
}