.586P                         ; система подкоманд (процессор Pentium)
.MODEL FLAT, STDCALL          ; модель памяти, соглашение о вызове
includelib kernel32.lib       ; подключаем библиотеку с функцией ExitProcess, компоновщику: компоновать с kernel32
includelib user32.lib

ExitProcess PROTO :DWORD      ; прототип функции для завершения процесса Windows
MessageBoxA PROTO :DWORD, :DWORD, :DWORD, :DWORD  ; прототип API-функции MessageBoxA (парам: слово без знака 4 байта)

.STACK 4096                   ; сегмент стека размером 4096 Мбайт

.DATA                         ; сегмент данных
    myBytes     BYTE    10h, 20h, 30h, 40h
    myWords     WORD    8Ah, 3Bh, 44h, 5Fh, 99h
    myDoubles   DWORD   1, 2, 3, 4, 5, 6, 7
    SUM         DWORD   0

    str0        db      "Борисов Никита, курс 2, ПИ", 0            
    str1        db      "Массив содержит 0", 0 
    str2        db      "Массив не содержит 0", 0

.CODE
main PROC
start:  
    ; Задание смещения для массива myWords
    mov ESI, OFFSET myWords    ; смещение myWords -> ESI (косвенный операнд)
    mov AX, [ESI + 4]          ; AX = myWords[2] (по индексу 2)
    mov BX, [ESI + 2]          ; BX = myWords[1] (по индексу 1)

    ; Инициализация смещения для массива myDoubles
    mov EDI, OFFSET myDoubles  ; смещение myDoubles -> EDI (косвенный операнд)
    mov ECX, 7                 ; Счетчик для массива из 7 элементов

    ; Вычисление суммы элементов массива myDoubles
CYCLE:
    mov EAX, [EDI]             ; Загружаем элемент массива в EAX
    add [SUM], EAX             ; Прибавляем к сумме
    add EDI, type myDoubles    ; Переходим к следующему элементу
    loop CYCLE                 ; Повторяем, пока не обработаны все 7 элементов

    ; Проверка наличия нулевого элемента в массиве
    mov EDI, OFFSET myDoubles  ; Снова указываем на начало массива
    mov ECX, 7                 ; Счетчик
CYCLE_2:
    mov EAX, [EDI]             ; Загружаем элемент массива в EAX
    add EDI, type myDoubles    ; Переходим к следующему элементу
    cmp EAX, 0                 ; Сравниваем с нулем
    jz  FOUND_ZERO             ; Если элемент равен 0, прыгаем на FOUND_ZERO
    loop CYCLE_2               ; Если не нашли ноль, продолжаем цикл

    ; Если не нашли ноль, ставим EBX в 1 и показываем соответствующее сообщение
    mov EBX, 1                 ; В EBX записываем 1 (нет нулевого элемента)
    invoke MessageBoxA, 0, offset str2, offset str0, 0
    jmp END_PROGRAM            ; Переходим к завершению программы

FOUND_ZERO:
    ; Если найден ноль, ставим EBX в 0 и показываем соответствующее сообщение
    mov EBX, 0                 ; В EBX записываем 0 (есть нулевой элемент)
    invoke MessageBoxA, 0, offset str1, offset str0, 0

END_PROGRAM:
    ; Завершаем программу, возвращая код
    push 0
    call ExitProcess           ; Завершаем процесс

main ENDP                     ; Конец процедуры main

end main                      ; Точка входа в программу
