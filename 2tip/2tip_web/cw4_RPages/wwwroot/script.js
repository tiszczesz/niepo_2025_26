//alert("hhh");
const elem = document.querySelector('#time')
updateTime(elem);
setInterval(() => {
    updateTime(elem);
}, 1000);

function updateTime(elemToUpdate) {
    elemToUpdate.innerText = new Date().toLocaleTimeString();
}