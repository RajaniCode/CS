// A program to find the first 1,000 prime numbers 


#include <stdio.h>
#include <stdlib.h>


int prime(int number, int * primes);

int main(void) {
    int primes[998] = { 3, 0 };
    int n = 5, i;
    int count = 0, found;

    printf("%8d%8d%8d", 1, 2, 3);               /*  Print first 3 primes     */


    /*  Find the next 997  */

    while ( count < 997 ) {
        i = 0;
        found = 1;


        /*  Test if number divides by any of the primes already found  */

        while ( primes[i] ) {
            if ( (n % primes[i++]) == 0 ) {   /*  If it does...              */
                found = 0;                    /*  ...then it isn't prime...  */
                break;                        /*  ...so stop looking         */
            }
        }

        if ( found ) {
            printf("%8d", n);                /*  If it's prime, print it...  */
            primes[i] =  n;                  /*  ...and add it to the list   */
            ++count;
        
        
            /*  Start a new line every 8 primes found  */
        
            if ( ((count + 3) % 8) == 0 )
                putchar('\n');
        }

        n += 2;     /*  There's no point testing even numbers, so skip them  */
    }

    putchar('\n');

    return EXIT_SUCCESS;
}
