import React, { useState, useEffect } from 'react';
import { View, TouchableOpacity, Text, StyleSheet, ImageBackground,  Modal, FlatList, ScrollView } from 'react-native';
import DateTimePicker from '@react-native-community/datetimepicker';
import { Feather } from '@expo/vector-icons'; // Importa los iconos de Feather (o cualquier otra biblioteca de iconos)
import { db, insertarSolicitudes, insertarLaboratorio, insertarHorarios, obtenerInstanciasHorario, } from '../DataBase_SQLite/DBTables'; // Importa la función para verificar y crear la base de datos


const HomeScreen = ({ navigation, route }) => {
    const { email } = route.params;
    const user = email.split('@')[0];

    const [date, setDate] = useState(null);
    const [showDatePicker, setShowDatePicker] = useState(false);
    const [showLabPickerModal, setShowLabPickerModal] = useState(false);
    const [showInfoPickerModal, setShowInfoPickerModal] = useState(false);
    const [showTimePickerModal, setShowTimePickerModal] = useState(false);
    const [selectedTime, setSelectedTime] = useState(null);
    const [approve, setApprove] = useState(false);
    const [selectedLab, setSelectedLab] = useState(null);
    const [capacidad, setCapacidad] = useState();
    const [computadores, setCantidadComputadores] = useState();

    const [prestamosList, setPrestamosList] = useState([]);
    const [laboratorios, setLaboratorios] = useState([]);

    const [horas, setHoras] = useState([]);
    const [horasSinSolicitud, setHorasSinSolicitud] = useState([]);

    const [diaSemana, setDiaSemana] = useState('');
    const [horaApert, setHoraApert] = useState("");
    const [horadeCierre, setHoradeCierre] = useState("");


    const [loading, setLoading] = useState(true); // Nuevo estado para indicar si los datos están cargando

    const [availableTimes, setAvailableTimes] = useState([]);

    const [solicitudesActivoEstudiante, setSolicitudesActivoEstudiante] = useState([]);

    useEffect(() => {


        const fetchData = async () => {
            try {
                const response = await fetch(`http://192.168.100.56:5095/Profesor/SolicitudesPendientes?correoProfesor=${email}`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });
                const data = await response.json();
                setSolicitudesActivoEstudiante(data);
            } catch (error) {
                console.error('Error:', error);
            }
        };
    
        fetchData();
    }, []);

   
    useEffect(() => {
        if (showTimePickerModal) {
            generarListaHoras(horaApert, horadeCierre);
        }
    }, [showTimePickerModal, horaApert, horadeCierre]);

      useEffect(() => { 
        if (solicitudesActivoEstudiante.length > 0) {
            obtenerYProcesarLaboratorios();

            insertarSolicitudes(solicitudesActivoEstudiante, email); // Movido aquí
            obtenerSolicitudes();
        }
    }, [solicitudesActivoEstudiante]);

    useEffect(() => {
        obtenerHorasDisponibles();

      }, [date, selectedLab]);
    
    useEffect(() => {
        if (!loading) {
            obtenerHorasFiltradas(); 
        }
      }, [horas, loading]);
    
    const obtenerSolicitudes = () => {
        if (!solicitudesActivoEstudiante) return; // Verifica si date y selectedLab están definidos
        db.transaction(tx => {
          tx.executeSql(
            'SELECT nombre_estudiante || ", " || tipo_activo || ", " || id || ", " || placa AS numero FROM SOLICITUD_ACTIVO WHERE aprobado = 0 AND profesor = ?;', // Concatena los valores de nombre_estudiante y tipo_activo con una coma
            [email],
            (tx, results) => {
              const data = [];
              for (let i = 0; i < results.rows.length; ++i) {
                data.push(results.rows.item(i).numero); // Agrega la cadena concatenada a la lista de datos
              }
              setPrestamosList(data);
            },
            error => {
              console.error('Error al obtener las solicitudes:', error);
            }
          );
        });
      };

      const obtenerLaboratoriosCreados = async () => {
        try {
          const response = await fetch('http://192.168.100.56:5095/Laboratorio/MostrarNombreLabsDisponibles');
          const data = await response.json();
          return data;
        } catch (error) {
          console.error('Error al obtener los laboratorios disponibles:', error);
          throw error;
        }
      };

      const obtenerDetalleLaboratorio = async (nombreLab) => {
        try {
          const response = await fetch(`http://192.168.100.56:5095/Laboratorio/MostrarInformacionLab?nombreLab=${nombreLab}`);
          const data = await response.json();
          return data[0];
        } catch (error) {
          console.error(`Error al obtener el detalle del laboratorio ${nombreLab}:`, error);
          throw error;
        }
      };

      const obtenerHorarioOcupado = async (nombreLab) => {
        try {
          const response = await fetch(`http://192.168.100.56:5095/PrestamoLab/MostrarHorarioReservado?nombreLab=${nombreLab}`);
          const data = await response.json();
          return data;
        } catch (error) {
          console.error(`Error al obtener el detalle del laboratorio ${nombreLab}:`, error);
          throw error;
        }
      };

      const obtenerYProcesarLaboratorios = async () => {
        try {
          const laboratoriosDisponibles = await obtenerLaboratoriosCreados();
          for (const lab of laboratoriosDisponibles) {
            const detalleLab = await obtenerDetalleLaboratorio(lab);
            const horariosLab = await obtenerHorarioOcupado(lab);
            insertarLaboratorio(lab, detalleLab.Capacidad, detalleLab.Computadores);
            insertarHorarios(lab, horariosLab);
          }
        } catch (error) {
          console.error('Error al obtener y procesar los laboratorios:', error);
        }
        obtenerLaboratoriosDisponibles();

      };


      const obtenerLaboratoriosDisponibles = () => {
        db.transaction(tx => {
            tx.executeSql(
                'SELECT nombre_lab FROM LABORATORIO;',
                [],
                (tx, results) => {
                    const data = [];
                    for (let i = 0; i < results.rows.length; ++i) {
                        data.push(results.rows.item(i).nombre_lab);
                    }
                    setLaboratorios(data);
                },
                error => {
                    console.error('Error al obtener los laboratorios:', error);
                }
            );
        });
    };


    const obtenerHorarioLab = async (nombreLab) => {
        try {
          const response = await fetch(`http://192.168.100.56:5095/Horario/MostrarHorariosLab?nombreLab=${nombreLab}`);
          const data = await response.json();
          let res = [];
          if(diaSemana === 'L'){
            res = data[0];
          }
          if(diaSemana === 'K'){
            res = data[1];
          }
          if(diaSemana === 'M'){
            res = data[2];
          }
          if(diaSemana === 'J'){
            res = data[3];
          }
          if(diaSemana === 'V'){
            res = data[4];
          }
          setHoraApert(res.HoraApertura);
          setHoradeCierre(res.HoraCierre);
          }
           catch (error) {
          console.error(`Error al obtener el horario del laboratorio ${nombreLab}:`, error);
          throw error;
        }
      };
      const generarListaHoras = (horaApertura, horaCierre) => {
        const fechaApertura = new Date(`2024-05-06T${horaApertura}`);
        const fechaCierre = new Date(`2024-05-06T${horaCierre}`);
    
        const listaHoras = [];
    
        let horaActual = new Date(fechaApertura);
    
        while (horaActual <= fechaCierre) {
            let horaActualStr = horaActual.toLocaleTimeString('es-ES', { hour: '2-digit', minute: '2-digit', second: '2-digit' });
    
            if (parseInt(horaActualStr.split(",")[0]) < 10){
                horaActualStr = `0${horaActualStr}`;
            }
    
            listaHoras.push(horaActualStr);
    
            horaActual.setHours(horaActual.getHours() + 1);
        }
        setAvailableTimes(listaHoras);

    };


    const obtenerHorasFiltradas = () => {
                // Restar las horas disponibles de la lista availableTimes
        const filteredTimes = availableTimes.filter(time => !horas.includes(time));
        setHorasSinSolicitud(filteredTimes);

    };

    const obtenerHorasDisponibles = () => {
        if (!date || !selectedLab) return; // Verifica si date y selectedLab están definidos
        db.transaction(tx => {
            tx.executeSql(
                'SELECT hora FROM HORARIO WHERE fecha = ? AND nombre_lab = ?;',
                [date.toISOString().split('T')[0], selectedLab],
                (tx, results) => {
                    const horasDisponibles = [];
                    for (let i = 0; i < results.rows.length; i++) {
                        horasDisponibles.push(results.rows.item(i).hora);
                    }
                    setHoras(horasDisponibles);
                    setLoading(false); // Indica que los datos ya no están cargando
                },
                error => {
                    console.error('Error al obtener las horas disponibles:', error);
                }
            );
        });
    };

    const obtenerCapacidad = (nombreLab) => {
        db.transaction(tx => {
            tx.executeSql(
                'SELECT capacidad FROM LABORATORIO WHERE nombre_lab = ?;',
                [nombreLab],
                (tx, results) => {
                    if (results.rows.length > 0) {
                        const capacidad = results.rows.item(0).capacidad;
                        setCapacidad(capacidad);
                    } else {
                        console.warn('No se encontró información de capacidad para el laboratorio seleccionado');
                    }
                },
                error => {
                    console.error('Error al obtener la capacidad del laboratorio:', error);
                }
            );
        });
    };
    
    const obtenerCantidadComputadoras = (nombreLab) => {
        db.transaction(tx => {
            tx.executeSql(
                'SELECT computadores FROM LABORATORIO WHERE nombre_lab = ?;',
                [nombreLab],
                (tx, results) => {
                    if (results.rows.length > 0) {
                        const cantidadComputadoras = results.rows.item(0).computadores;
                        setCantidadComputadores(cantidadComputadoras);
                    } else {
                        console.warn('No se encontró información de cantidad de computadoras para el laboratorio seleccionado');
                    }
                },
                error => {
                    console.error('Error al obtener la cantidad de computadoras del laboratorio:', error);
                }
            );
        });
    };

    const backLogin = () => {
        navigation.navigate('Login');
    };

    const manageAccount = () => {
        navigation.navigate('Account', { email: email });
    };

    const handleDateChange = (event, selectedDate) => {
        if (event.type === 'set') {
            const currentDate = selectedDate || date;
            setDate(currentDate);
            const diasSemana = ['D', 'L', 'K', 'M', 'J', 'V', 'S'];
            setDiaSemana(diasSemana[currentDate.getDay()]);
            setShowDatePicker(false);
            setShowLabPickerModal(true);
        }
    };

    const handleLabPress = (lab) => {
        setSelectedLab(lab);
        setShowLabPickerModal(false);
        obtenerHorarioLab(lab);
        obtenerHorasFiltradas(date,lab);
        setTimeout(() => {
            setShowTimePickerModal(true);
        }, 1000);
    }

    const handleCaracteristicas = (lab) => {
        setShowLabPickerModal(false);
        setShowInfoPickerModal(true);
        obtenerCapacidad(lab);
        obtenerCantidadComputadoras(lab);
    }

    const regresarLabs = () => {
        setShowInfoPickerModal(false);
        setShowLabPickerModal(true);
    }


        const handleTimePress = (time) => {
            setSelectedTime(time);
            setShowTimePickerModal(false);
        
            db.transaction(tx => {
                tx.executeSql(
                    'INSERT INTO HORARIO (fecha, nombre_lab, hora) VALUES (?, ?, ?);',
                    [date.toISOString().split('T')[0], selectedLab, time],
                    (tx, results) => {
                        console.log('Hora seleccionada guardada en la tabla HORARIO:', results.rowsAffected);
        
                        // Aquí realizas la solicitud POST
                        const horaSeleccionada = time.split(":")[0];
                        const horaFinalSeleccionada = (parseInt(horaSeleccionada) + 1).toString() + ":00:00";
                        console.log(horaFinalSeleccionada);
        
                        // Realizar la solicitud POST aquí
                        fetch('http://192.168.100.56:5095/Laboratorio/ApartarLaboratorioProfesor', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            body: JSON.stringify({
                                correoProfesor: email,
                                nombreLab: selectedLab,
                                fecha: date.toISOString().split('T')[0],
                                horaInicio: time,
                                horaFinal: horaFinalSeleccionada
                            })
                        })
                        .then(response => {
                            if (!response.ok) {
                                throw new Error('Error al realizar la solicitud POST');
                            }
                            // Procesar la respuesta si es necesario
                        })
                        .catch(error => {
                            console.error('Error al realizar la solicitud POST:', error);
                            // Manejar el error si es necesario
                        });
                    },
                    error => {
                        console.error('Error al guardar la hora seleccionada:', error);
                    }
                );
            });
        
            console.log('Día seleccionado:', date.toISOString().split('T')[0]);
            console.log('Lab seleccionado:', selectedLab);
            console.log('Hora seleccionada:', time);
        };

    const threeWeeksFromNow = new Date();
    threeWeeksFromNow.setDate(threeWeeksFromNow.getDate() + 21); 

    const handleCheck = (idSolicitud, placaActivo) => {
        db.transaction(tx => {
          tx.executeSql(
            'UPDATE SOLICITUD_ACTIVO SET aprobado = ? WHERE id = ?;',
            [1, idSolicitud], 
            () => { 
              console.log(`Solicitud ${idSolicitud} aprobada exitosamente`);
            },
            error => { console.error('Error al aprobar la solicitud:', error); }
          );
        });
        obtenerSolicitudes();

        fetch(`http://192.168.100.56:5095/SolicitudActivo/AprobarSolicitudActivoId?id=${idSolicitud}&placa=${placaActivo}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
        })
            .then(response => {
            if (!response.ok) {
              throw new Error('Error al aceptar el activo');
            }
            // Procesar la respuesta si es necesario
          })
          .catch(error => {
            console.error('Error al aceptar el activo:', error);
            // Manejar el error si es necesario
          });
      };

    


    return (
        <ImageBackground source={require('../assets/homeBG.png')} style={styles.background}>
            <View style={styles.container}>
                <View style={styles.content}>
                    <View style={styles.formContainer}>
                        <Text style={styles.buttonText}>¡Bienvenido/a {user}!</Text>

                        <TouchableOpacity style={styles.button} onPress={() => setShowDatePicker(true)}>
                            <Text style={styles.buttonText}>Reservar laboratorio</Text>
                        </TouchableOpacity>
                        {showDatePicker && (
                            <DateTimePicker
                                mode={'date'}
                                value={date || new Date()}
                                minimumDate={new Date()}
                                maximumDate={threeWeeksFromNow} 
                                onChange={handleDateChange}
                            />
                        )
                        }

                        <Modal
                            visible={showLabPickerModal}
                            animationType="slide"
                            transparent={true}
                        >
                            <View style={styles.modalContainer}>
                                <View style={styles.modalContent2}>
                                    <View style={styles.header}>
                                        <Text style={styles.headerText}>Laboratorio</Text>
                                        <Text style={styles.headerText}>Características</Text>

                                    </View>
                                    <ScrollView>
                                    {laboratorios.map((item, index) => (
                                        <View style={styles.row} key={index}>
                                            <TouchableOpacity onPress={() => handleLabPress(item)}>
                                                <Text style={styles.column}>Laboratorio {item}</Text>
                                            </TouchableOpacity>
                                            <TouchableOpacity style={[styles.iconContainer, {marginRight:70}]} onPress={() => handleCaracteristicas(item)}>
                                                    <Feather name="info" size={24} color="black" />
                                                </TouchableOpacity>
                                        </View>
                                    ))}
                                    
                                    </ScrollView>
                                    <TouchableOpacity onPress={() => setShowLabPickerModal(false)}>
                                        <Text style={styles.modalClose2}>Cancelar</Text>
                                    </TouchableOpacity>
                                </View>
                            </View>
                        </Modal>
                        <Modal
                            visible={showInfoPickerModal}
                            animationType="slide"
                            transparent={true}
                        >
                            <View style={styles.modalContainer}>
                                <View style={styles.modalContent2}>
                                    <View style={styles.header}>
                                        <Text style={styles.headerText}>Características del laboratorio </Text>
                                        
                                    </View>
                                    <Text style={[styles.item, {marginTop:10}]}>Capacidad: {capacidad}</Text>
                                    <Text style={[styles.item, {marginBottom:20 }]}>Cantidad computadoras: {computadores}</Text>

                                    <TouchableOpacity onPress={() => regresarLabs()}>
                                        <Text style={styles.modalClose2}>Regresar</Text>
                                    </TouchableOpacity>
                                </View>
                            </View>
                        </Modal>


                        <Modal
                            visible={showTimePickerModal}
                            animationType="slide"
                            transparent={true}
                        >
                            <View style={styles.modalContainer}>
                                <View style={styles.modalContent}>
                                    <View style={styles.modalHeader}>
                                        <Text style={styles.modalHeaderText}>Seleccione una hora:</Text>
                                    </View>
                                    <FlatList
                                        data={horasSinSolicitud}
                                        keyExtractor={(item) => item}
                                        renderItem={({ item }) => (
                                            <TouchableOpacity onPress={() => handleTimePress(item)}>
                                                <Text style={styles.item}>{item.split(':')[0] + ':' + item.split(':')[1] }</Text>
                                            </TouchableOpacity>
                                        )}
                                    />
                                    <TouchableOpacity onPress={() => setShowTimePickerModal(false)}>
                                        <Text style={styles.modalClose}>Cancelar</Text>
                                    </TouchableOpacity>
                                </View>
                            </View>
                        </Modal>


                        <TouchableOpacity style={styles.button} onPress={() => setApprove(true)}>
                            <Text style={styles.buttonText}>Aprobar préstamos de activos</Text>
                        </TouchableOpacity>
                        
                        <Modal
                            visible={approve}
                            animationType="slide"
                            transparent={true}
                        >
                            <View style={styles.modalContainer}>
                                <View style={styles.modalContent2}>
                                    <View style={styles.header}>
                                        <Text style={styles.headerText}>Estudiante</Text>
                                        <Text style={styles.headerText}>Activo</Text>
                                        <Text style={styles.headerText}></Text>


                                    </View>
                                    <ScrollView>
                                    {prestamosList.map((item, index) => (
                                        <View style={styles.row} key={index}>
                                            <Text style={styles.column}>{item.split(',')[0]}</Text>
                                            <Text style={styles.column}>{item.split(',')[1]}</Text>
                                            <TouchableOpacity style={styles.iconContainer} onPress={() => handleCheck(item.split(',')[2], item.split(',')[3])}>
                                                <Feather name="check-circle" size={20} color="green" />
                                            </TouchableOpacity>
                                        </View>
                                    ))}
                                    
                                    </ScrollView>
                                    <TouchableOpacity onPress={() => setApprove(false)}>
                                        <Text style={styles.modalClose2}>Cancelar</Text>
                                    </TouchableOpacity>
                                </View>
                            </View>
                        </Modal>
                    </View>
                </View>
                <View style={styles.bottomBar}>
                    <TouchableOpacity style={styles.buttonL} onPress={backLogin}>
                        <Text style={styles.buttonText}>Cerrar sesión</Text>
                    </TouchableOpacity>
                    <TouchableOpacity style={styles.buttonR} onPress={manageAccount}>
                        <Text style={styles.buttonText}>Administrar cuenta</Text>
                    </TouchableOpacity>
                </View>
            </View>
        </ImageBackground>
    );
};

const styles = StyleSheet.create({
    background: {
        flex: 1,
        resizeMode: 'cover', // Opcional, para ajustar la imagen de fondo a la pantalla
        justifyContent: 'center',
        backgroundColor: 'rgba(0,0,0,0.1)', // Opacidad del 80%
    },
    container: {
        flex: 1,
    },
    content: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },
    formContainer: {
        backgroundColor: 'rgba(0,0,0,0.5)', // Color de fondo semi-transparente
        borderRadius: 10,
        padding: 20,
        width: '90%',
        maxWidth: 400,
        justifyContent: 'center', // Centrar verticalmente
        alignItems: 'center', // Centrar horizontalmente
    },
    bottomBar: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        height: 55,
        backgroundColor: '#151a24', // Color de fondo de la barra inferior
    },
    buttonL: {
        flex: 1,
        height: 55,
        justifyContent: 'center',
        alignItems: 'center',
        borderRightWidth: 0.5,
        borderRightColor: 'white',
        backgroundColor: '#151a24', // Color de fondo del botón
    },
    buttonR: {
        flex: 1,
        height: 55,
        justifyContent: 'center',
        alignItems: 'center',
        borderLeftWidth: 0.5,
        borderLeftColor: 'white',
        backgroundColor: '#151a24', // Color de fondo del botón
    },
    button: {
        backgroundColor: '#4988af', // Color de fondo del botón
        width: 300,
        borderRadius: 5,
        paddingVertical: 10,
        paddingHorizontal: 15,
        alignItems: 'center',
        marginTop: 10,
        marginBottom: 20,
    },
    buttonText: {
        color: '#ffffff', // Color del texto del botón
        fontSize: 16,
    },
    modalContainer: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: 'rgba(0, 0, 0, 0.5)',
    },
    modalContent: {
        backgroundColor: 'white',
        borderRadius: 5,
        width: '80%',
        maxHeight: 300,
        marginTop: 40, // Ajusta el margen superior para que no se solape con el encabezado
    },
    modalHeader: {
        backgroundColor: '#1c73b4',
        padding: 15,
        borderTopLeftRadius: 5,
        borderTopRightRadius: 5,
    },
    modalHeaderText: {
        color: '#ffffff',
        fontSize: 20,
        textAlign: 'left',
        fontWeight: '400',
    },

    item: {
        fontSize: 18,
        marginTop: 25,
        fontWeight: '300',
        textAlign: 'center',
    },
    modalClose: {
        fontSize: 18,
        color: '#1c73b4',
        textAlign: 'center',
        marginTop: 15,
        marginBottom: 15,
        fontWeight: '500',
    },
    modalContent2: {
        backgroundColor: 'white',
        borderRadius: 5,
        padding: 20,
        width: '95%',
        maxHeight: 300,
    },
    header: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        marginBottom: 10,
    },
    headerText: {
        fontWeight: '500',
        fontSize: 20,
        flex: 1,
        textAlign: 'center',
        color: '#1c73b4',

    },
    row: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        marginBottom: 20,
        textAlign: 'center',
    },
    column: {
        flex: 1,
        textAlign: 'left',
        fontWeight: '400',
        fontSize: 15,
        marginLeft: 10,

    },
    iconContainer: {
        justifyContent: 'center',
        alignItems: 'left',
        width: 30,
        marginRight: 50,
    },
    modalClose2: {
        fontSize: 18,
        color: '#1c73b4',
        textAlign: 'center',
        fontWeight: '500',
    },
});

export default HomeScreen;
