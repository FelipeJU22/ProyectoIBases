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
    }
}
