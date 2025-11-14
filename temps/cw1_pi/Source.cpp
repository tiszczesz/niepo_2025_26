#include "Functions.h"
#include <iostream>
#include <string>
#include <cstdlib>
#include <ctime>


using namespace std;

int main() {
	srand(static_cast<unsigned>(time(nullptr)));
	unsigned steps;
	cout << "Podaj liczbe krokow do wyznaczenia liczby pi: ";
	cin >> steps;
	double pi = GenerPi(steps);
	cout << "Przyblizona wartosc liczby pi to: " << pi << endl;
	return 0;
}
