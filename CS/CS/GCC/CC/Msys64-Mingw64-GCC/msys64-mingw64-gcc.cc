#include <stdio.h>
#include <string.h>

extern "C" {
    __declspec(dllexport) char* hello_world(char *x, char *y) {  
       static char a[100];
       strcpy(a, x);
       strcat(a, y);
       return a;
    }

    __declspec(dllexport) char* hello(char *x) {
        static char a[100];
        strcpy(a, "Hello, ");
        strcat(a, x);
        return a;
    }

    __declspec(dllexport) char* world(char *y) {
       char* c = hello(y);
       strcat(c, "!");
       return c;
    }
}

/*
int 
main() {
    char *hw = (char*)"Hello, ";
    char *h = (char*)"World!";
    char *w = (char*)"World";
    printf("%s\n", hello_world(hw, h));
    printf("%s\n", hello(h));
    printf("%s\n", world(w));
}
*/