#include <stdio.h>

extern "C" {
    __declspec(dllexport) void __cdecl hello_cdecl() {  
       printf("Hello, cdecl!\n");
    }
}

/*
int 
main() {
    hello_cdecl();
}
*/