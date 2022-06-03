#include <stdio.h>
#include <string.h>

extern "C" {
    __declspec(dllexport) void __cdecl hello_cdecl() {  
       printf("Hello, cdecl!\n");
    }
}

int 
main() {
    hello_cdecl();
}