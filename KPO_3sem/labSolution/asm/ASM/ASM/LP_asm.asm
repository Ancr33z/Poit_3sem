.586P;														 ������� ������
.MODEL FLAT, STDCALL;										 ������ ������, ���������� � �������
includelib kernel32.lib;									 ������������: ����������� �  kernel32

ExitProcess PROTO : DWORD;									 
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD;        

.STACK 4096;   ��������� �����-������� ������, ���������� ��� ����

.CONST;        ������� ��������

.DATA;														 
MB_OK EQU 0;												 
STR1	DB "��� ������ ���������", 0;						
STR2	DB "������ ����", 0;								
HW		DD ? ;												
															 
.CODE;														 ������� ����-������� ������, � ������� ����������� ����������� ������� ���������;
main PROC;													 ����� ����� main 
START:;														 �����
PUSH MB_OK;													 
PUSH OFFSET STR1;											 ��������� OFFSET ��������� ������ ������
PUSH OFFSET STR2;
PUSH HW;
CALL MessageBoxA;											 ����� �������
	
	INVOKE MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK; 


push -1;                                     
call ExitProcess;                            

main ENDP;                                   
end main;                                    