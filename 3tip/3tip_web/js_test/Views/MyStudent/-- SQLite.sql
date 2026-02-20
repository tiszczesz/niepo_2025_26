-- SQLite
CREATE TABLE "Student" (
    "Id"	INTEGER NOT NULL PRIMARY KEY,
    "FirstName"	TEXT NOT NULL,
    "LastName"	TEXT NOT NULL,
    "Age"	INTEGER NOT NULL    
);
INSERT INTO Student (FirstName, LastName, Age) VALUES
('Jan', 'Kowalski', 20),
('Maria', 'Nowak', 21),
('Piotr', 'Lewandowski', 19),
('Anna', 'Wojcik', 22),
('Tomasz', 'Kaminski', 20),
('Katarzyna', 'Sokolowska', 21),
('Jakub', 'Wisniewski', 19),
('Ewa', 'Dabrowski', 23),
('Marcin', 'Zielinski', 20),
('Agnieszka', 'Kucharski', 22);