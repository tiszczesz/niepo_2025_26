//wyszukanie elementów przycisku i pola tekstowego
const btnCreate = document.querySelector("#btnCreate");
const input = document.querySelector("#inputText");
const result = document.querySelector("#result");
const btnReverse = document.querySelector("#btnReverse");
const btnAdd = document.querySelector("#btnAdd");
let isArrayCreated = false;
btnCreate.onclick = function () {
    //pobranie wartości z pola tekstowego 
    // i konwersja na liczbę całkowitą lub NaN
    const size = parseInt(input.value);
    //sprawdzamy czy wartość jest liczbą całkowitą
    if (isNaN(size)) return;
    //tworzymy tablicę i wypelniamy ją losowymi liczbami
    const numbers = []; //pusta tablica
    for (let i = 0; i < size; i++) {
        numbers.push(Math.floor(Math.random() * 100));//[0-99]
    }
    console.log(numbers);
    //wyświetlenie wyniku na stronie
    result.innerHTML = "Wylosowano liczby: " + numbers.join(" ");
    isArrayCreated = true;
    buttonsActive();
};
buttonsActive();
function buttonsActive(){
    //aktywacja przycisków dopiero po utworzeniu tablicy
    btnReverse.disabled = !isArrayCreated;
    btnAdd.disabled = !isArrayCreated;
}