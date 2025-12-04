#include <iostream>
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

int main()
{
	Person p1;
    std::cout << "Hello World!\n";
}

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

