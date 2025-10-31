#pragma once
#include <string>
#include <iostream>

class File
{
protected:
	std::string path;
	int size;
public:
	File() : path("noname"), size(0) {
		std::cout
		<< "Utworzenie obiektu File (domyslny konstruktor)"
		<< std::endl;
	}
	File(const std::string& path,int size)
		:path(path), size(size) {
		std::cout
			<< "Utworzenie obiektu File (z argumentami konstruktor)"
			<< std::endl;
	}
	virtual ~File() {
		std::cout
			<< "Usuniecie obiektu File"
			<< std::endl;
	}
};

