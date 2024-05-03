import React from 'react'
import ReactDOM from 'react-dom/client'
//import {RouterProvider, createBrowserRouter} from 'react-router-dom'
import { Route, Routes, BrowserRouter } from 'react-router-dom'

import App from './App.jsx'
import ProfessroPage from './routes/ProfessorPage.jsx'
import NotFound from './routes/NotFound.jsx'
import { AuthProvider } from './context/AuthProvider.jsx'

import './index.css'

// const router = createBrowserRouter ([
//   {path: '/' , element: <App/>},
//   {path: '/profesores', element: <ProfessroPage/>},
//   {path: '*', element: <NotFound/>}
// ]);


//<RouterProvider router={router} />

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <AuthProvider>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </AuthProvider>
  </React.StrictMode>,
)
