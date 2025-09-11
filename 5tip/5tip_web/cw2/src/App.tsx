// import { useState } from 'react'
// import reactLogo from './assets/react.svg'
// import viteLogo from '/vite.svg'
import 'bootstrap/dist/css/bootstrap.min.css'
import Rectangle from './components/Rectangle';
import './App.css'

function App() {


  return (
    <div className="container">
      <h1>Hello Vite + React!</h1>
      <Rectangle isBordered={true} content="First Rectangle" />
      <Rectangle color="yellow" isBordered={false} content="Second Rectangle" />

    </div>
  )
}

export default App
