document.querySelector('#first').onclick = function () {
    document.querySelector('#first').classList.toggle('border');
};
document.querySelector('#second').onclick = function (event) {
    event.target.classList.add('red');
};
document.querySelector('#third').onclick = function (event) {
    event.target.classList.remove('red');
    event.target.classList.add('underline');
};