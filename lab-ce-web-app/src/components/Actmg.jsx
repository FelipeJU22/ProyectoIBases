import React from 'react';
import classes from './AdminHome.module.css'; // Import CSS file for styling
import imageSrc from '../img/lab.jpg';
import activeSrc from '../img/activos.jpg';
import profSrc from '../img/prof.jpg';


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

class Actmg extends React.Component {
  

  render() {
    return (
      <div className={classes.mainadminpage}>
        <Header adminName="Administrador" />
        <div className={classes.managementtools}>
          <h1> Laboratorio de mediciones</h1>
          <h2> Capacidad {"10"} personas</h2>
          <h2> Posee {10} computadores</h2>
          <h2> Posee {2} facilidades</h2>
          <h2> Posee {5} activos</h2>
          <Button text="Ampliar información" Click={1} />
        </div>
        <div className={classes.actmanagement}>
          <h1> Laboratorio de computadores 1</h1>
          <h2> Capacidad {"10"} </h2>
          <h2> Posee {10} computadores</h2>
          <h2> Posee {2} facilidades</h2>
          <h2> Posee {5} activos</h2>
          <Button text="Ampliar información" Click={1} />
        </div>
        <div className={classes.profmanagement}>
          <h1> Laboratorio de mediciones</h1>
          <h2> Capacidad {"10"} personas</h2>
          <h2> Posee {10} computadores</h2>
          <h2> Posee {2} facilidades</h2>
          <h2> Posee {5} activos</h2>
          <Button text="Ampliar información" Click={1} />
        </div>
        <div className={classes.othermanagement}>
          <h1> Otros</h1>
          <Button text="Página principal" Click={1} />
          <Button text="Gestor de Laboratorios" Click={1} />
          <Button text="Gestor de profesores" Click={1} />
          <Button text="Cerrar sesión" Click={1} />
        </div>


        
      </div>
    );
  }
}

export default Actmg;
