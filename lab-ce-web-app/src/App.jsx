import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import MainHeader from './components/MainHeader'
import LoginPage from './components/LoginPage'
import {Route, Routes, BrowserRouter} from 'react-router-dom'
import ProfessorPage from './routes/ProfessorPage.jsx'
import NotFound from './routes/NotFound.jsx'
import Layout from './routes/Layout.jsx'
import Register from './routes/Register.jsx'

function App() {
  const [count, setCount] = useState(0)

  return (
    <Routes>
        <Route path='/' element={<Layout />}>
          {/*Public Routes*/}
          <Route path='register' element={<Register/>}/>
          <Route path='login-profesor' element={<LoginPage/>}/>
          {/* Private Routes */}
          <Route path='/profesores' element={<ProfessorPage/>}/>
          {/*Catches all other routes*/}
          <Route path='*' element={<NotFound/>}/>
        </Route>
      </Routes>
  ) 
} 

export default App