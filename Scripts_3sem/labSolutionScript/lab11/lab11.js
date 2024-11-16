
class Task {
    // Конструктор принимает id, title и isCompleted (по умолчанию false)
    constructor(id, title, isCompleted = false) {
        this.id = id;
        this.title = title;
        this.isCompleted = isCompleted;// Статус задачи (выполнена или нет)
    }

    // Метод для изменения названия задачи
    changeTitle(newTitle) {
        this.title = newTitle;// Изменяем название задачи
    }

    // Метод для изменения состояния задачи
    toggleCompletion() {
        this.isCompleted = !this.isCompleted; // Переключаем статус задачи на противополржный
    }
}

class Todolist {
    constructor(id, title) {
        this.id = id;
        this.title = title;
        this.tasks = [];
    }

    // Метод для изменения названия списка дел
    changeTitle(newTitle) {
        this.title = newTitle; // Изменяем название списка задач
    }

    // Метод для добавления новой задачи в список дел
    addTask(task) {
        this.tasks.push(task);// Добавляем задачу в массив задач
    }

    // Метод для фильтрации задач по состоянию (выполнена или не выполнена)
    filterTasksByCompletion(isCompleted) {
        return this.tasks.filter(task => task.isCompleted === isCompleted);// Возвращаем все задачи, у которых isCompleted совпадает с переданным значением
    }
}

// Создание задач и единственного списка дел
const task1 = new Task(1, "Купить продукты"); // isCompleted = false (по умолчанию)
const task2 = new Task(2, "Убрать блок", true); // isCompleted = true (установлено явно)
const task3 = new Task(3, "Сделать лабу"); // isCompleted = true изза task3.toggleCompletion();
const task4 = new Task(4, "Сделать курсовую"); // isCompleted = false (по умолчанию)

const todoList = new Todolist(1, "Ежедневные задачи");
todoList.addTask(task1);
todoList.addTask(task2);
todoList.addTask(task3);
todoList.addTask(task4);

// Создание нового списка дел
const personalTodoList = new Todolist(2, "Личные задачи");

// Создание задач для второго списка дел
const task5 = new Task(5, "Позвонить маме");//
const task6 = new Task(6, "Почистить обувь");
const task7 = new Task(7, "Прочитать книгу");// isCompleted = true изза task7.toggleCompletion();

// Добавляем задачи во второй список
personalTodoList.addTask(task5);
personalTodoList.addTask(task6);
personalTodoList.addTask(task7);



// Изменение названия и состояния задачи
task1.changeTitle("Купить хлеб");
task3.toggleCompletion();

task5.changeTitle("Позвонить другу");
task7.toggleCompletion();

// Вывод задач после изменений
console.log("Задачи первого списка после изменений:", todoList.tasks);
console.log("Задачи второго списка после изменений:", personalTodoList.tasks);

// Фильтрация задач первого списка
const completedTasks = todoList.filterTasksByCompletion(true);
const incompleteTasks = todoList.filterTasksByCompletion(false);

console.log("Завершенные задачи первого списка:", completedTasks);
console.log("Незавершенные задачи первого списка:", incompleteTasks);

// Фильтрация задач второго списка
const completedPersonalTasks = personalTodoList.filterTasksByCompletion(true);
const incompletePersonalTasks = personalTodoList.filterTasksByCompletion(false);

console.log("Завершенные задачи второго списка:", completedPersonalTasks);
console.log("Незавершенные задачи второго списка:", incompletePersonalTasks);
personalTodoList.changeTitle("Новый тайтл")
console.log(personalTodoList);
