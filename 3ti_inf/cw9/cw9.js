document.querySelector('#alert-button').onclick = function () {
    alert('Button clicked!');
}
document.querySelector('#confirm-button').onclick = function () {
    const result = confirm('Będziesz się uczył programowania?');
    console.log(result);
    if (result) {
        document.querySelector('#result-confirm').innerHTML
            = 'Użytkownik będzie się uczył programowania';
    } else {
        document.querySelector('#result-confirm').innerHTML
            = 'Użytkownik leje na programowanie i pożałuje!';
    }
}
document.querySelector('#prompt-button').onclick = function () {
    const name = prompt('Jak masz na imię?');
    console.log(name);
    if(name && name.trim() !== '') {  //czy nie null i czy nie pusty string
        document.querySelector('#result-prompt').innerHTML = `Cześć, ${name.trim()}!`;
    } else { //jeśli null lub pusty string
        document.querySelector('#result-prompt').innerHTML = 'Cześć, nieznajomy!';
    }
}