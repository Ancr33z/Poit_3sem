#include "stdafx.h"

// Метод Serializer::SerializeData(): Выполняет сериализацию данных и запись их в бинарный файл
void Serializer::SerializeData() {
    file = ofstream("bin.bin", ios::binary);
    //file = ofstream("E:\KPO\SE_Asm04\SE_Asm04\\bin.bin");
    //ofstream file("E:\\KPO\\SE_Asm04\\SE_Asm04\\bin.bin", ios::binary);
    if (!file.is_open()) {
        cout << "Ошибка: не удалось открыть файл для записи!" << endl;
        return;
    }

    // Сериализация bool
    file.write(reinterpret_cast<char*>(&boolMarker), sizeof(boolMarker));
    file.write(reinterpret_cast<char*>(&boolLength), sizeof(boolLength));
    file.write(reinterpret_cast<char*>(&boolValue), boolLength);

    // Сериализация int16_t
    file.write(reinterpret_cast<char*>(&int16Marker), sizeof(int16Marker));
    file.write(reinterpret_cast<char*>(&int16Length), sizeof(int16Length));
    file.write(reinterpret_cast<char*>(&int16Value), int16Length);

    //file  << boolValue << "\n";
    //file  << int16Value << "\n";


    file.close();
    cout << "Данные успешно сериализованы в файл bin.bin!" << endl;
}
