const contacts = [
    {
        id: 1,
        name: "Alice Johnson",
        email: "alice.johnson@example.com"
    },
    {
        id: 2,
        name: "Bob Smith",
        email: "bob.smith@example.com"
    },
    {
        id: 3,
        name: "Charlie Brown",
        email: "charlie.brown@example.com"
    },
    {
        id: 4,
        name: "David Wilson",
        email: "david.wilson@example.com"
    },
];
const left = document.querySelector('#left');
const table = document.createElement('table');
const thead = table.appendChild(document.createElement('thead'));
const headerRow = document.createElement('tr');
headerRow.innerHTML = `<th>Lp.</th>
                      <th>Nazwa</th>
                      <th>Email</th>`;
thead.appendChild(headerRow);
const tbody = table.appendChild(document.createElement('tbody'));
for(let i=0; i<contacts.length;i++){
    const row = document.createElement('tr');
    row.innerHTML = `<td>${i+1}</td>
                        <td>${contacts[i].name}</td>
                        <td>${contacts[i].email}</td>`;
    tbody.appendChild(row);
}
left.appendChild(table);