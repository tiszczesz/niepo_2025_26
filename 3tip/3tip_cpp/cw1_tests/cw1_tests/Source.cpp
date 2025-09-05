#include <iostream>
#include <cstdlib>
#include <ctime>
#include <string>
#include "counter.h"

using namespace std;

int main() {
	//cout << "Hello World!" << endl;
	Counter c1;
	c1.increment();
	cout << c1.getCount() << endl;
	return 0;
}