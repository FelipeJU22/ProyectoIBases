import classes from '../profesor/LoginPage.module.css';
import { useRef, useState, useEffect } from 'react';
import useAuth from '../../hooks/useAuth';
import { Link, useNavigate, useLocation } from 'react-router-dom';
import md5 from 'md5';

function ProfValidator() {

    const location = useLocation();
    const from = location.state?.from?.pathname || '/operador/prestamo-profesor'

    const userRef = useRef();
    const errRef = useRef();

    const [user, setUser] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [success, setSuccess] = useState(false);
    const [retryLogin, setRetryLogin] = useState(false);
    const [responseMsg, setResponseMsg] = useState('');

    const navigate = useNavigate();
    const goBack = () => navigate(-1);

    const API_URL = 'http://localhost:5095'
    const AVAILABLE_ACTIVES = '/Profesor/MostrarActivosDisponibles'

    useEffect(() => {
        userRef.current.focus();
    }, [])

    useEffect(() => {
        setErrMsg('');
    }, [user, pwd])


    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    };

    async function setActiveRequest() {
        const response = await fetch(API_URL + AVAILABLE_ACTIVES, requestOptions)
        const resData = await response.json();
        console.log(resData)
        setActiveList(resData)
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    correo: user,
                    contraseña: pwd
                })
            };

            const response = await fetch('http://localhost:5095/Ingreso/IngresoProfesor', requestOptions)
            const textData = await response.text();

            console.log(from)

            if (response.status === 200) {
                setResponseMsg(textData);
                //setSuccess(true);
                console.log(response);
                setUser('');
                setPwd('');
                //navigate('/adwda')
                //navigate('/profesores');
                navigate(from, { replace: true });
            } else {
                setResponseMsg(textData)
                setRetryLogin(true)
            }
            //const resData = await response.json();
            //console.log(resData);
            console.log(textData); // Log the response data
            //const resData = await JSON.parse(response); // Try parsing the response data

        } catch (err) {
            console.log('Error:', err);

        }
    }

    return (
        <div>
            <div className={classes.toptobottom}>
                <h3>Validación de Cuenta</h3>
            </div>
            <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"}>{errMsg}</p>
            <form className={classes.form}>
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

                <p>
                    *Indique las credenciales del profesor que requiere el activo.
                </p>

                <p id="loginnote" className={retryLogin ? classes.instructions : classes.hide}>
                    Usuario Incorrecto
                </p>

                <div className={classes.buttonSect}>
                    <button onClick={goBack}>Volver</button>
                    <button onClick={handleSubmit}>Validar</button>
                </div>
            </form>
        </div>
    )
}

export default ProfValidator;