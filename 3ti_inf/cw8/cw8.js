const colors = [ //tworzenie tablicy z kolorami
    "white",
    "black",
    "red",
    "blue",
    "green",
    "yellow",
    "purple",
    "gray",
    "pink",
    "orange"
]
//funkcja generująca select z opcjami kolorów
function generateColorSelect(elem) {
    let html = '<select id="colorSelect">'; //tworzenie elementu select z id colorSelect
    //iteracja po tablicy colors w celu wygenerowania wszystkich opcji
    for (let i = 0; i < colors.length; i++) {
        html += '<option value="' + colors[i] + '">' //<option value="red">
            + colors[i] + '</option>'; //dodanie opcji do selecta
    }
    html += '</select>'; //zamknięcie elementu select
    elem.innerHTML = html; //wstawienie wygenerowanego selecta do elementu przekazanego
    // jako argument
}
function changeBackgroundColor() {
    const select = document.querySelector('#colorSelect'); //pobranie elementu select
    const selectedColor = select.value; //pobranie wybranego koloru
    document.body.style.backgroundColor = selectedColor; //zmiana koloru tła strony
}
document.querySelector('#font-size-select').onchange = function () {
    console.log('zmiana rozmiaru czcionki'); //logowanie zmiany rozmiaru czcionki

    const fontSize = this.value; //pobranie wybranego rozmiaru czcionki
    console.log(fontSize);
    // debugger;
    document.querySelector('#toChangeSize').style.fontSize = fontSize; //zmiana rozmiaru czcionki
}
//za funkcja
const first = document.querySelector('#first'); //pobranie elementu o id first
generateColorSelect(first); //wywołanie funkcji generującej select z kolorami 
// i wstawienie go do elementu first
const select = document.querySelector('#colorSelect');
select.onchange = changeBackgroundColor; //ustawienie obsługi zdarzenia onchange