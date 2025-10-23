import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import { books,getMaxBookId, type Book } from './data/books';
import { useState } from 'react';


function App() {
  const [selectedBook, setSelectedBook] = useState<Book | null>(null);
  const [allBooks, setAllBooks] = useState<Book[]>(books);



  function handleClick(book: Book): void {
    console.log(book.title);
    setSelectedBook(book);
  }

  function addBookhandler(): void {
    const newBookId = getMaxBookId(allBooks) + 1;
    const newBook: Book = {
      id: newBookId,
      title: `Nowa książka ${newBookId}`,
      author: `Autor ${newBookId}`,
      publishedYear: 2023
    };
    setAllBooks([...allBooks, newBook]);//nowa tablica z dodaną książką
  }

  function deleteBookHandler(id: number): void {
    console.log(`usuwanie książki ${id}`);
    setAllBooks(allBooks.filter(book => book.id !== id));
  }

  return (
    <div className='container'>
      <h3>Lista książek</h3>
      <section className='d-flex justify-content-between align-items-center mb-3'>
        Liczba książek: {allBooks.length}
        <button onClick={()=>addBookhandler()} className='btn btn-secondary'>Dodaj książkę</button>
      </section>
      <section className='d-flex gap-2 flex-wrap'>
        {allBooks.map((book) => (
          <div className="card" key={book.id} style={{ cursor: "pointer" }} onClick={() => handleClick(book)}>
            <div className="card-body">
              <div className="card-title" style={{ fontWeight: 'bold', textDecoration: 'underline' }}>
                {book.title}
              </div>
              <div className="card-text">autor: {book.author}</div>
              <div className="card-text">Rok wydania: {book.publishedYear}</div>
            </div>
            <div className="card-footer">
              <button onClick={()=>deleteBookHandler(book.id)} className='btn btn-danger'>Usuń książkę</button>
            </div>
          </div>
        )
        )}
      </section>
      <hr />
      {selectedBook && <section>Tytuł: {selectedBook?.title} autor: {selectedBook?.author}</section>}
    </div>
  )
}

export default App
