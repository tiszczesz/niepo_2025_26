import readline from "readline/promises";
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});
const main = async () => {
    const answer = await rl.question("Co tam u ciebie majca zrobiona? ");
    console.log("Odpowiedz uzytkownika: ", answer);
    console.log("hello");

    rl.close();
}

main();