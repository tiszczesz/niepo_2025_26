const clients = ["Client A", "Client B", "Client C",
    "Client D", "Client E", "Client F", "Client G", "Client H", "Client I",
    "Client J", " Client K", "Client L", "Client M", "Client N"];
function generAllClients(clients, elem) {
    for (let i = 0; i < clients.length; i++) {
        const div = document.createElement("div");
        div.className = "item";
        div.textContent = clients[i];
        div.id = clients[i].toLowerCase().replace(" ", "-");
        elem.appendChild(div);
    }
}

generAllClients(clients, document.querySelector("#p1"));