https://chatgpt.com/s/t_6a26e6b090748191a4a67c761c2f37b4
Poniżej znajduje się gotowa zawartość pliku **`php_json.md`** podsumowująca naszą rozmowę.

# PHP i JSON

## Odczyt pliku JSON do tablicy asocjacyjnej

### Plik `dane.json`

```json
{
    "imie": "Jan",
    "nazwisko": "Kowalski",
    "wiek": 30
}
```

### Kod PHP

```php
<?php

$json = file_get_contents('dane.json');
$dane = json_decode($json, true);

print_r($dane);
```

### Wynik

```php
Array
(
    [imie] => Jan
    [nazwisko] => Kowalski
    [wiek] => 30
)
```

---

## Funkcja `json_decode()`

Służy do konwersji danych JSON na struktury danych PHP.

### Składnia

```php
json_decode(
    string $json,
    ?bool $associative = null,
    int $depth = 512,
    int $flags = 0
): mixed
```

### Parametry

| Parametr       | Opis                                                      |
| -------------- | --------------------------------------------------------- |
| `$json`        | Tekst w formacie JSON                                     |
| `$associative` | `true` → tablica asocjacyjna, `false` → obiekt `stdClass` |
| `$depth`       | Maksymalna głębokość zagnieżdżenia                        |
| `$flags`       | Dodatkowe opcje działania                                 |

### Przykład z tablicą asocjacyjną

```php
$json = '{"imie":"Jan","wiek":30}';

$dane = json_decode($json, true);

echo $dane['imie'];
```

Wynik:

```text
Jan
```

### Przykład z obiektem

```php
$json = '{"imie":"Jan","wiek":30}';

$dane = json_decode($json);

echo $dane->imie;
```

Wynik:

```text
Jan
```

---

## Obsługa błędów przy `json_decode()`

### Klasyczna metoda

```php
$dane = json_decode($json, true);

if (json_last_error() !== JSON_ERROR_NONE) {
    echo json_last_error_msg();
}
```

### Z wykorzystaniem wyjątków

```php
try {
    $dane = json_decode(
        $json,
        true,
        512,
        JSON_THROW_ON_ERROR
    );
} catch (JsonException $e) {
    echo $e->getMessage();
}
```

---

# Konwersja tablicy asocjacyjnej PHP do JSON

## Funkcja `json_encode()`

Służy do zamiany tablic i obiektów PHP na JSON.

### Przykład

```php
$dane = [
    'imie' => 'Jan',
    'nazwisko' => 'Kowalski',
    'wiek' => 30
];

$json = json_encode($dane);

echo $json;
```

Wynik:

```json
{"imie":"Jan","nazwisko":"Kowalski","wiek":30}
```

---

## Zapis JSON do pliku

```php
$dane = [
    'imie' => 'Jan',
    'nazwisko' => 'Kowalski',
    'wiek' => 30
];

file_put_contents(
    'dane.json',
    json_encode($dane)
);
```

---

## Czytelne formatowanie JSON

```php
$json = json_encode(
    $dane,
    JSON_PRETTY_PRINT
);
```

Wynik:

```json
{
    "imie": "Jan",
    "nazwisko": "Kowalski",
    "wiek": 30
}
```

---

## Polskie znaki

Domyślnie:

```php
$dane = [
    'miasto' => 'Łódź'
];

echo json_encode($dane);
```

Wynik:

```json
{"miasto":"\u0141\u00f3d\u017a"}
```

Z zachowaniem polskich znaków:

```php
echo json_encode(
    $dane,
    JSON_UNESCAPED_UNICODE
);
```

Wynik:

```json
{"miasto":"Łódź"}
```

---

## Łączenie opcji

```php
$json = json_encode(
    $dane,
    JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE
);
```

---

## Obsługa błędów przy `json_encode()`

### Z wyjątkami

```php
try {
    $json = json_encode(
        $dane,
        JSON_THROW_ON_ERROR
    );
} catch (JsonException $e) {
    echo $e->getMessage();
}
```

### Metoda klasyczna

```php
$json = json_encode($dane);

if (json_last_error() !== JSON_ERROR_NONE) {
    echo json_last_error_msg();
}
```

---

## Tablica wielowymiarowa

```php
$pracownicy = [
    [
        'imie' => 'Jan',
        'stanowisko' => 'Programista'
    ],
    [
        'imie' => 'Anna',
        'stanowisko' => 'Tester'
    ]
];

echo json_encode(
    $pracownicy,
    JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE
);
```

Wynik:

```json
[
    {
        "imie": "Jan",
        "stanowisko": "Programista"
    },
    {
        "imie": "Anna",
        "stanowisko": "Tester"
    }
]
```

---

# Najczęściej używane wzorce

## JSON → PHP

```php
$dane = json_decode(
    file_get_contents('dane.json'),
    true
);
```

## PHP → JSON

```php
file_put_contents(
    'dane.json',
    json_encode(
        $tablica,
        JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE
    )
);
```

## Zalecane podejście z wyjątkami

```php
try {
    $dane = json_decode(
        file_get_contents('dane.json'),
        true,
        512,
        JSON_THROW_ON_ERROR
    );
} catch (JsonException $e) {
    die($e->getMessage());
}
```

Możesz skopiować powyższą zawartość do pliku `php_json.md`.
