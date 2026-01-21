const clients = ["Client A", "Client B", "Client C",
    "Client D", "Client E", "Client F", "Client G", "Client H", "Client I",
    "Client J"];
function generAllClients(clients, elem) {
    for (let i = 0; i < clients.length; i++) {
        const div = document.createElement("div");
        div.className = "item";
        div.textContent = clients[i];
        elem.appendChild(div);
    }
}

generAllClients(clients, document.querySelector("#p1"));