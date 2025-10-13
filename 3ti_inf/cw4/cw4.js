console.log("cw4.js działa");
//wybieramy element o id result1
const result1 = document.querySelector("#result1");
const result2 = document.querySelector("#result2");
//instrukcja warunkowa if
if (result1 !== null) {
    //jesli if jest prawdziwe to wykonaj:
    alert("Znalazłem element o id result1");
    result1.innerHTML = "to jest teraz w result1";
} else {
    //jesli if jest falszywe to wykonaj:
    alert("Nie znalazłem elementu o id result1");
}
// if bez else
if (result2 !== null) {
    result2.innerHTML = "to jest teraz w result2";
}