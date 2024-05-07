using LabCE_MODEL.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using AutoMapper;
using LabCE_MODEL.DTOs;

namespace LabCE_DALSQL
{
    public class ProfesorDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ProfesorDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;   
        }

        public List<Profesor> GetProfesorCredenciales() 
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[credenciales_profesor]";

            var profesores = new List<Profesor>();
                            
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                Profesor profesor = new Profesor()
                                {
                                    Correo = respuesta["correo"].ToString(),
                                    Cedula = respuesta["num_cedula"].ToString(),
                                    Password = respuesta["password"].ToString(),
                                    Nombre = respuesta["nombre"].ToString(),
                                    Apellido1 = respuesta["apellido1"].ToString(),
                                    Apellido2 = respuesta["apellido2"].ToString(),
                                    FechaNacimiento = Convert.ToDateTime(respuesta["fecha_nacimiento"]).ToString("yyyy-MM-dd"),
                                    CorreoAdministrador = respuesta["correo_administrador"].ToString(),
                                };
                                profesores.Add(profesor);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return profesores;
        }

        public List<SolicitudPendienteDTO> GetSolicitudesPendientes(string correoProfesor)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[solicitudes_pendientes]";

            var solicitudes = new List<SolicitudPendienteDTO>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo_profesor", SqlDbType.VarChar).Value = correoProfesor;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                SolicitudPendienteDTO solicitud = new SolicitudPendienteDTO()
                                {
                                    NombreEstudiante = respuesta["nombre_estudiante"].ToString(),
                                    Apellido1Estudiante = respuesta["apellido1_estudiante"].ToString(),
                                    Apellido2Estudiante = respuesta["apellido2_estudiante"].ToString(),
                                    Tipo = respuesta["tipo"].ToString(),
                                    IdActivo = int.Parse(respuesta["id"].ToString()),
                                    PlacaActivo = respuesta["placa_activo"].ToString()
                                };
                                solicitudes.Add(solicitud);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return solicitudes;
        }

        public void CambiarContraseñaProfesor(ProfesorDTO profesor)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[cambiar_password_profesor]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo_profesor", SqlDbType.VarChar).Value = profesor.Correo;
                        comando.Parameters.Add("@nuevo_password", SqlDbType.VarChar).Value = profesor.Password;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AgregarProfesor(Profesor profesor)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[agregar_profesor]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = profesor.Correo;
                        comando.Parameters.Add("@num_cedula", SqlDbType.VarChar).Value = profesor.Cedula;
                        comando.Parameters.Add("@password", SqlDbType.VarChar).Value = profesor.Password;
                        comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = profesor.Nombre;
                        comando.Parameters.Add("@apellido1", SqlDbType.VarChar).Value = profesor.Apellido1;
                        comando.Parameters.Add("@apellido2", SqlDbType.VarChar).Value = profesor.Apellido2;
                        comando.Parameters.Add(new SqlParameter("@fecha_nacimiento", DateTime.Parse(profesor.FechaNacimiento)));
                        comando.Parameters.Add("@correo_administrador", SqlDbType.VarChar).Value = profesor.CorreoAdministrador;


                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarNombre(string correoProfesor, string nuevoNombre)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[cambiar_nombre_profesor]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correor_profesor", SqlDbType.VarChar).Value = correoProfesor;
                        comando.Parameters.Add("@nuevo_nombre", SqlDbType.VarChar).Value = nuevoNombre;


                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarPrimerApellido(string correoProfesor, string apellido)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[cambiar_apellido1_profesor]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correor_profesor", SqlDbType.VarChar).Value = correoProfesor;
                        comando.Parameters.Add("@nuevo_apellido1", SqlDbType.VarChar).Value = apellido;


                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarSegundoApellido(string correoProfesor, string apellido)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[cambiar_apellido2_profesor]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correor_profesor", SqlDbType.VarChar).Value = correoProfesor;
                        comando.Parameters.Add("@nuevo_apellido2", SqlDbType.VarChar).Value = apellido;


                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarCorreo(string correoActual, string correoNuevo)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[cambiar_correo_profesor]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correor_profesor_viejo", SqlDbType.VarChar).Value = correoActual;
                        comando.Parameters.Add("@correor_profesor_nuevo", SqlDbType.VarChar).Value = correoNuevo;


                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarCedulaProfesor(string correo, string cedula)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[cambiar_num_cedula_profesor]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correor_profesor", SqlDbType.VarChar).Value = correo;
                        comando.Parameters.Add("@nuevo_num_cedula", SqlDbType.VarChar).Value = cedula;


                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarFechaNacimiento(string correo, string fecha)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[cambiar_fecha_nacimiento_profesor]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correor_profesor", SqlDbType.VarChar).Value = correo;
                        comando.Parameters.Add(new SqlParameter("@nueva_fecha_nacimiento", DateTime.Parse(fecha)));


                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AprobarOperador(string correoOperador)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[aprobar_operador]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo_operador", SqlDbType.VarChar).Value = correoOperador;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
