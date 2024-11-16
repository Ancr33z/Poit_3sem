class Sudoku {
    constructor() {
        this.initialBoard = Array.from({ length: 9 }, () => Array(9).fill(0));
        this.board = this.cloneBoard(this.initialBoard);
    }

    // Клонируем игровое поле
    cloneBoard(board) {
        return board.map(row => [...row]);
    }

    // Метод для вывода игрового поля в консоль
    printBoard() {
        this.board.forEach(row => console.log(row.join("  ")));
    }

    // Метод для сброса игрового поля до исходного состояния
    resetBoard() {
        this.board = this.cloneBoard(this.initialBoard);
    }

    // Метод для проверки строки на наличие дубликатов
    checkRow(row) {
        const seen = new Set();
        for (let col = 0; col < 9; col++) {
            const num = this.board[row][col];
            if (num !== 0) {
                if (seen.has(num)) {
                    console.log(`Ошибка в строке ${row + 1}`);
                    return false;
                }
                seen.add(num);
            }
        }
        return true;
    }

    // Метод для проверки столбца на наличие дубликатов
    checkColumn(col) {
        const seen = new Set();
        for (let row = 0; row < 9; row++) {
            const num = this.board[row][col];
            if (num !== 0) {
                if (seen.has(num)) {
                    console.log(`Ошибка в столбце ${col + 1}`);
                    return false;
                }
                seen.add(num);
            }
        }
        return true;
    }

    // Метод для проверки квадрата 3x3 на наличие дубликатов
    checkSquare(row, col) {
        const seen = new Set();
        const startRow = row - (row % 3);
        const startCol = col - (col % 3);
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                const num = this.board[startRow + i][startCol + j];
                if (num !== 0) {
                    if (seen.has(num)) {
                        console.log(`Ошибка в квадрате (${startRow + 1}, ${startCol + 1})`);
                        return false;
                    }
                    seen.add(num);
                }
            }
        }
        return true;
    }

    // Метод для проверки всего игрового поля на наличие ошибок
    checkBoard() {
        let valid = true;
        for (let i = 0; i < 9; i++) {
            if (!this.checkRow(i)) valid = false;
            if (!this.checkColumn(i)) valid = false;
        }
        for (let row = 0; row < 9; row += 3) {
            for (let col = 0; col < 9; col += 3) {
                if (!this.checkSquare(row, col)) valid = false;
            }
        }
        return valid;
    }

    // Метод для генерации правильного игрового поля (заполняет поле корректно)
    generateSolution() {
        const fillBoard = (row, col) => {
            if (col === 9) {
                col = 0;
                row++;
                if (row === 9) return true;
            }

            const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9].sort(() => Math.random() - 0.5);

            for (const num of numbers) {
                if (this.isValidPlacement(row, col, num)) {
                    this.board[row][col] = num;
                    if (fillBoard(row, col + 1)) return true;
                    this.board[row][col] = 0;
                }
            }

            return false;
        };

        this.resetBoard();
        fillBoard(0, 0);
    }

    // Метод для проверки, может ли число быть поставлено на определенную позицию
    isValidPlacement(row, col, num) {
        for (let i = 0; i < 9; i++) {
            if (this.board[row][i] === num || this.board[i][col] === num) return false;
        }

        const startRow = row - (row % 3);
        const startCol = col - (col % 3);
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                if (this.board[startRow + i][startCol + j] === num) return false;
            }
        }

        return true;
    }
}

// Get references to the buttons
const createButton = document.getElementById('create');
const checkButton = document.getElementById('check');
const fullButton = document.getElementById('full');

const sudoku = new Sudoku();

function updateBoardFromInput() {
    const fields = document.querySelectorAll('.field');
    fields.forEach(field => {
        const row = parseInt(field.dataset.row);
        const col = parseInt(field.dataset.col);
        const value = parseInt(field.value) || 0;
        sudoku.board[row][col] = value;
    });
}

function updateInputFromBoard() {
    const fields = document.querySelectorAll('.field');
    fields.forEach(field => {
        const row = parseInt(field.dataset.row);
        const col = parseInt(field.dataset.col);
        const value = sudoku.board[row][col];
        field.value = value || '';
    });
}

function clearHighlights() {
    const fields = document.querySelectorAll('.field');
    fields.forEach(field => {
        field.style.backgroundColor = '';
    });
}

function highlightRow(row, color) {
    const fields = document.querySelectorAll(`.field[data-row="${row}"]`);
    fields.forEach(field => {
        field.style.backgroundColor = color;
    });
}

function highlightColumn(col, color) {
    const fields = document.querySelectorAll(`.field[data-col="${col}"]`);
    fields.forEach(field => {
        field.style.backgroundColor = color;
    });
}

function highlightSquare(startRow, startCol, color) {
    for (let row = startRow; row < startRow + 3; row++) {
        for (let col = startCol; col < startCol + 3; col++) {
            const field = document.querySelector(`.field[data-row="${row}"][data-col="${col}"]`);
            if (field) {
                field.style.backgroundColor = color;
            }
        }
    }
}

createButton.addEventListener('click', () => {
    sudoku.generateSolution();
    const numRemove = 40; // Number of cells to remove
    for (let i = 0; i < numRemove; i++) {
        const row = Math.floor(Math.random() * 9);
        const col = Math.floor(Math.random() * 9);
        sudoku.board[row][col] = 0;
    }
    updateInputFromBoard();
    clearHighlights();
});

// Event listener for the 'check' button
checkButton.addEventListener('click', () => {
    updateBoardFromInput();
    clearHighlights();
    let valid = true;

    for (let i = 0; i < 9; i++) {
        if (!sudoku.checkRow(i)) {
            highlightRow(i, 'red');
            valid = false;
        }
    }

    for (let i = 0; i < 9; i++) {
        if (!sudoku.checkColumn(i)) {
            highlightColumn(i, 'red');
            valid = false;
        }
    }

    for (let row = 0; row < 9; row += 3) {
        for (let col = 0; col < 9; col += 3) {
            if (!sudoku.checkSquare(row, col)) {
                highlightSquare(row, col, 'red');
                valid = false;
            }
        }
    }
    if (valid) {
        const fields = document.querySelectorAll('.field');
        fields.forEach(field => {
            field.style.backgroundColor = 'yellow';
        });
    }
});

fullButton.addEventListener('click', () => {
    sudoku.generateSolution();
    updateInputFromBoard();
    clearHighlights();
});