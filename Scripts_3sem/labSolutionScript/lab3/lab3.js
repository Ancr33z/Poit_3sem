//ЗАДАНИЕ 1. Объедините два массива с вложенностью используя reduce().

function flattenArray(arr) {
    return arr.reduce((acc, val) => {
        // Если элемент - массив, рекурсивно сворачиваем его
        return acc.concat(Array.isArray(val) ? flattenArray(val) : val);
    }, []);
};

console.log(flattenArray([1, [1, 2, [3, 4]], [2, 4]]))

//ЗАДАНИЕ 2. Найдите сумму элементов массива, если вложенность массива неизвестна. 

let initialValue = 0
function arrSum(arr) {
    return arr.reduce((acc, val) => {
        // Если элемент - массив, рекурсивно обрабатываем его
        return acc + (Array.isArray(val) ? arrSum(val) : val);
    }, 0);
};


console.log(arrSum([1, [1, 2, [3, 4]], [2, 4]]))

//ЗАДАНИЕ 3. Напишите функцию, которая на вход принимает массив из студентов, где студент — это объект с полями «имя», «возраст» и «номер группы» {name: string, age: number, groupId: number}, а на выходе возвращает объект, где ключ — это номер группы, а значение — массив из студентов старше 17 лет.

let students = [
    { name: 'Сергей', age: 18, groupId: 1 },
    { name: 'Миша', age: 20, groupId: 6 },
    { name: 'Настя', age: 16, groupId: 1 },
    { name: 'Давид', age: 19, groupId: 6 },
    { name: 'Алиса', age: 21, groupId: 3 }
];

function groupStudentsByAge(students) {
    const result = {};

    students.forEach(student => {
        if (student.age > 17) {
            const groupId = student.groupId;

            if (result[groupId]) {
                result[groupId].push(student);
            }
            else {
                result[groupId] = [student];
            }
        }
    }
    );

    return result;
}

let groupedStudents = groupStudentsByAge(students);
console.log(groupedStudents);


//ЗАДАНИЕ 4. Вам дана строка, состоящая из символов ASCII. Переведите символы в код - число total1, замените все цифры 7 на 1 - число total2. И вычтите из total1 число total2.


function translateStr(str) {
    let result1 = ""
    for (let i = 0; i < str.length; i++) {
        result1 += str[i].charCodeAt()
    }
    let result2 = ""
    for (let i = 0; i < result1.length; i++) {
        if (result1[i] == "7") {
            result2 += "1"
        } else {
            result2 += result1[i]
        }
    }
    console.log(result1)
    console.log(result2)
}
translateStr("ABC")

//ЗАДАНИЕ 5. Создайте функцию, которая принимает несколько объектов в качестве параметров и возвращает НОВЫЙ объект со всеми свойствами из входных объектов. Для объединения объектов и создания НОВОГО объекта использовать метод assign

function extend(...objects) {
    return Object.assign({}, ...objects);
}
console.log(extend({ a: 1, b: 2 }, { c: 3 }))

//ЗАДАНИЕ 6. Создайте башню-пирамиду, состоящую из символов "*". В качестве входного параметра приходит число этажей башни.

function buildPyramid(floors) {
    for (let i = 1; i <= floors; i++) {
        // Количество пробелов перед "*"
        const spaces = ' '.repeat(floors - i);
        // Количество символов "*"
        const stars = '*'.repeat(i * 2 - 1);
        // Строим строку для текущего этажа
        console.log(spaces + stars + spaces);
    }
}

buildPyramid(4)
