#include "stdafx.h"

int main() {
    setlocale(LC_ALL, "ru");
    bool b;
    int16_t i;

    cout << "Введите значение для bool (0 или 1): ";
    cin >> b;

    cout << "Введите значение для целочисленного литерала (2 байта): ";
    cin >> i;

    Serializer serializer(b, i);
    serializer.SerializeData();

    return 0;
}
