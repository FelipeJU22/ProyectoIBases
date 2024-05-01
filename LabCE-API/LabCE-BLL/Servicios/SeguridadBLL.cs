using LabCE_BLL.Interfaces;
using LabCE_DALSQL.Seguridad;
using LabCE_MODEL.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Servicios
{
    public class SeguridadBLL : ISeguridadBLL
    {
        private readonly IConfiguration _configuration;
        private readonly SeguridadDALSQL _seguridadDALSQL;

        public SeguridadBLL(IConfiguration configuration)
        {
            _configuration = configuration;
            _seguridadDALSQL = new SeguridadDALSQL(configuration);
        }


        public bool IngresoAdministradorBLL(UsuarioDTO usuario)
        {
            try
            {
                if (_seguridadDALSQL.IngresoAdministrador(usuario))
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IngresoOperadorBLL(UsuarioDTO usuario)
        {
            try
            {
                if (_seguridadDALSQL.IngresoOperador(usuario))
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IngresoProfesorBLL(UsuarioDTO usuario)
        {
            try
            {
                if (_seguridadDALSQL.IngresoProfesor(usuario))
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
