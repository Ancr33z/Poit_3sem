#pragma once

// ASM_HEAD: Макрос, содержащий заголовок для ассемблерной программы
#define ASM_HEAD \
    ".586P\n" \
    ".MODEL FLAT, STDCALL\n" \
    "includelib kernel32.lib\n\n" \
    "ExitProcess PROTO : DWORD\n\n" \
    ".STACK 4096\n\n" \
    ".CONST\n\n" \
    ".DATA\n"

// ASM_FOOTER: Макрос, содержащий завершение для ассемблерной программы
#define ASM_FOOTER \
    "\n.CODE\n\n" \
    "main PROC\n" \
    "START:\n" \
    "    push 0\n" \
    "    call ExitProcess\n" \
    "main ENDP\n" \
    "end main\n"
