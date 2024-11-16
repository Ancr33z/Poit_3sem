const inputField = document.querySelector("#task");
const buttons = document.querySelectorAll(".but");
const mainBody = document.querySelector(".main_body");
let checkboxes, editButtons, deleteButtons;
let tasksMassive = [];

class Task {
    constructor(id, title, isCompleted = false) {
        this.id = id;
        this.title = title;
        this.isCompleted = isCompleted;// Статус задачи (выполнена или нет)
    }
}

buttons.forEach((button) =>
    button.addEventListener("click", () => {
        const actions = {
            addButton: addTask,
            "show-all": () => renderTasks(tasksMassive),
            "show-complete": () => renderTasks(tasksMassive.filter((task) => task.isCompleted)),
            "show-uncomplete": () => renderTasks(tasksMassive.filter((task) => !task.isCompleted)),
        };
        actions[button.id]?.();
    })
);



function renderTasks(filteredTasks = tasksMassive) {
    mainBody.innerHTML = '';
    filteredTasks.forEach(element => {
        mainBody.innerHTML += `
        <div class="task_block">
            <form>
            <label>
                <input class="checkboxeee" type="checkbox" name="color" id="${element.id}"  ${element.isCompleted ? "checked" : ""}>
                    ${element.title}
            </label>
            </form>
            <div class="buttons_container">
                <button class="but blue edit" id="${element.id}">Редактировать</button>
                <button class="but red delete" id="${element.id}">Удалить</button>
            </div>
        </div > `
    });

    checkboxes = document.querySelectorAll(".checkboxeee");
    edit = document.querySelectorAll(".edit");
    taskDeleter = document.querySelectorAll(".delete");


    checkboxes.forEach((checkbox) => {
        checkbox.addEventListener("change", (event) => { toggleTaskCompletion(event.target.id) });
    });


    edit.forEach((button) => {
        button.addEventListener("click", (event) => { editTask(event.target.id) });
    });

    taskDeleter.forEach((button) => {
        button.addEventListener("click", (event) => { deleteTask(event.target.id) });
    });
}

function addTask() {
    let inputValue = inputField.value; // Получаем значение из input

    if (inputValue) {
        tasksMassive.push(new Task(tasksMassive.length + 1, inputValue, false));
        inputField.value = "";
        renderTasks();
    } else {
        alert("Введите название")
    }
}

function editTask(id) {
    const task = tasksMassive.find((task) => task.id == id);
    if (task) {
        const newName = prompt("Введите новое название задачи:", task.title);
        if (newName && newName.trim()) {
            task.title = newName.trim();
            renderTasks();
        }
    }
}

const deleteTask = (id) => {
    tasksMassive = tasksMassive.filter((task) => task.id != id);
    renderTasks();
};

const toggleTaskCompletion = (id) => {
    const task = tasksMassive.find((task) => task.id == id);
    if (task) {
        task.isCompleted = !task.isCompleted;
        renderTasks();
    }
};