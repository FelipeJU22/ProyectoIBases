import { useState, useEffect } from "react";

function ProfessorBody() {

    //List with all the solicitudes that the students have sent
    const [solicitudes, setSolicitude] = useState([])

    useEffect(() => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                correo: "betico@gmail.com",
                contraseña: "beto1234"
              })
        };

        async function fetchPosts() {
            const response = await fetch('http://localhost:5095/Ingreso/IngresoAdministrador', requestOptions)
            const textData = await response.text();
            //const resData = await response.json();
            //console.log(resData);
            console.log(textData); // Log the response data
            //const resData = await JSON.parse(response); // Try parsing the response data
        }

        fetchPosts();
    }, [])

    function newSolicHandler(event) {
        setSolicitude( (currentSolics)=> ["New Solicitude", ...currentSolics] )
        console.log(solicitudes)
    }

    return <>
        <h2>Solicitudes para préstamo de activos</h2>

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