import { useState, useEffect } from "react";
import classes from './AdminHome.module.css'; // Import CSS file for styling
import imageSrc from '../img/lab.jpg';
import activeSrc from '../img/activos.jpg';
import profSrc from '../img/prof.jpg';
import { Link } from "react-router-dom";


const Header = ({ adminName }) => {
  return (
    <div className={classes.toptobottom}>
      <h1>Gestor de Profesores</h1>
    </div>
  );
};

const enroute = (text) => {
  if(text == 1){
    console.log('Button clicked!', {text});
  }
  

}

const Button = ({ text, Click }) => {
  return (
    <button className={classes.btn} onClick={() => enroute(1)}>{text}</button>
  );
};

function Profmg() {
  const[profesores, setProfesores] = useState([])
  const API_URL = 'http://localhost:5095'
  const INFO_LAB_EP = '/Profesor/CredencialesProfesores'

  
  useEffect(() => {

    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    };

    async function fetchProfesor() {
        const response = await fetch(API_URL + INFO_LAB_EP, requestOptions)
        //const textData = await response.text();
        const resData = await response.json();
        console.log(resData)
        //console.log('leng: ' + resData.length)
        //const resData = await JSON.parse(response); // Try parsing the response data
        setProfesores(resData)
    }

    fetchProfesor();
}, [])



    return (
      <div className={classes.mainadminpage}>
        <Header adminName="Administrador" />
        <div className={classes.managementtools}>
          <h1> Profesores</h1>
          <Button text="Modificar" Click={1} />
          <Button text="Dar de alta" Click={1} />
          <Button text="Dar de baja" Click={1} />
          <Link to='/admin'>
          <Button text="Volver al Menú"/>
          </Link>
        </div>
        <div className={classes.moreinfo}>


        <div className={classes.line}> 
        <h2> Correo </h2>
        <div>
          <br></br>
        <ul>
                {profesores.map((ide) => 
                <div>
                <h2> {ide.Correo}</h2>
                </div>
              )
                }
            </ul>
            </div>
       </div>
       </div>
        



        
      </div>
    );
}

export default Profmg;
