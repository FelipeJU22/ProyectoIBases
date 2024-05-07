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
    public class RegistroOperadorDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public RegistroOperadorDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public List<RegistroHorasDTO>GetReporteHoras(string correoOperador)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[mostrar_reporte_horas_laboradas]";

            var registros = new List<RegistroHorasDTO>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo_operador", SqlDbType.VarChar).Value = correoOperador;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                RegistroHorasDTO registro = new RegistroHorasDTO()
                                {
                                    HoraEntrada = ((TimeSpan)respuesta["hora_entrada"]).ToString(@"hh\:mm\:ss"),
                                    HoraSalida = ((TimeSpan)respuesta["hora_salida"]).ToString(@"hh\:mm\:ss"),
                                    HorasTranscurridas = respuesta["horas_transcurridas"].ToString()
                                };

                                registros.Add(registro);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return registros;
        }

        public void InsertarJornada(OperadorDTO operador)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[insertar_jornada]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;


                        comando.Parameters.Add("@correo_operador", SqlDbType.VarChar).Value = operador.CorreoOperador;
                        comando.Parameters.Add(new SqlParameter("@hora_entrada", TimeSpan.Parse(operador.HoraEntrada)));
                        comando.Parameters.Add(new SqlParameter("@hora_salida", TimeSpan.Parse(operador.HoraSalida)));

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
