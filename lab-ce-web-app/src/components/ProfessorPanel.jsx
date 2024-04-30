import { Link } from 'react-router-dom';

function ProfessorPanel() {

    return <>
        <ul>
            <li>Préstamo de activos</li>
            <li>Reservar un laboratorio</li>
            <li>Cambiar contraseña</li>
            <Link to='/'> Cerrar Sesión </Link>
        </ul>
    </>
}

export default ProfessorPanel;