import { colors, generSelect } from "./index_module.js";
console.log("Hello from TS");
console.log(colors);
document.querySelector<HTMLDivElement>("main")!
    .appendChild(generSelect(colors));