#pragma once
#include <string>

class Person {
public:
	Person();
	Person(std::string firstName, std::string lastName, int age = 0);
	~Person();
	int GetAge() const;
	std::string GetFirstName() const;


private:
	std::string firstName;
	std::string lastName;
	int age;
};
