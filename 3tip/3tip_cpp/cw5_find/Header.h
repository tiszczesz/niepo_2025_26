#pragma once
#include <cstdlib>
#include <iostream>
//napisz w pliku Functions.cpp funkcje:
//1. Funkcja generujaca tablice n losowych liczb 
//    calkowitych z przedzialu od min do max
//2. Funkcja wyswietlajaca tablice
//3. Funkcja sortujaca tablice metoda dowolna
//4. Funkcja wyszukujaca w tablicy uporzadkowanej podanej liczby

int* GenerTab(const unsigned int size);
void ShowTab(const unsigned int size, int tab[]);
void SortTab(const unsigned int size, int tab[]);
int SearchTab(const unsigned int size, int tab[], int value);