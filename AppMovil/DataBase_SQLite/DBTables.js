import * as SQLite from 'expo-sqlite';
import md5 from 'md5';


// Abre la base de datos SQLite
const db = SQLite.openDatabase('mi_base_de_datos.db');

// Función para crear la base de datos y las tablas si no existen
const createDatabase = () => {
  db.transaction(tx => {
    // Crear tabla PROFESOR si no existe
    tx.executeSql(
      'CREATE TABLE IF NOT EXISTS PROFESOR (' +
      'correo TEXT PRIMARY KEY,' +
      'password TEXT NOT NULL' +
      ');',
      [],
      () => { console.log('Tabla PROFESOR creada exitosamente'); },
      error => { console.error('Error al crear la tabla PROFESOR:', error); }
    );

    // Crear tabla SOLICITUD_ACTIVO si no existe
    tx.executeSql(
        'CREATE TABLE IF NOT EXISTS SOLICITUD_ACTIVO (' +
        'id INTEGER PRIMARY KEY,' +
        'nombre_estudiante TEXT NOT NULL,' +
        'tipo_activo TEXT NOT NULL,' +
        'aprobado BOOLEAN DEFAULT 0,' + // Nuevo campo "aprobado"
        'placa TEXT NOT NULL,' +
        'profesor TEXT NOT NULL,' +
        'FOREIGN KEY (profesor) REFERENCES PROFESOR(correo)' +
        ');',
        [],
        () => { console.log('Tabla SOLICITUD_ACTIVO creada exitosamente"'); },
        error => { console.error('Error al crear la tabla SOLICITUD_ACTIVO ":', error); }
      );

    // Crear tabla LABORATORIO si no existe
    tx.executeSql(
      'CREATE TABLE IF NOT EXISTS LABORATORIO (' +
      'nombre_lab TEXT PRIMARY KEY,' +
      'capacidad INTEGER NOT NULL,' +
      'computadores INTEGER NOT NULL' +
      ');',
      [],
      () => { console.log('Tabla LABORATORIO creada exitosamente'); },
      error => { console.error('Error al crear la tabla LABORATORIO:', error); }
    );

    // Crear tabla HORARIO si no existe
    tx.executeSql(
      'CREATE TABLE IF NOT EXISTS HORARIO (' +
      'id INTEGER PRIMARY KEY AUTOINCREMENT,' +
      'nombre_lab TEXT NOT NULL,' +
      'fecha TEXT NOT NULL,' +
      'hora TEXT NOT NULL,' +
      'FOREIGN KEY (nombre_lab) REFERENCES LABORATORIO(nombre_lab)' +
      ');',
      [],
      () => { console.log('Tabla HORARIO creada exitosamente'); },
      error => { console.error('Error al crear la tabla HORARIO:', error); }
    );
  });
};

// Verificar si la base de datos ya existe y crearla si no
const crearBaseDeDatos = () => {
  db.transaction(tx => {
    // Consultar si existen las tablas
    tx.executeSql(
      "SELECT name FROM sqlite_master WHERE type='table' AND name IN ('PROFESOR', 'SOLICITUD_ACTIVO', 'LABORATORIO', 'HORARIO')",
      [],
      (tx, results) => {
        // Si no se encuentran las tablas, crear la base de datos
        if (results.rows.length !== 4) {
          createDatabase();
        } else {
          console.log('La base de datos y las tablas ya existen');
        }
      },
      error => {
        console.error('Error al verificar las tablas de la base de datos:', error);
      }
    );
  });
};

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

const insertarProfesores = (listaProfesores) => {
  db.transaction(tx => {
    // Itera sobre la lista de profesores
    listaProfesores.forEach(profesor => {
      tx.executeSql(
        'SELECT * FROM PROFESOR WHERE correo = ?;',
        [profesor.Correo],
        (tx, results) => {
          if (results.rows.length === 0) {
            tx.executeSql(
              'INSERT INTO PROFESOR (correo, password) VALUES (?, ?);',
              [profesor.Correo, profesor.Password],
              () => { console.log(`Profesor ${profesor.Correo} agregado exitosamente`); },
              error => { console.error(`Error al agregar ${profesor.Correo}:`, error); }
            );
          } else {
            console.log(`El profesor ${profesor.Correo} ya existe`);
          }
        },
        error => {
          //console.error(`Error al verificar si existe ${profesor.Correo}:`, error);
        }
      );
    });
  });
};


const insertarSolicitudes = (listaSolicitudes, correoProfe) => {
  db.transaction(tx => {
    listaSolicitudes.forEach(solicitud => {
      tx.executeSql(
        'SELECT * FROM SOLICITUD_ACTIVO WHERE id = ?;',
        [solicitud.IdActivo],
        (tx, results) => {
          if (results.rows.length === 0) {
            tx.executeSql(
              'INSERT INTO SOLICITUD_ACTIVO (id, nombre_estudiante, tipo_activo, aprobado, placa, profesor) VALUES (?, ?, ?, ?, ?, ?);',
              [solicitud.IdActivo, `${solicitud.NombreEstudiante} ${solicitud.Apellido1Estudiante}`, solicitud.Tipo, 0, solicitud.PlacaActivo, correoProfe],
              //() => { console.log(`Solicitud activo ${solicitud.IdActivo} agregada exitosamente`); },
              //error => { console.error(`Error al agregar solicitud activo ${solicitud.IdActivo}:`, error); }
            );
          } else {
            //console.log(`La solicitud activo ${solicitud.IdActivo} ya existe`);
          }
        },
        error => {
          //console.error(`Error al verificar si existe la solicitud activo ${solicitud.IdActivo}:`, error);
        }
      );
    });
  });
};


const insertarLaboratorio = (nombreLab, capacidad, computadores) => {
  db.transaction(tx => {
      tx.executeSql(
        'SELECT * FROM LABORATORIO WHERE nombre_lab = ?;',
        [nombreLab],
        (tx, results) => {
          if (results.rows.length === 0) {
            tx.executeSql(
              'INSERT INTO LABORATORIO (nombre_lab, capacidad, computadores) VALUES (?, ?, ?);',
              [nombreLab, capacidad, computadores],
              //() => { console.log(`Laboratorio ${nombreLab} agregado exitosamente`); },
              //error => { console.error(`Error al agregar laboratorio ${nombreLab}:`, error); }
            );
          } else {
            //console.log(`El laboratorio ${nombreLab} ya existe`);
          }
        },
        error => {
          //console.error(`Error al verificar si existe laboratorio ${nombreLab}:`, error);
        }
      );
    
  });
};


const insertarHorarios = (nombreLab, listaHorarios) => {
  db.transaction(tx => {
    listaHorarios.forEach(horario => {
      tx.executeSql(
        'SELECT * FROM HORARIO WHERE nombre_lab = ? AND fecha = ? AND hora = ?;',
        [nombreLab, horario.Fecha, horario.HoraInicio],
        (tx, results) => {
          if (results.rows.length === 0) {
            tx.executeSql(
              'INSERT INTO HORARIO (nombre_lab, fecha, hora) VALUES (?, ?, ?);',
              [nombreLab, horario.Fecha, horario.HoraInicio],
              //() => { console.log(`Horario agregado exitosamente`); },
              //error => { console.error(`Error al agregar horario:`, error); }
            );
          } else {
            //console.log(`El horario ya existe`);
          }
        },
        error => {
          //console.error(`Error al verificar si existe horario:`, error);
        }
      );
    });
  });
};

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

const cambiarContraseña = (correo, nuevaContraseña) => {
  return new Promise((resolve, reject) => {
    db.transaction(tx => {
      tx.executeSql(
        'UPDATE PROFESOR SET password = ? WHERE correo = ?;',
        [nuevaContraseña, correo],
        () => { 
          console.log('Contraseña cambiada exitosamente');
          resolve();
        },
        error => {
          console.error('Error al cambiar la contraseña:', error);
          reject(error);
        }
      );
    });
  });
};

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------


  const borrarBaseDeDatos = () => {
    db.transaction(tx => {
      tx.executeSql(
        'DROP TABLE IF EXISTS PROFESOR; DROP TABLE IF EXISTS SOLICITUD_ACTIVO; DROP TABLE IF EXISTS LABORATORIO; DROP TABLE IF EXISTS HORARIO;',
        [],
        () => { console.log('Base de datos borrada exitosamente'); },
        error => { console.error('Error al borrar la base de datos:', error); }
      );
    });
  };

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

const crearLaboratorios = () => {
  db.transaction(tx => {
    const laboratorios = [
      ['F2-01', 30, 20],
      ['F2-02', 30, 20],
      ['F2-03', 30, 20],
      ['F2-04', 30, 20]
    ];

    laboratorios.forEach(laboratorio => {
      const [nombre_lab, capacidad, computadores] = laboratorio;
      tx.executeSql(
        'SELECT * FROM LABORATORIO WHERE nombre_lab = ?;',
        [nombre_lab],
        (tx, results) => {
          if (results.rows.length === 0) {
            tx.executeSql(
              'INSERT INTO LABORATORIO (nombre_lab, capacidad, computadores) VALUES (?, ?, ?);',
              [nombre_lab, capacidad, computadores],
              () => { console.log(`Laboratorio ${nombre_lab} creado exitosamente`); },
              error => { console.error(`Error al crear el laboratorio ${nombre_lab}:`, error); }
            );
          } else {
            console.log(`El laboratorio ${nombre_lab} ya existe`);
          }
        },
        error => {
          console.error(`Error al verificar si existe el laboratorio ${nombre_lab}:`, error);
        }
      );
    });
  });
};
  const obtenerInstanciasHorario = () => {
    db.transaction(tx => {
        tx.executeSql(
            'SELECT * FROM HORARIO;',
            [],
            (tx, results) => {
                for (let i = 0; i < results.rows.length; i++) {
                    const instancia = results.rows.item(i);
                    console.log(instancia);
                }
            },
            error => {
                console.error('Error al obtener las instancias de HORARIO:', error);
            }
        );
    });
};
const obtenerInstanciasProfesor = () => {
  db.transaction(tx => {
    tx.executeSql(
      'SELECT * FROM PROFESOR;',
      [],
      (tx, results) => {
        console.log('Instancias de profesores:');
        for (let i = 0; i < results.rows.length; i++) {
          const instancia = results.rows.item(i);
          console.log(instancia);
        }
      },
      error => {
        console.error('Error al obtener las instancias de PROFESOR:', error);
      }
    );
  });
};

const obtenerInstanciasLaboratorio = () => {
  db.transaction(tx => {
    tx.executeSql(
      'SELECT * FROM LABORATORIO;',
      [],
      (tx, results) => {
        console.log('Instancias de labs:');
        for (let i = 0; i < results.rows.length; i++) {
          const instancia = results.rows.item(i);
          console.log(instancia);
        }
      },
      error => {
        console.error('Error al obtener las instancias de LABORATORIO:', error);
      }
    );
  });
};


//----------------------------------------------------------------------------
//----------------------------------------------------------------------------



const borrarSolicitudes = () => {
  db.transaction(tx => {
    tx.executeSql(
      'DELETE FROM SOLICITUD_ACTIVO WHERE rowid IN (SELECT rowid FROM SOLICITUD_ACTIVO LIMIT 1);',
      [],
      (tx, results) => {
        const rowCount = results.rowsAffected;
        if (rowCount > 0) {
          //console.log('Todas las solicitudes activas han sido eliminadas exitosamente');
        } else {
          //console.log('No hay solicitudes activas para borrar');
        }
      },
      error => {
        //console.error('Error al borrar las solicitudes activas', error);
      }
    );
  });
};

const borrarProfesores = () => {
  db.transaction(tx => {
    tx.executeSql(
      'DELETE FROM PROFESOR WHERE rowid IN (SELECT rowid FROM PROFESOR LIMIT 1);',
      [],
      (tx, results) => {
        const rowCount = results.rowsAffected;
        if (rowCount > 0) {
          console.log('Todos los profesores han sido eliminados exitosamente');
        } else {
          console.log('No hay profesores para borrar');
        }
      },
      error => {
        console.error('Error al borrar los profesores', error);
      }
    );
  });
};

const borrarLaboratorio = () => {
  db.transaction(tx => {
    tx.executeSql(
      'DELETE FROM LABORATORIO;',
      [],
      () => { console.log('Todos los laboratorios han sido eliminados exitosamente'); },
      error => { console.error('Error al borrar los laboratorios', error); }
    );
  });
};

const borrarHorario = () => {
  db.transaction(tx => {
    tx.executeSql(
      'DELETE FROM HORARIO;',
      [],
      () => { console.log('Todos los horarios han sido eliminados exitosamente'); },
      error => { console.error('Error al borrar los horarios', error); }
    );
  });
};




const borrarTablas = () => {
  db.transaction(tx => {
    tx.executeSql(
      'DROP TABLE IF EXISTS SOLICITUD_ACTIVO;',
      [],
      () => { console.log('Tabla borrada exitosamente'); },
      error => { console.error('Error al borrar la tabla:', error); }
    );
  });
};








export { db, crearBaseDeDatos, insertarProfesores, insertarSolicitudes,
   cambiarContraseña,crearLaboratorios, obtenerInstanciasHorario, obtenerInstanciasProfesor, borrarSolicitudes,
   borrarProfesores, borrarLaboratorio, borrarHorario, borrarTablas, borrarBaseDeDatos, insertarLaboratorio, obtenerInstanciasLaboratorio,
   insertarHorarios
};

