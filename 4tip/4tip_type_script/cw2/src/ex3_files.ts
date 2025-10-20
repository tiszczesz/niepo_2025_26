import { readFileSync, writeFileSync } from "node:fs";
import { countWords } from "./ex3_files_module.js";
import { type Student, students } from "./ex3_data.js";
const data: string = readFileSync('./input.txt', 'utf-8');
const words: string[] = data.split(/\s+/);
//const words: string[] = data.split(' ');
console.log(words);
console.log(`Number of words with 3 letters: ${countWords(3, words)}`);
students.forEach(
    (student) => {
        console.log(`${student.firstname} - ${student.lastname}, age: ${student.age}`);
    });
let output: string = ``;
students.forEach(
    (student) => {
        output += `${student.firstname} - ${student.lastname}, age: ${student.age}\n`;
    });
writeFileSync('./output.txt',output, 'utf-8');