// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <concepts>
#include <sstream>
#include <string>
#include <iostream>


template <typename T>
concept HasStdToString = requires(T v) {
    { std::to_string(v) } -> std::convertible_to<std::string>;
};

template <typename T>
concept StreamableToOstream = requires(T v, std::ostream & os) {
    { os << v } -> std::same_as<std::ostream&>;
};

template <typename T>
std::string stringify(const T& value) {
    if constexpr (HasStdToString<T>) {
        return std::to_string(value);
    }
    else if constexpr (StreamableToOstream<T>) {
        std::ostringstream oss;
        oss << value;
        return oss.str();
    }
    else {
        static_assert(HasStdToString<T> || StreamableToOstream<T>,
            "Type cannot be converted to string");
        return {};
    }
}
struct Point {
	int x, y;
	friend std::ostream& operator<<(std::ostream& os, const Point& p) {
		return os << "(" << p.x << ", " << p.y << ")";
	}
};


int main()
{

    // Użycie z typami wspieranymi przez std::to_string
    int liczba = 42;
    double pi = 3.14159;
    float temperatura = -5.5f;

    std::cout << "Int: " << stringify(liczba) << std::endl;
    std::cout << "Double: " << stringify(pi) << std::endl;
    std::cout << "Float: " << stringify(temperatura) << std::endl;

    // Użycie z typami wspierającymi operator<<
    std::string tekst = "Hello";
    const char* cstr = "World";

    std::cout << "String: " << stringify(tekst) << std::endl;
    std::cout << "C-string: " << stringify(cstr) << std::endl;

    // Użycie z własną klasą
    Point p(10, 20);
    std::cout << "Point: " << stringify(p) << std::endl;

    // Bezpośrednie użycie w wyrażeniach
    std::cout << "Wynik: " << stringify(100 + 23) << std::endl;
    std::cout << "Bool: " << stringify(true) << std::endl;

    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
