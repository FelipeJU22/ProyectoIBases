import { useState, useEffect } from "react";
import { Navigate } from "react-router-dom";

function ProfessorBody() {

    //List with all the solicitudes that the students have sent
    const [solicitudes, setSolicitude] = useState([])

    useEffect(() => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
        };

        async function fetchPosts() {
            const response = await fetch('http://localhost:5095/Profesor/SolicitudesPendientes?correoProfesor=jleiton@itcr.com', requestOptions)
            //const textData = await response.text();
            const resData = await response.json();
            //const resData = await JSON.parse(response); // Try parsing the response data
            console.log(resData[0].Tipo);
        }

        fetchPosts();
    }, [])

    function newSolicHandler(event) {
        setSolicitude((currentSolics) => ["New Solicitude", ...currentSolics])
        console.log(solicitudes)
    }

    function noseHandler(e) {
        <Navigate to="/testing" state={{ from: location }} replace />
    }

    return <>
        <h2>Solicitudes para préstamo de activos</h2>

        <button onClick={noseHandler}>MMEA</button>

        <button onClick={newSolicHandler}>Solicitud</button>

        {solicitudes.length > 0 ? (
            <ul>
                {solicitudes.map((solic) => solic)}
            </ul>
        ) :
            <div>
                <p>No hay solicitudes de préstamo pendientes.</p>
            </div>}
    </>
}

export default ProfessorBody;