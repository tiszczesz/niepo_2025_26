# Informacje o JS

1. JS służy np do przetwarzania drzewa DOM w przeglądarce
2. Pozwala manipulować html, css, i inne
3. JS jest językiem skryptowym (interpretowanym) np w przeglądarce
4. JS to język słabo-typowalny

   a. można łatwo zmienić typ zmiennej

   b. typ jest generowany po zawartości zmiennej

5. Tworzenie zmiennej w JS

```js
//pierwszy sposób
let a = 12; //nie mozna redeklarować ale można zmieniać zawartość
var b = 'ala'; //mozna redeklarować i można zmieniać zawartość stary sposób

const c = 45; //nie mozna redeklarować i nie można zmieniać zawartości
```

6. Typy w JS

- **number**  
   Przykład:

  ```js
  let liczba = 42;
  ```

- **string**  
   Przykład:

  ```js
  let tekst = 'Hello, world!';
  ```

- **boolean**  
   Przykład:

  ```js
  let prawda = true;
  let falsz = false;
  ```

- **undefined**  
   Przykład:

  ```js
  let x;
  // x jest undefined
  ```

- **null**  
   Przykład:

  ```js
  let y = null;
  ```

- **object**  
   Przykład:

  ```js
  let osoba = { imie: 'Jan', wiek: 30 };
  ```

- **array** (specjalny typ obiektu)  
   Przykład:

  ```js
  let tablica = [1, 2, 3];
  ```

- **Function** (też obiekt)  
   Przykład:

  ```js
  function dodaj(a, b) {
    return a + b;
  }
  ```

- **Symbol**  
   Przykład:

  ```js
  let sym = Symbol('id');
  ```

- **BigInt**  
   Przykład:
  ```js
  let duzaLiczba = 123456789012345678901234567890n;
  ```
6. Rodzaje zapisu typu number
### Rodzaje formatu typu number w JS

- **Dziesiętny**  
    Przykład:
    ```js
    let a = 123;
    ```

- **Liczba zmiennoprzecinkowa (float)**  
    Przykład:
    ```js
    let b = 3.14;
    ```

- **Szesnastkowy (hexadecimal)**  
    Przykład:
    ```js
    let c = 0xFF; // 255
    ```

- **Ósemkowy (octal)**  
    Przykład:
    ```js
    let d = 0o77; // 63
    ```

- **Binarny (binary)**  
    Przykład:
    ```js
    let e = 0b1010; // 10
    ```