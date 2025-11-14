#include <iostream>
#include <string>
#include "Functions.h"
#include <ctime>
using namespace std;

int main() {
	// Inicjalizacja generatora liczb losowych
	srand(static_cast<unsigned int>(time(nullptr)));
	//cout << static_cast<double>(3) / 5 << endl;
	//cout << (double) 3 / 5 << endl;
	unsigned int steps;
	cout << "Podaj liczbe krokow: ";
	cin >> steps;
	cout << "Przyblizenie liczby Pi dla " 
		<< steps << " krokow wynosi: " 
		<< GenerPi(steps) << endl;
	return 0;
}
