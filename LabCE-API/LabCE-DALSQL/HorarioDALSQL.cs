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
    public class HorarioDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public HorarioDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public List<HorarioLabDTO> GetHorarioLab(string nombreLab)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[mostrar_horario_lab]";

            var horarios = new List<HorarioLabDTO>();

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
                                HorarioLabDTO horario = new HorarioLabDTO()
                                {
                                    Dia = respuesta["dia"].ToString(),
                                    HoraApertura = ((TimeSpan)respuesta["hora_apertura"]).ToString(@"hh\:mm\:ss"),
                                    HoraCierre = ((TimeSpan)respuesta["hora_cierre"]).ToString(@"hh\:mm\:ss"),
                                };

                                horarios.Add(horario);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return horarios;
        }
        public void CambiarHorarioLab(string nombreLab, char dia, string horaApertura, string horaCierre)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[cambiar_horario_lab]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = nombreLab;
                        comando.Parameters.Add(new SqlParameter("@hora_apertura", TimeSpan.Parse(horaApertura)));
                        comando.Parameters.Add(new SqlParameter("@hora_cierre", TimeSpan.Parse(horaCierre)));
                        comando.Parameters.Add("@dia", SqlDbType.Char).Value = dia;

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
