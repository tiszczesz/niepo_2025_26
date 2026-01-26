-- SQLite
CREATE TABLE Students (
    id INTEGER PRIMARY KEY,
    firstname TEXT NOT NULL,
    lastname TEXT NOT NULL,
    enrollment_date DATE NOT NULL
);

INSERT INTO Students (firstname, lastname, enrollment_date) VALUES
('Jan', 'Kowalski', '2023-09-01'),
('Maria', 'Nowak', '2023-09-01'),
('Piotr', 'Lewandowski', '2023-09-02'),
('Anna', 'Wójcik', '2023-09-02'),
('Krzysztof', 'Kaminski', '2023-09-03'),
('Ewa', 'Zielinska', '2023-09-03'),
('Tomasz', 'Szymanski', '2023-09-04'),
('Magdalena', 'Wojcik', '2023-09-04'),
('Jakub', 'Dabrowski', '2023-09-05'),
('Katarzyna', 'Michalska', '2023-09-05');
