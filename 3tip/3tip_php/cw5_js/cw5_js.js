document.querySelector("#input").addEventListener("input", function () {
    console.log(`input: ${this.value}`);
});
document.querySelector("#input").addEventListener("change", function () {
    console.log(`change: ${this.value}`);
});
const cities = ["Warszawa", "Kraków", "Łódź", "Wrocław",
    "Poznań", "Gdańsk", "Szczecin", "Bydgoszcz", "Lublin", "Białystok",
    "Katowice", "Gdynia", "Częstochowa", "Radom", "Sosnowiec"];
function RenderCities() {
    const list = document.querySelector("#cities");
    list.innerHTML = "";
    cities.forEach(city => {
        const li = document.createElement("li");
        li.textContent = city;
        list.appendChild(li);
    });
}
RenderCities();