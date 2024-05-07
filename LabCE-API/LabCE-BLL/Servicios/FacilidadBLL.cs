using LabCE_BLL.Interfaces;
using LabCE_DALSQL;
using LabCE_MODEL.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Servicios
{
    public class FacilidadBLL : IFacilidadBLL
    {
        private readonly IConfiguration _configuration;
        private readonly FacilidadDALSQL _facilidadDALSQL;

        public FacilidadBLL(IConfiguration configuration, FacilidadDALSQL facilidadDALSQL)
        {
            _configuration = configuration;
            _facilidadDALSQL = facilidadDALSQL;
        }

        public void AgregarFacilidadBLL(FacilidadDTO facilidad)
        {
            try
            {
                _facilidadDALSQL.AgregarFacilidad(facilidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EliminarFacilidadBLL(FacilidadDTO facilidad)
        {
            try
            {
                _facilidadDALSQL.EliminarFacilidad(facilidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
