const clients = ["Client A", "Client B", "Client C",
    "Client D", "Client E", "Client F", "Client G", "Client H", "Client I",
    "Client J", "Client K", "Client L", "Client M", "Client N"];
const clientsSelected = [];
function generAllClients(clients, elem) {
    sortArrays();
    elem.innerHTML = "";
    for (let i = 0; i < clients.length; i++) {
        const div = document.createElement("div");
        div.className = "item";
        div.textContent = clients[i];
        div.id = clients[i].toLowerCase().replace(" ", "-");
        div.onclick = function (event) {
            // alert("You clicked on " + clients[i]);
            //dodaje do tablicy clientsSelected 
            clientsSelected.push(clients[i]);
            //usuwa z tablicy clients
            clients.splice(i, 1);
            //odswieza obie listy
            generSelectedClients(clientsSelected, document.querySelector("#p2"));
            generAllClients(clients, document.querySelector("#p1"));
            console.log(clientsSelected);
            console.log(clients);
        };
        elem.appendChild(div);
    }
}
function generSelectedClients(selectedClients, elem) {
    sortArrays();
    elem.innerHTML = "";
    for (let i = 0; i < selectedClients.length; i++) {
        const div = document.createElement("div");
        div.className = "item";
        div.textContent = selectedClients[i];
        div.id = selectedClients[i].toLowerCase().replace(" ", "-");
        div.onclick = function (event) {
            // alert("You clicked on " + clients[i])
            //dodaje do tablicy clientsSelected 
            clients.push(selectedClients[i]);
            //usuwa z tablicy clients
            selectedClients.splice(i, 1);
            //odswieza obie listy
            generSelectedClients(selectedClients, document.querySelector("#p2"));
            generAllClients(clients, document.querySelector("#p1"));

        };
        elem.appendChild(div);
    }
}

generAllClients(clients, document.querySelector("#p1"));
generAllClients(clientsSelected, document.querySelector("#p2"));
function sortArrays() {
    if (clients.length !== 0) {
        clients.sort();
    }
    if (clientsSelected.length !== 0) {
        clientsSelected.sort();
    }
}

