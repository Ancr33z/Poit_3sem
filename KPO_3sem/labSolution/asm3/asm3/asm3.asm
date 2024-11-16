.586P                         ; ������� ��������� (��������� Pentium)
.MODEL FLAT, STDCALL          ; ������ ������, ���������� � ������
includelib kernel32.lib       ; ���������� ���������� � �������� ExitProcess, ������������: ����������� � kernel32
includelib user32.lib

ExitProcess PROTO :DWORD      ; �������� ������� ��� ���������� �������� Windows
MessageBoxA PROTO :DWORD, :DWORD, :DWORD, :DWORD  ; �������� API-������� MessageBoxA (�����: ����� ��� ����� 4 �����)

.STACK 4096                   ; ������� ����� �������� 4096 �����

.DATA                         ; ������� ������
    myBytes     BYTE    10h, 20h, 30h, 40h
    myWords     WORD    8Ah, 3Bh, 44h, 5Fh, 99h
    myDoubles   DWORD   1, 2, 3, 4, 5, 6, 7
    SUM         DWORD   0

    str0        db      "������� ������, ���� 2, ��", 0            
    str1        db      "������ �������� 0", 0 
    str2        db      "������ �� �������� 0", 0

.CODE
main PROC
start:  
    ; ������� �������� ��� ������� myWords
    mov ESI, OFFSET myWords    ; �������� myWords -> ESI (��������� �������)
    mov AX, [ESI + 4]          ; AX = myWords[2] (�� ������� 2)
    mov BX, [ESI + 2]          ; BX = myWords[1] (�� ������� 1)

    ; ������������� �������� ��� ������� myDoubles
    mov EDI, OFFSET myDoubles  ; �������� myDoubles -> EDI (��������� �������)
    mov ECX, 7                 ; ������� ��� ������� �� 7 ���������

    ; ���������� ����� ��������� ������� myDoubles
CYCLE:
    mov EAX, [EDI]             ; ��������� ������� ������� � EAX
    add [SUM], EAX             ; ���������� � �����
    add EDI, type myDoubles    ; ��������� � ���������� ��������
    loop CYCLE                 ; ���������, ���� �� ���������� ��� 7 ���������

    ; �������� ������� �������� �������� � �������
    mov EDI, OFFSET myDoubles  ; ����� ��������� �� ������ �������
    mov ECX, 7                 ; �������
CYCLE_2:
    mov EAX, [EDI]             ; ��������� ������� ������� � EAX
    add EDI, type myDoubles    ; ��������� � ���������� ��������
    cmp EAX, 0                 ; ���������� � �����
    jz  FOUND_ZERO             ; ���� ������� ����� 0, ������� �� FOUND_ZERO
    loop CYCLE_2               ; ���� �� ����� ����, ���������� ����

    ; ���� �� ����� ����, ������ EBX � 1 � ���������� ��������������� ���������
    mov EBX, 1                 ; � EBX ���������� 1 (��� �������� ��������)
    invoke MessageBoxA, 0, offset str2, offset str0, 0
    jmp END_PROGRAM            ; ��������� � ���������� ���������

FOUND_ZERO:
    ; ���� ������ ����, ������ EBX � 0 � ���������� ��������������� ���������
    mov EBX, 0                 ; � EBX ���������� 0 (���� ������� �������)
    invoke MessageBoxA, 0, offset str1, offset str0, 0

END_PROGRAM:
    ; ��������� ���������, ��������� ���
    push 0
    call ExitProcess           ; ��������� �������

main ENDP                     ; ����� ��������� main

end main                      ; ����� ����� � ���������
