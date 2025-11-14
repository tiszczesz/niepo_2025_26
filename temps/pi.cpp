#include <iostream>
#include <cstdlib>   // rand, srand, strtoull
#include <ctime>     // time
#include <cmath>     // sqrt
#include <iomanip>   // setprecision
#include <cstdint>

// Estymacja pi metodą Monte Carlo używając tylko rand() i srand().
// Zwraca parę: <pi_estimate, standard_error>
std::pair<double,double> estimate_pi(std::uint64_t N) {
    if (N == 0) return {0.0, 0.0};

    std::uint64_t inside = 0;
    for (std::uint64_t i = 0; i < N; ++i) {
        // rand() zwraca wartość w [0, RAND_MAX], normalizujemy do [0,1)
        double x = rand() / (RAND_MAX + 1.0);
        double y = rand() / (RAND_MAX + 1.0);
        if (x * x + y * y <= 1.0) ++inside;
    }

    double p = static_cast<double>(inside) / static_cast<double>(N);
    double pi_est = 4.0 * p;
    double se = 4.0 * std::sqrt(p * (1.0 - p) / static_cast<double>(N));
    return {pi_est, se};
}

int main() {
    std::cout << "Estymacja liczby PI metoda Monte Carlo (uzywajac tylko rand/srand)\n";
    std::cout << "Podaj liczbe prob N (np. 1000000): ";
    unsigned long long N_input = 0;
    if (!(std::cin >> N_input) || N_input == 0) {
        std::cerr << "Nieprawidlowy parametr N. Podaj N > 0.\n";
        return 1;
    }

    std::cout << "Podaj seed (0 - losowy seed oparty na czasie): ";
    unsigned long long seed_input = 0;
    if (!(std::cin >> seed_input)) {
        std::cerr << "Nieprawidlowy seed.\n";
        return 1;
    }

    // Inicjalizacja generatora tylko przez srand (cast do unsigned)
    if (seed_input == 0) {
        srand(static_cast<unsigned>(time(nullptr)));
    } else {
        srand(static_cast<unsigned>(seed_input));
    }

    auto [pi_est, se] = estimate_pi(static_cast<std::uint64_t>(N_input));

    std::cout << std::fixed << std::setprecision(10);
    std::cout << "N = " << N_input << "\n";
    std::cout << "pi ≈ " << pi_est << "\n";
    std::cout << "szacowany blad standardowy ≈ " << se << "\n";
    std::cout << "Uwaga: program uzywa funkcji rand() o ograniczonej dlugosci okresu.\n";

    return 0;
}
