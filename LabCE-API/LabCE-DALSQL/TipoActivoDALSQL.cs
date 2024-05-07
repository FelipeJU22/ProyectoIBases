using AutoMapper;
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
    public class TipoActivoDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public TipoActivoDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public void AgregarTipoActivo(string tipo)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[agregar_tipo_activo]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@tipo_activo", SqlDbType.VarChar).Value = tipo;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarNombreTipo(string tipoActual, string tipoNuevo)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[cambiar_nombre_tipo_activo]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@tipo_activo_viejo", SqlDbType.VarChar).Value = tipoActual;
                        comando.Parameters.Add("@tipo_activo_nuevo", SqlDbType.VarChar).Value = tipoNuevo;

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
