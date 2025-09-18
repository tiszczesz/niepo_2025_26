import { Greeting, textDecorationOptions } from './data/info'
import './App.css'
import { useState, type ChangeEvent } from 'react'

function App() {
  console.log("Rendering App component");

  //const [greet, setGreet] = useState<string>(Greeting[0])
  const [currentIndex, setCurrentIndex] = useState<number>(0)
  const [size, setSize] = useState(16)
  const [isBold, setIsBold] = useState(false)
  const [decoration, setDecoration] = useState(textDecorationOptions[0])

  function handleClick(): void {
    //setGreet(Greeting[(Greeting.indexOf(greet) + 1) % Greeting.length])
    const nextIndex = (currentIndex + 1) % Greeting.length
    //setGreet(Greeting[nextIndex])
    setCurrentIndex(nextIndex)
  }

  function handleChange(e: ChangeEvent<HTMLSelectElement>): void {
    setDecoration(e.target.value)
  }

  return (
    <section className='App'>
      <h3 style={{
        textAlign: "center",
        backgroundColor: "#558B2F",
        padding: "1rem",
        color: "white"
      }}>
        Właściwości czcionki</h3>
      <p style={{ color: "grey", fontSize: "1.4rem" }}>Rozmiar: {size}</p>
      <input type="range" min={0} max={40} style={
        {
          width: "100%",
          accentColor: "#98e8f2ff"
        }
      } value={size} onChange={(e) => setSize(e.target.valueAsNumber)} />
      <p style={{
        color: "grey",
        fontSize: `${size}px`,
        fontWeight: isBold ? 'bold' : 'normal',
        textDecoration: decoration
      }}>{Greeting[currentIndex]}</p>
      <div style={{ textAlign: "center" }}>
        <input type="button" value={">>"}
          style={{
            backgroundColor: "#558B2F",
            padding: "1rem 2rem",
            color: "white"
          }} onClick={() => handleClick()} />

      </div>
      <select onChange={(e) => handleChange(e)} style={{ marginTop: "1rem" }}>
        {textDecorationOptions.map((option) => (
          <option key={option} value={option}>{option}</option>
        ))}
      </select>
      <div>
        <label htmlFor="">Bold? </label>
        <input type="checkbox" onChange={(e) => setIsBold(e.target.checked)} />
      </div>


    </section>
  )
}

export default App
