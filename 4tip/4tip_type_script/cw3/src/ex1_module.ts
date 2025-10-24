import { writeFileSync } from "node:fs";
export const hello = "Hello, world!";
export const saveArrayToFile = (fileName:string,data:string[]) => {
    const content = data.join("\n");
    writeFileSync(fileName,content,{encoding:"utf-8"});
};