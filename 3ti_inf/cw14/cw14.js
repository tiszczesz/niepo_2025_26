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
// Tworzenie obiektu za pomocą konstruktora 
// czyli mamy wzorzec do tworzenia obiektów tego samego typu
function Book(title, price, dateRealized) {
    this.title = title;
    this.price = price;
    this.dateRealized = dateRealized;
}
const book3 = new Book('1984', 9.99, '1949-06-08');
const book4 = new Book('Ala ma kota', 119.99, '1999-06-08');
console.log(book3);
console.log(book4);
document.querySelector("#result2")
    .textContent = `Tytuł: ${book3.title}, Cena: ${book3.price} zł,
           Data realizacji: ${book3.dateRealized}`;