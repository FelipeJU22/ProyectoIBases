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

        public void ModificarPlaca(string placaActual, string placaNueva)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[modificar_placa_activo]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@placa_vieja", SqlDbType.VarChar).Value = placaActual;
                        comando.Parameters.Add("@placa_nueva", SqlDbType.VarChar).Value = placaNueva;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarTipo(string placa, string nuevoTipo)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[modificar_tipo_activo]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@placa_activo", SqlDbType.VarChar).Value = placa;
                        comando.Parameters.Add("@nuevo_tipo", SqlDbType.VarChar).Value = nuevoTipo;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarMarca(string placa, string nuevaMarca)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[modificar_marca_activo]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@placa_activo", SqlDbType.VarChar).Value = placa;
                        comando.Parameters.Add("@marca", SqlDbType.VarChar).Value = nuevaMarca;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarFechaCompra(string placa, string fecha)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[modificar_fecha_compra_activo]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@placa_activo", SqlDbType.VarChar).Value = placa;
                        comando.Parameters.Add(new SqlParameter("@fecha", DateTime.Parse(fecha)));

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
