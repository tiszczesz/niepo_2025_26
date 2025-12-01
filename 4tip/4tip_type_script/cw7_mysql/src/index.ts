import readline from "readline/promises";
import mysql from "mysql2/promise";
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

const connection = await mysql.createConnection(
    {
        host: 'localhost',
        user: 'root',
        password: '',
        database: '4tip_students_2025_26'
    }
);
const resultTest = await connection.execute('SELECT 1+1 AS solution');
const [result2, fields] = await connection.execute('SELECT * FROM students');
console.log(`Odpowiedz bazy danych: `, resultTest);
console.log(`Wszyscy uczniowie: `, result2);
const answer = await rl.question("Czy dodać nowego ucznia? (tak/nie): ");
if (answer.toLowerCase() === 'tak') {
    const firstname = await rl.question("Podaj imię ucznia: ");
    const lastname = await rl.question("Podaj nazwisko ucznia: ");
    const birthDay = await rl.question("Podaj datę urodzenia ucznia (YYYY-MM-DD): ");
    const insertQuery = 'INSERT INTO students (firstname, lastname, birthDate) VALUES (?, ?, ?)';
    const [insertResult] = await connection.execute(insertQuery, [firstname, lastname, birthDay]);
    console.log(`Dodano nowego ucznia o ID: `, (insertResult as mysql.ResultSetHeader).insertId);
}
await connection.end();
console.log("Połączenie zakończone.");
rl.close();


