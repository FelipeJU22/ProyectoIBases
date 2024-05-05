import DataTable from "react-data-table-component";
import { useEffect, useState } from "react";
import LabOption from "./LabOption";
import CalendarComponent from "./CalendarComponent";
import TimeSelector from "./TimeSelector";

function Labs() {
    const API_URL = 'http://localhost:5095'
    const INFO_LAB_EP = '/Laboratorio/MostrarInformacionLab?nombreLab='
    const AVAILABLE_LABS = ['F2-06', 'F2-07', 'F2-08', 'F2-09']

    const [selectedDate, setSelectedDate] = useState(null);
    const [selectedTime, setSelectedTime] = useState(null);

    const [data, setData] = useState([]);
    const [selectedLab, setSelectedLab] = useState('');
    const [showCalendar, setShowCalendar] = useState(false)
    const [showTime, setShowTime] = useState(false)


    useEffect(() => {
        fetchData();
    }, []);

    useEffect(() => {
        setShowCalendar(selectedLab !== "");
    }, [selectedLab]);


    useEffect(() => {
        console.log('DATA UPDATED', data)
    }, [data]);

    function handleSelectedLab(labName) {
        console.log("LABNAME", labName)
        setSelectedLab(labName)
    }

    const handleDateSelect = (date) => {
        setSelectedDate(date);
        setShowTime(true)
    };

    const handleTimeSelect = (time) => {
        setSelectedTime(time);
    };

    useEffect(() => {
        setSelectedLab('')
        setShowCalendar(false)
        setShowTime(false)
        console.log('Time UPDATED', selectedTime)
        console.log('Date', selectedDate)
    }, [selectedTime]);

    async function fetchData() {
        try {
            let values = []
            for (let i = 0; i < AVAILABLE_LABS.length; i++) {
                const lab = AVAILABLE_LABS[i];
                console.log('Fetching Data...')
                const response = await fetch(API_URL + INFO_LAB_EP + lab);
                let jsonData = await response.json();
                jsonData[0].nombre = AVAILABLE_LABS[i]
                values.push(jsonData[0])

            }
            setData(values)
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    return (
        <div>
            <h2>Labs</h2>
            <table>
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Capacidad</th>
                        <th>Computadores</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {data.map((item, index) => {
                        if (selectedLab == item.nombre || selectedLab == "") {

                            return (
                                <LabOption
                                    key={index}
                                    nombre={item.nombre}
                                    capacidad={item.Capacidad}
                                    computadores={item.Computadores}
                                    selected={selectedLab}
                                    onSetLabName={handleSelectedLab}
                                />
                            )
                        }
                        else {
                            return (null)
                        }


                    }
                    )}
                </tbody>
            </table>

            <div style={{
                opacity: showCalendar ? 1 : 0,
                transition: 'opacity 0.5s ease-in-out'
            }}>
                {showCalendar && (
                    <div>
                        <h2>Seleccionar fecha</h2>
                        <CalendarComponent onSelectDate={handleDateSelect} />
                    </div>
                )}
            </div>

            <div style={{
                opacity: showTime ? 1 : 0,
                transition: 'opacity 0.5s ease-in-out'
            }}>
                {showTime && (
                    <div>
                        <h2>Seleccionar Hora</h2>
                        <TimeSelector onTimeSelect={handleTimeSelect} />
                    </div>
                )}
            </div>
        </div>
    )
}

export default Labs;
