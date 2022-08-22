#include <stdio.h>

extern "C" {
    __declspec(dllexport) void __thiscall hello_thiscall(char *x) {  
       printf("%s\n", x);
    }
}

/*
int 
main() {
    char *a = (char*)"Hello, thiscall!\n";
    hello_thiscall(a);
}
*/
