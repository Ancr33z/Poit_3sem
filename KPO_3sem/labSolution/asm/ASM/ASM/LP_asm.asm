.586P;														 система команд
.MODEL FLAT, STDCALL;										 модель памяти, соглашение о вызовах
includelib kernel32.lib;									 компановщику: компановать с  kernel32

ExitProcess PROTO : DWORD;									 
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD;        

.STACK 4096;   выделение стека-область памяти, отведенная под стек

.CONST;        сегмент констант

.DATA;														 
MB_OK EQU 0;												 
STR1	DB "Моя первая программа", 0;						
STR2	DB "Привет всем", 0;								
HW		DD ? ;												
															 
.CODE;														 сегмент кода-область памяти, в которой размещаются выполняемые команды программы;
main PROC;													 точка входа main 
START:;														 метка
PUSH MB_OK;													 
PUSH OFFSET STR1;											 Директива OFFSET указатель начала строки
PUSH OFFSET STR2;
PUSH HW;
CALL MessageBoxA;											 вызов функции
	
	INVOKE MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK; 


push -1;                                     
call ExitProcess;                            

main ENDP;                                   
end main;                                    