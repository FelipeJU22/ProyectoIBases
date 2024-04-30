import { useState, useEffect } from "react";

function ProfessorBody() {

    //List with all the solicitudes that the students have sent
    const [solicitudes, setSolicitude] = useState([])

    useEffect(() => {
        async function fetchPosts() {
            const response = await fetch('https://jsonplaceholder.typicode.com/posts')
            const resData = await response.json();
            console.log(resData);
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