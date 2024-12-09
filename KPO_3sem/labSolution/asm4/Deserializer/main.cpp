#include "stdafx.h"

int main() {
    setlocale(LC_ALL, "ru");

    Deserializer deserializer;
    deserializer.DeserializeData();
    deserializer.ConvertToAssembler();

    return 0;
}
