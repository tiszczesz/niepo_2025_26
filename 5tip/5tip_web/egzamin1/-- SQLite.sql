-- SQLite
CREATE TABLE Users (
    UserID INTEGER PRIMARY KEY,
    UserName TEXT NOT NULL,
    Email TEXT UNIQUE NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);
INSERT INTO Users (UserName, Email) VALUES
('Jan Kowalski', 'jan.kowalski@example.com'),
('Maria Nowak', 'maria.nowak@example.com'),
('Piotr Lewandowski', 'piotr.lewandowski@example.com'),
('Anna Zalewska', 'anna.zalewska@example.com'),
('Tomasz Wisniewski', 'tomasz.wisniewski@example.com');