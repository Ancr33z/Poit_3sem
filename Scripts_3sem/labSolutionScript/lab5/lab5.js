//Задание 1.1)
function makeCounter() {
    let currentCount = 1;

    return function () {
        return currentCount++;
    };
}

let counter = makeCounter();

alert(counter());//1
alert(counter());//2
alert(counter());//3

let counter2 = makeCounter();
alert(counter2());//1 функция вернёт значение currentCount для новой функции, которое равно 1 (независимо от того, что было с переменной currentCount в первом замыкании)

//1.2)

// let currentCount = 1;//Глобальная переменная currentCount:

// function makeCounter(){
//     return function(){
//         return currentCount++;
//     };
// }

// let counter = makeCounter();
// let counter2 = makeCounter();

/*Переменная currentCount глобальна, и оба счётчика (counter и counter2) используют одно и то же значение.
Значение переменной увеличивается независимо от того, какой счётчик вызывается, поскольку обе функции ссылаются на одну и ту же переменную. */
// alert( counter() );//1
// alert( counter() );//2

// alert( counter2() );//3
// alert( counter2() );//4

//Задание 2
//Каррированная функция — это функция, которая вместо того, чтобы принимать все свои аргументы сразу, принимает их по одному

/*2.Реализуйте каррированную функцию, которая рассчитывает объем прямоугольного параллелепипеда. 
Выполните преобразование функции для неоднократного расчёта объема прямоугольных параллелепипедов, у которых одно ребро 
одинаковой длины. */

function volume(a) {
    return function (h) {
        return function (b) {
            return a * h * b;
        };
    };
}

/*Она принимает аргументы по одному: сначала фиксируется длина a, затем высота h, и наконец ширина b, после чего происходит вычисление объема. */
const a = volume(10);     // Фиксируем 'a = 10'
let pr1 = a(2)(3);      // Сначала передаем 'h = 2', затем 'b = 3'
let pr2 = a(3)(4);      // Передаем 'h = 3', затем 'b = 4'
let pr3 = a(4)(5);
let pr4 = a(5)(6);

console.log(pr1); // 60
console.log(pr2); // 120
console.log(pr3); // 200
console.log(pr4); // 300

//Задание3
/*3.Пользователь управляет движением объекта, вводя в модальное окно  команды left, right, up, down. Объект совершает 10
 шагов в заданном направлении (т.е. высчитываются и выводятся в консоль соответствующие координаты) и запрашивает новую команду. 
 Разработайте генератор, который возвращает координаты объекта, согласно заданному направлению движения.  */

// function* moveObject() {
//     let x = 0;
//     let y = 0;

//     for (let i = 0; i < 10; i++) {
//         let step = prompt('Введите команду (left, right, up, down):', '');

//         switch (step) {
//             case 'left':
//                 x--;
//                 break;
//             case 'right':
//                 x++;
//                 break;
//             case 'up':
//                 y++;
//                 break;
//             case 'down':
//                 y--;
//                 break;
//             default:
//                 alert('Неверная команда! Попробуйте снова.');
//                 i--; // Уменьшаем i, чтобы не учитывать неверную команду как шаг
//                 continue; // Пропускаем остальную часть цикла
//         }

//         // Возвращаем текущие координаты
//         yield `Координаты: (${x}, ${y})`;
//     }
// }

// // Использование генератора
// const command = moveObject();

// console.log(command)

// // Выполнение генератора и вывод координат после каждого шага
// for (let move of    ) {
//     alert(move); // Показываем текущие координаты
// }

/*Команда left: Уменьшает значение x на 1 (x--), что перемещает объект влево. Если x уже равен 0, то после команды left он станет -1.
Команда right: Увеличивает значение x на 1 (x++), перемещая объект вправо. Это будет положительное значение.
Команда up: Увеличивает значение y на 1 (y++), перемещая объект вверх. Это тоже будет положительное значение.
Команда down: Уменьшает значение y на 1 (y--), перемещая объект вниз. Если y уже равен 0, то после команды down он станет -1. */

//Задание 4
/*4.Какие переменные и функции сохраняются в глобальный объект window? Получите значения всех созданных переменных и функции,
 которые хранятся в глобальном объекте window. Переопределите переменные через глобальный объект. */

// Объявляем глобальную переменную
globalVariable = "Hello, world!";

// Объявляем глобальную функцию
function globalFunction() {
    console.log("Это глобальная функция");
}

// Проверяем, что переменные и функции находятся в глобальном объекте
console.log(window.globalVariable); // "Hello, world!"
window.globalFunction(); // "Это глобальная функция"

// Переопределяем глобальную переменную
window.globalVariable = "Переопределенная переменная";

// Переопределяем глобальную функцию
window.globalFunction = function () {
    console.log("Переопределенная функция");
};

// Проверяем новые значения
console.log(globalVariable); // "Переопределенная переменная"
globalFunction(); // "Переопределенная функция"


