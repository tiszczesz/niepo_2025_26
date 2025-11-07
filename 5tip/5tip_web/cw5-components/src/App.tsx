import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import MySelect from './components/MySelect';
import { useState } from 'react';
import MyRange from './components/MyRange';
import MyInput from './components/MyInput';

function App() {
  const [selectedOption, setSelectedOption] = useState<string>("");
  const [rangeValue, setRangeValue] = useState<number>(0);

  function handleSelectChange(value: string): void {
    console.log("Wybrano poziom wykształcenia: ", value);
    setSelectedOption(value);
  }
  function handleSelectChange2(value: string): void {
    console.log("Wybrano status zawodowy: ", value);
    //setSelectedOption(value);
  }
  function changeColor(value: string): void {
    document.body.style.backgroundColor = value;
  }

  function handleOnChange(value: number): void {
    console.log("Wybrana wartość z zakresu: ", value);
    setRangeValue(value);
  }

  return (
    <>
      <h1>Komponenty</h1>
      <main className='container'>

        <div>
          <label htmlFor="">Zwykły input:</label>
          <input type="text" />
        </div>
        <MySelect
          options={["podstawowe", "średnie", "wyższe", "inne"]}
          title="Wybierz poziom wykształcenia:"
          handleOnChange={(value => handleSelectChange(value))}
        />
        <MySelect
          options={["uczeń", "student", "pracownik", "emeryt"]}
          title="Wybierz status zawodowy:"
          handleOnChange={(value => handleSelectChange2(value))}
        />
        <MySelect options={["white", "green", "blue", "yellow"]}
          title="Wybierz kolor:" handleOnChange={(value) => changeColor(value)} />
        <p>Wybrano: {selectedOption}</p>
        <MyRange label="Wybierz wartość:" min={0} max={100} startValue={rangeValue}
          handleOnChange={(value) => handleOnChange(value)} />
        <p>Wybrana wartość z zakresu: {rangeValue}</p>
        <h3>MyInput:</h3>
        <MyInput />
      </main>
    </>
  )
}

export default App
