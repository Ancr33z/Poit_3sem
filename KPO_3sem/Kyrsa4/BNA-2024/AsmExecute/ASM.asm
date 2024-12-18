.586
.model flat , stdcall
includelib libucrt.lib
includelib kernel32.lib
includelib ..\Debug\FuncLib.lib
ExitProcess PROTO:DWORD 
EXTRN random: PROC 
EXTRN toPow: PROC
EXTRN strLength: PROC
EXTRN writestr: PROC
EXTRN writenum: PROC
EXTRN writenumline: PROC
EXTRN writestrline: PROC
EXTRN system_pause:PROC
.stack 4096
.const
ZEROMESSAGE  BYTE 'Ошибка:деление на ноль',0
OVERFLOWMESSAGE  BYTE 'Ошибка:переполнение типа',0
	sumcalc_sum BYTE 'calc sum', 0
	multisumcal_combo_sum BYTE 'cal combo sum', 0
	main4 DWORD 4
	main5 DWORD 5
	main10 DWORD 10
	main3 DWORD 3
	main9 DWORD 9
	mainbitwise_operations BYTE 'bitwise operations', 0
	main1 DWORD 1
	mainn BYTE 'n', 0
	main7 DWORD 7
	main0 DWORD 0
.data
	mainresult1 DWORD ?
	maincounter1 DWORD ?
	mainmessage1 DWORD ?

.code
sum PROC sumi1 :  DWORD , sumo1 :  DWORD 
push OFFSET sumcalc_sum
pop eax
push eax
call writestrline
push sumi1
push sumo1
pop eax
pop ebx
add eax,ebx
push eax
jc OVERFLOW
pop eax
 
ret
ZEROERROR:
push OFFSET ZEROMESSAGE
call writestrline
push -1
	call		ExitProcess
OVERFLOW:
push OFFSET OVERFLOWMESSAGE
call writestrline
push -1
	call		ExitProcess
sum ENDP

multisum PROC multisumi1 :  DWORD , multisumo1 :  DWORD 
push OFFSET multisumcal_combo_sum
pop eax
push eax
call writestrline
push multisumi1
push multisumo1
pop eax
pop ebx
add eax,ebx
push eax
jc OVERFLOW
push multisumi1
push multisumo1
call sum
 push eax
pop eax
pop ebx
add eax,ebx
push eax
jc OVERFLOW
pop eax
 
ret
ZEROERROR:
push OFFSET ZEROMESSAGE
call writestrline
push -1
	call		ExitProcess
OVERFLOW:
push OFFSET OVERFLOWMESSAGE
call writestrline
push -1
	call		ExitProcess
multisum ENDP

main PROC
push main4
push main5
call multisum
 push eax
pop eax
push eax
pop mainresult1
push mainresult1
pop eax
push eax
call writenumline
push main10
pop eax
push eax
pop maincounter1
push maincounter1
pop eax
push eax
call writenumline
push main5
push main3
push main9
pop ebx
pop eax
mul ebx
push eax
jc OVERFLOW
pop eax
pop ebx
add eax,ebx
push eax
jc OVERFLOW
pop eax
push eax
pop maincounter1
push OFFSET mainbitwise_operations
pop eax
push eax
call writestrline
push maincounter1
push main1
pop ebx
pop eax
shl eax, 1
push eax 
jc OVERFLOW
pop eax
push eax
pop maincounter1
push maincounter1
pop eax
push eax
call writenumline
push maincounter1
push main1
pop ebx
pop eax
sar eax, 1
push eax 
jc OVERFLOW
pop eax
push eax
pop maincounter1
push maincounter1
pop eax
push eax
call writenumline
push mainresult1
push main1
pop eax
pop ebx
add eax,ebx
push eax
jc OVERFLOW
pop eax
push eax
pop mainresult1
push OFFSET mainn
pop eax
push eax
pop mainmessage1
push mainresult1
push main7

	pop ebx
	pop eax
test ebx, ebx
jz ZEROERROR
	cdq
	div ebx
	push edx
jc OVERFLOW
push main1
pop eax
pop ebx
add eax,ebx
push eax
jc OVERFLOW
pop eax
push eax
pop mainresult1
push main0
pop eax
push eax
call	system_pause
 	call		ExitProcess
ZEROERROR:
push OFFSET ZEROMESSAGE
call writestrline
push -1
	call		ExitProcess
OVERFLOW:
push OFFSET OVERFLOWMESSAGE
call writestrline
push -1
	call		ExitProcess
 main ENDP
END main