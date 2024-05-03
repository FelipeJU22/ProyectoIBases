import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import MainHeader from './components/MainHeader'
import LoginPage from './components/LoginPage'
import { Route, Routes, BrowserRouter } from 'react-router-dom'
import ProfessorPage from './routes/ProfessorPage.jsx'
import NotFound from './routes/NotFound.jsx'
import Layout from './routes/Layout.jsx'
import Register from './routes/Register.jsx'
import RequireAuth from './components/RequireAuth.jsx'
import ProfessorBody from './components/ProfessorBody.jsx'
import Home from './routes/Home.jsx'
import Unauthorized from './routes/Unauthorized.jsx'

function App() {
  const [count, setCount] = useState(0)

  return (
    <Routes>
      <Route path='/' element={<Layout />}>
        {/*Public Routes*/}
        <Route path='register' element={<Register />} />
        <Route path='login-profesor' element={<LoginPage />} />
        <Route path='/' element={<Home />} />
        <Route path='unauthorized' element={<Unauthorized />} />


        {/* Private Routes */}
        <Route element={<RequireAuth allowedRoles={[100]} />}>
          <Route path='profesores' element={<ProfessorPage />} />
        </Route>

        <Route element={<RequireAuth allowedRoles={[101]} />}>
          <Route path='testing' element={<ProfessorBody />} />
        </Route>

        {/* <Route element={<RequireAuth allowedRole={[100]} />}>
        </Route> */}

        {/*Catches all other routes*/}
        <Route path='*' element={<NotFound />} />
      </Route>
    </Routes>
  )
}

export default App