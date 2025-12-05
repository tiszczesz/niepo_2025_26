#pragma once
#include <iostream>

#include "Gift.h"
#include "SizeEnum.h"
class Cloth :public Gift
{
protected:
	SizeEnum size;
	std::string material;
public:
	Cloth() :Gift(), size(SizeEnum::M), material("Unknown") {}
	Cloth(double p, const std::string& n, SizeEnum s, const std::string& m)
		:Gift(p, n), size(s), material(m) {}
	std::string ToString() override {
		return Gift::ToString() + ", Rozmiar: " 
			+ SizeToString()
			+ ", Material: " + material;
	}
	void Open() override {
		std::cout << "Otwarcie prezentu ubranie o nazwie: " << name << std::endl;
	}
	std::string SizeToString() {
		switch (size) {
		case SizeEnum::XS : return "XS";
		case SizeEnum::S: return "S";
		case SizeEnum::M: return "M";
		case SizeEnum::L: return "L";
		case SizeEnum::XL: return "XL";
		case SizeEnum::XXL: return "XXL";
		case SizeEnum::XXXL: return "XXXL";
		case SizeEnum::XXXXL: return "XXXXL";
		default: return "Unknown Size";
		}
	}
};

