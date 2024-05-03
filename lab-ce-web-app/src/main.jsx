import React from 'react'
import ReactDOM from 'react-dom/client'
import {RouterProvider, createBrowserRouter} from 'react-router-dom'

import App from './App.jsx'
import ProfessroPage from './routes/ProfessorPage.jsx'
import AdminHome from './components/AdminHome.jsx'
import Labmg from './components/Labmg.jsx'
import Actmg from './components/Actmg.jsx'
import Profmg from './components/Profmg.jsx'
import Opap from './components/Opap.jsx'
import Password from './components/Password.jsx'
import Reports from './components/Reports.jsx'
import Operador from './components/operador/Operador.jsx'
import './index.css'

const router = createBrowserRouter ([
  {path: '/' , element: <App/>},
  {path: '/profesores', element: <ProfessroPage/>},
  {path: '/admin', element: <AdminHome/>},
  {path: '/admin/lab', element: <Labmg/>},
  {path: '/admin/act', element: <Actmg/>},
  {path: '/admin/prof', element: <Profmg/>},
  {path: '/admin/opap', element: <Opap/>},
  {path: '/admin/password', element: <Password/>},
  {path: '/admin/reports', element: <Reports/>},
  {path: '/operador', element: <Operador/>}
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
