import { hello,saveArrayToFile } from "./ex1_module.js";
const colors = ["red", "green", "blue"];
for (const color of colors) {
    console.log(color);
}
console.log(hello);
saveArrayToFile("colors.txt", colors);