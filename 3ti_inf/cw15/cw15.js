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
document.querySelector("input[type='checkbox']").onclick = function (e) {
    console.log(e.target);
    const btns = document.querySelectorAll(".slider button");
    if (e.target.checked) {
        for (let btn of btns) {
            btn.style.visibility = "hidden";
        }
    } else {
        for (let btn of btns) {
            btn.style.visibility = "visible";
        }
    }
}
document.querySelector("#lt").onclick = function () {}
document.querySelector("#gt").onclick = function () {}