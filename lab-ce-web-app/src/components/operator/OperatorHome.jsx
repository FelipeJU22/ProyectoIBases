import { Link } from 'react-router-dom';
import classes from '../profesor/NewPasswordView.module.css';


function OperatorHome() {

    return <>
        <div className={classes.box}>
            <h1>Opciones de Operador</h1>

            <Link to='/prestamo-activos'>Manejo de Activos</Link> <br />
            <Link to='/reserva-lab'>Reservar Laboratorio</Link> <br />
            <Link to='/testing'>testLink</Link> <br />
            <Link to='/logout'> Cerrar Sesión </Link>
        </div>
    </>
}

export default OperatorHome;