// Pobiera wszystkie wiersze z tabeli i zwraca je jako tablicę.
// Jeśli tabela ma nagłówki (<th>), zwróci tablicę obiektów {kolumna: wartość}.
// W przeciwnym razie zwróci tablicę tablic z wartościami komórek.
function getTableRows(selector) {
    const table = document.querySelector(selector);
    if (!table) return [];

    const headerCells = table.querySelectorAll("thead tr th, tr th");
    const headers = Array.from(headerCells).map(th => th.textContent.trim());

    const rows = Array.from(table.querySelectorAll("tbody tr")).length
        ? Array.from(table.querySelectorAll("tbody tr"))
        : Array.from(table.querySelectorAll("tr")).filter(tr => !tr.querySelector("th"));

    if (headers.length > 0) {
        // Zwracaj obiekty z kluczami wg nagłówków
        return rows.map(tr => {
            const cells = Array.from(tr.querySelectorAll("td"));
            const obj = {};
            headers.forEach((h, i) => {
                obj[h || `col${i + 1}`] = (cells[i]?.textContent || "").trim();
            });
            return obj;
        });
    } else {
        // Zwracaj zwykłe tablice wartości komórek
        return rows.map(tr => Array.from(tr.querySelectorAll("td")).map(td => td.textContent.trim()));
    }
}

// Przykład użycia:
 const data = getTableRows("#mojaTabela");
 console.log(data);