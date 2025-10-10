#include <iostream>
#include <string>
#include "Animal.h"
#include "Dog.h"
#include "Cat.h"
#include <vector>
using namespace std;
void clearAll(const vector<Animal*>& animals);
int main() {
	//dyamiczne tworzenie obiektu na stercie
	vector<Animal*> animals;

	animals.push_back(new Animal(3, "Leo"));
	animals.push_back(new Dog(5, "Burek", "Owczarek"));
	animals.push_back(new Dog(2, "Reksio", "Mieszaniec"));
	animals.push_back(new Cat(6, "Filemon", true));
	for (auto a : animals) {
		a->MakeSound();//kazdy obiekt wywola swoja metode MakeSound
	}
	//a1->MakeSound();// (*a1).MakeSound();
	//d1->MakeSound();
	//d1->Fetch();
	clearAll(animals);//zwolnienie pamieci
	return 0;
}
//zwalnienie pamieci dla wszystkich obiektow w wektorze
void clearAll(const vector<Animal*>& animals) {
	for (auto a : animals) {
		delete a; //zwolnienie pamieci
	}
}