#include <iostream>
#include <ostream>
#include <string>
#include "Person.h"

Person::Person() :age(0) {
	std::cout << "Person created!" << std::endl;
}
Person::Person(std::string firstName, std::string lastName, int age) {
	this->firstName = firstName;
	this->lastName = lastName;
	this->age = age < 0 ? -age : age;
}
Person::~Person() {
	std::cout << "Person destroyed!" << std::endl;
}
int Person::GetAge() const {
	return age;
}
std::string Person::GetFirstName() const {
	return firstName;
}