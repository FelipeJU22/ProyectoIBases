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
using System.Numerics;

namespace LabCE_DALSQL
{
    public class PrestamoLabDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PrestamoLabDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public List<PrestamoLabDTO> GetHorariosReservadosLab(string nombreLab)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[mostrar_reservas_lab]";

            var reservas = new List<PrestamoLabDTO>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = nombreLab;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                PrestamoLabDTO reserva = new PrestamoLabDTO()
                                {
                                    Fecha = Convert.ToDateTime(respuesta["fecha"]).ToString("yyyy-MM-dd"),
                                    HoraInicio = ((TimeSpan)respuesta["hora_inicio"]).ToString(@"hh\:mm\:ss"),
                                    HoraFinal = ((TimeSpan)respuesta["hora_final"]).ToString(@"hh\:mm\:ss"),

                                };

                                reservas.Add(reserva);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return reservas;
        }

        public void ReservarLabEstudiante(EstudiantePrestamoLabDTO estudiante)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[reserva_lab_estudiante]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@carnet_estud", SqlDbType.Int).Value = estudiante.CarneEstudiante;
                        comando.Parameters.Add("@correo_estud", SqlDbType.VarChar).Value = estudiante.CorreoEstudiante;
                        comando.Parameters.Add("@nombre_estud", SqlDbType.VarChar).Value = estudiante.NombreEstudiante;
                        comando.Parameters.Add("@apellido1_estud", SqlDbType.VarChar).Value = estudiante.Apellido1Estudiante;
                        comando.Parameters.Add("@apellido2_estud", SqlDbType.VarChar).Value = estudiante.Apellido2Estudiante;
                        comando.Parameters.Add(new SqlParameter("@fecha", DateTime.Parse(estudiante.Fecha)));
                        comando.Parameters.Add(new SqlParameter("@hora_inicio", TimeSpan.Parse(estudiante.HoraInicio)));
                        comando.Parameters.Add(new SqlParameter("@hora_final", TimeSpan.Parse(estudiante.HoraFinal)));
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = estudiante.NombreLab;

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
