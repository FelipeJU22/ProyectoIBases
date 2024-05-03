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
    internal class ActivoBLL : IActivoBLL
    {
        private readonly IConfiguration _configuration;
        private readonly ActivoDALSQL _activoDALSQL;
        public ActivoBLL(IConfiguration configuration, ActivoDALSQL activoDALSQL)
        {
            _configuration = configuration;
            _activoDALSQL = activoDALSQL;
        }
        public List<ActivoInfoDTO> GetActivosInfoBLL()
        {
            try
            {
                var resultado = _activoDALSQL.GetActivosInfo();

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
