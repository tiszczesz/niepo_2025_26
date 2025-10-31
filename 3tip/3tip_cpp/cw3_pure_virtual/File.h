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
	virtual void ShowInfo() { //moge nadpisac lub nie
		std::cout
			<< "Sciezka: " << path
			<< ", rozmiar: " << size
			<< std::endl;
	}
	//metoda czysto wirtualna nie ma implementacji!!!!
	//musi byc nadpisana w klasach pochodnych (nie abstrakcyjnych)
	virtual void ShowContent() = 0; // metoda czysto wirtualna

	virtual ~File() {
		std::cout
			<< "Usuniecie obiektu File"
			<< std::endl;
	}
	void NoVirtual() {
		std::cout
			<< "Metoda nie wirtualna z klasy File"
			<< std::endl;
	}
};

