export const colors: string[] = [
    "white",
    "red",
    "green",
    "blue",
    "yellow",
];
export function generSelect(items: string[]): HTMLSelectElement {
    const select = document.createElement("select");
    for (const item of items) {
        const option = document.createElement("option");
        option.value = item;
        option.innerText = item;
        select.appendChild(option);
        select.style.width = "250px";
    }
    select.id = "colorSelect";
    return select;
}
