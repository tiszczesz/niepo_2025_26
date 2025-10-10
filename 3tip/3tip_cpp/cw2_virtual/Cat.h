#pragma once
#include "Animal.h"

class Cat : public Animal
{
protected:
	bool isIndoor;

public:
	Cat() : Animal(), isIndoor(true) {}
	Cat(int a, const std::string& n, bool indoor)
		: Animal(a, n), isIndoor(indoor) {}
	~Cat() {
		std::cout << "Czyszczenie zasobow klasy Cat\n";
	}
	// Przesloniecie metody z klasy bazowej
	void MakeSound() override {
		std::cout << "Miau Miau\n";
	}
	// Nowa metoda w klasie pochodnej
	void Scratch() {
		std::cout << name << " drapie meble!\n";
	}

};

