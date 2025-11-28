#include <cmath>
#include <cstdlib>

double GenerPi(unsigned steps) {
	//uzycie monte carlo do wyznaczenia liczby pi
	double inside = 0.0;
	for (unsigned i = 0; i < steps; ++i) {
		double x = static_cast<double>(rand()) / RAND_MAX;
		double y = static_cast<double>(rand()) / RAND_MAX;
		if (sqrt(x * x + y * y) <= 1.0) {
			inside += 1.0;
		}
	}
	return (inside / steps) * 4.0;
}
