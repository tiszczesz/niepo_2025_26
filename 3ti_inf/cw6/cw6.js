const btn1 = document.querySelector('#showDate');
const dateSpan = document.querySelector('.row span');
//przypisanie funkcji do zdarzenia onclick dla przycisku btn1
btn1.onclick = function(){
    const now = new Date(); //pobranie aktualnej daty i godziny
    dateSpan.innerText = now.toLocaleDateString(); //ustawienie tekstu wewnątrz elementu span na aktualną datę i godzinę
};