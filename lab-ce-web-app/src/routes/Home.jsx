import { Link } from "react-router-dom";
import classes from './Home.module.css'

function Home() {
    return (
        <section className={classes.links}>

            <Link to="/login-profesor">Login Profesores</Link>
            <Link to="/profesores">Profesores</Link>
            <Link to="/testing">Test</Link>
            <Link to="/register">Registrarse</Link>

        </section>
    )
}

export default Home;