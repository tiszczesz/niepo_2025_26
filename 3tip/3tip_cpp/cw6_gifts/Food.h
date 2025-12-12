#pragma once
#include <iostream>
#include "Gift.h"
#include "IDurability.h"

class Food :    public Gift ,public IDurability
{
	protected:
	double weight; // in grams
	std::string cuisineType;
	std::string expiryDate;
public:
	Food() : Gift(), weight(500.0), cuisineType("International"), 
	 expiryDate("2025-12-31") {}
	Food(double p, const std::string& n, double w,
		const std::string& ct, const std::string& ed)
		: Gift(p, n), weight(w), cuisineType(ct), expiryDate(ed) {}
	std::string ToString() override {
		return Gift::ToString() + ", Waga: "
			+ std::to_string(weight) + " g, Typ kuchni: " + cuisineType
			+ ", Data wa¿noœci: " + expiryDate;
	}
	void Open() override {
		std::cout << "Otwarcie prezentu jedzenie o nazwie: "
			<< name << std::endl;
	}
	void DurabilityInfo() override {
		std::cout << "-------- Data wa¿noœci jedzenia o nazwie " << name
			<< ": " << expiryDate << std::endl;
	}
};

