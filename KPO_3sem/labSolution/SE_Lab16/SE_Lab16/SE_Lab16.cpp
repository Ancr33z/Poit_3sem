#include "FST.h"
#include <tchar.h>
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");
    /*должны создать узлы (состояния), в которых начнём с символа a, затем перейдём к b, и закончим символом f.
Узел описывается как FST::NODE(). Этот узел содержит информацию о том, какие переходы возможны из этого состояния.*/

// Цепочка a b f

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



    //FST::FST fst1(
    //    //(char*)"abf",                // строка для распознавания
        6,                             // количество состояний (включая конечное)
        FST::NODE(1, FST::RELATION('a', 1)),                         // состояние 0: распознаем 'a'
        FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),  // состояние 1: один или более 'b', переходим в состояние 2
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)), // состояние 2: принимаем 'c', 'd', или 'e'
        FST::NODE(2, FST::RELATION('b', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        FST::NODE(1, FST::RELATION('f', 5)),                         // состояние 4: принимаем 'f'
        FST::NODE()                                                  // состояние 5: конечное состояние
    //    (char*)"abf",                // строка для проверки (это значение не используется в execute)
    //    7,                            // количество состояний (включая конечное)
    //    FST::NODE(1, FST::RELATION('a', 1)),                                   // состояние 0: распознаем 'a'
    //    FST::NODE(1, FST::RELATION('b', 2)),                                   // состояние 1: один или несколько 'b'
    //    FST::NODE(4, FST::RELATION('b', 4), FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),  // состояние 2: 'c', 'd', или 'e', или 'b'
    //    FST::NODE(1, FST::RELATION('b', 5)),                                   // состояние 3: распознаем 'b'
    //    FST::NODE(1, FST::RELATION('f', 6)),                                   // состояние 4: распознаем 'f'
    //    FST::NODE()
    //);

    FST::FST fst1(
        (char*)"abcf",
        6,
        FST::NODE(2, FST::RELATION('a', 1), FST::RELATION('a', 2)),
        FST::NODE(2, FST::RELATION('b', 1), FST::RELATION('b', 2)),
        FST::NODE(6, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4)),
        FST::NODE(7, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4), FST::RELATION('f', 5)),
        FST::NODE(2, FST::RELATION('b', 4), FST::RELATION('f', 5)),
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
        FST::NODE(2, FST::RELATION('a', 1), FST::RELATION('a', 2)),
        FST::NODE(2, FST::RELATION('b', 1), FST::RELATION('b', 2)),
        FST::NODE(6, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4)),
        FST::NODE(7, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4), FST::RELATION('f', 5)),
        FST::NODE(2, FST::RELATION('b', 4), FST::RELATION('f', 5)),
        FST::NODE()
    );
    if (FST::execute(fst2))
        cout << "Цепочка " << fst2.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst2.string << " не распознана" << endl;

    // Цепочка a b c d e f
    FST::FST fst3(
        (char*)"abcdef",
        6,
        FST::NODE(2, FST::RELATION('a', 1), FST::RELATION('a', 2)),
        FST::NODE(2, FST::RELATION('b', 1), FST::RELATION('b', 2)),
        FST::NODE(6, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4)),
        FST::NODE(7, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4), FST::RELATION('f', 5)),
        FST::NODE(2, FST::RELATION('b', 4), FST::RELATION('f', 5)),
        FST::NODE()
    );
    if (FST::execute(fst3))
        cout << "Цепочка " << fst3.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst3.string << " не распознана" << endl;

    // Цепочка a b c c d e f
    FST::FST fst4(
        (char*)"abccdef",
        6,
        FST::NODE(2, FST::RELATION('a', 1), FST::RELATION('a', 2)),
        FST::NODE(2, FST::RELATION('b', 1), FST::RELATION('b', 2)),
        FST::NODE(6, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4)),
        FST::NODE(7, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4), FST::RELATION('f', 5)),
        FST::NODE(2, FST::RELATION('b', 4), FST::RELATION('f', 5)),
        FST::NODE()
    );
    if (FST::execute(fst4))
        cout << "Цепочка " << fst4.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst4.string << " не распознана" << endl;

    // Цепочка a b b c d e f
    FST::FST fst5(
        (char*)"abbcdf",
        6,
        FST::NODE(2, FST::RELATION('a', 1), FST::RELATION('a', 2)),
        FST::NODE(2, FST::RELATION('b', 1), FST::RELATION('b', 2)),
        FST::NODE(6, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4)),
        FST::NODE(7, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4), FST::RELATION('f', 5)),
        FST::NODE(2, FST::RELATION('b', 4), FST::RELATION('f', 5)),
        FST::NODE()
    );
    if (FST::execute(fst5))
        cout << "Цепочка " << fst5.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst5.string << " не распознана" << endl;

    // Цепочка a b c d c d b e b f
    FST::FST fst6(
        (char*)"abf",
        6,
        FST::NODE(2, FST::RELATION('a', 1), FST::RELATION('a', 2)),
        FST::NODE(2, FST::RELATION('b', 1), FST::RELATION('b', 2)),
        FST::NODE(6, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4)),
        FST::NODE(7, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('t', 3), FST::RELATION('c', 4), FST::RELATION('d', 4), FST::RELATION('t', 4), FST::RELATION('f', 5)),
        FST::NODE(2, FST::RELATION('b', 4), FST::RELATION('f', 5)),
        FST::NODE()
    );
    if (FST::execute(fst6))
        cout << "Цепочка " << fst6.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst6.string << " не распознана" << endl;

    // Цепочка a b c b c b d b e b f
    FST::FST fst7(
        (char*)"abccdebf",
        6,
        //FST::NODE(1, FST::RELATION('a', 1)),                         // состояние 0: распознаем 'a'
        //FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('b', 2), FST::RELATION('b', 4)),  // состояние 1: один или более 'b', переходим в состояние 2
        //FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)), // состояние 2: принимаем 'c', 'd', или 'e'
        //FST::NODE(2, FST::RELATION('b', 3), FST::RELATION('b', 4)),                         // состояние 3: принимаем 'b'
        //FST::NODE(1, FST::RELATION('f', 5)),                         // состояние 4: принимаем 'f'
        //FST::NODE()
                               // количество состояний (включая конечное)
        FST::NODE(1, FST::RELATION('a', 1)),                               // состояние 0: распознаем 'a'
        FST::NODE(2, FST::RELATION('b', 1), FST::RELATION('b', 2)),        // состояние 1: один или более 'b'
        FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('d', 3), FST::RELATION('e', 3)),  // состояние 2: принимаем 'c', 'd', или 'e'
        FST::NODE(1, FST::RELATION('b', 4)),                               // состояние 3: принимаем символ 'b' после 'c', 'd', или 'e'
        FST::NODE(1, FST::RELATION('f', 5)),                               // состояние 4: принимаем символ 'f'
        FST::NODE()                                                        // состояние 5: конечное состояние
        // состояние 5: конечное состояние


    );
    if (FST::execute(fst7))
        cout << "Цепочка " << fst7.string << " распознана" << endl;
    else
        cout << "Цепочка " << fst7.string << " не распознана" << endl;

    return 0;
}
