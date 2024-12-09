#include "stdafx.h"

// Метод Deserializer::DeserializeData(): Выполняет десериализацию данных из файла
void Deserializer::DeserializeData() {
    file = ifstream("../Serializer/bin.bin", ios::binary);

    if (!file.is_open()) {
        cout << "Ошибка: не удалось открыть файл для чтения!" << endl;
        return;
    }

    unsigned char marker, length;

    while (!file.eof()) {
        file.read(reinterpret_cast<char*>(&marker), sizeof(marker));
        file.read(reinterpret_cast<char*>(&length), sizeof(length));

        if (file.eof()) break;

        if (marker == 0x01) {
            file.read(reinterpret_cast<char*>(&boolValue), length);
        }
        else if (marker == 0x02) {
            file.read(reinterpret_cast<char*>(&int16Value), length);
        }
    }

    file.close();
    cout << "Данные десериализованы: bool = " << boolValue << ", int16 = " << int16Value << endl;
}

// Метод Deserializer::ConvertToAssembler(): Преобразует десериализованные данные в код на ассемблере
void Deserializer::ConvertToAssembler() {
    fileAsm = ofstream("../asm4/asm4.asm");

    if (!fileAsm.is_open()) {
        cout << "Ошибка: не удалось открыть файл для записи ASM!" << endl;
        return;
    }

    fileAsm << ASM_HEAD;
    fileAsm << "BOOLF DB " << (boolValue ? 1 : 0) << endl;
    fileAsm << "INT16F DW " << int16Value << endl;
    fileAsm << ASM_FOOTER;

    fileAsm.close();
    cout << "Ассемблерный код успешно записан в файл asm4.asm!" << endl;
}
