#include<iostream>
#include<string>
#include<cstdlib>
#include <vector>
#include "Person.h"
using namespace std;
//szablon funkcji
template <typename T>
void Show(T info) {
	cout << info << endl;
}
//template dla Add

int main() {
	vector<string> texts = 
		{ "Hello", "World", "from", "C++20" };
	vector<int> numbers = 	{ 1, 2, 3, 4, 5 };
	vector<double> decimals = { 1.1, 2.2, 3.3, 4.4, 5.5 };
	for (const string& text : texts) {
		Show<string>(text);
	}
	for (const int& number : numbers) {
		Show<int>(number);
	}
	for (const double& d : decimals) {
		Show<double>(d);
	}
	Person p1("Alice", 30);
	Show<Person>(p1);
	return 0;
}