import { useState } from "react";
type FormResult = {
    firstName: string;
    lastName: string;
    myDate: string;
    age: number;
    item: string;
}
const options = [
    "dsdssd","dfdfdf","fdfdfd","gfgfgf"
];


const MyFormAction = () => {
    console.log("Render MyFormAction");
    const [formResult, setFormResult] = useState<FormResult | null>(null);
    const [ishow, setIsHow] = useState(true);
    const handleFormSubmit = (formData: FormData) => {
        console.log(formData);
        //cała logika obsługi formularza tutaj
        const result: FormResult = {
            firstName: formData.get("firstName") as string,
            lastName: formData.get("lastName") as string,
            myDate: formData.get("myDate") as string,
            age: Number(formData.get("age")), //parseInt też ok
            item: formData.get("items") as string,
        }
        setFormResult(result); //ustawiamy stan z wynikiem formularza renderowanie
    }
    return (
        <div>
            <form action={handleFormSubmit} >
                <div>Formularz z akcją</div>
                <input type="text" name="firstName" placeholder="Imię" />
                <input type="text" name="lastName" placeholder="Nazwisko" />
                <input type="date" name="myDate" />
                <input type="number" name="age" placeholder="Podaj wiek" />
                <select name="items">
                    {options.map((opt, index) => (
                        <option key={index} value={opt}>{opt}</option>
                    ))}
                </select>
                <button type="submit">Wyślij</button>
            </form>
            <hr />
            <div>
                <h3>Result formularza</h3>
                {formResult && (
                    <pre>{JSON.stringify(formResult, null, 2)}</pre>
                )}
            </div>
            <button onClick={() => setIsHow(!ishow)}>Pokaż/Ukryj sekret</button>
            {ishow &&<div>SECRET</div>}
        </div>
    )
}

export default MyFormAction