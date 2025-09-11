-- SQLite
CREATE TABLE Holidays(
 id Integer PRIMARY KEY,
 place Text,
 date_start Text,
 date_end Text,
 price Float,
 count Integer,
 isFoodIncluded Integer
);
INSERT INTO Holidays (place, date_start, date_end, price, count, isFoodIncluded) VALUES
('Greece', '2025-06-15', '2025-06-22', 1200.50, 2, 1),
('Spain', '2025-07-01', '2025-07-10', 1500.00, 4, 0),
('Italy', '2025-08-05', '2025-08-12', 1100.75, 3, 1),
('Croatia', '2025-09-10', '2025-09-17', 900.00, 2, 0);