//definicja funkcji
function Result1(elem, color, text) {
    //ciało funkcji
    elem.style.backgroundColor = color; //ustawienie koloru tła
    elem.innerText = text;//ustawienie tekstu wewnątrz elementu bez znaczników HTML!!!
}

//wywołanie funkcji
//szukamy elementu o id result1
const result1Element = document.querySelector("#result1");
if (result1Element !== null) {
    Result1(result1Element, "lightblue", "ala ma kota"); //użycie funkcji
}