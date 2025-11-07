import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import Layout from './components/Layout';
import { Route, Routes } from 'react-router';
import Home from './pages/Home';
import About from './pages/About';
import Contact from './pages/Contact';

function App() {


  return (
    <>
      <header>
        <Layout />
      </header>
      <main className="container mt-4">
        <h1>Welcome to the App</h1>
        <p>This is the main content area.</p>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/contact" element={<Contact />} />
        </Routes> 
      </main>
      <footer>
        <p>© 2023 My App. All rights reserved.</p>
      </footer>
    </>
  )
}

export default App
