import { useState, useEffect } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import Actives from "../profesor/Actives";
import classes from '../profesor/NewPasswordView.module.css';
import { Link } from "react-router-dom";


function OperatorLoan() {

    const navigate = useNavigate();
    const goBack = () => navigate(-1);

    //List with all the solicitudes that the students have sent
    const [solicitudes, setSolicitude] = useState([])

    useEffect(() => {
        const API_URL = 'http://localhost:5095'
        const INFO_LAB_EP = '/Laboratorio/MostrarInformacionLab?nombreLab='
        const AVAILABLE_LABS = ['F2-06', 'F2-07', 'F2-08', 'F2-09']

        const requestOptions = {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
        };

        async function fetchPosts() {
            const response = await fetch('http://localhost:5095/Profesor/SolicitudesPendientes?correoProfesor=jleiton@itcr.com', requestOptions)
            //const textData = await response.text();
            const resData = await response.json();
            console.log(resData)
            //console.log('leng: ' + resData.length)
            //const resData = await JSON.parse(response); // Try parsing the response data
            setSolicitude(resData)
        }

        fetchPosts();
    }, [])

    function activeReqHadler(resData) {
        for (let i = 0; i < resData.length; i++) {
            //const element = resData[i];
            console.log(resData[i])
            setSolicitude((solics) => [resData[i], ...solics]);
        }
    }

    function newSolicHandler(event) {
        setSolicitude((currentSolics) => ["New Solicitude", ...currentSolics])
        console.log(solicitudes)
    }

    function noseHandler(e) {
        console.log(solicitudes)
    }

    function handleDelete(id) {
        setSolicitude(solicitudes.filter(solic => solic.IdActivo !== id));
    };

    return <>

        <div className={classes.box}>
            <h2>Opciones para préstamo de activos</h2>

            <Link to='/operador/prestamo-profesor'>Solicitar préstamo a profesor</Link> <br />
            <Link to='/operador/labs'>Solicitar préstamo a estudiante</Link> <br />
            <Link to='/testing'>Devolución de activo</Link> <br />

            <button onClick={goBack}>Volver</button>
        </div>
    </>
}

export default OperatorLoan;