const book1 = {
    title: 'The Great Gatsby',
    price: 10.99,
    dateRealized: '1925-04-10',
}
const book2 = {
    title: 'To Kill a Mockingbird',
    price: 8.99,
    dateRealizd: '1960-07-11', // Błąd w nazwie właściwości
}
console.log(book1);
console.log(book2);

document.querySelector("#result1")
    .textContent = `Tytuł: ${book1.title}, Cena: ${book1.price} zł,
           Data realizacji: ${book1.dateRealized}`;

function Book(title, price, dateRealized) {
    this.title = title;
    this.price = price;
    this.dateRealized = dateRealized;
}