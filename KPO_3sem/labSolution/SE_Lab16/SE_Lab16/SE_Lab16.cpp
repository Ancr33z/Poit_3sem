#include "FST.h"
#include <tchar.h>
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");

    FST::FST fst0(			// недетермнированный конечный автомат (a+b)*aba
        (char*)"aabbabaaba",					// цепочка для распознования
        4,										// количество состяний
        FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),	// состояние 0 (начальное)
        FST::NODE(1, FST::RELATION('b', 2)),												// состояние 1
        FST::NODE(1, FST::RELATION('a', 3)),												// состояние 2
        FST::NODE()																			// состояние 3 (конечное)
    );
    if (FST::execute(fst0))
        cout << "Цепочка " << fst0.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst0.string << " не распознана" << endl;



    FST::FST fst1(                    // По формулеa a(b)^+((c+d+e);)^+b^+f
        (char*)"abcbf",                // строка для распознавания
        6,                             // количество состояний (включая конечное)
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),
        FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('f', 5)),
        FST::NODE()
    );


    if (FST::execute(fst1))
        cout << "Цепочка " << fst1.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst1.string << " не распознана" << endl;

    // Цепочка a b b f
    FST::FST fst2(
        (char*)"abbf",
        6,
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),
        FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('f', 5)),
        FST::NODE()

    );
    if (FST::execute(fst2))
        cout << "Цепочка " << fst2.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst2.string << " не распознана" << endl;

    // Цепочка a b c d e f
    FST::FST fst3(
        (char*)"abcdebf",
        6,
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),
        FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('f', 5)),
        FST::NODE()

    );
    if (FST::execute(fst3))
        cout << "Цепочка " << fst3.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst3.string << " не распознана" << endl;

    // Цепочка a b c c d e f
    FST::FST fst4(
        (char*)"abccdebf",
        6,
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),
        FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('f', 5)),
        FST::NODE()

    );
    if (FST::execute(fst4))
        cout << "Цепочка " << fst4.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst4.string << " не распознана" << endl;

    // Цепочка a b b c d e f
    FST::FST fst5(
        (char*)"abbcdbf",
        6,
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),
        FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('f', 5)),
        FST::NODE()

    );
    if (FST::execute(fst5))
        cout << "Цепочка " << fst5.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst5.string << " не распознана" << endl;

    // Цепочка a b c d c d b e b f
    FST::FST fst6(
        (char*)"abcbf",
        6,
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),
        FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('f', 5)),
        FST::NODE()

    );
    if (FST::execute(fst6))
        cout << "Цепочка " << fst6.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst6.string << " не распознана" << endl;

    // Цепочка a b c b c b d b e b f
    FST::FST fst7(
        (char*)"abcdebf",
        6,
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),
        FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('f', 5)),
        FST::NODE()


        //FST::NODE(3, FST::RELATION('a', 1), FST::RELATION('a', 2), FST::RELATION('a', 4)),
        //FST::NODE(2, FST::RELATION('b', 1), FST::RELATION('b', 2)),
        //FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('c', 4), FST::RELATION('d', 4)),
        //FST::NODE(4, FST::RELATION('b', 3), FST::RELATION('b', 4)),
        //FST::NODE(1, FST::RELATION('f', 5)),
        //FST::NODE()
    );
    if (FST::execute(fst7))
        cout << "Цепочка " << fst7.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst7.string << " не распознана" << endl;



    /*Цепочка, при которой разбор проходит все символы входной цепочки, но цепочка не распознается*/
    FST::FST fst8(
        (char*)"abcbdef",
        6,
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),
        FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('f', 5)),
        FST::NODE()


    );
    /*В этой цепочке все символы соответствуют допустимым переходам: автомат примет a, затем b, затем примет любой из символов c, d
    или e, но на этом цепочка завершится без перехода в состояние, где требуется f. Таким образом, разбор цепочки пройдет, но автомат
    не распознает её как валидную, так как не будет достигнуто конечное состояние.*/
    if (FST::execute(fst8))
        cout << "Цепочка " << fst8.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst8.string << " не распознана" << endl;




    FST::FST fst9(
        (char*)"abcbf",
        6,
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),
        FST::NODE(4, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('b', 4),  FST::RELATION('f', 5)),
        FST::NODE()

    );
    /*В этой цепочке все символы соответствуют допустимым переходам: автомат примет a, затем b, затем примет любой из символов c, d
    или e, но на этом цепочка завершится без перехода в состояние, где требуется f. Таким образом, разбор цепочки пройдет, но автомат
    не распознает её как валидную, так как не будет достигнуто конечное состояние.*/
    if (FST::execute(fst9))
        cout << "Цепочка " << fst9.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst9.string << " не распознана" << endl;


    return 0;
}
