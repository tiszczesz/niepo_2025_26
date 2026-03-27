-- SQLite
CREATE TABLE games(
    id INTEGER  PRIMARY KEY,
    title TEXT NOT NULL,
    description TEXT NOT NULL,
    price REAL NOT NULL,
    release_date TEXT NOT NULL
);
INSERT INTO games (title, description, price, release_date) VALUES
('The Legend of Zelda', 'Epic adventure game', 59.99, '2023-05-12'),
('Elden Ring', 'Dark fantasy action RPG', 59.99, '2022-02-25'),
('Cyberpunk 2077', 'Futuristic sci-fi RPG', 49.99, '2020-12-10'),
('Hogwarts Legacy', 'Magical wizarding adventure', 69.99, '2023-02-10'),
('Baldurs Gate 3', 'Fantasy turn-based RPG', 59.99, '2023-08-03'),
('Starfield', 'Space exploration game', 69.99, '2023-09-06'),
('Tekken 8', 'Fighting game', 69.99, '2024-01-26'),
('Final Fantasy XVI', 'Fantasy action RPG', 69.99, '2023-06-22'),
('Street Fighter 6', 'Fighting game', 59.99, '2023-06-02'),
('Palworld', 'Creature collecting adventure', 29.99, '2024-01-19');
