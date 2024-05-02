import classes from './LoginPage.module.css';
import { useRef, useState, useEffect, useContext } from 'react';


function LoginPage() {

    const userRef = useRef();
    const errRef = useRef();

    const [user, setUser] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [success, setSuccess] = useState(false);
    const [retryLogin, setRetryLogin] = useState(false);
    const [responseMsg, setResponseMsg] = useState('');

    useEffect(() => {
        userRef.current.focus();
    }, [])

    useEffect(() => {
        setErrMsg('');
    }, [user, pwd])

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            console.log(user, pwd)

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    correo: user,
                    contraseña: pwd
                })
            };

            const response = await fetch('http://localhost:5095/Ingreso/IngresoAdministrador', requestOptions)
            const textData = await response.text();

            if (response.status === 200) {
                setResponseMsg(textData)
                setSuccess(true);
                console.log(response);
                setUser('');
                setPwd('');
            } else {
                setResponseMsg(textData)
                setRetryLogin(true)
            }
            //const resData = await response.json();
            //console.log(resData);
            console.log(textData); // Log the response data
            //const resData = await JSON.parse(response); // Try parsing the response data

        } catch (err) {

        }
    }

    return (
        <>
            {success ? (
                <section>
                    <h1>{responseMsg}</h1>
                    <br />
                    <p>
                        <a href="#">Ir a inicio</a>
                    </p>
                </section>
            ) : (
                <div>
                    <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"}>{errMsg}</p>
                    <h1>Iniciar Sesión</h1>
                    <form onSubmit={handleSubmit} className={classes.form}>
                        <p>
                            <label htmlFor="username">Usuario</label>
                            <input
                                type="text"
                                id="username"
                                ref={userRef}
                                required
                                autoComplete='off'
                                onChange={(e) => setUser(e.target.value)}
                                value={user}
                            />
                        </p>
                        <p>
                            <label htmlFor="password">Contraseña</label>
                            <input
                                type="password"
                                id="password"
                                required
                                value={pwd}
                                onChange={(e) => setPwd(e.target.value)}
                            />
                        </p>

                        <p id="loginnote" className={retryLogin ? classes.instructions : classes.hide}>
                            Usuario Incorrecto
                        </p>

                        <p className={classes.actions}>
                            <button>Ingresar</button>
                        </p>
                    </form>
                    <p>
                        No tiene cuenta?<br />
                        <span className="line">
                            {/*put router link here*/}
                            <a href="#">Registrarse</a>
                        </span>
                    </p>
                </div>
            )}
        </>
    )
}

export default LoginPage;