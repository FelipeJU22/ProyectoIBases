import classes from './LoginPage.module.css';

function LoginPage() {

    return(
        <form className={classes.form}>
        <p>
            <label htmlFor="body">Usuario</label>
            <input type="text" id="name" required />
        </p>
        <p>
            <label htmlFor="name">Contraseña</label>
            <input type="password" id="name" required />
        </p>

        <p className={classes.actions}>
            <button>Ingresar</button>
        </p>
        </form>
    )
}

export default LoginPage;