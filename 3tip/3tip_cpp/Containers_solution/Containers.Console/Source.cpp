#include <iostream>
#include <cstdlib>
#include "Stack.h"

using namespace std;
int main() {
	Stack<int> stack;
	cout << "Ilosc elementow w stosie: " << stack.GetSize() << endl;
	stack.push(34);
	cout << "Ilosc elementow w stosie po operacjach: " << stack.GetSize() << endl;
	cout << "Top element: " << stack.top() << endl;
	cout << "Popped element: " << stack.pop() << endl;
	
	return EXIT_SUCCESS;
}