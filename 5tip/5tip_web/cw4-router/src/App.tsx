import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import {  RouterProvider,createBrowserRouter } from 'react-router';


const router = createBrowserRouter([]);
function App() { 
  return <RouterProvider router={router} />
}

export default App
