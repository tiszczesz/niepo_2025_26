#pragma once
#include <iostream>
#include "Gift.h"
class Sweets :
	public Gift, public IDurability
{
    protected:
    double weight; // in grams
	std::string flavor;
    std::string expiryDate;
    public:
    Sweets() : Gift(), weight(100.0), flavor("Chocolate")
	   ,expiryDate("2025-09-09") {}
    Sweets(double p, const std::string& n, double w, 
        const std::string& f,std::string _expireDate)
        : Gift(p, n), weight(w), flavor(f),expiryDate(_expireDate) {}
    std::string ToString() override {
        return Gift::ToString() + ", Waga: " 
            + std::to_string(weight) + " g, Smak: " + flavor;
    }
    void Open() override {
        std::cout << "Otwarcie prezentu slodycze o nazwie: "
            << name << std::endl;
	}
    void DurabilityInfo() override {
        std::cout << " ------ Data wa¿noœci s³odyczy o nazwie " << name 
            << ": " << expiryDate << std::endl;
	}
};

