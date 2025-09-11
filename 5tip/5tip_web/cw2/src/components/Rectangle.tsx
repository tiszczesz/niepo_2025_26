

type Props = {
    color?: string,
    isBordered: boolean,
    content: string
}

export default
    function Rectangle({ color, isBordered, content }: Props) {
    return (
        <div style={{
            backgroundColor: color ? color : "lightgrey",
            border: isBordered ? "1px solid black" : "none",
            padding: "10px",
            margin: "10px"
        }}>{content}</div>
    )
}