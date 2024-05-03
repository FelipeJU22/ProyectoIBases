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

        public List<ProfesorDTO> GetProfesorCredenciales() 
        {
            string baseDatos = _configuration.GetConnectionString("default");
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
                                    Password = respuesta["password"].ToString()
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
            List<ProfesorDTO> profesoresDTOs = profesores.Select(p => _mapper.Map<ProfesorDTO>(p)).ToList();

            return profesoresDTOs;
        }

        public List<SolicitudPendienteDTO> GetSolicitudesPendientes(string correoProfesor)
        {
            string baseDatos = _configuration.GetConnectionString("default");
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
                                    IdActivo = int.Parse(respuesta["id"].ToString())
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
            string baseDatos = _configuration.GetConnectionString("default");
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
    }
}
