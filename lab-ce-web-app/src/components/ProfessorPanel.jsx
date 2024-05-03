import { Link } from 'react-router-dom';

function ProfessorPanel() {

    return <>
        <div>
            <Link to='/prestamo-activos'>Préstamo de activos</Link>
            <li>Reservar un laboratorio</li>
            <Link to='/cambiar-clave'>Cambiar contraseña</Link> <br />
            <Link to='/testing'> Cerrar Sesión </Link>
        </div>
    </>
}

export default ProfessorPanel;