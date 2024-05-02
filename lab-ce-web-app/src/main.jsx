import React from 'react'
import ReactDOM from 'react-dom/client'
import {RouterProvider, createBrowserRouter} from 'react-router-dom'

import App from './App.jsx'
import ProfessroPage from './routes/ProfessorPage.jsx'
import AdminHome from './components/AdminHome.jsx'
import Labmg from './components/Labmg.jsx'
import './index.css'

const router = createBrowserRouter ([
  {path: '/' , element: <App/>},
  {path: '/profesores', element: <ProfessroPage/>},
  {path: '/admin', element: <AdminHome/>},
  {path: '/admin/lab', element: <Labmg/>}
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
