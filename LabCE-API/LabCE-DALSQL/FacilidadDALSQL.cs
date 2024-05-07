using AutoMapper;
using LabCE_MODEL.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabCE_MODEL.DTOs;

namespace LabCE_DALSQL
{
    public class FacilidadDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public FacilidadDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public void EliminarFacilidad(FacilidadDTO facilidad)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[eliminar_facilidad]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = facilidad.NombreLab;
                        comando.Parameters.Add("@facilidad", SqlDbType.VarChar).Value = facilidad.NombreFacilidad;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AgregarFacilidad(FacilidadDTO facilidad)
        {
            string baseDatos = _configuration.GetConnectionString("DefaultConnection");
            string procedAlmacenado = "[agregar_facilidad]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = facilidad.NombreLab;
                        comando.Parameters.Add("@facilidad", SqlDbType.VarChar).Value = facilidad.NombreFacilidad;

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
