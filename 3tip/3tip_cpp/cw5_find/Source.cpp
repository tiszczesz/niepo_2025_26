#include <iostream>
#include <cstdlib>
#include <ctime>
#include <string>
#include "Header.h"


using namespace std;

int main() {
	srand(static_cast<unsigned int>(time(nullptr)));
	int* tab = nullptr; //wskaznik na tablice
	cout << "Podaj rozmiar tablicy: ";
	unsigned int size;
	cin >> size;
	tab = GenerTab(size);
	ShowTab(size, tab);
	SortTab(size, tab);
	ShowTab(size, tab);
	cout << "Podaj liczbe do wyszukania: ";
	int value;
	cin >> value;
	int index = SearchTab(size, tab, value);
	delete[] tab; //zwolnienie pamieci
	tab = nullptr;//uniewaznienie wskaznika
	return 0;
}