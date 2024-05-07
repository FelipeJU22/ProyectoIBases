import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import MainHeader from './components/profesor/MainHeader.jsx'
import LoginPage from './components/profesor/LoginPage.jsx'
import { Route, Routes, BrowserRouter } from 'react-router-dom'
import ProfessorPage from './routes/ProfessorPage.jsx'
import NotFound from './routes/NotFound.jsx'
import Layout from './routes/Layout.jsx'
import Register from './routes/Register.jsx'
import RequireAuth from './components/RequireAuth.jsx'
import ProfessorBody from './components/profesor/ProfessorBody.jsx'
import Home from './routes/Home.jsx'
import Unauthorized from './routes/Unauthorized.jsx'
import MainAdminPage from './components/AdminHome.jsx'
import Labmg from './components/Labmg.jsx'
import Actmg from './components/Actmg.jsx'
import Profmg from './components/Profmg.jsx'
import Opap from './components/Opap.jsx'
import Password from './components/Password.jsx'
import Reports from './components/Reports.jsx'
import Operador from './components/operador/Operador.jsx'
import Labrsv from './components/operador/Labrsv.jsx'
import Prestamopf from './components/operador/Prestamopf.jsx'
import Prestamoest from './components/operador/Prestamoest.jsx'
import Devolucionact from './components/operador/Devolucionact.jsx'
import Regaverias from './components/operador/Regaverias.jsx'
import Reportsop from './components/operador/Reportsop.jsx'
import LoginAdmin from './components/LoginAdmin.jsx'
import NewPasswordView from './components/profesor/NewPasswordView.jsx'
import Labs from './components/profesor/Labs.jsx'
import LogoutPage from './routes/LogoutPage.jsx'
import OperatorLogin from './components/operator/OperatorLogin.jsx'
import OperatorHome from './components/operator/OperatorHome.jsx'
import OperatorLoan from './components/operator/OperatorLoan.jsx'
import OperatorLabs from './components/operator/OperatorLabs.jsx'
import OperatorLoanPf from './components/operator/OperatorLoanPf.jsx'
import ProfValidator from './components/operator/ProfValidator.jsx'



function App() {
  const [count, setCount] = useState(0)

  return (
    <Routes>
      <Route path='/' element={<Layout />}>
        {/*Public Routes*/}
        <Route path='register' element={<Register />} />
        <Route path='login-profesor' element={<LoginPage />} />
        <Route path='login-admin' element={<LoginAdmin />} />
        <Route path='/' element={<Home />} />
        <Route path='unauthorized' element={<Unauthorized />} />
        <Route path='/admin' element={<MainAdminPage />} />
        <Route path='/admin/labmg' element={<Labmg />} />
        <Route path='/admin/actmg' element={<Actmg />} />
        <Route path='/admin/profmg' element={<Profmg />} />
        <Route path='/admin/opap' element={<Opap />} />
        <Route path='/admin/password' element={<Password />} />
        <Route path='/admin/reports' element={<Reports />} />
        <Route path='/operador' element={<Operador />} />
        <Route path='/operador/labrsv' element={<Labrsv />} />
        <Route path='/operador/prestamopf' element={<Prestamopf />} />
        <Route path='/operador/prestamoest' element={<Prestamoest />} />
        <Route path='/operador/devolucionact' element={<Devolucionact />} />
        <Route path='/operador/regaverias' element={<Regaverias />} />
        <Route path='/operador/reportes' element={<Reportsop />} />
        <Route path='/logout' element={<LogoutPage />} />

        {/* NEW OPERATOR Routes */}
        <Route path='/operador/login' element={<OperatorLogin />} />
        <Route path='/operador/home' element={<OperatorHome />} />
        <Route path='/operador/prestamo' element={<OperatorLoan />} />
        <Route path='/operador/labs' element={<OperatorLabs />} />
        <Route path='/operador/prestamo-profesor' element={<OperatorLoanPf />} />
        <Route path='/operador/prestamo-estudiante' element={<OperatorHome />} />
        <Route path='/operador/validacion-profesor' element={<ProfValidator />} />

        {/* Professor Routes */}
        <Route element={<RequireAuth allowedRoles={[100]} />}>
          <Route path='prestamo-activos' element={<ProfessorBody />} />
          <Route path='reserva-lab' element={<Labs />} />
          <Route path='profesores' element={<ProfessorPage />} />
          <Route path='cambiar-clave' element={<NewPasswordView />} />
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