#include<iostream>

#include <cstdlib>

int* GenerTab(const unsigned int size) {
	int* tab = new int[size];
	for (size_t i=0;i<size;i++){
		tab[i]= rand() % 100; //losowe liczby od 0 do 99
	}
	return tab;
}
void ShowTab(const unsigned int size,int tab[]) {
	for (size_t i=0;i<size;i++) {
		std::cout << tab[i] << " ";
	}
	std::cout << std::endl;	
}
void SortTab(const unsigned int size, int tab[]) {
	//todo zmienia tablice na posortowana
}
int SearchTab(const unsigned int size, int tab[], int value) {
	//todo zwraca index znalezionej lub -1 jak nie znaleziono
	return -1;
}