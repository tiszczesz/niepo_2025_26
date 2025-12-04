import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import MyTimer from './components/MyTimer';
import MyFocused from './components/MyFocused';
import MyFormAction from './components/MyFormAction';

function App() {


  return (
    <>
      <main className='container'>
        <h1>Hello</h1>
        {/* <MyTimer /> */}
        <hr />
        <MyFocused />
        <MyFormAction />
      </main>
    </>
  )
}

export default App
