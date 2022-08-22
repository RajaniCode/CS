// ArmstrongNumber

#include <iostream>
#include <stdlib.h>

using namespace std;

int main () {
    int a;
	int s = 0;
	int n;
	int temp;
	cout << "Enter the number: ";
	cin >> n;
	temp = n;
	while (n != 0) {
        a = n % 10;
        s = s + (a * a * a);
        n = n / 10;
    } 
    if(temp == s) {
        cout << "\n" << temp << " is Armstrong";
    }
    else {
        cout << "\n" << temp << " is not Armstrong";
    }
    cout << endl;
    cout << endl;
    system("pause");
}

// >cl 1.cs

// >1