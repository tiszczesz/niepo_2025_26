function fun1() {
    const a = 5;
    console.log(`typ zmiennej a to ${typeof a} a = ${a}`);
}
function Repeater(a, text) {
    for (let i = 0; i < a; i++) {
        console.log(text);
    }
}
fun1();
Repeater(3, "Ala ma kota");
export {};
//# sourceMappingURL=ex1.js.map