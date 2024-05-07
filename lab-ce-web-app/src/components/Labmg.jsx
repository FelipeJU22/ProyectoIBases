import DataTable from "react-data-table-component";
import { useEffect, useState } from "react";
import LabOption from "./profesor/LabOption";
import CalendarComponent from "./profesor/CalendarComponent";
import TimeSelector from "./profesor/TimeSelector";
import classes from './AdminHome.module.css'; // Import CSS file for styling
import { Link } from 'react-router-dom';

const Header = ({ adminName }) => {
  return (
    <div className={classes.toptobottom}>
      <h1>Gestor de Laboratorios de {adminName}</h1>
    </div>
  );
};


const Button = ({ text, Click }) => {
  return (
    <button className={classes.btn} onClick={() => enroute(Click)}>{text}</button>
  );
};

function Labs() {
    const API_URL = 'http://localhost:5095'
    const INFO_LAB_EP = '/Laboratorio/MostrarInformacionLab?nombreLab='
    const CURRENT_LABS_EP = '/Laboratorio/MostrarNombreLabsDisponibles'
    const LAB_SCHEDULE_EP = '/Horario/MostrarHorariosLab?nombreLab='
    const LAB_RESERVATION_EP = '/Laboratorio/ApartarLaboratorioProfesor'
    const LAB_FACILITIES = '/Laboratorio/MostrarFacilidades?nombreLab='
    const LAB_ACTIVES = '/Laboratorio/MostrarActivosLab?nombreLab='

    const usuarioProfesor = 'jleiton@itcr.com'

    const [data, setData] = useState([]);
    const [selectedLab, setSelectedLab] = useState('');
    const [selectedDate, setSelectedDate] = useState(null);
    const [selectedTime, setSelectedTime] = useState(null);
    const [weekSchedule, setWeekSchedule] = useState([]);
    const [facilities, setFacilities] = useState([]);
    const [actives, setActives] = useState([]);
    const [hourScheduleArray, sethourScheduleArray] = useState([]);

    const [showCalendar, setShowCalendar] = useState(false);
    const [showTime, setShowTime] = useState(false);

    const goBack = () => navigate(-1);

    const [isVisible, setIsVisible] = useState(true);
    const [isVisible2, setIsVisible2] = useState(true);

      const requestOptions = {
          method: 'GET',
          headers: { 'Content-Type': 'application/json' },
      };
    async function fetchPosts(labName) {
          const response = await fetch(API_URL + LAB_FACILITIES + labName, requestOptions)
          const resData = await response.json();
          console.log(resData)
          setFacilities(resData)
      }

      async function fetchActives(labName) {
        const response = await fetch(API_URL + LAB_ACTIVES + labName, requestOptions)
        const resData = await response.json();
        console.log(resData)
        setActives(resData)
    }


    async function fetchSchedule(labName) {
      const response = await fetch(API_URL + LAB_SCHEDULE_EP + labName, requestOptions)
      const resData = await response.json();
      console.log(resData)
      setWeekSchedule(resData)
  }

    const toggleVisibility = () => {
      fetchSchedule(data[2].nombre);
      fetchActives(data[0].nombre);
      fetchPosts(data[0].nombre);
      setIsVisible(!isVisible);
      setIsVisible2(true);
    };
    const toggleVisibility2 = () => {
      fetchActives(data[1].nombre);
      fetchPosts(data[1].nombre);
      setIsVisible2(!isVisible2);
      setIsVisible(true);
    }
    

    useEffect(() => {
        async function fetchDataAndLabs() {
            fetchLabs();
        }
        fetchDataAndLabs();
    }, []);


    useEffect(() => {
        setShowCalendar(selectedLab !== "");
    }, [selectedLab]);

    function handleSelectedLab(labName) {
        console.log("LAB_NAME", labName)
        setSelectedLab(labName)
        fetchLabSchedule(labName)
    }

    const handleDateSelect = (date) => {
        const dayAbbreviation = date.toString().split(' ')[0];
        let selectedDay = translateDayAbbreviation(dayAbbreviation)
        getDaySchedule(selectedDay);

        setSelectedDate(formatDate(date));
        setShowTime(true)
    };

    const handleTimeSelect = (time) => {
        setSelectedTime(formatTime(time));
    };

    useEffect(() => {
        if (showTime) {
            LabReservation()
        }
        setSelectedLab('')
        setShowCalendar(false)
        setShowTime(false)
        console.log('Time UPDATED', selectedTime)
        console.log('Date', selectedDate)
    }, [selectedTime]);

    function getDaySchedule(dayToSchedule) {
        console.log(weekSchedule);
        for (let i = 0; i < weekSchedule.length; i++) {
            const day = weekSchedule[i];
            //console.log('Day: ', daysSchedule)
            if (day.Dia === dayToSchedule) {
                sethourScheduleArray(generateHourArray(day.HoraApertura, day.HoraCierre))
                console.log(hourScheduleArray);
            }
        }
    }

    function generateHourArray(initialHour, closingHour) {
        const hoursArray = [];
        const [initialHourValue, initialMinuteValue] = initialHour.split(':');
        const initialDate = new Date(`2000-01-01T${initialHourValue}:${initialMinuteValue}`);
        const closingDate = new Date(`2000-01-01T${closingHour}`);

        // Add initial hour to the array
        hoursArray.push(`${initialHourValue}:${initialMinuteValue}`);

        // Generate hours between initial and closing hour
        let currentHour = new Date(initialDate);
        while (currentHour < closingDate) {
            currentHour.setHours(currentHour.getHours() + 1);
            const hourString = currentHour.toTimeString().slice(0, 5);
            console.log(hourString)
            hoursArray.push(hourString);
        }

        return hoursArray;
    }


    function translateDayAbbreviation(dayAbbreviation) {
        const dayMappings = {
            "Mon": "L", // Lunes
            "Tue": "K", // Martes
            "Wed": "M", // Miércoles
            "Thu": "J", // Jueves
            "Fri": "V", // Viernes
            "Sat": "S", // Sábado
            "Sun": "D"  // Domingo
        };

        // Extract the day abbreviation from the given string
        const regex = /([A-Za-z]{3})/;
        const matches = dayAbbreviation.match(regex);
        if (matches && matches.length > 1) {
            const day = matches[1];
            // Retrieve the corresponding Spanish first letter from the mapping
            return dayMappings[day] || "";
        }
        return "";
    }

    function formatDate(inputDate) {
        const dateObj = new Date(inputDate);
        const year = dateObj.getFullYear();
        const day = String(dateObj.getDate()).padStart(2, '0');
        const month = String(dateObj.getMonth() + 1).padStart(2, '0'); // Adding 1 to get the month as 1-indexed

        return `${year}-${month}-${day}`;
    }

    function formatTime(originalTime) {
        const [hours, minutes] = originalTime.split(':');
        const formattedHours = String(hours).padStart(2, '0');
        const formattedMinutes = String(minutes).padStart(2, '0');

        return `${formattedHours}:${formattedMinutes}:00`;
    }

    async function LabReservation() {
        try {
            const body = {
                correoProfesor: usuarioProfesor,
                nombreLab: selectedLab,
                fecha: selectedDate,
                horaInicio: selectedTime,
                horaFinal: "00:00:00"
            }
            const requestBody = {
                method: 'POST',
                body: JSON.stringify(body),
                headers: {
                    'Content-Type': 'application/json',
                }
            }

            console.log('BODY: ', body)

            const response = await fetch(API_URL + LAB_RESERVATION_EP, requestBody);
            const jsonResp = await response.text();
            console.log('New Reservation!!!', jsonResp)
        } catch (error) {
            console.error('Error reservating lab:', error);
        }
    };

    async function fetchLabSchedule(labName) {
        try {
            const response = await fetch(API_URL + LAB_SCHEDULE_EP + labName);
            const jsonResp = await response.json();
            setWeekSchedule(jsonResp);
        } catch (error) {
            console.error('Error fetching labs:', error);
        }
    };

    async function fetchLabFacilities(labName){
      try {
        const response = await fetch(API_URL + LAB_FACILITIES + labName);
        const jsonResp = await response.json();
        setFacilities(jsonResp);
      } catch (error) {
        console.error('Error getting facilities', error);
      }
    }

    async function fetchLabs() {
        try {
            const response = await fetch(API_URL + CURRENT_LABS_EP);
            const currentLabs = await response.json();
            await fetchData(currentLabs)
            console.log('Labs Loaded!')
        } catch (error) {
            console.error('Error fetching labs:', error);
        }
    };

    async function fetchData(availableLabs) {
        try {
            console.log('Bringing labs info')
            console.log('Based on LABS: ', availableLabs)
            let values = []
            for (let i = 0; i < availableLabs.length; i++) {
                const lab = availableLabs[i];
                console.log('Fetching Data...')
                const response = await fetch(API_URL + INFO_LAB_EP + lab);
                let jsonData = await response.json();
                jsonData[0].nombre = availableLabs[i]
                values.push(jsonData[0])
            }
            setData(values)
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    return (
      <div className={classes.mainadminpage}>
           
      <Header adminName="Administrador"/>

      {isVisible2? (
      <div className={classes.managementtools}>

{data.map((item, index) => {
                        if (index == 0) {

                            return (
                              <div>
                              <h1> {item.nombre}</h1>
                              <p></p>
                              <h2> Capacidad {item.Capacidad} personas</h2>
                              <p></p>
                              <h2> </h2>
                              <h2> Posee {item.Computadores} Computadores</h2>
                              <p></p>
                              <h2></h2>
                              </div>
                            )
                        }
                        else {
                            return (null)
                        }
                    }
                    )}
        {!isVisible? (
        <button className={classes.btn} onClick> Cambiar capacidad</button>
           ) : null}
        <button className={classes.btn} onClick={toggleVisibility}> {isVisible ? "Ampliar información" : "Volver"}</button>
      </div>
      ) : null}

      {isVisible && isVisible2 ? (
      <div className={classes.actmanagement}>
        {data.map((item, index) => {
                        if (index == 1) {

                            return (
                              <div>
                              <h1> {item.nombre}</h1>
                              <p></p>
                              <h2> Capacidad {item.Capacidad} personas</h2>
                              <p></p>
                              <h2> </h2>
                              <h2> Posee {item.Computadores} Computadores</h2>
                              <p></p>
                              <h2></h2>
                              </div>
                            )
                        }
                        else {
                            return (null)
                        }
                    }
                    )}
        <button className={classes.btn} onClick={toggleVisibility2}> Ampliar información</button>
      </div>
      ) : null}
    {isVisible && isVisible2 ?(
      <div className={classes.profmanagement}>
        {data.map((item, index) => {
                        if (index == 2) {

                            return (
                              <div>
                              <h1> {item.nombre}</h1>
                              <p></p>
                              <h2> Capacidad {item.Capacidad} personas</h2>
                              <p></p>
                              <h2> </h2>
                              <h2> Posee {item.Computadores} Computadores</h2>
                              <p></p>
                              <h2></h2>
                              </div>
                            )
                        }
                        else {
                            return (null)
                        }
                    }
                    )}
        <button className={classes.btn} onClick={toggleVisibility2}> Ampliar información</button>
      </div>
    ) : null}
    {!isVisible || !isVisible2 ? (
      <div>
      <div className={classes.moreinfo}>
       <div className={classes.line}> 
        <h2> Facilidades </h2>
        <div>
          <br></br>
        <ul>
                {facilities.map((ide) => 
                <h2> {ide}</h2>)}
            </ul>
            </div>
       </div>
       <div className={classes.line}> 
        <h2> Activos </h2>

        <div>
          <br></br>
        <ul>
                {actives.map((ide) => 
                <div>
                <h2> {ide.Placa}</h2>
                <h2> {ide.Tipo}</h2>
                </div>
              )
                
                }
            </ul>
            </div>
       </div>
       <div className={classes.line}> 
        <h2> Horarios </h2>
        <div>
          <br></br>
        <ul>
                {weekSchedule.map((ide) => 
                <div>
                <h2> {ide.Fecha}</h2>
                <h2> {ide.HoraApertura}</h2>
                </div>
              )
                
                }
            </ul>
            </div>

        

       </div>
    </div>
    <div className={classes.line2}>
    <button className={classes.btn}> Modificar</button>
    <button className={classes.btn}> Ver facilidades</button>
    <button className={classes.btn}> Ver Activos</button>
    <button className={classes.btn}> Ver horarios</button>
    </div>
    </div>
    ) : null}
    {isVisible && isVisible2 ?(
      <div className={classes.othermanagement}>
        <h1> Otros</h1>
        <Link to='/admin'>
        <Button text="Página principal"/>
        </Link>
        <Link to='/admin/actmg'>
        <Button text="Gestor de Activos"/>
        </Link>
        <Link to='/admin/profmg'>
        <Button text="Gestor de profesores" Click={1} />
        </Link>
        <Link to='/'>
        <Button text="Cerrar sesión" Click={1} />
        </Link>
      </div>
      ) : null}
    
    {!isVisible2? (
      <div className={classes.managementtools}>
         {data.map((item, index) => {
                        if (index == 2) {

                            return (
                              <div>
                              <h1> {item.nombre}</h1>
                              <p></p>
                              <h2> Capacidad {item.Capacidad} personas</h2>
                              <p></p>
                              <h2> </h2>
                              <h2> Posee {item.Computadores} Computadores</h2>
                              <p></p>
                              <h2></h2>
                              </div>
                            )
                        }
                        else {
                            return (null)
                        }
                    }
                    )}
        {!isVisible2? (
        <button className={classes.btn} onClick> Cambiar capacidad</button>
           ) : null}
        <button className={classes.btn} onClick={toggleVisibility2}> Volver</button>
      </div>
      ) : null}

      
    </div>
  );
}


export default Labs;