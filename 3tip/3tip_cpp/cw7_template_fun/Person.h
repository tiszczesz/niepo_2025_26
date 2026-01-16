#pragma once
#include <string>
#include <ostream>

class Person
{
private:
	std::string name;
	int age;
public:
	Person(const std::string& name, int age){
		this->name = name;
		this->age = age;
	}
	std::string getName() const {
		return name;
	}
	int getAge() const {
		return age;
	}
	friend std::ostream & operator<<(std::ostream &os, const Person &person) {
		os << "Osoba(Nazwa: " << person.name << ", Wiek: " << person.age << ")";
		return os;
	}
};

