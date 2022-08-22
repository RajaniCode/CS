#include <stdio.h>

extern "C" {
    __declspec(dllexport) void __stdcall hello_stdcall() {  
       printf("Hello, stdcall!\n");
    }
}

/*
int 
main() {
    hello_stdcall();
}
*/