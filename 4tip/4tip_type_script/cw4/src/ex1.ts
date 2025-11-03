import readline from "node:readline/promises";
import {a} from "./ex1_module.js";
//cin z c++
const rl: readline.Interface = readline.createInterface({
    input: process.stdin,
    output: process.stdout
})

//uzyjemy await i aync do czekania na wejscie uzytkownika
// tworzymy funkcje asynchroniczna main poniewaz 
// top-level await nie jest jeszcze powszechnie wspierany
async function main() {
    //tutaj mozna uzyc await
    //to jest podobne do cin w c++
    const firstname:string = await rl.question("Podaj imie: ");
    rl.close();
    console.log(`Witaj, ${firstname}!`);
}
//wywolujemy funkcje main
main();

console.log(a);
for(let i=0; i<3; i++) {
    console.log(`Iteration ${i+1}`);
}