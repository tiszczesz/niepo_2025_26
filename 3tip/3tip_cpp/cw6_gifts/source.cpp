#include <iostream>
#include <vector>
#include <string>
#include "Gift.h"
#include "Cloth.h"
std::vector<Gift*> GenerGifts();
void ClearGifts(std::vector<Gift*>& gifts);
using namespace std;
int main() {
	std::vector<Gift*> gifts = GenerGifts();
	for (const auto& gift : gifts) {
		cout << gift->ToString() << endl;
		gift->Open();
	}
	return 0;
}

std::vector<Gift*> GenerGifts() {
	std::vector<Gift*> gifts;
	gifts.push_back(
		new Cloth(49.99, "T-Shirt", SizeEnum::L, "Cotton"));
	return gifts;
}
void ClearGifts(std::vector<Gift*>& gifts) {
	for (auto gift : gifts) {
		delete gift;
	}
	gifts.clear();
}