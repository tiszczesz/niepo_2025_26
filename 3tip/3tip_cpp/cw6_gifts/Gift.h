#pragma once
#include <string>

class Gift
{
protected:
	double price;
	std::string name;
public:
	Gift() : price(0.0), name("Unnamed Gift") {}
	Gift(double p, const std::string& n) : price(p), name(n) {}
	virtual std::string ToString() {
		return "Nazwa: " + name + ", Cena: " 
		+ std::to_string(price);
	}
	virtual ~Gift() {}
	virtual void Open() = 0;
};

