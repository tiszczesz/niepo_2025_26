#include <iostream>
#include <vector>
#include <string>
#include "Gift.h"
#include "Cloth.h"
#include "Functions.h"

using namespace std;
int main() {
	std::vector<Gift*> gifts = GenerGifts();
	ShowGifts(gifts);
	return 0;
}

