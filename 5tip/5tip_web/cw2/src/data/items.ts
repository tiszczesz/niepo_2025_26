type Item = {
    id: number,
    color: string,
    isBordered: boolean,
    content: string
}
export const myItems: Item[] = [
    { id: 1, color: "lightblue", isBordered: true, content: "Item 1" },
    { id: 2, color: "lightgreen", isBordered: false, content: "Item 2" },
    { id: 3, color: "lightcoral", isBordered: true, content: "Item 3" },
    { id: 4, color: "lightgoldenrodyellow", isBordered: false, content: "Item 4" },
    { id: 5, color: "lightpink", isBordered: true, content: "Item 5" }
]