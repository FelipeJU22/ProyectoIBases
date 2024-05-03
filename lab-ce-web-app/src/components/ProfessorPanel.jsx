import { Link } from 'react-router-dom';

function ProfessorPanel() {

    return <>
        <ul>
            <Link to='/prestamo-activos'>Préstamo de activos</Link>
            <li>Reservar un laboratorio</li>
            <li>Cambiar contraseña</li>
            <Link to='/testing'> Cerrar Sesión </Link>
        </ul>
    </>
}

export default ProfessorPanel;