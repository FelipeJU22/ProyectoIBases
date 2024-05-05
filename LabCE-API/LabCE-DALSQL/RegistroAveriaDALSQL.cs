using AutoMapper;
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
    public class RegistroAveriaDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public RegistroAveriaDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public void AgregarAveria(int id, string detalle)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[agregar_averia]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@id_solicitud", SqlDbType.Int).Value = id;
                        comando.Parameters.Add("@detalle", SqlDbType.VarChar).Value = detalle;

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
