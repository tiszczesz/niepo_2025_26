import React, { useEffect, useRef } from 'react'

type Props = {}
 function input(el: HTMLInputElement) {
        if (el) {
            el.focus();
        }
    }
const MyFocused = (props: Props) => {
    const inputRef = useRef<HTMLInputElement>(null);
    useEffect(() => input(inputRef.current!), []);

   
    return (
        <>
            <div>To jest komponent </div>
            <input placeholder='to nie fokusuje' />
            <input ref={inputRef} type="text" placeholder='Skupienie na tym polu' />
        </>

    )
}

export default MyFocused    