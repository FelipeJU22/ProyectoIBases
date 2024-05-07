using LabCE_BLL.Interfaces;
using LabCE_DALSQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Servicios
{
    public class RegistroAveriaBLL : IRegistroAveriaBLL
    {
        private readonly IConfiguration _configuration;
        private readonly RegistroAveriaDALSQL _registroAveriaDALSQL;

        public RegistroAveriaBLL(IConfiguration configuration, RegistroAveriaDALSQL registroAveriaDALSQL)
        {
            _configuration = configuration;
            _registroAveriaDALSQL = registroAveriaDALSQL;
        }

        public void AgregarAveriaBLL(int id, string detalle)
        {
            try
            {
                _registroAveriaDALSQL.AgregarAveria(id, detalle);
            }
            catch
            {
                throw;
            }
        }
    }
}
