using LabCE_BLL.Interfaces;
using LabCE_DALSQL;
using LabCE_MODEL.DTOs;
using LabCE_MODEL.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Servicios
{
    public class ProfesorBLL : IProfesorBLL
    {
        private readonly IConfiguration _configuration;
        private readonly ProfesorDALSQL _profesorDALSQL;

        public ProfesorBLL(IConfiguration configuration, ProfesorDALSQL profesorDALSQL)
        {
            _configuration = configuration;
            _profesorDALSQL = profesorDALSQL;
        }

        public void CambiarContraseñaProfesorBLL(ProfesorDTO profesor)
        {
            try
            {
                _profesorDALSQL.CambiarContraseñaProfesor(profesor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ProfesorDTO> GetProfesorCredencialesBLL()
        {
            try
            {
                var resultado = _profesorDALSQL.GetProfesorCredenciales();

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<SolicitudPendienteDTO> GetSolicitudesPendientesBLL(string correo)
        {
            try
            {
                var resultado = _profesorDALSQL.GetSolicitudesPendientes(correo);

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
