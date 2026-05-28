document.querySelector("#input").addEventListener("input", function () {
    console.log(`input: ${this.value}`);
});
document.querySelector("#input").addEventListener("change", function () {
    console.log(`change: ${this.value}`);
});
const cities = ["Warszawa", "Kraków", "Łódź", "Wrocław",
    "Poznań", "Gdańsk", "Szczecin", "Bydgoszcz", "Lublin", "Białystok",
    "Katowice", "Gdynia", "Częstochowa", "Radom", "Sosnowiec"];