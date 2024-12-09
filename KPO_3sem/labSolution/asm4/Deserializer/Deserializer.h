#pragma once
#include "stdafx.h"

// Класс Deserializer: Описывает функциональность для десериализации данных и преобразования их в ассемблерный код
class Deserializer {
private:
    std::ifstream file;         // Поток для чтения данных из файла
    std::ofstream fileAsm;      // Поток для записи ассемблерного кода в файл
    bool boolValue;             // Десериализованное значение bool
    int16_t int16Value;         // Десериализованное значение int16_t

public:
    // Конструктор
    Deserializer() : boolValue(false), int16Value(0) {}

    // Метод для десериализации данных
    void DeserializeData();

    // Метод для преобразования данных в ассемблерный код
    void ConvertToAssembler();
};

