#include <iostream>
#include <string>
#include "Animal.h"
#include "Dog.h"
#include <vector>
using namespace std;
int main() {
	//dyamiczne tworzenie obiektu na stercie
	vector<Animal*> animals;
	Animal* a1 = new Animal(3, "Leo");
	Dog* d1 = new Dog(5, "Burek", "Owczarek");
	animals.push_back(a1);
	animals.push_back(d1);
	for (auto a : animals) {
		a->MakeSound();
	}
	a1->MakeSound();// (*a1).MakeSound();
	d1->MakeSound();
	d1->Fetch();
	delete a1; //zwolnienie pamieci
	delete d1; //zwolnienie pamieci
	return 0;
}