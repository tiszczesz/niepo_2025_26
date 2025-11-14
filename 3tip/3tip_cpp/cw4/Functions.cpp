#include <cstdlib>

double GenerPi(unsigned int steps) {
	//użycie monte carlo
	unsigned int insideCircle = 0;
	for (size_t i=0;i<steps;i++) {
		double x = static_cast<double>(rand()) / RAND_MAX;
		double y = static_cast<double>(rand()) / RAND_MAX;
	}
	return 3.12;
}