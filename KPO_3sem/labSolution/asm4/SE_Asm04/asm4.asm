.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD

.STACK 4096

.CONST

.DATA
BOOLF DB 1
INT16F DW 16

.CODE

main PROC
START:
    push 0
    call ExitProcess
main ENDP
end main
