import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import MySelect from './components/MySelect';
import { useState } from 'react';

function App() {
  const [selectedOption, setSelectedOption] = useState<string>("");

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

  return (
    <>
      <h1>Komponenty</h1>
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
    </>
  )
}

export default App
