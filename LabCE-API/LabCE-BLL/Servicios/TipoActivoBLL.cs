using LabCE_BLL.Interfaces;
using LabCE_DALSQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Servicios
{
    public class TipoActivoBLL : ITipoActivoBLL
    {
        private readonly IConfiguration _configuration;
        private readonly TipoActivoDALSQL _tipoActivoDALSQL;
        public TipoActivoBLL(IConfiguration configuration, TipoActivoDALSQL tipoActivoDALSQL)
        {
            _configuration = configuration;
            _tipoActivoDALSQL = tipoActivoDALSQL;
        }

        public void AgregarTipoActivoBLL(string tipo)
        {
            try
            {
                _tipoActivoDALSQL.AgregarTipoActivo(tipo);
            }
            catch
            {
                throw;
            }
        }


        public void ModificarNombreTipoBLL(string tipoActual, string tipoNuevo)
        {
            try
            {
                _tipoActivoDALSQL.ModificarNombreTipo(tipoActual, tipoNuevo);
            }
            catch
            {
                throw;
            }
        }
    }
}
