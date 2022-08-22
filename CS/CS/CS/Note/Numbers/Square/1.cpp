#include <iostream>

using namespace std;

float squareroot(float n)
{
   float i=0;
   float x1,x2;
   while( (i*i) <= n )
          i+=0.1;
   x1=i;
   for(int j=0;j<10;j++)
   {
        x2=n;
      x2/=x1;
      x2+=x1;
      x2/=2;
      x1=x2;
   }
   return x2;
}

int main()
{
   cout<<"Enter the number for which square root is to be found:";
   float number;
   cin>>number;
   cout<<"Square Root using sqroot()= "<<squareroot(number);
   return 0;
}
