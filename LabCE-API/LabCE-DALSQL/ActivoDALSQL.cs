using AutoMapper;
using LabCE_MODEL.DTOs;
using LabCE_MODEL.Modelos;
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
    public class ActivoDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ActivoDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public List<ActivoInfoDTO> GetActivosInfo()
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[mostrar_info_activos]";

            var activos = new List<ActivoInfoDTO>();

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
                                ActivoInfoDTO activo = new ActivoInfoDTO()
                                {
                                    Placa = respuesta["placa"].ToString(),
                                    Tipo = respuesta["tipo"].ToString(),
                                    Marca = respuesta["marca"].ToString(),
                                    FechaCompra = respuesta["fecha_compra"] == DBNull.Value ? null : Convert.ToDateTime(respuesta["fecha_compra"]).ToString("yyyy-MM-dd"),
                                };

                                activos.Add(activo);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return activos;
        }
    }
}
