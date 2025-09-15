# Tablice w języku C#

## Co to jest tablica?
Tablica to uporządkowana kolekcja elementów tego samego typu. Tablice pozwalają przechowywać wiele wartości w jednej strukturze danych oraz odwoływać się do nich poprzez indeksy.

## Deklaracja tablicy

```csharp
int[] liczby; // deklaracja tablicy typu int
```

## Tworzenie (inicjalizacja) tablicy

```csharp
liczby = new int[5]; // tworzy tablicę pięcioelementową
```

Można też od razu zadeklarować i zainicjować tablicę:

```csharp
int[] liczby = new int[3] { 1, 2, 3 };
string[] imiona = { "Anna", "Bartek", "Celina" };
```

## Dostęp do elementów tablicy

Indeksy w tablicy zaczynają się od 0.

```csharp
liczby[0] = 10; // przypisanie wartości 10 do pierwszego elementu
int x = liczby[2]; // pobranie trzeciego elementu
```

## Iteracja po tablicy

Najczęściej używamy pętli `for` lub `foreach`:

```csharp
for (int i = 0; i < liczby.Length; i++)
{
    Console.WriteLine(liczby[i]);
}

foreach (int liczba in liczby)
{
    Console.WriteLine(liczba);
}
```

## Typy tablic

- **Jednowymiarowe tablice** — najczęściej używane.
- **Wielowymiarowe tablice** (np. dwuwymiarowe — tablica "macierz"):

```csharp
int[,] macierz = new int[3, 4];
macierz[0, 1] = 5;
```

- **Tablice z tablicami (tablica tablic) — "tablice nieregularne" (jagged arrays)**:

```csharp
int[][] jagged = new int[3][];
jagged[0] = new int[2];
jagged[1] = new int[3];
```

## Właściwości tablic

- `Length` — zwraca liczbę elementów w tablicy.
- Elementy mają domyślne wartości (np. 0 dla typu `int`).

## Przykład użycia

```csharp
string[] zwierzeta = { "Kot", "Pies", "Mysz" };
foreach (string zwierze in zwierzeta)
{
    Console.WriteLine(zwierze);
}
```

## Podsumowanie

Tablica jest podstawowym typem struktury danych w C#, pozwalającym przechowywać wiele wartości tego samego typu. Do obsługi bardziej zaawansowanych kolekcji warto zapoznać się z typami takimi jak `List<T>`.