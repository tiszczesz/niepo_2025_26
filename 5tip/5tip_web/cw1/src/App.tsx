import 'bootstrap/dist/css/bootstrap.min.css';

import './App.css'
import { useState } from 'react';

function App() {
  const [count, setCount] = useState(10);
  const [text, setText] = useState("");
  const [checked, setChecked] = useState(false);

  return (
    <>
      <div className="container">
        <header>
          <h1>Hello, World!</h1>
        </header>
        <main>
          <section className='row'>
            <input 
            value={count}
             onChange={
              (e)=>setCount(Number(e.target.value))
            }
            type="range" min={10} max={100}
              className="col-8" />
            <span className='col-4'>{count}</span>
          </section>
          <section>
            <div style={{
              backgroundColor:"red",
              width:`${count}px`,
              height:`${count}px`,
              }}></div>
          </section>
          <section>
            <textarea value={text} onChange={(e) => setText(e.target.value)}></textarea>
            <p>{text}</p>
            <div dangerouslySetInnerHTML={{ __html: text.replace(/\n/g, "<br />") }} />
          </section>
          <section>
            <input type="checkbox" checked={checked} onChange={(e) => setChecked(e.target.checked)} />
            {checked && <input type="button" value="Przycisk" /> }
          </section>
        </main>
      </div>
    </>
  )
}

export default App
