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
    public class LaboratorioDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LaboratorioDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public List<string> GetFacilidadesLaboratorio(string nombreLab) 
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[mostrar_facilidades]";

            var facilidades = new List<string>();

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
                                Facilidad facilidad = new Facilidad()
                                {
                                    NombreFacilidad = respuesta["facilidad"].ToString(),
                                };
                                facilidades.Add(facilidad.NombreFacilidad);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return facilidades;

        }
    }
}
