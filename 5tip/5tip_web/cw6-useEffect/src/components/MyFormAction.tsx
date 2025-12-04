import { useState } from "react";
type FormResult = {
    firstName: string;
    lastName: string;
    myDate: string;
    age: number;
    item: string;
}

type Props = {}

const MyFormAction = (props: Props) => {
    const [formResult, setFormResult] = useState<FormResult | null>(null);
    const handleFormSubmit = (formData: FormData) => {
        console.log(formData);
        //cała logika obsługi formularza tutaj
    }
    return (
        <div>
            <form action={handleFormSubmit}>
                <div>Formularz z akcją</div>
                <input type="text" name="firstName" placeholder="Imię" />
                <input type="text" name="lastName" placeholder="Nazwisko" />
                <input type="date" name="myDate"/>
                <input type="number" name="age" placeholder="Podaj wiek"/>
                <select name="items">
                    <option value="item1">Item 1</option>
                    <option value="item2">Item 2</option>
                    <option value="item3">Item 3</option>
                </select>
                <button type="submit">Wyślij</button>
            </form>
            <hr />
            <div>
                <h3>Result formularza</h3>
            </div>
        </div>
    )
}

export default MyFormAction