#pragma once
#include "stdafx.h"

// Класс Serializer: Описывает функциональность для сериализации данных и записи их в файл
class Serializer {
private:
    std::ofstream file;              // Поток для записи данных в файл
    unsigned char boolMarker;        // Маркер для bool
    unsigned char int16Marker;       // Маркер для int16_t
    unsigned char boolLength;        // Длина bool
    unsigned char int16Length;       // Длина int16_t
    bool boolValue;                  // Сериализованное значение bool
    int16_t int16Value;              // Сериализованное значение int16_t

public:
    // Конструктор: Инициализирует значения и маркеры
    Serializer(bool boolValue, int16_t int16Value)
        : boolMarker(0x01), int16Marker(0x02), boolLength(sizeof(bool)), int16Length(sizeof(int16_t)) {
        this->boolValue = boolValue;
        this->int16Value = int16Value;
    }

    // Метод для сериализации данных
    void SerializeData();
};

