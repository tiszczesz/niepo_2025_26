#pragma once
#include <complex.h>
#include <vector>
#include "Cloth.h"	
#include "Electronics.h"
#include "Food.h"
#include "Sweets.h"


std::vector<Gift*> GenerGifts() {
	std::vector<Gift*> gifts;
	gifts.push_back(
		new Cloth(49.99, "T-Shirt", SizeEnum::L, "Cotton"));
	gifts.push_back(new Electronics(299.99, "Smartphone",
		  24, 15.0));
	gifts.push_back(new Food());
	gifts.push_back(new Sweets());
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
		//rzutowanie dynamiczne do IDurability
		IDurability* durabilityPtr = dynamic_cast<IDurability*>(gift);
		if (durabilityPtr) {
			durabilityPtr->DurabilityInfo();
		}
	}
}
