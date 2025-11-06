import { use, useRef, useState, type FormEvent } from "react";

type Props = {}

const Contacts = (props: Props) => {
  const firstNameRef = useRef<HTMLInputElement>(null);
  const descriptionRef = useRef<HTMLTextAreaElement>(null);
  const educationRef = useRef<HTMLSelectElement>(null);
  const [formData, setFormData] = useState<string | null>(null);

  function handleSubmit(e: FormEvent<HTMLFormElement>): void {
    e.preventDefault();
    console.log(e);
    if(firstNameRef.current && descriptionRef.current && educationRef.current) {
      const formData = {
        firstname: firstNameRef.current.value,
        description: descriptionRef.current.value,
        education: educationRef.current.value
      };
      setFormData(JSON.stringify(formData));
      console.log(formData);
    }

  }

  return (
    <>
      <h1>Dane kontaktowe</h1>
      <form onSubmit={(e) => handleSubmit(e)}>
        <div className="row m-2">
          <label className="col-3 text-end" htmlFor="firstname" >Imię:</label>
          <input className="col-6" ref={firstNameRef} type="text" id="firstname" name="firstname" />
        </div>
        <div className="row m-2">
          <label className="col-3 text-end" htmlFor="description" >Opis:</label>
          <textarea className="col-6" ref={descriptionRef} id="description" name="description" />
        </div>
        <div className="row m-2">
          <label className="col-3 text-end" htmlFor="education" >Wykształcenie:</label>
          <select className="col-6" ref={educationRef} id="education" name="education" >
            <option value="podstawowe">Podstawowe</option>
            <option value="średnie">Średnie</option>
            <option value="wyższe">Wyższe</option>
          </select>
        </div>
        <div className="row m-2">
          <button
            className="btn btn-primary col-6 offset-3"
            type="submit">Wyślij</button>
        </div>
      </form>
      <section>
        {formData}
      </section>
    </>
    // formularz kontaktowy za pomocą useRef i wyświetlenie danych w konsoli
    //input (imię), textarea(opis siebie), select (wykształcenie)
  )
}

export default Contacts