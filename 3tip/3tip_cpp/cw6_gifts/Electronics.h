#pragma once
#include <iostream>


#include "Gift.h"
class Electronics :  public Gift
{
protected:
	int warrantyPeriod; // in months
	double power;
public:
	Electronics() : Gift(), warrantyPeriod(12), power(100.0) {}
	Electronics(double p, const std::string& n, int wp, 
		double pow)
		: Gift(p, n), warrantyPeriod(wp), power(pow) {}
	std::string ToString() override {
		return Gift::ToString() + ", Okres gwarancji: " 
			+ std::to_string(warrantyPeriod) + " mies., Moc: " 
			+ std::to_string(power) + " W";
	}
	void Open() override {
		std::cout << "Otwarcie prezentu elektronika o nazwie: "
		<< name << std::endl;
	}
};

