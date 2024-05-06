using AutoMapper;
using LabCE_MODEL.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_DALSQL
{
    public class SolicitudActivoDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public SolicitudActivoDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public void AprobarSolicitudActivoId(int id, string placa)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[aprobacion_activo]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@id_solicitud", SqlDbType.Int).Value = id;
                        comando.Parameters.Add("@placa_activo", SqlDbType.VarChar).Value = placa;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PrestamoActivoDTO> GetPrestamosActivo(string placa)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[mostrar_prestamos_activo]";

            var prestamos = new List<PrestamoActivoDTO>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@placa_activo", SqlDbType.VarChar).Value = placa;


                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                PrestamoActivoDTO prestamo = new PrestamoActivoDTO()
                                {
                                    NombreEstudiante = respuesta["nombre_estudiante"].ToString(),
                                    Apellido1Estudiante = respuesta["apellido1_estudiante"].ToString(),
                                    Apellido2Estudiante = respuesta["apellido2_estudiante"].ToString(),
                                    CorreoEstudiante = respuesta["correo_estudiante"].ToString(),
                                    Hora = ((TimeSpan)respuesta["hora"]).ToString(@"hh\:mm\:ss"),
                                    Fecha = Convert.ToDateTime(respuesta["fecha"]).ToString("yyyy-MM-dd"),
                                    Finalizado = Convert.ToBoolean(respuesta["finalizado"]),
                                    CorreoProfesor = respuesta["correo_profesor"].ToString(),
                                    CorreoOperador = respuesta["correo_operador"].ToString(),
                                };

                                prestamos.Add(prestamo);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return prestamos;
        }
        public void EliminarSolicitudActivoId(int id)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[eliminar_solicitud_activo]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AgregarSolicitudActivo(SolicitudActivoDTO solicitud)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[solicitud_activos]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo_estud", SqlDbType.VarChar).Value = solicitud.CorreoEstudiante;
                        comando.Parameters.Add("@nombre_estud", SqlDbType.VarChar).Value = solicitud.NombreEstudiante;
                        comando.Parameters.Add("@apellido1_estud", SqlDbType.VarChar).Value = solicitud.Apellido1Estudiante;
                        comando.Parameters.Add("@apellido2_estud", SqlDbType.VarChar).Value = solicitud.Apellido2Estudiante;
                        comando.Parameters.Add("@placa_activo", SqlDbType.VarChar).Value = solicitud.PlacaActivo;
                        comando.Parameters.Add("@correo_profesor", SqlDbType.VarChar).Value = solicitud.CorreoProfesor;
                        comando.Parameters.Add("@correo_operador", SqlDbType.VarChar).Value = solicitud.CorreoOperador;


                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void FinalizarPrestamo(int id, string placa_activo)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[finalizar_prestamo_activo]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@id_prestamo", SqlDbType.Int).Value = id;
                        comando.Parameters.Add("@placa_activo", SqlDbType.VarChar).Value = placa_activo;
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
