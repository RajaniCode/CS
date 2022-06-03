#include <stdio.h>
#include <string.h>

char* hello_world(char *x, char *y) {  
   static char a[100];
   strcpy(a, x);
   strcat(a, y);
   return a;
}

char* hello(char *x) {
    static char a[100];
    strcpy(a, "Hello, ");
    strcat(a, x);
    return a;
}

char* world(char *y) {
   char* c = hello(y);
   strcat(c, "!");
   return c;
}

int 
main(void) {
    printf("%s\n", hello_world("Hello, ", "World!"));
    printf("%s\n", hello("World!"));
    printf("%s\n", world("World"));
}