#include "stdafx.h"
using namespace std;

namespace In
{
    void removeExtraSpaces(std::string& input)// Удаляем лишние пробелы из текущей строки.
    {

        bool insideQuotes = false;

        for (size_t i = 0; i < input.length(); ++i)
        {
            if (input[i] == '\'') 
            {
                insideQuotes = !insideQuotes;
            }
            if (!insideQuotes && input[i] == ' ')
            {
                if (i == 0 || i == input.length() - 1)
                {
                    input.erase(i, 1);
                }
                size_t spacesToRemove = 0;
                while (i + spacesToRemove < input.length() && input[i + spacesToRemove] == ' ')
                {// Подсчет количества последовательных пробелов после текущего символа.
                    ++spacesToRemove;
                }
                if (spacesToRemove > 1)
                {
                    input.erase(i + 1, spacesToRemove - 1);
                }
            }
        }
    }

    void removeSpacesAroundOperators(std::string& input)// Удаляем пробелы вокруг операторов из текущей строки.
    {
        const std::string operators = ";,}{()=+-/*";

        for (size_t i = 0; i < input.length(); ++i)
        {
            if (operators.find(input[i]) != std::string::npos)
            {
                // Удаляем пробелы перед символом
                while (i > 0 && std::isspace(input[i - 1]))
                {
                    input.erase(i - 1, 1);
                    --i;
                }

                // Удаляем пробелы после символа
                while (i + 1 < input.length() && std::isspace(input[i + 1]))
                {
                    input.erase(i + 1, 1);
                }
            }
        }
    }

    IN getin(wchar_t infile[])
    {

        ifstream fin;
        char* outFile = new char[wcslen(infile) + 1];// Создаем буфер для имени файла в формате char.
        wcstombs_s(NULL, outFile, wcslen(infile) + 1, infile, wcslen(infile) + 1);//Преобразуем имя файла из wchar_t в char.
        fin.open(infile);
        if (fin.bad())
        {
            throw ERROR_THROW(116);
        }
        if (!fin.is_open())
        {
            throw ERROR_THROW(110);
        }
        IN resultIn;
        resultIn.size = 0;
        resultIn.lines = 0;
        int position = 0;
        int ch;
        std::string currentLine; // Строка для накопления символов
        std::string buffer;;// Буфер для считывания строк из файла.
        // Инициализируем первый элемент массива textstart
        while (std::getline(fin, buffer))
        {
            resultIn.lines++;
            for (int i = 0; i < buffer.length(); i++)// Проходим по символам в считанной строке.
            {
                ch = buffer[i];

                if (ch == fin.eof())
                {
                    break;
                }

                switch (resultIn.code[(unsigned char)ch]) //анализ символа с помощью таблицы resultIn.code
                {
                case IN::F:// Если символ является буквой, цифрой или знаком подчеркивания, то это идентификатор.
                {
                    resultIn.text.push_back(currentLine);
                    throw ERROR_THROW_IN(111, resultIn.lines, ++position, buffer, resultIn.text);
                    break;
                }
                case IN::I:// Если символ игнорируется, увеличиваем счетчик игнорируемых символов и позицию.
                {
                    resultIn.ignor++;
                    position++;
                    break;
                }
                case IN::T:// Если символ является текстовым символом, добавляем его к текущей строке.
                {

                    currentLine += ch;
                    position++;
                    resultIn.size++;
                    break;
                }
                default:// Если символ не попадает ни в одну из вышеперечисленных категорий.
                {
                    currentLine += resultIn.code[(unsigned char)ch];
                    resultIn.size++;
                    position++;
                    break;
                }
                }
            }

            if (!currentLine.empty())
            {
                resultIn.size++;
                position++;
                position = 0;
                currentLine += resultIn.code[IN_CODE_ENDL];
                removeExtraSpaces(currentLine);
                removeSpacesAroundOperators(currentLine);
                resultIn.text.push_back(currentLine);// Добавляем текущую строку к результату.
                currentLine.clear();
            }
        }

        fin.close();
        return resultIn;
    }
}
