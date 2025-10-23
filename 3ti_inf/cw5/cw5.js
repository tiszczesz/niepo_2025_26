

//inny sposob definicji funkcji działa jak zmienna
//mozna jej uzyc dopiero po zdefiniowaniu!!!!!
const showDate = function () {
    console.log(new Date());
};

showDate(); //wywołanie funkcji ale dopiero po zdefiniowaniu

//definicja funkcji strzałkowej
const showTime = (text) => {
    console.log(text + " " + new Date().toLocaleTimeString());
};
showTime("aktualna godzina to: "); //wywołanie funkcji strzałkowej
//wywołanie funkcji
//szukamy elementu o id result1
const result1Element = document.querySelector("#result1");
const result2Element = document.querySelector("#result2");
if (result1Element !== null) {
    InsertText(result1Element, "lightblue", "ala ma kota"); //użycie funkcji
}
if (result2Element !== null) {
    InsertText(result2Element, "green", "to jest inny tekst"); //użycie funkcji
}

//definicja funkcji
function InsertText(elem, color, text) {
    //ciało funkcji
    elem.style.backgroundColor = color; //ustawienie koloru tła
    elem.innerText = text;//ustawienie tekstu wewnątrz elementu bez znaczników HTML!!!
}
function GenerSelect() {
    let html = '<select>';
    for (let i = 1; i <= 10; i++) {

    }
}