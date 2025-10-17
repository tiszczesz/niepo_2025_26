import { readFileSync } from "node:fs";
import { countWords } from "./ex3_files_module.js";
const data = readFileSync('./input.txt', 'utf-8');
const words = data.split(/\s+/);
//const words: string[] = data.split(' ');
console.log(words);
console.log(`Number of words with 3 letters: ${countWords(3, words)}`);
//# sourceMappingURL=ex3_files.js.map