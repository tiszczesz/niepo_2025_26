const scene1 = document.querySelector('#scene1');
const scene2 = document.querySelector('#scene2');

scene1.onmouseover = function () {
    scene1.textContent = "Wskaźnik myszy jest nad elementem";
    scene1.style.color = 'red';
}
scene1.onmouseout = function () {
    scene1.textContent = "Wskaźnik myszy jest poza elementem";
    scene1.style.color = 'black';
}
scene2.onmouseover = function () {
    console.log("nad elementem");
    scene2.style.opacity = '1'

}
scene2.onmouseout = function () {

    console.log('poza elementem');
    scene2.style.opacity = '0'
}