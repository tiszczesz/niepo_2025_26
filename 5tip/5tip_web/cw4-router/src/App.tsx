import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import {  RouterProvider,createBrowserRouter } from 'react-router';
import  Layout from './components/Layout';
import Home from './pages/Home';
import About from './pages/About';
import Contacts from './pages/Contacts';
import PageNotFound from './pages/PageNotFound';


const router = createBrowserRouter([
  {
    path: '/',
    element: <Layout />,
    children: [
      {index: true, element: <Home />},
      {path: 'about', element: <About />},
      {path: 'contacts', element: <Contacts />},
      {path: '*', element: <PageNotFound />},
    ]
  }
]);
function App() { 
  return <RouterProvider router={router} />
}

export default App
