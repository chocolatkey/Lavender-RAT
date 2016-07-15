#pragma once

#define CWA(dll, api)                 ::api
#define MEM_PERSONAL_HEAP             1
#define MEM_ALLOC_SAFE_BYTES          1
#define XLIB_UCL_ONLY_MAX_COMPRESSION 1
#define XLIB_UCL_ENABLE_NRV2B         1
#define XLIB_UCL_ENABLE_NRV2D         0
#define XLIB_UCL_ENABLE_NRV2E         0
#define XLIB_DEBUG_SERVER_URL         "http://localhost/dserver/report.php"
#define XLIB_DEBUG_SERVER_CRYPTKEY    "hello"
#define PEIMAGE_32                    1
#define PEIMAGE_64                    0
#define XLIB_PECRYPT_LITE             0
#define XLIB_MSCAB_FCI                1
#define XLIB_MSCAB_FDI                0
#define NTDLL_IMPORT                  0
#define FS_ALLOW_FILEMAPPING          0

#define BO_DEBUG 1

//Шрифт используемый в диалогах
#define FONT_DIALOG "MS Shell Dlg 2"

#if defined _WIN64
#  define ASM_INTERNAL_DEF
#  define ASM_INTERNAL
#else
#  define ASM_INTERNAL_DEF __stdcall
#  define ASM_INTERNAL     __declspec(naked) __stdcall
#endif

//Конвертация BIG_ENDIAN <=> LITTLE_ENDIAN 
#define SWAP_WORD(s) (((((WORD)(s)) >> 8) & 0x00FF) | ((((WORD)(s)) << 8) & 0xFF00))
#define SWAP_DWORD(l) (((((DWORD)(l)) >> 24) & 0x000000FFL) | ((((DWORD)(l)) >>  8) & 0x0000FF00L) | ((((DWORD)(l)) <<  8) & 0x00FF0000L) | ((((DWORD)(l)) << 24) & 0xFF000000L))

//Создание qword из двух dword
#define MAKEDWORD64(l, h) ((DWORD64)(((DWORD)((DWORD64)(l) & MAXDWORD)) | ((DWORD64)((DWORD)((DWORD64)(h) & MAXDWORD))) << 32))


//#include "..\common\config.h"
//#include "..\common\defines.h"

