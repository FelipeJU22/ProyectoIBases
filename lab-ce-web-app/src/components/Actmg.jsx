import { useState, useEffect } from "react";
import classes from './AdminHome.module.css'; // Import CSS file for styling
import imageSrc from '../img/lab.jpg';
import activeSrc from '../img/activos.jpg';
import profSrc from '../img/prof.jpg';
import { Link } from "react-router-dom";


const Header = ({ adminName }) => {
  return (
    <div className={classes.toptobottom}>
      <h1>Gestor de Activos de {adminName}</h1>
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

function Actmg () {
  const API_URL = 'http://localhost:5095'
  const ACTIVES = '/Profesor/InfoActivos'


  const [actives, setActives] = useState([]);

  useEffect(() => {

    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    };

    async function fetchActives() {
        const response = await fetch(API_URL + ACTIVES, requestOptions)
        //const textData = await response.text();
        const resData = await response.json();
        console.log(resData)
        //console.log('leng: ' + resData.length)
        //const resData = await JSON.parse(response); // Try parsing the response data
        setActives(resData)
    }

    fetchActives();
}, [])
  

    return (
      <div className={classes.mainadminpage}>
        <Header adminName="Administrador" />
        <div className={classes.managementtools}>
          <h1> Activos</h1>
          <Button text="Modificar" Click={1} />
          <Link to='/admin'>
          <Button text="Volver al Menú"/>
          </Link>
        </div>
        <div className={classes.moreinfo}>

       <div className={classes.line}> 
        <h2> Placa </h2>

        <div>
          <br></br>
        <ul>
                {actives.map((ide) => 
                <div>
                <h2> {ide.Placa}</h2>
                </div>
              )
                
                }
            </ul>
            </div>
       </div>
       <div className={classes.line}> 
        <h2> Tipo </h2>
        <div>
          <br></br>
        <ul>
                {actives.map((ide) => 
                <div>
                <h2> {ide.Tipo}</h2>
                </div>
              )
                
                }
            </ul>
            </div>
            <div className={classes.line}> 
        <h2> Marca </h2>

        <div>
          <br></br>
        <ul>
                {actives.map((ide) => 
                <div>
                <h2> {ide.Marca}</h2>
                </div>
              )
                
                }
            </ul>
            </div>
       </div>
        
       <div className={classes.line}> 
        <h2> Fecha Compra </h2>

        <div>
          <br></br>
        <ul>
                {actives.map((ide) => 
                <div>
                <h2> {ide.FechaCompra}</h2>
                </div>
              )
                
                }
            </ul>
            </div>
       </div>
        

       </div>

          
        </div>


        
      </div>
    );
}

export default Actmg;
