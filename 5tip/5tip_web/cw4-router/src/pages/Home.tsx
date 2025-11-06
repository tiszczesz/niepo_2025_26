import { useRef, useState } from "react";

type Props = {}

function Home({ }: Props) {
    // useRef is used to create a mutable object
    const inputRef = useRef<HTMLInputElement>(null);
    const [info, setInfo] = useState<string>("na początku było...");
    console.log("renderowanie Home...");
    
    function handleInput(): void {
        //pobranie wartości z inputa
        if (inputRef.current) {
            const inputValue = inputRef.current.value;
            console.log(inputValue);
            //zmiana stanu komponentu
            setInfo(`Witaj ${inputValue}`);
            console.log(info);            
        }
    }

    return (
        <>
            <h1>UseRef</h1>
            <p>UseRef is a React Hook that allows you to
                 create a mutable object which holds 
                 a `.current` property. This object 
                 persists for the full lifetime
                  of the component.</p>
             <input ref={inputRef} type="text" placeholder="podaj imię" />  
            <button onClick={() => handleInput()}>Pobierz z inputa</button>
             <span>{info}</span>   
        </>
    )
}

export default Home 