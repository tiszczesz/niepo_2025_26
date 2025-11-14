# Metoda Monte Carlo do wyznaczania liczby PI — krok po kroku (C++)

Ten dokument opisuje krok po kroku prostą implementację metody Monte Carlo do oszacowania liczby π oraz zawiera kompletny przykładowy kod w C++.

## Idea (intuicja)
Bierzemy kwadrat jednostkowy [0,1]×[0,1] oraz ćwiartkę okręgu jednostkowego o środku w (0,0) i promieniu 1 (czyli część okręgu znajdującą się w pierwszej ćwiartce). Pole kwadratu = 1. Pole ćwiartki okręgu = π/4. Losując punkty równomiernie w kwadracie, stosunek punktów trafionych wewnątrz ćwiartki do wszystkich punktów zbliża się do π/4. Stąd estymator π:

π ≈ 4 * (liczba_punktów_wewnątrz) / (liczba_punktów_całkowita)

## Matematyczne oszacowanie niepewności
Jeśli p = (liczba_punktów_wewnątrz) / N jest estymatorem prawdopodobieństwa trafienia w ćwiartkę, to wariancja p ≈ p(1−p)/N. Dla π mamy:
SE(π) ≈ 4 * sqrt( p(1−p) / N )

Dla dużego N błąd maleje jak O(1/√N).

## Algorytm krok po kroku
1. Wybrać liczbę prób N (np. 1e6).
2. Zainicjalizować generator liczb pseudolosowych.
3. Dla i = 1..N:
   - Wylosować x ∈ [0,1), y ∈ [0,1).
   - Jeżeli x*x + y*y <= 1, zwiększyć licznik `inside`.
4. Po zakończeniu obliczyć π_est = 4.0 * inside / N.
5. Obliczyć przybliżony błąd standardowy SE(π) = 4.0 * sqrt(p*(1−p)/N), gdzie p = inside/N.
6. Zwrócić/wyświetlić wynik.

## Przykładowa implementacja w C++
Poniższy kod to kompletna, prosta i bezpieczna implementacja w C++17 korzystająca z std::mt19937_64 oraz std::uniform_real_distribution. Program przyjmuje opcjonalnie dwa argumenty:
- N — liczba rzutów (domyślnie 1000000)
- seed — (opcjonalny) całkowity seed; jeżeli nie podany, użyty zostanie seed oparty na zegarze.

```cpp
// pi_estimate.cpp
#include <iostream>
#include <random>
#include <chrono>
#include <iomanip>
#include <cstdint>
#include <cstdlib>
#include <cmath>

int main(int argc, char** argv) {
    // Domyślna liczba prób
    std::uint64_t N = 1000000ULL;
    // Seed: jeśli 0 -> losowy seed na podstawie zegara
    std::uint64_t seed = 0;

    if (argc >= 2) {
        N = std::strtoull(argv[1], nullptr, 10);
        if (N == 0) {
            std::cerr << "Nieprawidłowa liczba prób. Użyj N > 0.\n";
            return 1;
        }
    }
    if (argc >= 3) {
        seed = std::strtoull(argv[2], nullptr, 10);
    }

    // Inicjalizacja generatora
    if (seed == 0) {
        seed = static_cast<std::uint64_t>(
            std::chrono::high_resolution_clock::now().time_since_epoch().count()
        );
    }
    std::mt19937_64 rng(seed);
    std::uniform_real_distribution<double> dist(0.0, 1.0);

    std::uint64_t inside = 0;
    for (std::uint64_t i = 0; i < N; ++i) {
        double x = dist(rng);
        double y = dist(rng);
        if (x * x + y * y <= 1.0) ++inside;
    }

    double p = static_cast<double>(inside) / static_cast<double>(N);
    double pi_est = 4.0 * p;
    double se = 4.0 * std::sqrt(p * (1.0 - p) / static_cast<double>(N));

    std::cout << std::fixed << std::setprecision(10);
    std::cout << "N = " << N << "\n";
    std::cout << "inside = " << inside << "\n";
    std::cout << "pi ≈ " << pi_est << "\n";
    std::cout << "szacowany błąd standardowy ≈ " << se << "\n";
    std::cout << "użyty seed = " << seed << "\n";

    return 0;
}
```

## Kompilacja i uruchomienie
- Kompilacja (g++):
  g++ -std=c++17 -O2 pi_estimate.cpp -o pi_estimate
- Przykładowe uruchomienie (1 milion prób):
  ./pi_estimate 1000000
- Z podanym seedem:
  ./pi_estimate 1000000 12345

## Przykładowy wynik
Dla N = 1 000 000 możesz zobaczyć coś w stylu:
- N = 1000000
- inside = 785398
- pi ≈ 3.1415920
- szacowany błąd standardowy ≈ 0.0010
(wartości losowe — wynik będzie się różnić przy każdym uruchomieniu jeśli seed = 0)

## Ulepszenia i warianty
- Zwiększyć N, aby zmniejszyć błąd (błąd ~ 1/√N).
- Użyć równoległego generowania losowych punktów (OpenMP, wielowątkowość) — trzeba ostrożnie łączyć countery lub użyć niezależnych RNG na wątek.
- Zamiast prostego RNG można użyć generatorów sprzętowych lub kryptograficznych, ale nie ma to wielkiego wpływu na szybkość zbieżności.
- Zastosować techniki zmniejszania wariancji (np. stratified sampling) by przyspieszyć konwergencję.

## Komentarz praktyczny
Metoda Monte Carlo jest prosta i pouczająca, ale ma powolną konwergencję względem deterministycznych metod (np. rozwinięcia szeregów). Przydatna jest jednak jako przykład symulacji i do problemów, gdzie inne metody są trudne do zastosowania.


