-- SQLite
CREATE TABLE "users" (
    id INTEGER PRIMARY KEY,
    username TEXT NOT NULL,
    email TEXT NOT NULL,
    date DATE
);
INSERT INTO "users" (username, email, date) VALUES ('john_doe', 'john@example.com', '2025-01-01');
INSERT INTO "users" (username, email, date) VALUES ('jane_smith', 'jane@example.com', '2025-01-02');
INSERT INTO "users" (username, email, date) VALUES ('bob_wilson', 'bob@example.com', '2025-01-03');
INSERT INTO "users" (username, email, date) VALUES ('alice_brown', 'alice@example.com', '2025-01-04');
INSERT INTO "users" (username, email, date) VALUES ('charlie_davis', 'charlie@example.com', '2025-01-05');
INSERT INTO "users" (username, email, date) VALUES ('emma_miller', 'emma@example.com', '2025-01-06');