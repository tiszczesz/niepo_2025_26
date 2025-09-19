#pragma once
#include "Animal.h"
class Dog : public Animal
{
protected:
	std::string breed;
public:
	Dog(): Animal(),breed("Unknown") {}
	Dog(int a, const std::string& n, const std::string& b)
	: Animal(a, n), breed(b) {}
	~Dog() {
		std::cout << "Czyszczenie zasobow klasy Dog\n" ;
	}
	// Przesloniecie metody z klasy bazowej
	void MakeSound() {
		std::cout << "Hau Hau\n" ;
	}
	// Nowa metoda w klasie pochodnej
	void Fetch() {
		std::cout << name << " przynosi pilke!\n" ;
	}
};

