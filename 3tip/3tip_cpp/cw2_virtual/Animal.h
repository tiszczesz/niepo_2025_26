#pragma once
#include <iostream>
#include <string>

class Animal
{
protected:
	int age;
	std::string name;
public:
	Animal() : age(0), name("Unknown") {}
	Animal(int a, const std::string& n) : age(a), name(n) {}
	~Animal() {
		std::cout << "Czyszczenie zasobow klasy Animal" << std::endl;
	}
	void MakeSound(){
		std::cout << "Dzwiek zwierzecia\n" ;
	}
};

