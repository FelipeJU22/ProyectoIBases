import React from 'react';
import classes from '../AdminHome.module.css'; // Import CSS file for styling
import imageSrc from '../../img/lab.jpg';
import activeSrc from '../../img/activos.jpg';
import profSrc from '../../img/prof.jpg';


const Header = ({ adminName }) => {
  return (
    <div className={classes.toptobottom}>
      <h1>Bienvenido, {adminName}</h1>
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

class Operador extends React.Component {
  

  render() {
    return (
      <div className={classes.mainadminpage}>
        <Header adminName="Administrador" />
        <div className={classes.managementtools}>
          <h1> Gestor de Laboratorios</h1>
          <p> Permite gestionar toda la información de los laboratorios:
          </p>
          <p> -Nombre <br></br>
            -Capacidad de personas <br></br> -Computadores
            <br></br> -Facilidades
            <br></br> -Horarios
            <br></br> -Activos
          </p>
          <div className={classes.imagecontainer}>
        <img src={imageSrc} alt='None'/>
          </div>
          <Button text="Ir a Laboratorios" Click={1} />
        </div>


        <div className={classes.actmanagement}>
          <h1> Gestor de Activos</h1>
          <p> Permite gestionar toda la información de los activos:
          </p>
          <p> -Placa <br></br>
            -Tipo <br></br> -Marca
            <br></br> -Fecha de compra
            <br></br> -Préstamos
          </p>
          <div className={classes.imagecontainer}>
        <img src={activeSrc} alt='None'/>
          </div>
          <Button text="Ir a Activos" onClick={() => this.handleToolButtonClick('labgestor')} />
        </div>

        <div className={classes.profmanagement}>
          <h1> Gestor de Profesores</h1>
          <p> Permite dar de alta, modificar o eliminar profesores:
          </p>
          <p><br></br>
            <br></br>
            <br></br>
          </p>
          <div className={classes.imagecontainer}>
        <img src={profSrc} alt='None'/>
          </div>
          <Button text="Ir a Profesores" onClick={() => this.handleToolButtonClick('labgestor')} />
        </div>

        <div className={classes.othermanagement}>
          <h1> Otros</h1>
          <p> Otras funcionalidades de Administrador
          </p>
          <p></p>
        <Button text="Aprobación de operadores" onClick={() => this.handleToolButtonClick('labgestor')} />
        <p></p>
        <Button text="Reestablecer contrseñas" onClick={() => this.handleToolButtonClick('labgestor')} />
        <p></p>
        <Button text="Generador de reportes" onClick={() => this.handleToolButtonClick('labgestor')} />
        </div>
        
        
      </div>
    );
  }
}

export default Operador;

