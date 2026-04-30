const images = [
    "images/jedzenie1.png",
    "images/jedzenie2.png",
    "images/jedzenie3.png",
    "images/jedzenie4.png",
    "images/jedzenie5.png",
    "images/jedzenie6.png",
    "images/jedzenie7.png",
    "images/jedzenie8.png"
];
let current = 0;
let interval;
document.querySelector("input[type='checkbox']").onclick = function (e) {
    console.log(e.target);
    const btns = document.querySelectorAll(".slider button");
    if (e.target.checked) {
        for (let btn of btns) {
            btn.style.visibility = "hidden";
        }
        interval = autoSlide();
    } else {
        for (let btn of btns) {
            btn.style.visibility = "visible";
        }
        if (interval) {
            clearInterval(interval);
        }
    }
}
document.querySelector("#lt").onclick = function () {
    current--;
    current = current < 0 ? images.length - 1 : current;
    document.querySelector(".slider img").src = images[current % images.length];
    console.log(images[current % images.length]);
}
document.querySelector("#gt").onclick = function () {
    current++;
    document.querySelector(".slider img").src = images[current % images.length];
    console.log(images[current % images.length]);
}
function autoSlide() {
    const interval = setInterval(() => {
        let random = Math.floor(Math.random() * images.length);
        current = random;
        document.querySelector(".slider img").src = images[current];
        console.log(images[current]);
    }, 5000);
    return interval;
}