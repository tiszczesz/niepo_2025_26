#pragma once
#include <vector>
#include "Cloth.h"	



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
void ShowGifts(const std::vector<Gift*>& gifts) {
	for (const auto& gift : gifts) {
		std::cout << gift->ToString() << std::endl;
		gift->Open();
	}
}
