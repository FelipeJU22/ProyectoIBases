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
    public class SolicitudActivoBLL : ISolicitudActivoBLL
    {
        private readonly IConfiguration _configuration;
        private readonly SolicitudActivoDALSQL _solicitudActivoDALSQL;

        public SolicitudActivoBLL(IConfiguration configuration, SolicitudActivoDALSQL solicitudActivoDALSQL)
        {
            _configuration = configuration;
            _solicitudActivoDALSQL = solicitudActivoDALSQL;
        }

    }
}
