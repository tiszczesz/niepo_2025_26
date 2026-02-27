# Szablony klas w C++ — przykłady

## 1) Co to jest szablon klasy?
**Szablon klasy** pozwala zdefiniować klasę „parametryzowaną typem” (albo wartością). Kompilator tworzy konkretną wersję klasy dopiero wtedy, gdy użyjesz jej z konkretnym typem/parametrem.

---

## 2) Najprostszy szablon klasy (1 parametr typu)

```cpp
#include <iostream>

template <typename T>
class Box {
    T value;

public:
    Box(const T& v) : value(v) {}

    const T& get() const { return value; }
    void set(const T& v) { value = v; }
};

int main() {
    Box<int> bi(10);
    Box<std::string> bs("hello");

    std::cout << bi.get() << "\n";
    std::cout << bs.get() << "\n";
}
```

**Uwaga:** `typename` i `class` w `template <...>` są tu równoważne:
- `template <class T>` działa tak samo jak `template <typename T>`.

---

## 3) Szablon klasy z kilkoma parametrami typu

```cpp
#include <iostream>
#include <string>

template <typename K, typename V>
class Pair {
public:
    K first;
    V second;

    Pair(const K& f, const V& s) : first(f), second(s) {}
};

int main() {
    Pair<int, std::string> p(1, "jeden");
    std::cout << p.first << " -> " << p.second << "\n";
}
```

---

## 4) Metody szablonu klasy zdefiniowane poza klasą

```cpp
#include <iostream>

template <typename T>
class Counter {
    T value;

public:
    Counter(T start);
    void inc();
    T get() const;
};

template <typename T>
Counter<T>::Counter(T start) : value(start) {}

template <typename T>
void Counter<T>::inc() {
    ++value;
}

template <typename T>
T Counter<T>::get() const {
    return value;
}

int main() {
    Counter<int> c(5);
    c.inc();
    std::cout << c.get() << "\n";
}
```

---

## 5) Specjalizacja pełna (pełne dopasowanie typu)

Czasem chcesz **inne zachowanie dla konkretnego typu**, np. `bool`.

```cpp
#include <iostream>

template <typename T>
class Printer {
public:
    static void print(const T& x) {
        std::cout << x << "\n";
    }
};

// Specjalizacja pełna dla bool:
template <>
class Printer<bool> {
public:
    static void print(const bool& x) {
        std::cout << (x ? "true" : "false") << "\n";
    }
};

int main() {
    Printer<int>::print(123);
    Printer<bool>::print(true);
}
```

---

## 6) Specjalizacja częściowa (częściowe dopasowanie)

Przykład: ogólna wersja dla `T`, ale osobna dla wskaźników `T*`.

```cpp
#include <iostream>

template <typename T>
class TypeInfo {
public:
    static void show() { std::cout << "Zwykly typ\n"; }
};

template <typename T>
class TypeInfo<T*> { // specjalizacja częściowa dla wskaźników
public:
    static void show() { std::cout << "Wskaznik\n"; }
};

int main() {
    TypeInfo<int>::show();
    TypeInfo<int*>::show();
}
```

---

## 7) Parametry nietypowe (NTTP) — szablon z wartością, np. rozmiarem

Tu parametr to nie typ, tylko stała znana w czasie kompilacji (np. `int N`).

```cpp
#include <iostream>

template <typename T, int N>
class StaticArray {
    T data[N];

public:
    T& operator[](int i) { return data[i]; }
    const T& operator[](int i) const { return data[i]; }

    int size() const { return N; }
};

int main() {
    StaticArray<int, 5> a;
    a[0] = 42;
    std::cout << "a[0] = " << a[0] << ", size = " << a.size() << "\n";
}
```

---

## 8) Domyślne argumenty szablonu

```cpp
#include <iostream>
#include <string>

template <typename T = int>
class DefaultBox {
    T value;
public:
    DefaultBox(T v) : value(v) {}
    T get() const { return value; }
};

int main() {
    DefaultBox<> a(10);              // T = int (domyślnie)
    DefaultBox<std::string> b("ok"); // T = std::string
    std::cout << a.get() << "\n";
    std::cout << b.get() << "\n";
}
```

---

## 9) Szablony klas w praktyce: prosty "stos" oparty o std::vector

```cpp
#include <vector>
#include <stdexcept>
#include <iostream>

template <typename T>
class Stack {
    std::vector<T> v;

public:
    void push(const T& x) { v.push_back(x); }

    void pop() {
        if (v.empty()) throw std::runtime_error("Stack is empty");
        v.pop_back();
    }

    T& top() {
        if (v.empty()) throw std::runtime_error("Stack is empty");
        return v.back();
    }

    bool empty() const { return v.empty(); }
    std::size_t size() const { return v.size(); }
};

int main() {
    Stack<int> s;
    s.push(1);
    s.push(2);
    std::cout << s.top() << "\n"; // 2
    s.pop();
    std::cout << s.top() << "\n"; // 1
}
```

---

## 10) Najczęstsze uwagi i błędy
1. **Definicje metod szablonów** zwykle muszą być w tym samym pliku co deklaracja (np. w nagłówku `.hpp`), bo kompilator generuje kod dopiero przy użyciu szablonu.
2. Specjalizacje muszą być widoczne w miejscu użycia.
3. Jeśli masz błąd typu „undefined reference” przy szablonach, to często oznacza, że definicje są w `.cpp` i nie są dostępne przy instancjowaniu.

---

## 11) Ćwiczenia (krótkie)
1. Zrób szablon `MinMax<T>` trzymający dwie wartości i mający metody `min()` i `max()`.
2. Zrób specjalizację `Printer<std::string>` drukującą napis w cudzysłowie.
3. Zrób `StaticArray<double, 3>` i policz sumę elementów.