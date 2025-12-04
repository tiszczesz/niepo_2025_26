import { useEffect, useState } from 'react'

// type Props = {}

const MyTimer = () => {
    const [time, setTime] = useState<string>(new Date().toLocaleTimeString());
    //uzycie useEffect do aktualizacji czasu co sekunde
    useEffect(() => {
        const timer = setInterval(() => {
            const now = new Date();
            setTime(now.toLocaleTimeString());
            console.log("timer useEffect", time);

        }, 1000);
        return () => clearInterval(timer); //czyszczenie interwalu przy odmontowaniu komponentu
    }, [time]);//pusta tablica zaleznosci - efekt wykona sie tylko raz przy montowaniu komponentu

    function handleClick(): void {
        const now = new Date();
        setTime(now.toLocaleTimeString())
    }
    console.log('MyTimer render')
    return (
        <div>
            <h2>Aktualny czas: {time} </h2>
            <button
                className='btn btn-primary'
                onClick={() => handleClick()} >Pokaż aktualny czas</button>
        </div>
    )
}

export default MyTimer  