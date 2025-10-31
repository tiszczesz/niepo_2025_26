#pragma once
#include <vector>
#include <string>

#include "File.h"
class FileText : public File
{
private:
	std::vector<std::string> content;
public:
	FileText()
		:File(), content()
	{
		std::cout
			<< "Utworzenie obiektu FileText (domyslny konstruktor)"
			<< std::endl;
	}
	FileText(const std::string& path, int size, 
		const std::vector<std::string>& content)
		:File(path, size), content(content) {
		std::cout
			<< "Utworzenie obiektu FileText (argumenty konstruktor)"
			<< std::endl;
	}
	// nadpisanie metody czysto wirtualnej
	void ShowContent() override {
		std::cout
			<< "Zawartosc pliku tekstowego: "
			<< std::endl;
		for (const auto& line : content) {
			std::cout << line << std::endl;
		}
	}
};

