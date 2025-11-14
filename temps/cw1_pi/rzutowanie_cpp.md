# Rzutowanie w C++ — przewodnik z przyk³adami

Opisano najwa¿niejsze rodzaje rzutowañ w C++ oraz kiedy ich u¿ywaæ. Przyk³ady s¹ krótkie i praktyczne.

## Ogólna zasada
Rzutowanie zmienia typ wyra¿enia. W C++ warto preferowaæ zdefiniowane, bezpieczniejsze formy: `static_cast`, `dynamic_cast`, `const_cast`, `reinterpret_cast` zamiast tradycyjnego rzutowania C-style `(T)x`.

## 1. Rzutowanie C-style
- Sk³adnia: `(T)expr` lub `T(expr)`.
- Dzia³a dla prawie wszystkiego — ale jest niebezpieczne, bo ³¹czy zachowania `static_cast`, `const_cast` i `reinterpret_cast`.

Przyk³ad:
```cpp
int i = 3;
double d = (double)i; // C-style
```

## 2. `static_cast` (najczêœciej u¿ywane)
- Do konwersji miêdzy typami pokrewnymi (np. liczbowymi) i do jawnego rzutowania wskaŸników w hierarchii klas, gdy konwersja jest bezpieczna (np. upcast lub zatwierdzony downcast jeœli programista jest pewien).
- Nie zmienia kwalifikatorów `const`.

Przyk³ad konwersji numerycznej:
```cpp
int i = 42;
double d = static_cast<double>(i);
```

Przyk³ad rzutowania w hierarchii klas (bezpieczny upcast):
```cpp
struct Base {};
struct Derived : Base {};

Derived* pd = new Derived();
Base* pb = static_cast<Base*>(pd); // OK — upcast
```

## 3. `dynamic_cast` (rzutowanie z kontrol¹ czasu wykonania)
- S³u¿y do rzutowania wskaŸników/referencji w hierarchii klas zawieraj¹cej przynajmniej jedn¹ metodê wirtualn¹ (RTTI).
- Jeœli rzutowanie wskaŸnikowe siê nie powiedzie, zwraca `nullptr`. Dla referencji rzuca `std::bad_cast`.

Przyk³ad:
```cpp
struct Base { virtual ~Base() = default; };
struct Derived : Base { void foo() {} };

Base* pb = new Derived();
Derived* pd = dynamic_cast<Derived*>(pb);
if (pd) {
    pd->foo(); // bezpieczne
}
```

U¿ywaj `dynamic_cast`, gdy nie jesteœ pewien rzeczywistego typu obiektu.

## 4. `const_cast` (usuwanie/dodawanie const)
- S³u¿y tylko do zmiany kwalifikatorów `const`/`volatile`.
- Nie wolno usuwaæ `const` z obiektu, który by³ faktycznie zdefiniowany jako `const` i nastêpnie zmieniaæ go — to niezdefiniowane zachowanie.

Przyk³ad:
```cpp
void f(const int* p) {
    int* q = const_cast<int*>(p);
    // tylko czytanie jest bezpieczne, pisanie mo¿e byæ UB jeœli orygina³ by³ const
}
```

## 5. `reinterpret_cast` (interpretacja bitów)
- Najmniej bezpieczne. Umo¿liwia traktowanie bitów obiektu jako innego typu (np. wskaŸnik na inny typ, konwersja do `uintptr_t`).
- U¿ywaæ tylko gdy naprawdê potrzebujesz niskopoziomowej manipulacji i rozumiesz konsekwencje.

Przyk³ad:
```cpp
#include <cstdint>

int x = 0x12345678;
uintptr_t addr = reinterpret_cast<uintptr_t>(&x);

char* bytes = reinterpret_cast<char*>(&x); // dostêp do bajtów obiektu (uwa¿aj na aliasing)
```

## 6. Wskazówki i dobre praktyki
- Preferuj `static_cast` i `dynamic_cast` nad C-style.
- U¿ywaj `const_cast` tylko wtedy, gdy naprawdê musisz usun¹æ `const` (np. interfejs biblioteki wymagaj¹cy nie-const wskaŸnika), i upewnij siê, ¿e oryginalny obiekt nie by³ const.
- `reinterpret_cast` stosuj oszczêdnie i tylko do niskopoziomowych operacji.
- Dla konwersji numerycznych sprawdzaj zakresy (mo¿e nast¹piæ utrata danych).
- W kodach wielow¹tkowych i systemowych preferuj bezpieczne, jawne konwersje; nie polegaj na rzutowaniach do obejœcia projektowych problemów.

## 7. Przyk³adowe scenariusze
1) Liczby:
```cpp
float f = 3.14f;
int n = static_cast<int>(f); // obciêcie czêœci u³amkowej
```

2) Konwersja wskaŸnika do klasy bazowej:
```cpp
Derived d;
Derived* pd = &d;
Base* pb = static_cast<Base*>(pd); // upcast — zawsze bezpieczny
```

3) Bezpieczny "sprawdŸ i u¿yj" dla downcast:
```cpp
Base* pb = /* mo¿e byæ Derived lub inny */;
if (Derived* pd = dynamic_cast<Derived*>(pb)) {
    // u¿ywaj pd
}
```

4) Operacje niskopoziomowe (z ostro¿noœci¹):
```cpp
int value = 0x01020304;
char* p = reinterpret_cast<char*>(&value);
// odczyt bajtów (endianizm ma znaczenie)
```

---
Podsumowuj¹c: rzutowania w C++ daj¹ kontrolê nad konwersjami typów, ale powinny byæ u¿ywane rozwa¿nie. Preferuj bezpieczniejsze, bardziej jednoznaczne formy (`static_cast`, `dynamic_cast`, `const_cast`, `reinterpret_cast`) zamiast ogólnego rzutowania C-style.
